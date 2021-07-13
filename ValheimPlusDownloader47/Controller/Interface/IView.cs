using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusDownloader47.Controller.Interface
{
    public interface IView
    {
        IController controller { get; set; }

        void SetController(IController controller);
    }
}
