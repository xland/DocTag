using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocTag
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            MainWB.Url = new Uri(@"file:///D:/Code/DocTag/DocTag/DocTag/Html/Main.html");
        }
    }
}
