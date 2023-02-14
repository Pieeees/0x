using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using WeAreDevs_API;

namespace _0x
{
    public partial class Form1 : Form
    {
        ExploitAPI api = new ExploitAPI();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("scripts");
            checkinjected();
            panel2.Hide();
            timer1.Start();
            fastColoredTextBox1.Refresh();
            api.IsUpdated();
            WebClient webclientupdate = new WebClient();
            WebClient WebClient = new WebClient();
            if (!webclientupdate.DownloadString("https://pastebin.com/raw/2qWU0HQv").Contains("0.2"))

                if (MessageBox.Show("New Upate\nyou want to download it?", "New update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    WebClient auto = new WebClient();

                    string file = WebClient.DownloadString("https://pastebin.com/raw/Fktjh448");
                    WebClient.DownloadFile(file, "0x.zip");
                    Application.Exit();
                    string batchCommands = string.Empty;
                    string exeFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty).Replace("/", "\\");

                    batchCommands += "@ECHO OFF\n";
                    batchCommands += "title Updating do not close or touch!!!\n";
                    batchCommands += "timeout /T 3 /NOBREAK > nul\n";
                    batchCommands += "echo j | del /F ";
                    batchCommands += exeFileName + "\n";
                    batchCommands += "tar -xf 0x.zip > nul\n";
                    batchCommands += "del 0x.zip > nul\n";
                    batchCommands += "echo j | del updater.bat > nul\n";

                    File.WriteAllText("updater.bat", batchCommands);

                    Process.Start("updater.bat");

                }
                else
                {
                    Application.Exit();
                }
            try
            {
                this.BackgroundImage = Image.FromFile("bg.png");
                this.Refresh();
            }
            catch (Exception)
            {
                try
                {
                    this.BackgroundImage = Image.FromFile("bg.jpg");
                    this.Refresh();
                }
                catch (Exception)
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string text = File.ReadAllText(openFileDialog.FileName);
                this.fastColoredTextBox1.Text = text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label5.Refresh();
            api.IsUpdated();
            api.LaunchExploit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./scripts", "*.lua");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = File.ReadAllText($"./scripts/{listBox1.SelectedItem}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox1.Text);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string script = fastColoredTextBox1.Text;
            api.SendLuaScript(script);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel2.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.TopMost = true;
            }
            else
            if (checkBox1.Checked == false)
            {
                this.TopMost = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/MSHCS8u7eJ");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Pieeees/0x");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            api.DoBTools();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            api.ToggleClickTeleport();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            api.ToggleFloat();
        }
        private void checkinjected()
        {
            if (api.isAPIAttached())
            {
                label5.Text = "Injected";
            }
            else
            {
                label5.Text = "Uninjected";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            api.isAPIAttached();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            string username = textBox1.ToString();
            api.TeleportToPlayer(username);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            api.SendLuaScript("loadstring(game:HttpGet(('https://pastebin.com/raw/kHe8NhT6'),true))()");
        }
    }
}
