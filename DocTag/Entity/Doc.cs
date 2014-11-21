using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace DocTag.Entity
{
    public class Doc
    {
        private List<Tag> tags;
        public string DocName
        {
            get;
            set;
        }
        public string DocPath
        {
            get;
            set;
        }
        /// <summary>
        /// 0：文件
        /// 1：目录
        /// </summary>
        public int DocType
        {
            get;
            set;
        }
        public int HasSync
        {
            get;
            set;
        }
        public List<Tag> Tags
        {
            get
            {
                return tags;
            }
        }
        public Doc()
        {
            tags = new List<Tag>();
        }
        public void GetTagByDoc(string Path)
        {

        }
    }
}
