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
using System.Xml;

namespace Kepler_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //utiliser
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("test-doc.xml");
            XmlNodeList userNodes = xmlDoc.SelectNodes("//users/user");
            foreach (XmlNode userNodee in userNodes)
            {
                listBox1.Items.Add(userNodee.InnerXml);
            }
        }

        private void btn_website_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://google.com");
        }

        private void btn_loadSave_Click(object sender, EventArgs e)
        {

             // Crée
            //XmlDocument xmlDoc = new XmlDocument();
            //XmlNode rootNode = xmlDoc.CreateElement("users");
            //xmlDoc.AppendChild(rootNode);

            //XmlNode userNode = xmlDoc.CreateElement("user");
            //XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            //attribute.Value = "42";
            //userNode.Attributes.Append(attribute);
            //userNode.InnerText = "John Doe";
            //rootNode.AppendChild(userNode);

            //userNode = xmlDoc.CreateElement("user");
            //attribute = xmlDoc.CreateAttribute("age");
            //attribute.Value = "39";
            //userNode.Attributes.Append(attribute);
            //userNode.InnerText = "Jane Doe";
            //rootNode.AppendChild(userNode);

            //xmlDoc.Save("test-doc.xml");

            // MODIFIER

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("test-doc.xml");
            XmlNodeList userNodes = xmlDoc.SelectNodes("//users/user");
            foreach (XmlNode userNodee in userNodes)
            {
                int age = int.Parse(userNodee.Attributes["age"].Value);
                userNodee.Attributes["age"].Value = (age + 1).ToString();
                btn_loadSave.Text = userNodee.InnerXml;
            }
            xmlDoc.Save("test-doc.xml");
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            LaunchGame();
            var p = new Process();
            p.StartInfo.FileName = @"..\..\..\Kepler-22_B\bin\Windows\x86\Debug\Kepler-22_B.exe";
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
