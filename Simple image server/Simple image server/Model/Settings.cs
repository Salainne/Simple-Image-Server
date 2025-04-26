using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_image_server.Model
{
    internal class Settings
    {
        public int SettingsVersion { get { return 1; } }
        public bool AllowRemoteAccess { get; set; }
        public int Port { get; set; }
        public bool Autostart { get; set; }

        public List<Model.Imagelist> Lists { get; set; }

        public Settings()
        {
            Lists = new List<Model.Imagelist>();
        }
    }
}
