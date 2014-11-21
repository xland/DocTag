using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace DocTag.Entity
{
    public class Tag
    {
        private List<Doc> docs;
        public int RowId
        {
            get;
            set;
        }
        public string TagVal
        {
            get;
            set;
        }
        public int ReferCount
        {
            get;
            set;
        }
        public int HasSync
        {
            get;
            set;
        }
        public List<Doc> Docs
        { 
            get
            {
                return docs;
            }
        }
        public Tag()
        {
            docs = new List<Doc>();
        }
        public void GetDocByTag(string Path)
        {

        }
    }
}
