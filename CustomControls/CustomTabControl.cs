using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    class CustomTabControl : TabControl
    {
        public TabPageCollection TabPages { get; set; }

        public CustomTabControl() : base()
        {
            base.Width = 200;
            base.Height = 100;

        }
    }
}
