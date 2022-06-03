using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket
{
    public partial class Splach : Form
    {
        public Splach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 1;
            bunifuProgressBar1.Value = startPoint;
            if (bunifuProgressBar1.Value == 100)
            {
                bunifuProgressBar1.Value = 0;
                timer1.Stop();
                
                    Form1 log = new Form1();
                    this.Hide();
                    log.Show();
               

            }

        }

        private void Splach_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
