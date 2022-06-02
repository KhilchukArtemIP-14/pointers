using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateSelection;
using Field;
using Solution_window;

namespace TestingWinForms
{
    public partial class Pointers : Form
    {
        private bool ifWasHelped = false;
        static FieldInstance mainField = FieldInstance.templates[0];
        static Stack<FieldButton.FieldButton> buttonReferences = new Stack<FieldButton.FieldButton>();
        private int ticks;
        public Pointers()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Привіт");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PressFieldButton(button2);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            PressFieldButton(button21);
        }

        private void Pointers_Load(object sender, EventArgs e)
        {
            mainField = FieldInstance.templates[0];
            buttonReferences.Push(button1);
            SyncData();
            ticks = 0;
            timer1.Start();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

            Form1 frm2 = new Form1();
            frm2.Activated += new EventHandler(frm2_Activated);
            frm2.FormClosed += new FormClosedEventHandler(frm2_FormClosed); 
            frm2.Show();
        }
        private void frm2_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainField = Form1.temp;
            SyncData();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Нелегальний хід");
        }
        public void SyncData()
        {
            SetInitialValues();
            this.button1.queueNumber = "1";
            this.button25.queueNumber = "25";
            buttonReferences.Push(button1);
            FieldButton.FieldButton[] fieldButtons = new FieldButton.FieldButton[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            for (int i = 0; i < 25; i++)
            {
                fieldButtons[i].Arrow= mainField.RecieveArrowText(i);
                fieldButtons[i].numberOfButton = i;
                fieldButtons[i].UseCompatibleTextRendering = true;
                fieldButtons[i].Enabled = true;
            }
            button29.Enabled=true;
            button31.Enabled = true;
            ticks = 0;
            timer1.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PressFieldButton(button10);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PressFieldButton(button8);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            PressFieldButton(button13);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PressFieldButton(button3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PressFieldButton(button6);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            PressFieldButton(button22);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SolutionWindow solution = new SolutionWindow();
            solution.fieldToBeResolved = mainField;
            solution.Show();
            ifWasHelped = true;
        }

        private void fieldButton1_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (buttonReferences.Count == 24)
            {
                PressFieldButton(button25);
            }

            if (CheckIfTheWayIsRight())
            {
                //MessageBox.Show("Перемога!!!");
                foreach(var a in buttonReferences)
                {
                    a.Enabled = false;
                }
                button29.Enabled = false;
                timer1.Stop();
                VictoryStatsWindow.VictoryStats tempWindow = new VictoryStatsWindow.VictoryStats(ticks, true, ifWasHelped);
                tempWindow.Show();
                ifWasHelped = false;
                button31.Enabled = false;
            }
            else
            {
                MessageBox.Show("Неправильний шлях");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PressFieldButton(button5);
        }
        public void SetInitialValues()
        {
            WipeQueueData();
            FieldButton.FieldButton[] fieldButtons = new FieldButton.FieldButton[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            int seventeenth = mainField.GetSeventeenth();
            fieldButtons[seventeenth].queueNumber = "17";
        }
        public void WipeQueueData()
        {
            buttonReferences = new Stack<FieldButton.FieldButton>();
            FieldButton.FieldButton[] fieldButtons = new FieldButton.FieldButton[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            foreach(var a in fieldButtons)
            {
                a.queueNumber = "";
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (buttonReferences.Count != 1)
            {
                if((buttonReferences.Peek().GetNumberOfButton() !=mainField.GetSeventeenth())&& (buttonReferences.Peek().GetNumberOfButton() != 24))
                {
                    buttonReferences.Peek().queueNumber = "";
                }
                buttonReferences.Peek().Focus();
                buttonReferences.Pop();
            }
        }
        public static void PressFieldButton( FieldButton.FieldButton button)
        {
            int[] playersMoves = GetArrayOfNumbersOfButtons();
            if (mainField.GetMatrixOfPossibleMoves()[buttonReferences.Peek().GetNumberOfButton()].Contains(button.GetNumberOfButton()) & !playersMoves.Contains(button.GetNumberOfButton()))
            {
                if (!((playersMoves.Count() != 16) ^ (button.GetNumberOfButton() != mainField.GetSeventeenth())))
                {
                    button.queueNumber = (playersMoves.Length + 1).ToString();
                    buttonReferences.Push(button);
                }
                else
                {
                    MessageBox.Show("Нелегальний хід");
                }

            }
            else
            {
                MessageBox.Show("Нелегальний хід");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PressFieldButton(button4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PressFieldButton(button7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PressFieldButton(button9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PressFieldButton(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PressFieldButton(button12);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PressFieldButton(button14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PressFieldButton( button15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            PressFieldButton(button16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            PressFieldButton(button17);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            PressFieldButton(button18);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            PressFieldButton(button19);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            PressFieldButton(button20);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            PressFieldButton(button23);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            PressFieldButton(button24);
        }
        public bool CheckIfTheWayIsRight()
        {
            int[] playersPath = GetArrayOfNumbersOfButtons();
            int[] truePath = FieldInstance.fieldFactory.GeneratePath(mainField.GetMatrixOfPossibleMoves(), mainField.GetSeventeenth()).ToArray();
            if (buttonReferences.Count != 25 || truePath.Length != 25) return false;
            for (int i = 0; i < 25; i++)
            {
                if (playersPath[i] != truePath[i]) return false;
            }
            return true;
        }
        public static int[] GetArrayOfNumbersOfButtons()
        {
            List<int> temp = new List<int>();
            foreach(var a in buttonReferences)
            {
                temp.Add(a.GetNumberOfButton());
            }
            return temp.ToArray();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            FieldButton.FieldButton[] fieldButtons = new FieldButton.FieldButton[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            foreach (var a in fieldButtons)
            {
                a.Enabled = true;
            }
            button29.Enabled = true;
            button31.Enabled = true;
            while (buttonReferences.Count != 1)
            {
                if ((buttonReferences.Peek().queueNumber != "17") && (buttonReferences.Peek().queueNumber != "25"))
                {
                    buttonReferences.Peek().queueNumber = "";
                }
                buttonReferences.Peek().Focus();
                buttonReferences.Pop();
            }
            ifWasHelped = false;
            ticks = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            label2.Text = String.Format("Час: {0:d2}:{1:d2}", ticks / 60, ticks % 60);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            VictoryStatsWindow.VictoryStats tempWindow = new VictoryStatsWindow.VictoryStats(ticks, false, ifWasHelped);
            tempWindow.Show();
            ifWasHelped = false;
            button31.Enabled = false;
            FieldButton.FieldButton[] fieldButtons = new FieldButton.FieldButton[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25 };
            foreach(var a in fieldButtons)
            {
                a.Enabled = false;
            }
            button29.Enabled = false;
        }
    }
}
