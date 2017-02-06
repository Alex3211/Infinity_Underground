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

namespace InfinityUndergroundLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_website_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alexandrepicard.fr/InfinityUnderground/");
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            LaunchGame();
            var p = new Process();
            p.StartInfo.FileName = @".\..\..\..\InfinityUndergroundReload\bin\DesktopGL\x86\Debug\InfinityUndergroundReload.exe";
            p.Start();
            Close();
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
