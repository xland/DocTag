using DocTag.Helper;
using DocTag.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocTag
{
    public partial class DocTag : Form
    {
        private int docId;
        private List<Tag> curDocTags;
        public string CurPath
        {
            get;
            set;
        }
        private TagSuggestionCtl tsc;
        
        public DocTag()
        {
            InitializeComponent();

            docId = 0;
            curDocTags = new List<Tag>();
            tsc = new TagSuggestionCtl();
            this.Controls.Add(tsc);
            tsc.Hide();            
        }


        void DocTagWin_Loaded(object sender, EventArgs e)
        {
            var conn = new SQLiteConnection(DB.GetConnStr());
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
                    entity.Id = Convert.ToInt32(reader["RowId"]);
                    curDocTags.Add(entity);

                    var btn = UI.CreateBtn();
                    btn.Text = entity.TagVal;
                    btn.Tag = entity;
                    btn.ContextMenuStrip = BtnMenu;
                    TagWP.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
        private void SaveTagBtn_Click(object sender, EventArgs e)
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
            var conn = new SQLiteConnection(DB.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                //判断整个数据库中是否存在这个标签;
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
                var btn = UI.CreateBtn();
                btn.Text = entity.TagVal;
                TagWP.Controls.Add(btn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void TagTB_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TagTB.Text))
            {
                tsc.Hide();
                return;
            }
            tsc.ClearTags();
            var conn = new SQLiteConnection(DB.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            bool showTagSuggession = false;
            try
            {
                conn.Open();
                cmd.CommandText = "select RowId,TagVal from Tag where TagVal like @tagval order by ReferCount desc";
                cmd.Parameters.Add(new SQLiteParameter("tagval", "%" + TagTB.Text.Trim() + "%"));
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    var entity = new Tag();
                    entity.TagVal = reader["TagVal"].ToString();
                    entity.Id = Convert.ToInt32(reader["RowId"]);
                    //如果当前文档已经存在此标签，则不再显示在智能提示中
                    var flag = curDocTags.Any(m => m.Id == entity.Id);
                    if (flag)
                    {
                        continue;
                    }
                    showTagSuggession = true;
                    var tagBtn = UI.CreateLinkLabel();
                    tagBtn.Text = entity.TagVal;
                    tagBtn.Tag = entity;
                    tagBtn.Click += tagBtn_Click;
                    tsc.AddTag(tagBtn);
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
            if (!showTagSuggession)
            {
                return;
            }
            tsc.Left = TagTB.Location.X+6;
            tsc.Top = TagTB.Location.Y + 25+6;
            tsc.Width = TagTB.Width; 
            tsc.Show();
            tsc.BringToFront();
        }

        void tagBtn_Click(object sender, EventArgs e)
        {
            var ll = (LinkLabel)sender;
            var tag = (Tag)ll.Tag;
            var conn = new SQLiteConnection(DB.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                //给标签的引用计数加一
                cmd.CommandText = "update Tag set ReferCount =  ReferCount + 1 where rowid = @rowid;";
                cmd.Parameters.Add(new SQLiteParameter("rowid", tag.Id));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
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
                cmd.Parameters.Add(new SQLiteParameter("TagId", tag.Id));
                cmd.Parameters.Add(new SQLiteParameter("HasSync", 0));
                cmd.ExecuteNonQuery();
                //把这个标签增加到当前界面中
                curDocTags.Add(tag);
                var btn = UI.CreateBtn();
                btn.Text = tag.TagVal;
                btn.ContextMenuStrip = BtnMenu;
                TagWP.Controls.Add(btn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void DelTagMenu_Click(object sender, EventArgs e)
        {
            var btn = (Button)BtnMenu.SourceControl;
            var tag = (Tag)btn.Tag;
            var conn = new SQLiteConnection(DB.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandText = "select ReferCount from Tag where rowid = @rowid;";
                cmd.Parameters.Add(new SQLiteParameter("rowid", tag.Id));                
                var referCount = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Parameters.Clear();
                if (referCount > 1)
                {
                    cmd.CommandText = "update Tag set ReferCount =  ReferCount - 1 where rowid = @rowid;";
                }
                else
                {
                    cmd.CommandText = "delete from Tag where rowid = @rowid;";
                }
                cmd.Parameters.Add(new SQLiteParameter("rowid", tag.Id));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "delete from TagDoc where tagid = @tagid and docid = @docid;";
                cmd.Parameters.Add(new SQLiteParameter("tagid", tag.Id));
                cmd.Parameters.Add(new SQLiteParameter("docid", docId));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                TagWP.Controls.Remove(btn);
                if (TagWP.Controls.Count == 0)
                {
                    cmd.CommandText = "delete from Doc where  rowid = @docid;";
                    cmd.Parameters.Add(new SQLiteParameter("docid", docId));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
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
