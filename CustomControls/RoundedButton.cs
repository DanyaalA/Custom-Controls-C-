using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CustomControls
{
    public class RoundedButton : Button
    {


        public RoundedButton()
        {
            //BackColor = Color.DodgerBlue;
            ////defaultColor = BackColor;
            //ForeColor = Color.White;
            Font Fnt = Font;
        }

        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();

            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);

            GraphPath.CloseFigure();
            return GraphPath;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath GraphPath = GetRoundPath(Rect, 50);

            this.Region = new Region(GraphPath);
            using (Pen pen = new Pen(Color.CadetBlue, 1.75f))
            {
                pen.Alignment = PenAlignment.Inset;
                pevent.Graphics.DrawPath(pen, GraphPath);
            }

            //GraphicsPath p = new GraphicsPath();
            //p.AddEllipse(1, 1, Width, Height);
            //Region = new Region(p);

            //pevent.Graphics.FillEllipse(new SolidBrush(this.BackColor), 1, 1, this.Width, this.Height);
            //TextFormatFlags Flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            //TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, new Point(this.Width + 3, this.Height / 2), this.ForeColor, Flags);
        }

        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    BackColor = onMouseHoverBackColor;
        //}

        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    BackColor = defaultColor;
        //}

        //protected override void OnMouseDown(MouseEventArgs mevent)
        //{
        //    base.OnMouseDown(mevent);
        //    BackColor = onMouseClickColor;
        //}

        //protected override void OnMouseUp(MouseEventArgs mevent)
        //{
        //    base.OnMouseUp(mevent);
        //    BackColor = defaultColor;
        //}

        //Settings

        //private Color onMouseHoverBackColor = Color.DarkOrchid;
        //private Color onMouseClickColor = Color.RoyalBlue;
        //private Color defaultColor = Color.DodgerBlue;
        //public Color OnMouseHoverBackColor
        //{
        //    get { return onMouseHoverBackColor; }
        //    set { onMouseHoverBackColor = value; }
        //}

        //public Color OnMouseClickColor
        //{
        //    get { return onMouseClickColor; }
        //    set { onMouseClickColor = value; }
        //}

        //public Color DefaultColor
        //{
        //    get { return defaultColor; }
        //    set { defaultColor = value; }
        //}
    }
}
