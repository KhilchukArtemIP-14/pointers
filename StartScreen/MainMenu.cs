using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingWinForms;
using Field;
namespace StartScreen
{
    public partial class MainMenu : Form
    {
        
        public MainMenu()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Pointers newForm = new Pointers();
            newForm.Show();
            this.Hide();
            // this.Show();*/
            Pointers frm2 = new Pointers();
            frm2.Activated += new EventHandler(frm2_Activated); // Handler when the form is activated
            frm2.FormClosed += new FormClosedEventHandler(frm2_FormClosed); // Hander when the form is closed
            frm2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void frm2_Activated(object sender, EventArgs e)
        {
            this.Hide(); // Hides Form1 but it is till in Memory
        }
        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show(); // Unhide Form1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
