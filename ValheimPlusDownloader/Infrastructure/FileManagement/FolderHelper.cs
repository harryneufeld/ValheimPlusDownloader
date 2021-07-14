using System.Windows.Forms;

namespace ValheimPlusDownloader.Infrastructure
{
    public static class FolderHelper
    {
        public static string FindFolder()
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            return dialog.SelectedPath;
        }
    }
}