using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DocTag
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 0)
            {
                var dtw = new DocTagWin();
                dtw.CurPath = e.Args[0];
                dtw.Show();
            }
            else
            {
                var w = new MainWindow();
                w.Show();
            }

            //var dtw = new DocTagWin();
            //dtw.CurPath = @"D:\Code\DocTag\DocTag\DocTag\bin\Debug";
            //dtw.Show();
            
        }
    }
}
