using Kepler_22_B.API.Data;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Xml;


namespace Kepler_Launcher
{
    public partial class Form1 : Form
    {

        XmlNodeList dataTab;
        Data data;
        public Form1()
        {
            InitializeComponent();

            data = new Data("test-doc");
            dataTab = data.GetDataInTab("test-doc");

        }

        private void btn_website_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://google.com");
        }

        private void btn_loadSave_Click(object sender, EventArgs e)
        {
            data.ReplaceAttributeInTab("test-doc",1, "4");
            foreach (XmlNode userNodee in dataTab)
            {
                listBox1.Items.Add(userNodee.InnerXml+" "+userNodee.Attributes["age"].Value);
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            LaunchGame();
            var p = new Process();
            p.StartInfo.FileName = @"..\..\..\InfinityUnderground\bin\DesktopGL\x86\Debug\InfinityUnderground.exe";
            p.Start();
            Close();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar_Click(object sender, EventArgs e)
        {
        }

        private void LaunchGame()
        {
            progressBar.Maximum = 1000;
            int milliseconds = 100;
            while (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Increment(200);
                Thread.Sleep(milliseconds);
            }
        }

        private void btn_ResetSave_Click(object sender, EventArgs e)
        {

        }
    }
}
