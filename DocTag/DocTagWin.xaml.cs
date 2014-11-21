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
using System.Data.SQLite;
using DocTag.Entity;

namespace DocTag
{
    /// <summary>
    /// DocTagWin.xaml 的交互逻辑
    /// </summary>
    public partial class DocTagWin : Window
    {
        public DocTagWin()
        {
            InitializeComponent();
        }

        private void SaveTagBtn_Click(object sender, RoutedEventArgs e)
        {
            var entity = new Tag();
            entity.TagVal = TagTB.Text.Trim();
            entity.ReferCount = 1;
            entity.HasSync = 0;
            var conn = new SQLiteConnection("Data Source=db.db;");
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO Tag(TagVal, ReferCount, HasSync) VALUES(@TagVal, @ReferCount, @HasSync)";
                cmd.Parameters.Add(new SQLiteParameter("TagVal", entity.TagVal));
                cmd.Parameters.Add(new SQLiteParameter("ReferCount", entity.ReferCount));
                cmd.Parameters.Add(new SQLiteParameter("HasSync", entity.HasSync));
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
