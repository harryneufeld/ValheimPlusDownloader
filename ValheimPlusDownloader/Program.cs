using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValheimPlusDownloader.Controller;

namespace ValheimPlusDownloader
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Startscreen view = new Startscreen();
            view.Visible = false;
            StartscreenController controller = new StartscreenController(view);
            view.LoadView();
            view.ShowDialog();
        }
    }
}
