using Microsoft.Win32;
using Simple_image_server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Simple_image_server
{
    public partial class Form1 : Form
    {
        enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        private string _settingsPath;

        private Thread serverThread;
        private HttpListener httpListener;
        private bool isRunning = false;
        private LogLevel logLevel = LogLevel.Info;
        private Model.Settings _settings;
        private string _contentLocation = Application.StartupPath + "/content";
        private string _appName = "SimpleImageServer";

        private Dictionary<string, Model.Client> _clientIds = new Dictionary<string, Model.Client>();
        
        private DarkModeTheme _darkMode = null;

        public Form1()
        {
            _settingsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimpleImageServer", "settings.json");
#if DEBUG
            _settingsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimpleImageServer", "settings-DEBUG.json");
#endif

            InitializeComponent();
            lbLists.DrawMode = DrawMode.OwnerDrawFixed;
            lbLists.DrawItem += LbLists_DrawItem;

            ListsettingsGroupSetEnabled(false);

            btnServertoggle.Text = "Start Server";
            toolStripStatusLabel1.Text = $"Server not running";

            SetAutostartText();
        }

        private void ListsettingsGroupSetEnabled(bool enabled)
        {
            foreach(Control c in grpListsettings.Controls)
            {
                c.Enabled = enabled;
            }
        }

        private void SetAutostartText()
        {
            if (AutoStartOnBootIsEnabled())
            {
                btnStartOnBoot.Text = "Disable autostart on boot";
            }
            else
            {
                btnStartOnBoot.Text = "Enable autostart on boot";
            }
        }

        private bool AutoStartOnBootIsEnabled()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (regKey != null)
            {
                var value = regKey.GetValue(_appName);
                if (value != null && value.ToString() == Application.ExecutablePath)
                {
                    return true;
                }
            }
            return false;
        }

        private void ToogleAutostart()
        {
            if (AutoStartOnBootIsEnabled() == false)
            {
                AddToStartup();
            }
            else
            {
                RemoveFromStartup();
            }
            SetAutostartText();
        }

        public void AddToStartup()
        {
            string appPath = Application.ExecutablePath;

            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (regKey != null)
            {
                regKey.SetValue(_appName, appPath);
                regKey.Close();
            }
        }

        public void RemoveFromStartup()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (regKey != null)
            {
                regKey.DeleteValue(_appName, false);
                regKey.Close();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get our settings...
            LoadSettings();

            _darkMode = new DarkModeTheme(this)
            {
                ColorMode = _settings.DarkMode ? DarkModeTheme.DisplayMode.DarkMode : DarkModeTheme.DisplayMode.ClearMode
            };
            _darkMode.ApplyTheme(_settings.DarkMode);
            DarkMode.Checked = _settings.DarkMode;

            chkAllowremoteAccess.Checked = _settings.AllowRemoteAccess;
            txtPort.Text = _settings.Port.ToString();
            chkAutostart.Checked = _settings.Autostart;            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (_settings.Autostart)
            {
                btnServertoggle_Click(sender, e);
                this.Close();
            }
        }

        private void LoadSettings()
        {
            var settingsJson = string.Empty;
            if (Directory.Exists(Path.GetDirectoryName(_settingsPath)))
            {
                if (File.Exists(_settingsPath))
                {
                    settingsJson = System.IO.File.ReadAllText(_settingsPath);
                    if (!string.IsNullOrEmpty(settingsJson))
                    {
                        _settings = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.Settings>(settingsJson);
                        LoadLists();
                        return;
                    }
                }
            }
            
            _settings = new Model.Settings
            {
                AllowRemoteAccess = false,
                Port = 9191,
                DarkMode = true
            };
        }

        private void SaveSettings()
        {
            _settings.AllowRemoteAccess = chkAllowremoteAccess.Checked;
            _settings.Port = int.TryParse(txtPort.Text, out int port) ? port : 9191;
            _settings.Autostart = chkAutostart.Checked;
            _settings.DarkMode = DarkMode.Checked;

            if (!Directory.Exists(Path.GetDirectoryName(_settingsPath)))
            {
                // we should probaly not create the directory unless the settings have been changed? hmm..
                Directory.CreateDirectory(Path.GetDirectoryName(_settingsPath));
            }

            var settingsJson = Newtonsoft.Json.JsonConvert.SerializeObject(_settings, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(_settingsPath, settingsJson);
        }

        private void btnServertoggle_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                serverThread = new Thread(StartServer);
                serverThread.IsBackground = true;
                isRunning = true;
                serverThread.Start();
                btnServertoggle.Text = "Stop Server";
            }
            else
            {
                isRunning = false;
                httpListener.Stop();
                btnServertoggle.Text = "Start Server";
                toolStripStatusLabel1.Text = $"Server not running";
            }
        }

        private async void StartServer()
        {
            httpListener = new HttpListener();
            var prefix = chkAllowremoteAccess.Checked ? $"http://+:{txtPort.Text}/" : $"http://localhost:{txtPort.Text}/";
            httpListener.Prefixes.Add(prefix);

            try
            {
                Invoke(new Action(() => Log($"Starting server on port: {_settings.Port}", LogLevel.Info)));
                httpListener.Start();
                toolStripStatusLabel1.Text = $"Server running on port {_settings.Port}";
                while (isRunning)
                {
                    var context = await httpListener.GetContextAsync();
                    HandleRequest(context);
                }
            }
            catch(HttpListenerException ex)
            {
                isRunning = false;
                Invoke(new Action(() => btnServertoggle.Text = "Start Server"));
                
                if (ex.NativeErrorCode != 995)
                {
                    MessageBox.Show("Error starting server: " + ex.Message);
                }
            }
            Invoke(new Action(() => Log($"Server stopped", LogLevel.Info)));
            toolStripStatusLabel1.Text = "Server is stopped";
        }

        private async Task HandleRequest(HttpListenerContext context)
        {
            try
            {
                var request = context.Request;
                var response = context.Response;
                if (request.HttpMethod == "GET")
                {
                    string filePath = request.Url.LocalPath.TrimStart('/').ToLower();
                    string fullPath = System.IO.Path.Combine(_contentLocation, filePath);

                    var clientid = request.QueryString["clientid"] ?? "anyclient";
                    var cropToSquare = request.QueryString["croptosquare"] == "1";
                    var width = request.QueryString["width"] != null ? int.Parse(request.QueryString["width"]) : 0;
                    var format = request.QueryString["format"] != null ? request.QueryString["format"] : "image";

                    //response.ContentType = "image/jpeg";
                    response.ContentType = "image/png";

                    byte[] resultBytes = null;
                    string statusmessage = string.Empty;
                    int statuscode = 200;

                    if (format == "json")
                    {
                        resultBytes = GetJsonResponse(clientid, cropToSquare, width, request.Url);
                        //response.ContentType = "application/json";
                        response.ContentType = "text/plain";
                        response.StatusCode = statuscode;
                    }
                    else
                    {
                        resultBytes = GetReponse(clientid, cropToSquare, width, filePath, out statuscode, out statusmessage);
                        response.StatusCode = statuscode;
                    }

                    Invoke(new Action(() => Log($"GET: {filePath}. Client: {clientid} Width: {width}, crop: {cropToSquare}, Statuscode: {statuscode}", LogLevel.Info)));
                    if (resultBytes != null)
                    {
                        response.ContentLength64 = resultBytes.Length;
                        using(var outputStream = response.OutputStream)
                        {
                            await outputStream.WriteAsync(resultBytes, 0, resultBytes.Length);
                        }
                    }
                    else
                    {
                        byte[] errorMessage = Encoding.UTF8.GetBytes(statusmessage);
                        using (var outputStream = response.OutputStream)
                        {
                            await outputStream.WriteAsync(errorMessage, 0, errorMessage.Length);
                        }
                    }
                }
                response.Close();
            }
            catch(HttpListenerException ex)
            {
                Invoke(new Action(() => Log($"Client dropped connection: {ex.Message}", LogLevel.Info)));
            }
            catch (IOException ex)
            {
                Invoke(new Action(() => Log($"Network error: {ex.Message}", LogLevel.Info)));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => Log($"Error handling request: {ex.Message}", LogLevel.Error)));
            }
        }

        private byte[] GetJsonResponse(
            string clientid,
            bool cropToSquare,
            int width,
            Uri uri
            )
        {
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            query.Remove("format");
            var builder = new UriBuilder(uri)
            {
                Query = query.ToString()
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                backgroundImageUrl = builder.Uri
            }, Newtonsoft.Json.Formatting.Indented);
            
            return Encoding.UTF8.GetBytes(json);
        }

        private byte[] GetReponse(
            string clientid, 
            bool cropToSquare, 
            int width,
            string filePath, 
            out int statuscode, 
            out string statusmessage)
        {
            if (!_clientIds.ContainsKey(clientid))
            {
                _clientIds.Add(clientid, new Model.Client
                {
                    Id = clientid,
                    LastServedImageId = 0,
                    LastServedImageList = filePath
                });
            }

            var client = _clientIds[clientid];
            client.LastRequest = DateTime.Now;
            // if requested list is not the same as the last one, reset the last served image
            if (client.LastServedImageList != filePath)
            {
                client.LastServedImageId = 0;
                client.LastServedImageList = filePath;
            }

            var list = GetFirstActivelistWithName(filePath);
            if(list == null)
            {
                statuscode = 404;
                statusmessage = "List not found";
                return null;
            }

            if (list.Images.Count == 0)
            {
                statuscode = 200;
                statusmessage = "List empty";
                return null;
            }

            if (client.LastServedImageId >= list.Images.Count)
            {
                client.LastServedImageId = 0;
            }

            var bytes = File.ReadAllBytes(list.Images[client.LastServedImageId].Path);

            if (cropToSquare)
            {
                bytes = CropToSquare(bytes);
            }

            if(width > 0)
            {
                bytes = ResizeImage(bytes, width);
            }

            client.LastServedImageId++;
            statuscode = 200;
            statusmessage = "OK";
            return bytes;
        }

        private Imagelist GetFirstActivelistWithName(string filePath)
        {
            //var list = _settings.Lists.FirstOrDefault(a => string.Equals(a.Name, filePath, StringComparison.OrdinalIgnoreCase));
            var lists = _settings.Lists.Where(
                a => 
                string.Equals(a.Name, filePath, StringComparison.OrdinalIgnoreCase) && 
                a.IsActive && 
                a.ActiveDays.HasFlag((OpenDays)(1 << (int)DateTime.Now.DayOfWeek)) &&
                a.IsInActiveTime(DateTime.Now.Hour, DateTime.Now.Minute)
                ).ToList();

            return lists.FirstOrDefault();
        }

        public static byte[] CropToSquare(byte[] imageBytes)
        {
            using (var inputStream = new MemoryStream(imageBytes))
            using (var originalImage = Image.FromStream(inputStream))
            {
                int side = Math.Min(originalImage.Width, originalImage.Height);
                int x = (originalImage.Width - side) / 2;
                int y = (originalImage.Height - side) / 2;

                using (var squareBitmap = new Bitmap(side, side))
                using (var graphics = Graphics.FromImage(squareBitmap))
                {
                    graphics.DrawImage(originalImage, new Rectangle(0, 0, side, side), new Rectangle(x, y, side, side), GraphicsUnit.Pixel);

                    using (var outputStream = new MemoryStream())
                    {
                        squareBitmap.Save(outputStream, ImageFormat.Png);
                        return outputStream.ToArray();
                    }
                }
            }
        }

        public static byte[] ResizeImage(byte[] imageBytes, int width)
        {
            using (var inputStream = new MemoryStream(imageBytes))
            using (var originalImage = Image.FromStream(inputStream))
            {
                // Beregn højden baseret på aspect ratioen af det oprindelige billede
                int height = (int)(originalImage.Height * ((float)width / originalImage.Width));

                // Resize the image to the specified width and calculated height
                using (var resizedBitmap = new Bitmap(originalImage, new Size(width, height)))
                using (var graphics = Graphics.FromImage(resizedBitmap))
                {
                    // Set the interpolation mode for high-quality resizing
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    // Draw the resized image into a new bitmap
                    graphics.DrawImage(originalImage, 0, 0, width, height);

                    using (var outputStream = new MemoryStream())
                    {
                        resizedBitmap.Save(outputStream, ImageFormat.Png);
                        return outputStream.ToArray();
                    }
                }
            }
        }

        private void Log(string message, LogLevel logLevel)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{DateTime.Now}: {message}");
            sb.Append(string.Join(Environment.NewLine, txtLog.Lines.Take(30).ToArray()));

            txtLog.Text = sb.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                notifyIcon1.Visible = true;
            }

            SaveSettings();
        }

        private void btnAddNewList_Click(object sender, EventArgs e)
        {
            var listname = Microsoft.VisualBasic.Interaction.InputBox("Enter listname", "Name", "", this.Left, this.Top);
            if (!string.IsNullOrEmpty(listname))
            {
                var list = new Model.Imagelist
                {
                    Id = Guid.NewGuid(),
                    Name = listname,
                };
                _settings.Lists.Add(list);
            }
            LoadLists();
        }

        private void LoadLists()
        {
            if (_settings.Lists != null)
            {
                lbLists.Items.Clear();
                foreach (var list in _settings.Lists)
                {
                    var item = new Model.ListboxItemWrapper
                    {
                        Name = list.Name,
                        Tag = list
                    };
                    lbLists.Items.Add(item);
                }
            }
        }

        private void lbLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Simple_image_server.Model.ListboxItemWrapper)((ListBox)sender).SelectedItem == null)
            {
                return;
            }

            ListsettingsGroupSetEnabled(true);

            var theElement = ((Simple_image_server.Model.ListboxItemWrapper)((ListBox)sender).SelectedItem).Tag;

            lbElementsInList.Items.Clear();
            if (theElement != null)
            {
                var list = _settings.Lists.FirstOrDefault(a => a.Id == ((Model.Imagelist)theElement).Id);
                LoadListsettings(list);
                foreach (var image in list.Images)
                {
                    var item = new Model.ListboxItemWrapper
                    {
                        Name = image.Path,
                        Tag = image
                    };
                    lbElementsInList.Items.Add(item);
                }
            }
        }

        private void LoadListsettings(Imagelist item)
        {
            foreach(Control c in grpListsettings.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Label))
                {
                    continue;
                }

                if (c.GetType() == typeof(System.Windows.Forms.CheckBox))
                {
                    ((System.Windows.Forms.CheckBox)c).CheckedChanged -= new System.EventHandler(this.SetListsettings);
                    continue;
                }
                if (c.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ((System.Windows.Forms.TextBox)c).TextChanged -= new System.EventHandler(this.SetListsettings);
                    continue;
                }
                if (c.GetType() == typeof(System.Windows.Forms.NumericUpDown))
                {
                    ((System.Windows.Forms.NumericUpDown)c).ValueChanged -= new System.EventHandler(this.SetListsettings);
                    continue;
                }
            }

            chkListActive.Checked = item.IsActive;
            txtListname.Text = item.Name;
            chkListMonday.Checked = item.ActiveDays.HasFlag(OpenDays.Monday);
            chkListTuesday.Checked = item.ActiveDays.HasFlag(OpenDays.Tuesday);
            chkListWednesday.Checked = item.ActiveDays.HasFlag(OpenDays.Wednesday);
            chkListThursday.Checked = item.ActiveDays.HasFlag(OpenDays.Thursday);
            chkListFriday.Checked = item.ActiveDays.HasFlag(OpenDays.Friday);
            chkListSaturday.Checked = item.ActiveDays.HasFlag(OpenDays.Saturday);
            chkListSunday.Checked = item.ActiveDays.HasFlag(OpenDays.Sunday);
            numFromHour.Value = item.GetStartTime().Hours;
            numFromMinute.Value = item.GetStartTime().Minutes;
            numToHour.Value = item.GetEndTime().Hours;
            numToMinute.Value = item.GetEndTime().Minutes;


            foreach (Control c in grpListsettings.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Label))
                {
                    continue;
                }

                if (c.GetType() == typeof(System.Windows.Forms.CheckBox))
                {
                    ((System.Windows.Forms.CheckBox)c).CheckedChanged += new System.EventHandler(this.SetListsettings);
                    continue;
                }
                if (c.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    ((System.Windows.Forms.TextBox)c).TextChanged += new System.EventHandler(this.SetListsettings);
                    continue;
                }
                if (c.GetType() == typeof(System.Windows.Forms.NumericUpDown))
                {
                    ((System.Windows.Forms.NumericUpDown)c).ValueChanged += new System.EventHandler(this.SetListsettings);
                    continue;
                }
            }
        }

        private void SetListsettings(object sender, EventArgs e)
        {
            if ((ListboxItemWrapper)lbLists.SelectedItem == null)
            {
                return;
            }
            var theElement = ((ListboxItemWrapper)(lbLists).SelectedItem).Tag;
            var item = _settings.Lists.FirstOrDefault(a => a.Id == ((Imagelist)theElement).Id);

            item.IsActive = chkListActive.Checked;
            item.Name = txtListname.Text;

            item.ActiveDays = OpenDays.None;
            if (chkListMonday.Checked) { item.ActiveDays |= OpenDays.Monday; }
            if (chkListTuesday.Checked) { item.ActiveDays |= OpenDays.Tuesday; }
            if (chkListWednesday.Checked) { item.ActiveDays |= OpenDays.Wednesday; }
            if (chkListThursday.Checked) { item.ActiveDays |= OpenDays.Thursday; }
            if (chkListFriday.Checked) { item.ActiveDays |= OpenDays.Friday; }
            if (chkListSaturday.Checked) { item.ActiveDays |= OpenDays.Saturday; }
            if (chkListSunday.Checked) { item.ActiveDays |= OpenDays.Sunday; }
            item.SetStarttime((int)numFromHour.Value, (int)numFromMinute.Value);
            item.SetEndtime((int)numToHour.Value, (int)numToMinute.Value);

            ((ListboxItemWrapper)lbLists.SelectedItem).Name = item.Name;
            // weird hack to update the listbox item..
            int index = lbLists.SelectedIndex;
            lbLists.Items[index] = lbLists.Items[index];
            lbLists.Invalidate();
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if(lbLists.SelectedItem == null)
            {
                MessageBox.Show("Please select a list first");
                return;
            }

            var list = _settings.Lists.FirstOrDefault(a => a.Id == ((Model.Imagelist)((Simple_image_server.Model.ListboxItemWrapper)lbLists.SelectedItem).Tag).Id);

            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Select images to add to list";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileNames.Length > 0)
                {
                    foreach (var file in openFileDialog1.FileNames)
                    {
                        if (list.Images.Count(a => a.Path == file) > 0)
                        {
                            // already in list..
                            continue;
                        }

                        var image = new Model.ImageElement
                        {
                            Id = Guid.NewGuid(),
                            Path = file
                        };
                        list.Images.Add(image);
                    }
                    
                    lbLists_SelectedIndexChanged(lbLists, e);
                }
            }
        }

        private void btnStartOnBoot_Click(object sender, EventArgs e)
        {
            ToogleAutostart();
        }

        private void lbElementsInList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((ListBox)sender).SelectedItem == null)
            {
                pbPreview.ImageLocation = "";
                return;
            }

            pbPreview.ImageLocation = ((Simple_image_server.Model.ListboxItemWrapper)((ListBox)sender).SelectedItem).Name;
        }

        private void DarkMode_CheckedChanged(object sender, EventArgs e)
        {
            _settings.DarkMode = DarkMode.Checked;

            if (_settings.DarkMode)
            {
                _darkMode = new DarkModeTheme(this)
                {
                    ColorMode = DarkModeTheme.DisplayMode.DarkMode
                };
            }
            else
            {
                _darkMode = new DarkModeTheme(this)
                {
                    ColorMode = DarkModeTheme.DisplayMode.ClearMode
                };
            }

            _darkMode.ApplyTheme(_settings.DarkMode);
        }

        private void LbLists_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            var item = (ListboxItemWrapper)lbLists.Items[e.Index];
            Color foreColor = this.ForeColor;
            if (((Imagelist)item.Tag).IsActive == false)
            {
                foreColor = Color.Yellow;
            }
            e.DrawBackground();
            TextRenderer.DrawText(
                e.Graphics,
                item.Name,
                lbLists.Font,
                e.Bounds,
                foreColor,
                TextFormatFlags.Left
            );
            e.DrawFocusRectangle();
        }

        private void btnSaveSettingsNow_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
