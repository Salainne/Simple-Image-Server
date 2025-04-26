using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private Thread serverThread;
        private HttpListener httpListener;
        private bool isRunning = false;
        private LogLevel logLevel = LogLevel.Info;
        private int _port = 9191;

        private string _contentLocation = Application.StartupPath + "/content";

        public Form1()
        {
            InitializeComponent();

            btnServertoggle.Text = "Start Server";
            toolStripStatusLabel1.Text = "Server is stopped";
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
            }
        }

        private void StartServer()
        {
            httpListener = new HttpListener();
            httpListener.Prefixes.Add($"http://localhost:{_port}/");

            try
            {
                Invoke(new Action(() => Log($"Starting server on port: {_port}", LogLevel.Info)));
                httpListener.Start();
                toolStripStatusLabel1.Text = $"Server running on port {_port}";
                while (isRunning)
                {
                    var context = httpListener.GetContext();
                    var request = context.Request;
                    var response = context.Response;
                    if (request.HttpMethod == "GET")
                    {
                        string filePath = request.Url.LocalPath.TrimStart('/');
                        string fullPath = System.IO.Path.Combine(_contentLocation, filePath);

                        Invoke(new Action(() => Log($"GET: {filePath}", LogLevel.Info)));

                        if (System.IO.File.Exists(fullPath))
                        {
                            byte[] imageBytes = System.IO.File.ReadAllBytes(fullPath);
                            response.ContentType = "image/jpeg";
                            response.ContentLength64 = imageBytes.Length;
                            response.OutputStream.Write(imageBytes, 0, imageBytes.Length);
                        }
                        else
                        {
                            response.StatusCode = 404;
                            byte[] errorMessage = Encoding.UTF8.GetBytes("File not found");
                            response.OutputStream.Write(errorMessage, 0, errorMessage.Length);
                        }
                    }
                    response.Close();
                }
            }
            catch(HttpListenerException ex)
            {
                if (ex.NativeErrorCode != 995)
                {
                    MessageBox.Show("Error starting server: " + ex.Message);
                }
            }
            Invoke(new Action(() => Log($"Server stopped", LogLevel.Info)));
            toolStripStatusLabel1.Text = "Server is stopped";
        }

        private void Log(string message, LogLevel logLevel)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{DateTime.Now}: {message}");
            sb.Append(string.Join(Environment.NewLine, txtLog.Lines.Take(10).ToArray()));

            txtLog.Text = sb.ToString();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
