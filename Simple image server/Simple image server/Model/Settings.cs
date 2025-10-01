using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_image_server.Model
{
    internal class Settings
    {
        public bool DarkMode { get; set; }
        public int SettingsVersion { get { return 1; } }
        public bool AllowRemoteAccess { get; set; }
        public int Port { get; set; }
        public bool Autostart { get; set; }

        public List<Model.Imagelist> Lists { get; set; }
        public string CultureInfoName { get; set; }

        public bool ShowUpdatenowDialogOnAppStart { get; set; }
        public bool RandomImageFromAllActiveListsWithName { get; set; }
        public LogLevel Loglevel { get; set; }
        public int SslPort { get; set; }
        public bool EnableSsl { get; set; }

        public CheckState Nsfw { get; set; }
        public long CacheSize { get; set; }

        public Settings()
        {
            Lists = new List<Model.Imagelist>();
            CultureInfoName = "en-US";
            RandomImageFromAllActiveListsWithName = true;
            Loglevel = LogLevel.Info;
            Nsfw = CheckState.Indeterminate;
            CacheSize = 512L * 1024 * 1024; // 512 MB

        }
    }
}
