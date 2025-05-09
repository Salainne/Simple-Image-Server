using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_image_server.Model
{
    public class LogMessage
    {
        public string Text { get; set; }
        public ImageElement SelectedImage { get; set; }
        public int Width { get; internal set; }
        public bool Crop { get; internal set; }
        public int Statuscode { get; internal set; }
        public string Filepath { get; internal set; }
        public string StatusMessage { get; internal set; }
        public LogLevel LogLevel { get; internal set; }
        public DateTime Eventtime { get; internal set; }
        public string Client { get; internal set; }
    }
}
