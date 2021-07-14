using GitHub.ReleaseDownloader;
using Ionic.Zip;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValheimPlusDownloader.Model;

namespace ValheimPlusDownloader.Infrastructure
{
    public class RepositoryDownloader
    {
        private string currentVersion;
        private string latestVersion;
        private bool isMostRecentVersion;
        private string valheimPath;
        private string downloadPath;
        private InstallationType installationType;
        
        public string LatestVersion { get => this.latestVersion; }
        public string CurrentVersion { get => this.currentVersion; }
        public bool IsMostRecentVersion { get => this.isMostRecentVersion; }

        public RepositoryDownloader(string valheimPath, string currentVersion = "0.0.0", InstallationType installationType = InstallationType.WindowsClient)
        {
            this.valheimPath = valheimPath;
            this.currentVersion = currentVersion;
            this.installationType = installationType;
        }

        public async Task<bool> DownloadLatestRelease()
        {
            bool success = true;
            // create settings object
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(15);
            string author = "valheimPlus";
            string repo = "ValheimPlus";
            bool includePreRelease = true;
            downloadPath = Path.Combine(Path.GetTempPath(), "ValheimPlusDownloader");
            IReleaseDownloaderSettings settings = new ReleaseDownloaderSettings(httpClient, author, repo, includePreRelease, downloadPath);

            // create downloader
            IReleaseDownloader downloader = new ReleaseDownloader(settings);

            // check version
            isMostRecentVersion = downloader.IsLatestRelease(currentVersion);

            // download latest github release
            if (!isMostRecentVersion)
            {
                if (!Directory.Exists(downloadPath))
                    Directory.CreateDirectory(downloadPath);
                success = await downloader.DownloadLatestRelease();
            }
            else
            {
                MessageBox.Show("Es ist bereits die aktuellste Version installiert.", "ValheimPlus ist aktuell", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (success)
            {
                this.latestVersion = downloader.LatestVersion;
                this.ExtractFile();
            }

            // clean up
            downloader.DeInit();
            httpClient.Dispose();

            return success;
        }
        private void ExtractFile()
        {
            string file = this.installationType.ToString() + ".zip";
            using (var zip = ZipFile.Read(Path.Combine(this.downloadPath, file)))
            {
                foreach (ZipEntry z in zip)
                    z.Extract(this.valheimPath, ExtractExistingFileAction.OverwriteSilently);
            }
        }
    }
}
