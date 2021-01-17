using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public class UndlerLineTBox : TextBox
    {
        public UndlerLineTBox()
        {
            BorderStyle = BorderStyle.None;
        }

        //protected override void OnFontChanged(EventArgs e)
        //{
        //    base.OnFontChanged(e);
        //    RefreshHeight();
        //}


        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            Pen xPen = new Pen(Color.Blue);
            e.Graphics.DrawLine(xPen,
                                Location.X,
                                Location.Y + Height,
                                Location.X + Width,
                                Location.Y + Height);
            
        }


    }
}
