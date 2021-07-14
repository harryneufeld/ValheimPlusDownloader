using System.Threading.Tasks;

namespace GitHub.ReleaseDownloader
{
    public interface IReleaseDownloader
    {
        string LatestVersion { get; }
        bool IsLatestRelease(string version);
        Task<bool> DownloadLatestRelease();
        void DeInit();
    }
}