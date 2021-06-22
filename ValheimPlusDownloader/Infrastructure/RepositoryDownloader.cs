using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ValheimPlusDownloader.Infrastructure
{
    public class RepositoryDownloader
    {
        public RepositoryDownloader()
        {

        }

        public void DownloadRelease()
        {
            string remoteUri = "https://github.com/valheimPlus/ValheimPlus/releases/latest";
            string fileName = "WindowsClient.zip", myStringWebResource = null;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(new Uri(myStringWebResource), fileName);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
        }
    }
}
