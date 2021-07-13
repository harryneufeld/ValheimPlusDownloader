using System;
using System.IO;
using System.Windows.Forms;
using ValheimPlusDownloader47.Controller;
using ValheimPlusDownloader47.Controller.Interface;
using ValheimPlusDownloader47.Infrastructure;

namespace ValheimPlusDownloader47
{
    public partial class Startscreen : Form, IStartscreenView
    {
        private string valheimPath = "";
        private IController controller;

        string IStartscreenView.ValheimPath { get => this.valheimPath; set { this.valheimPath = value; }}
        IController IView.controller { get => this.controller; set { this.controller = value; }}

        public Startscreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = this.FindValheimPath();
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        public string FindValheimPath() =>
            FolderHelper.FindFolder();
    }
}
