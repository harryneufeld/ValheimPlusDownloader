using GitHub.ReleaseDownloader;
using System.Net.Http;

namespace ValheimPlusDownloader.Infrastructure
{
    public class RepositoryDownloader
    {
        public RepositoryDownloader()
        {

        }

        public void DownloadLatestRelease()
        {
            // create settings object
            HttpClient httpClient = new HttpClient();
            string author = "valheimPlus";
            string repo = "ValheimPlus";
            bool includePreRelease = true;
            string downloadDirPath = "%TMP%";
            IReleaseDownloaderSettings settings = new ReleaseDownloaderSettings(httpClient, author, repo, includePreRelease, downloadDirPath);

            // create downloader
            IReleaseDownloader downloader = new ReleaseDownloader(settings);

            // check version
            string currentVersion = "0.0.0";
            bool isMostRecentVersion = downloader.IsLatestRelease(currentVersion);

            // download latest github release
            if (!isMostRecentVersion)
            {
                downloader.DownloadLatestRelease();
            }

            // clean up
            downloader.DeInit();
            httpClient.Dispose();
        }
    }
}
