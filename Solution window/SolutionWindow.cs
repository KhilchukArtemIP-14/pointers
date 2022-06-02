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

namespace Solution_window
{
    public partial class SolutionWindow : Form
    {
        public FieldInstance fieldToBeResolved= null;
        public SolutionWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Label[] labels = new Label[] { label1,label2,label3,label4,label5,label6,label7,label8,label9,label10,label11,label12,label13,label14,label15,label16,label17,label18,label19,label20,label21,label22,label23,label24,label25 };
            int[] path = FieldInstance.fieldFactory.GeneratePath(fieldToBeResolved.GetMatrixOfPossibleMoves(), fieldToBeResolved.GetSeventeenth()).ToArray();
            Array.Reverse(path);
            for (int i = 0; i < 25; i++)
            {
                labels[path[i]].Text=(i+1).ToString();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
