using System;
using System.Windows.Forms;
using ValheimPlusDownloader.Controller;
using ValheimPlusDownloader.Controller.Interface;

namespace ValheimPlusDownloader
{
    public partial class Startscreen : Form, IStartscreenView<StartscreenController>
    {
        private string valheimPath;
        private string currentVersion;
        private StartscreenController controller;
        StartscreenController IView<StartscreenController>.Controller { get => this.controller; set { this.controller = value; }}

        public Startscreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.valheimPath = this.FindValheimPath();
            if (!String.IsNullOrWhiteSpace(this.valheimPath))
            {
                textBox1.Text = this.valheimPath;
                lblNotFound.Visible = false;
            }
            else
                lblNotFound.Visible = true;

            this.GetCurrentVersion();
        }

        public void LoadView()
        {
            this.valheimPath = this.controller.GetValheimPath();
            if (!String.IsNullOrWhiteSpace(this.valheimPath))
            {
                textBox1.Text = this.valheimPath;
                lblNotFound.Visible = false;
            }
            else
                lblNotFound.Visible = true;

            this.GetCurrentVersion();
        }

        private void GetCurrentVersion()
        {
            if (!String.IsNullOrWhiteSpace(this.valheimPath))
            {
                this.currentVersion = this.controller.GetCurrentVersion(this.valheimPath);
                lblVersion.Text = this.currentVersion;
            }
        }

        public void SetController(StartscreenController controller)
        {
            this.controller = controller;
        }

        public string FindValheimPath() =>
            this.controller.FindFolder();

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            bool success = true;
            success = await this.controller.InstallVallheimPlus(this.valheimPath, this.currentVersion);
            this.GetCurrentVersion();
            if (success)
                MessageBox.Show("Installation erfolgreich!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Fehler bei der Installation.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
