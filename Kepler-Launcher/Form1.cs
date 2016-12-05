using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kepler_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_website_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://google.com");
        }

        private void btn_loadSave_Click(object sender, EventArgs e)
        {

        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            LaunchGame();
            var p = new Process();
            p.StartInfo.FileName = @"D:\S3\S3PI\projet_actuel\Kepler-22_B\Kepler-22_B\bin\Windows\x86\Debug\Kepler-22_B.exe";
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
