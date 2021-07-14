using System;
using System.IO;
using System.Threading.Tasks;
using ValheimPlusDownloader.Controller.Interface;
using ValheimPlusDownloader.Infrastructure;

namespace ValheimPlusDownloader.Controller
{
    public class StartscreenController : ControllerBase, IController
    {
        protected IStartscreenView<StartscreenController> view;
        protected IController controller;
        protected string valheimVersionFileName = "ValheimPlusVersion.txt";
        private string latestVersion;

        public StartscreenController(IStartscreenView<StartscreenController> view)
        {
            this.view = view;
            this.view.SetController(this);
        }

        public string FindFolder()
        {
            return Infrastructure.FolderHelper.FindFolder();
        }

        public string GetValheimPath()
        {
            string valheimPath = null;

            if (!Directory.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Valheim"))
                if (!Directory.Exists(@"D:\Program Files(x86)\Steam\steamapps\common\Valheim"))
                    if (!Directory.Exists(@"D:\Steam\steamapps\common\Valheim"))
                        valheimPath = "";
                    else
                        valheimPath = @"D:\Steam\steamapps\common\Valheim";
                else
                    valheimPath = @"D:\Program Files(x86)\Steam\steamapps\common\Valheim";
            else
                valheimPath = @"C:\Program Files (x86)\Steam\steamapps\common\Valheim";

            return valheimPath;
        }

        public async Task<bool> InstallVallheimPlus(string valheimPath, string currentVersion)
        {
            bool success = true;
            RepositoryDownloader dl = new RepositoryDownloader(valheimPath, currentVersion);
            success = await dl.DownloadLatestRelease();

            if (success)
            {
                this.latestVersion = dl.LatestVersion;
                this.SetCurrentVersion(valheimPath, this.latestVersion);
            }
            return success;
        }

        public void SetCurrentVersion(string valheimPath, string currentVersion)
        {
            string valheimVersionFile = Path.Combine(valheimPath, this.valheimVersionFileName);
            using (var sw = new StreamWriter(valheimVersionFile))
                sw.WriteLine(currentVersion);
        }

        public string GetCurrentVersion(string valheimPath)
        {
            string currentVersion = "0.0.0";
            string valheimVersionFile = Path.Combine(valheimPath, this.valheimVersionFileName);
            if (File.Exists(valheimVersionFile))
            {
                using (var sr = new StreamReader(valheimVersionFile))
                {
                    var text = sr.ReadToEnd().Trim();
                    if (!String.IsNullOrWhiteSpace(text))
                        currentVersion = text;
                }
            } else
            {
                this.SetCurrentVersion(valheimPath, currentVersion);
            }
            return currentVersion;
        }

        public string FindValheimPath() => 
            FolderHelper.FindFolder();
    }
}