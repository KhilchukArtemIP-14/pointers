using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VictoryStatsWindow
{
    public partial class VictoryStats : Form
    {

        public VictoryStats(int timerTicks,bool ifVictory,bool ifWasHelped)
        {
           
            InitializeComponent();
            if (!ifVictory)
            {
                label1.Text = "Передчасно закінчена гра";
                label1.Font = new Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
                label1.UseCompatibleTextRendering = true;
                label6.Visible = false;
            }
            label3.Text = String.Format("{0:d2}:{1:d2}", timerTicks / 60, timerTicks % 60);
            if (!ifWasHelped)
            {
                label4.Text = "Ні";
                label4.ForeColor = Color.Green;
            }
            else
            {
                label4.Text = "Так";
                label4.ForeColor = Color.Red;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
