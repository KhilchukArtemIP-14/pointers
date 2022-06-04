using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Field;
namespace TemplateSelection
{
    public partial class SelectionWindow : Form
    {
        public static FieldInstance temp = FieldInstance.templates[0];
        public SelectionWindow()
        {
            this.ControlBox = false;
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp = FieldInstance.templates[1];
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp = FieldInstance.templates[2];
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            temp = FieldInstance.templates[3];
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temp = FieldInstance.GenerateRandomField();
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
