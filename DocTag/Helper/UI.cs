using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DocTag.Helper
{
    public class UI
    {
        public static Button CreateBtn()
        {
            var btn = new Button();
            btn.Margin = new System.Windows.Forms.Padding(6);
            btn.Padding = new System.Windows.Forms.Padding(6);
            btn.AutoSize = true;
            btn.Height = 36;
            return btn;
        }
        public static LinkLabel CreateLinkLabel()
        {
            var label = new LinkLabel();
            label.AutoSize = true;
            label.Padding = new System.Windows.Forms.Padding(4);
            label.Margin = new Padding(2);
            label.Font = new System.Drawing.Font("微软雅黑", 10F);
            label.Height = 32;
            return label;
        }
    }
}
