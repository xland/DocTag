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
            AddDocTag();
        }


        void AddDocTag()
        {
            var entity = new TagDocEntity();
            entity.TagVal = "DocTag";
            entity.DocPath = @"D:\Code\DocTag\DocTag\DocTag.UI\bin\Debug";
            entity.DocName = "DocPath";
            entity.DocType = 1;
            var conn = new SQLiteConnection("Data Source=db.db;");
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {

                conn.Open();
                cmd.CommandText = "INSERT INTO TagDoc(TagVal, DocPath, DocName,DocType) VALUES(@TagVal, @DocPath, @DocName, @DocType)";
                cmd.Parameters.Add(new SQLiteParameter("TagVal", entity.TagVal));
                cmd.Parameters.Add(new SQLiteParameter("DocPath", entity.DocPath));
                cmd.Parameters.Add(new SQLiteParameter("DocName", entity.DocName));
                cmd.Parameters.Add(new SQLiteParameter("DocType", entity.DocType));
                cmd.ExecuteNonQuery();
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
