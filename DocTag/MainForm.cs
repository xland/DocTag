using DocTag.DB;
using DocTag.Entity;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DocTag
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TitleBarPanel.Hide();//todo:重绘标题栏，设置form的padding
            this.Load += MainForm_Load;
        }


        void MainForm_Load(object sender, EventArgs e)
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
                while (reader.Read())
                {
                    var entity = new Tag();
                    entity.TagVal = reader["TagVal"].ToString();
                    entity.RowId = Convert.ToInt32(reader["RowId"]);

                    var tagBtn =  createBtn();
                    tagBtn.Click += tagBtn_Click;
                    tagBtn.Text = entity.TagVal;
                    tagBtn.Tag = entity;

                    TagFlowPanel.Controls.Add(tagBtn);
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

        void tagBtn_Click(object sender, EventArgs e)
        {
            DocFlowPanel.Controls.Clear();
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

                    var docBtn = createBtn();
                    docBtn.Text = entity.DocName;
                    docBtn.Tag = entity;
                    docBtn.Click += docBtn_Click;
                    DocFlowPanel.Controls.Add(docBtn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
        void docBtn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var doc = (Doc)btn.Tag;
            System.Diagnostics.Process.Start(doc.DocPath);
        }

        Button createBtn()
        {
            var btn = new Button();
            btn.Margin = new System.Windows.Forms.Padding(6);
            btn.Padding = new System.Windows.Forms.Padding(6);
            btn.Height = 36;
            return btn;
        }
        #region 重绘标题栏
        //[DllImport("user32.dll")]
        //public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wparam, int lparam);
        //[DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();
        //private void TitleBarPanel_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(Handle, 0x0112, 0xF010 + 0x0002, 0);
        //}

        //const int WM_NCHITTEST = 0x0084; 
        //const int HTLEFT = 10;    //左边界
        //const int HTRIGHT = 11;   //右边界 
        //const int HTTOP = 12; //上边界 
        //const int HTTOPLEFT = 13; //左上角 
        //const int HTTOPRIGHT = 14;    //右上角 
        //const int HTBOTTOM = 15;  //下边界 
        //const int HTBOTTOMLEFT = 0x10; //左下角 
        //const int HTBOTTOMRIGHT = 17; //右下角 
        //const int BorderWidth = 4;
        //protected override void WndProc(ref Message m) 
        //{ 
        //    base.WndProc(ref m); 
        //    switch(m.Msg) 
        //    { 
        //        case WM_NCHITTEST: 
        //        { 
        //            Point vPoint = new Point((int)m.LParam & 0xFFFF,(int)m.LParam >> 16 & 0xFFFF); 
        //            vPoint = PointToClient(vPoint); 
        //            //判断：仅当当前窗体状态不是最大化时，相关鼠标事件生效 
        //           if(this.WindowState != FormWindowState.Maximized) 
        //            {
        //                if (vPoint.X < BorderWidth) 
        //                {
        //                    if (vPoint.Y < BorderWidth) 
        //                    { 
        //                        m.Result = (IntPtr)HTTOPLEFT; 
        //                    }
        //                    else if (vPoint.Y > this.Height - BorderWidth) 
        //                    { 
        //                        m.Result = (IntPtr)HTBOTTOMLEFT; 
        //                    } 
        //                    else 
        //                   { 
        //                        m.Result = (IntPtr)HTLEFT; 
        //                    } 
        //                }
        //                else if (vPoint.X > this.Width - BorderWidth) 
        //                {
        //                    if (vPoint.Y < BorderWidth) 
        //                    { 
        //                        m.Result = (IntPtr)HTTOPRIGHT; 
        //                    }
        //                    else if (vPoint.Y > this.Height - BorderWidth) 
        //                    { 
        //                        m.Result = (IntPtr)HTBOTTOMRIGHT; 
        //                    } 
        //                    else 
        //                   { 
        //                        m.Result = (IntPtr)HTRIGHT; 
        //                    } 
        //                }
        //                else if (BorderWidth < vPoint.X && vPoint.X < this.Width - BorderWidth) 
        //                {
        //                    if (vPoint.Y < BorderWidth) 
        //                    { 
        //                        m.Result = (IntPtr)HTTOP; 
        //                    }
        //                    else if (vPoint.Y > this.Height - BorderWidth) 
        //                    { 
        //                        m.Result = (IntPtr)HTBOTTOM; 
        //                    } 
        //                } 
        //            } 
        //            break; 
        //        } 
        //    } 
        //}
#endregion
    }
}
