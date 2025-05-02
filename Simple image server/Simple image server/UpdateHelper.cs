using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_image_server
{
    public static class UpdateHelper
    {
        static string autoupdaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "autoupdater", "autoupdater.exe");
        public static string LastFoundVersion = "Unknown";

        public static bool CheckForUpdate()
        {
            if (!File.Exists(autoupdaterPath))
            {
                return false;
            }

            // 1. Check for new version
            var check = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = autoupdaterPath,
                    Arguments = "checkversion",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = Path.GetDirectoryName(autoupdaterPath)
                }
            };

            check.Start();
            var output = check.StandardOutput.ReadToEnd();
            check.WaitForExit();

            LastFoundVersion = TryGetVersionFromJson();

            return check.ExitCode == 1;
        }

        public static void UpdateNow()
        {
            if (!File.Exists(autoupdaterPath))
            {
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = autoupdaterPath,
                Arguments = "updatenow",
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(autoupdaterPath)
            });
            Environment.Exit(0);
        }

        private static string TryGetVersionFromJson()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "autoupdater", "availableupdate.json");
                if (!File.Exists(path))
                {
                    return "Unknown";
                }

                var json = File.ReadAllText(path);
                var update = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);
                return update?.Version;
            }
            catch
            {
                return "Unknown";
            }
        }
    }
}
