using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CustomControls
{
    class CustomTBox : TextBox
    {
        private Font Fnt;
        private Color Col;
        public CustomTBox()
        {
            BorderStyle = BorderStyle.None;
            Fnt = Font;
            Col = ForeColor;

            SetStyle(ControlStyles.UserPaint, true);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen redPen = new Pen(Color.Black, 1);
            int size = Width;
            int location = Height;
            //e.Graphics.DrawLine(redPen, 1, 1, Width + 25, 1);
            e.Graphics.DrawLine(redPen, 1, location - 1, Width + 25, location - 1);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Pen redPen = new Pen(Color.Black, 1);
            int size = Width;
            int location = Height;
            //e.Graphics.DrawLine(redPen, 1, 1, Width + 25, 1);
            e.Graphics.DrawLine(redPen, 1, location - 1, Width + 25, location - 1);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (Text == watermark)
            {
                Font = new Font(this.Font, this.Font.Style | FontStyle.Italic);
                ResetText();
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Pen redPen = new Pen(Color.Black, 1);
            int size = Width;
            int location = Height;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseDown(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            CheckWatermark();
        }

        private string watermark = string.Empty;

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Font = Fnt;
            ForeColor = Col;
        }

        private void CheckWatermark()
        {
            if (Text == "" || Text == watermark)
            {
                Text = watermark;
                ForeColor = Color.Gray;
                Font = new Font(Font, FontStyle.Italic);
            }
            else
            {
                Font = Fnt;
                ForeColor = Col;
            }
        }

        public string Watermark
        {
            get { return watermark; }
            set { watermark = value; Text = watermark; CheckWatermark(); }
        }

    }

}
