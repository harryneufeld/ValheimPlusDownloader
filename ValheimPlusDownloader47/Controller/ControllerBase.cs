using ValheimPlusDownloader47.Controller.Interface;

namespace ValheimPlusDownloader47.Controller
{
    public abstract class ControllerBase : IController
    {
        protected IView view;

        public ControllerBase(IView view)
        {
            this.view = view;
            this.view.SetController(this);
        }
    }
}
