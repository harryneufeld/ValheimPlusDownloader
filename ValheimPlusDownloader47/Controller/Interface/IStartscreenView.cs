using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValheimPlusDownloader47.Controller.Interface
{
    public interface IStartscreenView : IView
    {
        string ValheimPath { get; set; }

        string FindValheimPath();
    }
}
