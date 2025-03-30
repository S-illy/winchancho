using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winchancho
{
    public partial class PayloadFinal : Form
    {
        public PayloadFinal()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not my problem dude...");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("THERE IS NO PASSWORD!!!!11211");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PayloadFinal_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // can't escape!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

    }
}
