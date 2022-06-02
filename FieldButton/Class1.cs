using System;
using System.Windows.Forms;
using System.Drawing;
namespace FieldButton
{
    public class FieldButton : Button
    {
        //private static int numberOfInstances = 0;
        public FieldButton()
        {
            //this.numberOfButton = Convert.ToInt32(numberOfInstances.ToString());
            //numberOfInstances += 1;
            UseVisualStyleBackColor = false;
            TextImageRelation = TextImageRelation.ImageAboveText;
        }
        public int GetNumberOfButton()
        {
            return numberOfButton;
        }
        public override string Text
        {
            get { return ""; }
            set { base.Text = value; }
        }
        public string Arrow;
        public string queueNumber;
        public int numberOfButton;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Rectangle rect = ClientRectangle;
            rect.Inflate(-5, -5);
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                using (Brush brush = new SolidBrush(ForeColor))
                {
                    Font arrowFont = new Font("Segoe UI",19, System.Drawing.FontStyle.Bold);
                    pevent.Graphics.DrawString(Arrow, arrowFont, brush, rect, sf);
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    pevent.Graphics.DrawString(queueNumber, new Font("Segoe UI", 6), brush, rect, sf);
                }
            }
        }
    }
}
