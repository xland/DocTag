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

                    var tagBtn = new Button();
                    tagBtn.Margin = new Thickness(8, 8, 8, 8);
                    tagBtn.Padding = new Thickness(6, 6, 6, 6);
                    tagBtn.Click += tagBtn_Click;
                    tagBtn.Content = reader["TagVal"].ToString();
                    tagBtn.Tag = entity;
                    TagWP.Children.Add(tagBtn);
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

        void tagBtn_Click(object sender, RoutedEventArgs e)
        {
            DocWP.Children.Clear();
            var btn = (Button)sender;
            var tag = (Tag)btn.Tag;
            var conn = new SQLiteConnection(DBSQLite.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandText = "select d.* from tagdoc td left join Doc d  on td.docid = d.rowid where td.tagid = @tagid";
                cmd.Parameters.Add(new SQLiteParameter("tagid", tag.RowId));
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var entity = new Doc();
                    entity.DocName = reader["DocName"].ToString();
                    entity.DocPath = reader["DocPath"].ToString();
                    entity.DocType = Convert.ToInt32(reader["DocType"]);

                    var docBtn = new Button();
                    docBtn.Margin = new Thickness(8, 8, 8, 8);
                    docBtn.Padding = new Thickness(6, 6, 6, 6);
                    docBtn.Content = entity.DocName;
                    docBtn.Tag = entity;
                    docBtn.Click += docBtn_Click;
                    DocWP.Children.Add(docBtn);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        void docBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var doc = (Doc)btn.Tag;
            System.Diagnostics.Process.Start(doc.DocPath);
        }



        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
