using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValheimPlusDownloader.Controller.Interface
{
    public interface IStartscreenView<T> : IView<T>
        where T : IController
    {
        string FindValheimPath();
    }
}
