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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SQLite;
using DocTag.Entity;
using DocTag.DB;

namespace DocTag
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += TagDoc_Loaded;
        }

        void TagDoc_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllTag();
        }

        void GetAllTag()
        {
            var conn = new SQLiteConnection(DBSQLite.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandText = "select RowId,TagVal from Tag order by ReferCount desc";
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var entity = new Tag();
                    entity.TagVal = reader["TagVal"].ToString();
                    entity.RowId = Convert.ToInt32(reader["RowId"]);

                    var btn = new Button();
                    btn.Margin = new Thickness(8, 8, 8, 8);
                    btn.Padding = new Thickness(6, 6, 6, 6);
                    btn.Content = reader["TagVal"].ToString();
                    TagWP.Children.Add(btn);
                }
            }
            catch
            {
                MessageBox.Show("存储异常，请联系管理员");
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }


    }
}
