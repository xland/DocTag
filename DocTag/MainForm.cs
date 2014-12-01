using DocTag.Helper;
using DocTag.Entity;
using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

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
            var conn = new SQLiteConnection(DB.GetConnStr());
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
                    entity.Id = Convert.ToInt32(reader["RowId"]);

                    var tagBtn = UI.CreateBtn();
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
            var conn = new SQLiteConnection(DB.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandText = "select d.* from tagdoc td left join Doc d  on td.docid = d.rowid where td.tagid = @tagid";
                cmd.Parameters.Add(new SQLiteParameter("tagid", tag.Id));
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var entity = new Doc();
                    entity.DocName = reader["DocName"].ToString();
                    entity.DocPath = reader["DocPath"].ToString();
                    entity.DocType = Convert.ToInt32(reader["DocType"]);

                    var docBtn = UI.CreateBtn();
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

        private void TagSearchTB_TextChanged(object sender, EventArgs e)
        {
            TagFlowPanel.Controls.Clear();
            var conn = new SQLiteConnection(DB.GetConnStr());
            SQLiteCommand cmd = conn.CreateCommand();
            try
            {
                conn.Open();
                cmd.CommandText = "select RowId,TagVal from Tag where TagVal like @tagval order by ReferCount desc";
                cmd.Parameters.Add(new SQLiteParameter("tagval", "%" + TagSearchTB.Text.Trim() + "%"));
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var entity = new Tag();
                    entity.TagVal = reader["TagVal"].ToString();
                    entity.Id = Convert.ToInt32(reader["RowId"]);

                    var tagBtn = UI.CreateBtn();
                    tagBtn.Click += tagBtn_Click;
                    tagBtn.Text = reader["TagVal"].ToString();
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

        private void DocSearchTB_TextChanged(object sender, EventArgs e)
        {
            int i;
            const int bufsize = 260;
            StringBuilder buf = new StringBuilder(bufsize);

            // set the search
            Everything_SetSearchW(DocSearchTB.Text);

            // use our own custom scrollbar... 			
            // Everything_SetMax(listBox1.ClientRectangle.Height / listBox1.ItemHeight);
            // Everything_SetOffset(VerticalScrollBarPosition...);

            // execute the query
            Everything_QueryW(true);

            // sort by path
            // Everything_SortResultsByPath();

            // clear the old list of results			
            DocFlowPanel.Controls.Clear();

            // set the window title
            //Text = textBox1.Text + " - " + Everything_GetNumResults() + " Results";

            // loop through the results, adding each result to the listbox.
            for (i = 0; i < Everything_GetNumResults(); i++)
            {
                // get the result's full path and file name.
                Everything_GetResultFullPathNameW(i, buf, bufsize);
                var btn = UI.CreateBtn();
                btn.Text = buf.ToString();
                // add it to the list box				
                DocFlowPanel.Controls.Add(btn);
            }
        }
        #region everything sdk
        const int EVERYTHING_OK = 0;
        const int EVERYTHING_ERROR_MEMORY = 1;
        const int EVERYTHING_ERROR_IPC = 2;
        const int EVERYTHING_ERROR_REGISTERCLASSEX = 3;
        const int EVERYTHING_ERROR_CREATEWINDOW = 4;
        const int EVERYTHING_ERROR_CREATETHREAD = 5;
        const int EVERYTHING_ERROR_INVALIDINDEX = 6;
        const int EVERYTHING_ERROR_INVALIDCALL = 7;

        [DllImport("Everything32.dll", CharSet = CharSet.Unicode)]
        public static extern int Everything_SetSearchW(string lpSearchString);
        [DllImport("Everything32.dll")]
        public static extern void Everything_SetMatchPath(bool bEnable);
        [DllImport("Everything32.dll")]
        public static extern void Everything_SetMatchCase(bool bEnable);
        [DllImport("Everything32.dll")]
        public static extern void Everything_SetMatchWholeWord(bool bEnable);
        [DllImport("Everything32.dll")]
        public static extern void Everything_SetRegex(bool bEnable);
        [DllImport("Everything32.dll")]
        public static extern void Everything_SetMax(int dwMax);
        [DllImport("Everything32.dll")]
        public static extern void Everything_SetOffset(int dwOffset);

        [DllImport("Everything32.dll")]
        public static extern bool Everything_GetMatchPath();
        [DllImport("Everything32.dll")]
        public static extern bool Everything_GetMatchCase();
        [DllImport("Everything32.dll")]
        public static extern bool Everything_GetMatchWholeWord();
        [DllImport("Everything32.dll")]
        public static extern bool Everything_GetRegex();
        [DllImport("Everything32.dll")]
        public static extern UInt32 Everything_GetMax();
        [DllImport("Everything32.dll")]
        public static extern UInt32 Everything_GetOffset();
        [DllImport("Everything32.dll")]
        public static extern string Everything_GetSearchW();
        [DllImport("Everything32.dll")]
        public static extern int Everything_GetLastError();

        [DllImport("Everything32.dll")]
        public static extern bool Everything_QueryW(bool bWait);

        [DllImport("Everything32.dll")]
        public static extern void Everything_SortResultsByPath();

        [DllImport("Everything32.dll")]
        public static extern int Everything_GetNumFileResults();
        [DllImport("Everything32.dll")]
        public static extern int Everything_GetNumFolderResults();
        [DllImport("Everything32.dll")]
        public static extern int Everything_GetNumResults();
        [DllImport("Everything32.dll")]
        public static extern int Everything_GetTotFileResults();
        [DllImport("Everything32.dll")]
        public static extern int Everything_GetTotFolderResults();
        [DllImport("Everything32.dll")]
        public static extern int Everything_GetTotResults();
        [DllImport("Everything32.dll")]
        public static extern bool Everything_IsVolumeResult(int nIndex);
        [DllImport("Everything32.dll")]
        public static extern bool Everything_IsFolderResult(int nIndex);
        [DllImport("Everything32.dll")]
        public static extern bool Everything_IsFileResult(int nIndex);
        [DllImport("Everything32.dll", CharSet = CharSet.Unicode)]
        public static extern void Everything_GetResultFullPathNameW(int nIndex, StringBuilder lpString, int nMaxCount);
        [DllImport("Everything32.dll")]
        public static extern void Everything_Reset();
        #endregion
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
