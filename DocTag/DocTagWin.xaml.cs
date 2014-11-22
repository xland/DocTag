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
using System.IO;
using DocTag.DB;

namespace DocTag
{
    /// <summary>
    /// DocTagWin.xaml 的交互逻辑
    /// </summary>
    public partial class DocTagWin : Window
    {
        private int docId = 0;
        private List<Tag> curDocTags = new List<Tag>();
        public string CurPath
        {
            get;
            set;
        }
        public DocTagWin()
        {
            InitializeComponent();
            this.Loaded += DocTagWin_Loaded;
        }

        void DocTagWin_Loaded(object sender, RoutedEventArgs e)
        {
            var conn = new SQLiteConnection(DBSQLite.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                //判断是否存在此文档,如果存在则获取其ID
                cmd.CommandText = "select rowid from Doc where DocPath = @DocPath";
                cmd.Parameters.Add(new SQLiteParameter("DocPath", CurPath));
                var val = cmd.ExecuteScalar();
                docId = Convert.ToInt32(val);
                //取出当前文档的所有标签
                cmd.Parameters.Clear();
                cmd.CommandText = "select t.RowId,t.TagVal from TagDoc td left join Tag t on td.tagid = t.rowid where td.docid = @DocId order by t.ReferCount desc";
                cmd.Parameters.Add(new SQLiteParameter("DocId", docId));
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var entity = new Tag();
                    entity.TagVal = reader["TagVal"].ToString();
                    entity.RowId = Convert.ToInt32(reader["RowId"]);
                    curDocTags.Add(entity);

                    var btn = new Button();
                    btn.Margin = new Thickness(8, 8, 8, 8);
                    btn.Padding = new Thickness(6, 6, 6, 6);
                    btn.Content = entity.TagVal;
                    btn.Tag = entity;
                    TagWP.Children.Add(btn);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void SaveTagBtn_Click(object sender, RoutedEventArgs e)
        {
            var hasThisTag = curDocTags.Any(m => m.TagVal.Equals(TagTB.Text.Trim()));
            if (hasThisTag)
            {
                MessageBox.Show("当前文档已经存在此标签");
                return;
            }
            var entity = new Tag();
            entity.TagVal = TagTB.Text.Trim();
            entity.ReferCount = 1;
            entity.HasSync = 0;
            var conn = new SQLiteConnection(DBSQLite.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                //判断整个数据库中是否存在这个标签;todo：应该引入智能提示机制
                cmd.CommandText = "select rowid from Tag where TagVal = @TagVal";
                cmd.Parameters.Add(new SQLiteParameter("TagVal", entity.TagVal));
                var tagId = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                if (tagId > 0)
                {
                    //存在此标签，则给标签的引用计数加一
                    cmd.CommandText = "update Tag set ReferCount =  ReferCount + 1 where rowid = @rowid;";
                    cmd.Parameters.Add(new SQLiteParameter("rowid", tagId));
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                else
                {
                    //不存在此标签，则新增一行记录，并返回ID
                    cmd.CommandText = "INSERT INTO Tag (TagVal, ReferCount, HasSync) VALUES (@TagVal, @ReferCount, @HasSync);select last_insert_rowid();";
                    cmd.Parameters.Add(new SQLiteParameter("TagVal", entity.TagVal));
                    cmd.Parameters.Add(new SQLiteParameter("ReferCount", entity.ReferCount));
                    cmd.Parameters.Add(new SQLiteParameter("HasSync", entity.HasSync));
                    tagId = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Parameters.Clear();
                }                
                if (docId <= 0)
                {
                    //数据库中没有这个文档的记录，新增文档记录
                    cmd.CommandText = "INSERT INTO Doc (DocName, DocPath, DocType,HasSync) VALUES (@DocName, @DocPath,@DocType, @HasSync);select last_insert_rowid();";
                    if (File.Exists(CurPath))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("DocName", System.IO.Path.GetFileName(CurPath)));
                        cmd.Parameters.Add(new SQLiteParameter("DocType", 0));
                    }
                    else
                    {
                        var di = new DirectoryInfo(CurPath);
                        cmd.Parameters.Add(new SQLiteParameter("DocName", di.Name));
                        cmd.Parameters.Add(new SQLiteParameter("DocType", 1));
                    }
                    cmd.Parameters.Add(new SQLiteParameter("DocPath", CurPath));                    
                    cmd.Parameters.Add(new SQLiteParameter("HasSync", 0));
                    var val = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    docId = Convert.ToInt32(val);
                }
                //增加文档和标签的关系
                cmd.CommandText = "INSERT INTO TagDoc(DocId, TagId, HasSync) VALUES (@DocId, @TagId, @HasSync)";
                cmd.Parameters.Add(new SQLiteParameter("DocId", docId));
                cmd.Parameters.Add(new SQLiteParameter("TagId", tagId));
                cmd.Parameters.Add(new SQLiteParameter("HasSync", 0));
                cmd.ExecuteNonQuery();
                //把这个标签增加到当前界面中
                curDocTags.Add(entity);
                var btn = new Button();
                btn.Margin = new Thickness(8, 8, 8, 8);
                btn.Padding = new Thickness(6, 6, 6, 6);
                btn.Content = entity.TagVal;
                TagWP.Children.Add(btn);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
    }
}
