using System.IO;
using ValheimPlusDownloader47.Controller.Interface;
using ValheimPlusDownloader47.Infrastructure;

namespace ValheimPlusDownloader47.Controller
{
    public class StartscreenController : ControllerBase, IController
    {
        IStartscreenView view;

        public StartscreenController(IStartscreenView view) :
            base(view){}

        public string FindValheimPath() => 
            FolderHelper.FindFolder();
    }
}