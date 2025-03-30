using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;

/* 
        This project was made by S-illy
           https://github.com/S-illy
      Also you can support me with a donation
           https://ko-fi.com/silly69
You can modify this source as you give me credits :D
 
*/
namespace winchancho
{
    public partial class Payload5 : Form
    {
        private WaveOutEvent waveOut; // Yeah i did copy + paste to my own code, problem?
        private Thread effectThread;
        private bool isRunning = true;
        private System.Windows.Forms.Timer effectTimer;

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        private const int SRCINVERT = 0x00660046; // XOR
        private const int SRCCOPY = 0x00CC0020;  // Copy
        private const int NOTSRCCOPY = 0x00330008; // Invert

        private System.Windows.Forms.Timer audioTimer;

        public Payload5()
        {
            waveOut = new WaveOutEvent();
            Noise();
            InitializeComponent();
        }

        private void Payload5_Load(object sender, EventArgs e)
        {
            // Start the timer for the audio loop
            audioTimer = new System.Windows.Forms.Timer
            {
                Interval = 12000
            };
            audioTimer.Tick += new EventHandler(AudioTimer_Tick);
            audioTimer.Start();

            // start the effect thread (drugs)
            effectThread = new Thread(new ThreadStart(FUCKINGDRUGS));
            effectThread.IsBackground = true;
            effectThread.Start();

            effectTimer = new System.Windows.Forms.Timer();
            effectTimer.Interval = 24000;
            effectTimer.Tick += SillyGoto;
            effectTimer.Start();
        }

        private void Noise()
        {
            var mp3Stream = new System.IO.MemoryStream(Properties.Resources.bytebeatloop);
            var reader = new Mp3FileReader(mp3Stream);
            if (waveOut.PlaybackState == PlaybackState.Playing)
            {
                waveOut.Stop();
            }
            waveOut.Init(reader);
            waveOut.Play();
        }

        private void FUCKINGDRUGS()
        {
            IntPtr hdcScreen = GetDC(IntPtr.Zero);
            Random random = new Random();

            try
            {
                while (isRunning)
                {
                    int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                    int screenHeight = Screen.PrimaryScreen.Bounds.Height;

                    for (int i = 0; i < 5; i++)
                    {
                        int x = random.Next(-50, 50);
                        int y = random.Next(-50, 50);
                        int width = screenWidth - random.Next(100);
                        int height = screenHeight - random.Next(100);

                        // You will shit rainbows
                        BitBlt(hdcScreen, x, y, width, height, hdcScreen, 0, 0, SRCINVERT);
                        Thread.Sleep(10);
                        BitBlt(hdcScreen, 0, 0, screenWidth, screenHeight, hdcScreen, x, y, NOTSRCCOPY);
                    }
                }
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, hdcScreen); // HDC
            }
        }

        private void SillyGoto(object sender, EventArgs e)
        {
            // Payload 6 & last
            isRunning = false;
            if (effectThread != null && effectThread.IsAlive)
            {
                effectThread.Join();
            }
            audioTimer.Stop();
            effectTimer.Stop();

            this.Hide();
            Payload3 nextForm = new Payload3(); 
            nextForm.Show();
        }

        private void AudioTimer_Tick(object sender, EventArgs e)
        {
            Noise(); // Loop the noise
        }

        // POR SI LAS MOSKAS ACUERDENSE

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            isRunning = false;
            if (effectThread != null && effectThread.IsAlive)
            {
                effectThread.Join();
            }
        }
    }
}

/* 
        _________
       [_________]
        |  .-.  |
        |,(o.o).|
        | >|n|< |
        |` `"` `|
        |POISON!|
        `"""""""`
     Epilepsy & Drugs
 */