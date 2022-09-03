using CmlLib.Core;
using CmlLib.Core.Auth;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Noise_Client
{
    public partial class NoiseStarter : Form
    {
        public NoiseStarter()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public static string versiyon;

        private void path()
        {
            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);

            foreach (var item in launcher.GetAllVersions())
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        private void Launch()
        {

            var path = new MinecraftPath();
            var launcher = new CMLauncher(path);
            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.GetOfflineSession(textBox1.Text),
                //ServerIP = "serverıp.domain",
                //ServerPort = Port,
            };

            versiyon = comboBox1.SelectedItem.ToString();
            var process = launcher.CreateProcess(versiyon, launchOption);
            process.Start();
            Hide();

        }

        private void kapatma_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        private void NoiseStarter_Load(object sender, EventArgs e)
        {
            path();
        }
        private void play_Click(object sender, EventArgs e)
        {
            play.Enabled = false;
            Thread thread = new Thread(() => Launch());
            thread.IsBackground = true;
            thread.Start();
            List<string> Yazilar = new List<string>();
            Yazilar.Add("Açılıyor...");
            Yazilar.Add("Açılıyor...");
            Random Rastgele = new Random();
            int indeks = Rastgele.Next(1, Yazilar.Count);
            play.Text = Yazilar[indeks];
        }
    }
}
