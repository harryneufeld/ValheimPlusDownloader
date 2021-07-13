using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusDownloader.Infrastructure;
using ValheimPlusDownloader47.Controller;

namespace ValheimPlusDownloader47
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Startscreen view = new Startscreen();
            view.Visible = false;
            StartscreenController controller = new StartscreenController(view);
            view.ShowDialog();

            //RepositoryDownloader downloader = new RepositoryDownloader();
            //downloader.DownloadLatestRelease();
        }
    }
}
