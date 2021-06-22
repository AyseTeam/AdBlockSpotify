using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AdBlockSpotify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string url = folderBrowserDialog1.SelectedPath;

                if (File.Exists(url + @"\AdsBlocker-Sotify.exe"))
                {
                    label1.Text = url + @"\AdsBlocker-Sotify.exe";


                    button1.Visible = false;
                    button2.Visible = true;

                    lb2.Text = "This file already exists";
                    lb2.ForeColor = Color.Red;
                    lb2.Location = new Point(198, 252);

                    lb2.Visible = true;

                }
                else
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/833825844757397504/844997493225816075/EZBlocker.exe", url + @"\AdsBlocker-Sotify.exe");

                    lb2.Text = "AdsBlocker-Sotify - has been installed !";
                    lb2.ForeColor = Color.Green;
                    lb2.Location = new Point(69, 258);

                    lb2.Visible = true;

                    ProcessStartInfo info = new ProcessStartInfo(url + @"\AdsBlocker-Sotify.exe");
                    info.UseShellExecute = true;
                    info.Verb = "runas";
                    Process.Start(info);

                    tm.Start();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete(label1.Text.ToString());

            lb2.Text = "File been deleted !";
            lb2.ForeColor = Color.GreenYellow;
            lb2.Location = new Point(228, 249);

            lb2.Visible = true;

            button1.Visible = true;
            button2.Visible = false;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            tm.Stop();
            MessageBox.Show("Thank you for using our software", "Using software", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCWEn3fgBNVQgiWOKSfs1dgQ?view_as=subscriber");
        }
    }
}
