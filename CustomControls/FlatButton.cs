using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace CustomControls
{
    public class FlatButton : Button
    {
        public FlatButton()
        {
            BackColor = Color.DodgerBlue;
            defaultColor = BackColor;
            ForeColor = Color.White;
            Font Fnt = Font;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
            TextFormatFlags Flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, new Point(this.Width + 3, this.Height / 2), this.ForeColor, Flags);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            BackColor = onMouseHoverBackColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = defaultColor;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            BackColor = onMouseClickColor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            BackColor = defaultColor;
        }

        //Settings

        private Color onMouseHoverBackColor = Color.DarkOrchid;
        private Color onMouseClickColor = Color.RoyalBlue;
        private Color defaultColor = Color.DodgerBlue;
        public Color OnMouseHoverBackColor
        {
            get { return onMouseHoverBackColor; }
            set { onMouseHoverBackColor = value; }
        }

        public Color OnMouseClickColor
        {
            get { return onMouseClickColor; }
            set { onMouseClickColor = value; }
        }

        public Color DefaultColor
        {
            get { return defaultColor; }
            set { defaultColor = value; }
        }
    }
}
