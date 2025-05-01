using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomComponents
{
    public class CustomMaterialMaskedTextBox : MaterialMaskedTextBox
    {
        private Color underlineColor = Color.Red; // Default color, change as needed

        public Color UnderlineColor
        {
            get => underlineColor;
            set
            {
                underlineColor = value;
                Invalidate(); // Redraw the control to apply the new color
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the custom underline
            using (var pen = new Pen(underlineColor, 2)) // Change 2 to your desired thickness
            {
                var underlineY = this.Height - 1; // Adjust as needed
                e.Graphics.DrawLine(pen, 0, underlineY, this.Width, underlineY);
            }
        }
    }
}
