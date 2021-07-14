using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimPlusDownloader.Controller.Interface
{
    public interface IView<T>
        where T : IController
    {
        T Controller { get; set; }
        void SetController(T controller);
    }
}
