using Microsoft.Win32;
using Simple_image_server.Model;
using Simple_image_server.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
            Info = 0,
            Warning = 1,
            Error = 2
        }

        private string _settingsPath;

        private Thread serverThread;
        private HttpListener httpListener;
        private bool isRunning = false;
        private LogLevel logLevel = LogLevel.Info;
        private Model.Settings _settings;
        private string _contentLocation = Application.StartupPath + "/content";
        private string _appName = "SimpleImageServer";
        private Random _random = new Random();

        private Dictionary<string, Model.Client> _clientIds = new Dictionary<string, Model.Client>();
        
        private DarkModeTheme _darkMode = null;
        private System.Windows.Forms.Timer _timer = null;

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

            btnServertoggle.Text = Resources.StartServer;
            toolStripStatusLabel1.Text = Resources.ServerNotRunning;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(this.Timer_Tick);
            _timer.Start();

            SetAutostartText();
        }

        private void SetFormLocalizationTexts()
        {
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_settings.CultureInfoName);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            // Apply localization to all controls
            ResourceHelper.ApplyResources(this);
            SetAutostartText();
            SetStatusTexts();

            if (ResourceHelper.MissingResourceentries.ToString() != string.Empty)
            {
                Log(ResourceHelper.MissingResourceentries.ToString(), logLevel);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lbLists.Invalidate();
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
                btnStartOnBoot.Text = Resources.DisableAutostartOnBoot;
            }
            else
            {
                btnStartOnBoot.Text = Resources.EnableAutostartOnBoot;
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
            cmbLanguage.SelectedIndexChanged += (s, ee) =>
            {
                switch (cmbLanguage.SelectedItem.ToString())
                {
                    case "Dansk":
                        _settings.CultureInfoName = "da-DK";
                        break;
                    case "English":
                        _settings.CultureInfoName = "en-US";
                        break;
                }
                SetFormLocalizationTexts();
            };
            if(_settings.CultureInfoName == "da-DK")
            {
                cmbLanguage.SelectedIndex = 1;
            }
            else
            {
                cmbLanguage.SelectedIndex = 0;
            }

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
            // check for updates..
            if (UpdateHelper.CheckForUpdate())
            {
                if (_settings.ShowUpdatenowDialogOnAppStart)
                {
                    var result = MessageBox.Show(string.Format(Resources.NewVersionAvailable, UpdateHelper.LastFoundVersion), Resources.Form1, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        UpdateHelper.UpdateNow();
                        return;
                    }
                }
            }

            statusStrip1.Items.Add(new ToolStripStatusLabel(string.Format(Resources.CurrentVerionText, Assembly.GetExecutingAssembly().GetName().Version.ToString())));

            SetStatusStripButtons();

            if (_settings.Autostart)
            {
                btnServertoggle_Click(sender, e);
                this.Close();
            }
        }

        private void SetStatusStripButtons()
        {
            var tmp = statusStrip1.Items[0];
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(tmp);

            statusStrip1.Items.Add(new ToolStripButton(string.Format(Resources.NewVersionAvailable + " " + Resources.ClickToUpdateNow, UpdateHelper.LastFoundVersion), null, (s, ee) => { UpdateHelper.UpdateNow(); }, "UpdateNowButton") { Visible = UpdateHelper.LastFoundVersion != "Unknown" });
            statusStrip1.Items.Add(new ToolStripButton(Resources.CheckForUpdates, null, (s, ee) => {
                if (UpdateHelper.CheckForUpdate())
                {
                    var result = MessageBox.Show(string.Format(Resources.NewVersionAvailable, UpdateHelper.LastFoundVersion), Resources.Form1, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        UpdateHelper.UpdateNow();
                        return;
                    }
                    SetStatusStripButtons();
                }
                else
                {
                    MessageBox.Show(Resources.NoNewVersionAvailable, Resources.Form1, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }, "UpdateNowButton") { Visible = true });
        }

        private void LoadSettings()
        {
            var settingsJson = string.Empty;
            if (Directory.Exists(Path.GetDirectoryName(_settingsPath)))
            {
                if (File.Exists(_settingsPath))
                {
                    settingsJson = File.ReadAllText(_settingsPath);
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
                DarkMode = true,
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
                // we should probaly not create the directory unless the settings has been changed? hmm..
                Directory.CreateDirectory(Path.GetDirectoryName(_settingsPath));
            }

            var settingsJson = Newtonsoft.Json.JsonConvert.SerializeObject(_settings, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_settingsPath, settingsJson);
        }

        private void btnServertoggle_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                serverThread = new Thread(StartServer);
                serverThread.IsBackground = true;
                isRunning = true;
                serverThread.Start();
                SetStatusTexts();
            }
            else
            {
                isRunning = false;
                SetStatusTexts();
                httpListener.Stop();
            }
        }

        private void SetStatusTexts()
        {
            if (isRunning)
            {
                toolStripStatusLabel1.Text = string.Format(Resources.ServerRunningOnPort, _settings.Port);
                btnServertoggle.Text = Resources.StopServer;
            }
            else
            {
                Invoke(new Action(() => notifyIcon1_MouseClick(this, null)));
                Invoke(new Action(() => btnServertoggle.Text = Resources.StartServer));
                btnServertoggle.Text = Resources.StartServer;
                toolStripStatusLabel1.Text = Resources.ServerNotRunning;
            }
        }

        private async void StartServer()
        {
            httpListener = new HttpListener();
            var prefix = chkAllowremoteAccess.Checked ? $"http://+:{txtPort.Text}/" : $"http://localhost:{txtPort.Text}/";
            httpListener.Prefixes.Add(prefix);

            try
            {
                Invoke(new Action(() => Log(string.Format(Resources.StartingServerOnPort, _settings.Port), LogLevel.Info)));
                httpListener.Start();
                toolStripStatusLabel1.Text = string.Format(Resources.ServerRunningOnPort, _settings.Port);
                while (isRunning)
                {
                    var context = await httpListener.GetContextAsync();
                    await HandleRequest(context);
                }
            }
            catch(HttpListenerException ex)
            {
                isRunning = false;
                SetStatusTexts();
                
                if (ex.NativeErrorCode != 995)
                {
                    MessageBox.Show(string.Format(Resources.ErrorStartingServer, ex.Message));
                }
            }
            Invoke(new Action(() => Log(Resources.ServerNotRunning, LogLevel.Info)));
            toolStripStatusLabel1.Text = Resources.ServerNotRunning;
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

                    response.ContentType = "image/png";

                    byte[] resultBytes = null;
                    string statusmessage = string.Empty;
                    int statuscode = 200;

                    if (format == "json")
                    {
                        resultBytes = GetJsonResponse(clientid, cropToSquare, width, request.Url);
                        response.ContentType = "text/plain";
                        response.StatusCode = statuscode;
                        statusmessage = $"OK json index";
                    }
                    else if (format == "htmltemplate01" || format == "htmltemplate02")
                    {
                        resultBytes = GetHtmlTemplateResponse(format, clientid, cropToSquare, width, request.Url);
                        response.ContentType = "text/html";
                        response.StatusCode = statuscode;
                        statusmessage = $"OK htmltemplate index";
                    }
                    else
                    {
                        resultBytes = GetReponse(clientid, cropToSquare, width, filePath, out statuscode, out statusmessage);
                        response.StatusCode = statuscode;
                    }

                    Invoke(new Action(() => Log($"GET: {filePath} {statusmessage}. Client: {clientid} Width: {width}, crop: {cropToSquare}, Statuscode: {statuscode}", LogLevel.Info)));
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
                        response.ContentType = "text/plain";
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
                Invoke(new Action(() => Log(string.Format(Resources.ClientDroppedConnection, ex.Message), LogLevel.Info)));
            }
            catch (IOException ex)
            {
                Invoke(new Action(() => Log(string.Format(Resources.NetworkError, ex.Message), LogLevel.Info)));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => Log(string.Format(Resources.ErrorHandlingRequest, ex.Message), LogLevel.Error)));
            }
        }

        private byte[] GetHtmlTemplateResponse(string templatename, string clientid, bool cropToSquare, int width, Uri uri)
        {
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            query.Remove("format");
            var builder = new UriBuilder(uri)
            {
                Query = query.ToString()
            };

            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var template = File.ReadAllText(Path.Combine(basePath, "assets", templatename + ".html"));

            var list = GetFirstActivelistWithName(builder.Path.Replace("/", ""));
            var interval = 10000;
            var title = Resources.Form1;
            if (list != null)
            {
                // wait one more second to make sure the new image is "ready"..
                interval = (list.Interval + 1) * 1000;
                title = list.Name;
                if(!string.IsNullOrEmpty(list.Description))
                {
                    title += " - " + list.Description;
                }
            }
            var parsedTemplate = template.Replace("[URI]", builder.Uri.ToString());
            parsedTemplate = parsedTemplate.Replace("[INTERVAL]", interval.ToString());
            parsedTemplate = parsedTemplate.Replace("[TITLE]", title);

            return Encoding.UTF8.GetBytes(parsedTemplate);
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
                _clientIds.Add(clientid, new Client
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
            if (list == null)
            {
                statuscode = 404;
                statusmessage = Resources.ListNotFound;
                return null;
            }

            if (list.Images.Count == 0)
            {
                statuscode = 200;
                statusmessage = Resources.EmptyList;
                return null;
            }

            // When changing from one active list to another you could end in a situation where the index gives you a index out of range exception.
            EnforceImagelistBounds(client, list);

            var bytes = File.ReadAllBytes(list.Images[client.LastServedImageId].Path);

            if (cropToSquare)
            {
                bytes = CropToSquare(bytes);
            }

            if (width > 3200)
            {
                width = 3200;
            }
            if (width > 0 || (list.MaxWidth > 0 && width == 0))
            {
                bytes = ResizeImage(bytes, width > 0 ? width : list.MaxWidth);
            }


            if (client.LastNewImagetime.AddSeconds(list.Interval) < DateTime.Now)
            {
                client.LastNewImagetime = DateTime.Now;
                client.LastServedImageId++;
                if (list.UseRandomImage)
                {
                    client.LastServedImageId = _random.Next(0, list.Images.Count);
                }
                else
                {
                    EnforceImagelistBounds(client, list);
                }
            }

            statuscode = 200;
            statusmessage = $"OK Imageid {client.LastServedImageId}";
            return bytes;
        }

        private void EnforceImagelistBounds(Client client, Imagelist list)
        {
            if (client.LastServedImageId >= list.Images.Count)
            {
                if (list.UseRandomImage)
                {
                    client.LastServedImageId = _random.Next(0, list.Images.Count);
                }
                else
                {
                    client.LastServedImageId = 0;
                }
            }
        }


        private Imagelist GetFirstActivelistWithName(string filePath)
        {
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
                if(originalImage.Width < width)
                {
                    return imageBytes;
                }

                int height = (int)(originalImage.Height * ((float)width / originalImage.Width));

                using (var resizedBitmap = new Bitmap(originalImage, new Size(width, height)))
                using (var graphics = Graphics.FromImage(resizedBitmap))
                {
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
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
            if(logLevel < this.logLevel)
            {
                return;
            }
            var sb = new StringBuilder();
            sb.AppendLine($"{DateTime.Now}: {message}");
            sb.Append(string.Join(Environment.NewLine, txtLog.Lines.Take(30).ToArray()));

            txtLog.Text = sb.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown ||
            e.CloseReason == CloseReason.TaskManagerClosing ||
            e.CloseReason == CloseReason.ApplicationExitCall)
            {
                try
                {
                    if (isRunning)
                    {
                        httpListener.Stop();
                    }
                }
                catch
                {

                }
                isRunning = false;
                SaveSettings();
                return;
            }

            // If the form is closing for any other reason, we want to minimize it to the system tray
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
            var listname = Microsoft.VisualBasic.Interaction.InputBox(Resources.EnterListName, Resources.Name, "", this.Left, this.Top);
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
            lbLists.SelectedIndex = lbLists.Items.Count - 1;
        }

        private void LoadLists()
        {
            if (_settings.Lists != null)
            {
                lbLists.Items.Clear();
                foreach (var list in _settings.Lists)
                {
                    var item = new ListboxItemWrapper
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
            if ((ListboxItemWrapper)((ListBox)sender).SelectedItem == null)
            {
                return;
            }

            ListsettingsGroupSetEnabled(true);

            var theElement = ((ListboxItemWrapper)((ListBox)sender).SelectedItem).Tag;

            lbElementsInList.Items.Clear();
            if (theElement != null)
            {
                var list = _settings.Lists.FirstOrDefault(a => a.Id == ((Imagelist)theElement).Id);
                LoadListsettings(list);
                foreach (var image in list.Images)
                {
                    var item = new ListboxItemWrapper
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
                    ((System.Windows.Forms.CheckBox)c).CheckedChanged -= new EventHandler(this.SetListsettings);
                    continue;
                }
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).TextChanged -= new EventHandler(this.SetListsettings);
                    continue;
                }
                if (c.GetType() == typeof(NumericUpDown))
                {
                    ((NumericUpDown)c).ValueChanged -= new EventHandler(this.SetListsettings);
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
            numInterval.Value = item.Interval;
            numMaxWidth.Value = item.MaxWidth;
            chkRandomImage.Checked = item.UseRandomImage;
            txtListdescription.Text = item.Description;


            foreach (Control c in grpListsettings.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    continue;
                }

                if (c.GetType() == typeof(System.Windows.Forms.CheckBox))
                {
                    ((System.Windows.Forms.CheckBox)c).CheckedChanged += new EventHandler(this.SetListsettings);
                    continue;
                }
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).TextChanged += new EventHandler(this.SetListsettings);
                    continue;
                }
                if (c.GetType() == typeof(NumericUpDown))
                {
                    ((NumericUpDown)c).ValueChanged += new EventHandler(this.SetListsettings);
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
            item.Interval = (int)numInterval.Value;
            item.MaxWidth = (int)numMaxWidth.Value;
            item.UseRandomImage = chkRandomImage.Checked;
            item.Description = txtListdescription.Text;

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
                MessageBox.Show(Resources.SelectListFirst);
                return;
            }

            var list = _settings.Lists.FirstOrDefault(a => a.Id == ((Imagelist)((ListboxItemWrapper)lbLists.SelectedItem).Tag).Id);

            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = Resources.SelectImages;
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

                        var image = new ImageElement
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

            pbPreview.ImageLocation = ((ListboxItemWrapper)((ListBox)sender).SelectedItem).Name;
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

            var txt = $"{item.Name}";
            if (string.IsNullOrEmpty(((Imagelist)item.Tag).Description) == false)
            {
                txt += $" [{((Imagelist)item.Tag).Description}]";
            }
            if (((Imagelist)item.Tag).IsActive == false)
            {
                foreColor = Color.Orange;
                txt += Resources.Inactive;
            }

            // check other rules..
            if (((Imagelist)item.Tag).ActiveDays.HasFlag((OpenDays)(1 << (int)DateTime.Now.DayOfWeek)) == false)
            {
                txt += Resources.InactiveBecauseWeekday;
                foreColor = Color.Yellow;
            }
            if (((Imagelist)item.Tag).IsInActiveTime(DateTime.Now.Hour, DateTime.Now.Minute) == false)
            {
                txt += Resources.InactiveBecauseTimeOfDay;
                foreColor = Color.Yellow;
            }

            e.DrawBackground();
            TextRenderer.DrawText(
                e.Graphics,
                txt,
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

        private void btnOpenSettingsfolder_Click(object sender, EventArgs e)
        {
            try
            {
                var settingsFolder = Path.GetDirectoryName(_settingsPath);
                if (!Directory.Exists(Path.GetDirectoryName(settingsFolder)))
                {
                    MessageBox.Show(Resources.SettingsFolderNotFound, Resources.Notice, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                ProcessStartInfo startInfo = new ProcessStartInfo(settingsFolder)
                {
                    UseShellExecute = true,
                    Verb = "explore"
                };

                Process.Start(startInfo);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.SettingsfolderCouldNotBeOpened, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoveListUp_Click(object sender, EventArgs e)
        {
            MoveListIndex(-1);
        }

        private void MoveListIndex(int indexChange)
        {
            if (lbLists.SelectedItem == null)
            {
                return;
            }
            var list = _settings.Lists.FirstOrDefault(a => a.Id == ((Imagelist)((ListboxItemWrapper)lbLists.SelectedItem).Tag).Id);
            var index = _settings.Lists.IndexOf(list);

            var newIndex = index + indexChange;
            if (newIndex < 0 || newIndex >= _settings.Lists.Count)
            {
                return;
            }

            _settings.Lists.RemoveAt(index);
            _settings.Lists.Insert(newIndex, list);
            LoadLists();
            lbLists.SelectedIndex = newIndex;
        }

        private void btnMoveListDown_Click(object sender, EventArgs e)
        {
            MoveListIndex(1);
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if(lbElementsInList.SelectedItem == null || lbLists.SelectedItem == null)
            {
                return;
            }

            var selectedList = _settings.Lists.FirstOrDefault(a => a.Id == ((Imagelist)((ListboxItemWrapper)lbLists.SelectedItem).Tag).Id);

            var imgId = ((ImageElement)((ListboxItemWrapper)lbElementsInList.SelectedItem).Tag).Id;
            var img = selectedList.Images.FirstOrDefault(a => a.Id == imgId);
            var newIndex = selectedList.Images.IndexOf(img);
            selectedList.Images.Remove(img);
            lbLists_SelectedIndexChanged(lbLists, e);
            if(newIndex >= selectedList.Images.Count)
            {
                newIndex = selectedList.Images.Count - 1;
            }
            if (newIndex < 0)
            {
                pbPreview.ImageLocation = "";
            }
            else
            {
                lbElementsInList.SelectedIndex = newIndex;
            }
        }

        private void btnDeleteSelectedList_Click(object sender, EventArgs e)
        {
            if (lbLists.SelectedItem == null)
            {
                return;
            }

            var selectedList = _settings.Lists.FirstOrDefault(a => a.Id == ((Imagelist)((ListboxItemWrapper)lbLists.SelectedItem).Tag).Id);

            if(selectedList == null)
            {
                return;
            }

            if(selectedList.Images.Count > 0)
            {
                var result = MessageBox.Show(Resources.ListContainsImagesWarning, Resources.Warning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            var index = _settings.Lists.IndexOf(selectedList);
            _settings.Lists.RemoveAt(index);
            LoadLists();

            lbElementsInList.Items.Clear();
            pbPreview.ImageLocation = "";
        }

        private void btnDuplicateList_Click(object sender, EventArgs e)
        {
            if (lbLists.SelectedItem == null)
            {
                return;
            }

            var selectedList = _settings.Lists.FirstOrDefault(a => a.Id == ((Imagelist)((ListboxItemWrapper)lbLists.SelectedItem).Tag).Id);

            if (selectedList == null)
            {
                return;
            }

            var newList = new Imagelist
            {
                Id = Guid.NewGuid(),
                Name = selectedList.Name,
                Description = selectedList.Description + " - Copy",
                IsActive = selectedList.IsActive,
                ActiveDays = selectedList.ActiveDays,
                Starttime = selectedList.Starttime,
                Endtime = selectedList.Endtime,
                Interval = selectedList.Interval,
                MaxWidth = selectedList.MaxWidth,
                UseRandomImage = selectedList.UseRandomImage,
            };
            foreach (var image in selectedList.Images)
            {
                var newImage = new ImageElement
                {
                    Id = Guid.NewGuid(),
                    Path = image.Path
                };
                newList.Images.Add(newImage);
            }
            _settings.Lists.Add(newList);
            LoadLists();
            lbLists.SelectedIndex = lbLists.Items.Count - 1;
            lbLists_SelectedIndexChanged(lbLists, e);
            pbPreview.ImageLocation = "";
            txtListname.Focus();
            txtListname.SelectAll();
        }
    }
}
