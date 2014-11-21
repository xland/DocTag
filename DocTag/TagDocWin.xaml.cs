using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DocTag
{
    /// <summary>
    /// TagDocWin.xaml 的交互逻辑
    /// </summary>
    public partial class TagDocWin : Window
    {
        public TagDocWin()
        {
            InitializeComponent();
        }
        void InitTags()
        {
            var btn = new Button();
            btn.Margin = new Thickness(8, 8, 8, 8);
            btn.Padding = new Thickness(6, 6, 6, 6);
            btn.Content = "test";
            TagWP.Children.Add(btn);

            var btn2 = new Button();
            btn2.Margin = new Thickness(8, 8, 8, 8);
            btn2.Padding = new Thickness(6, 6, 6, 6);
            btn2.Content = "测试长一点的文字";
            TagWP.Children.Add(btn2);
        }
    }
}
