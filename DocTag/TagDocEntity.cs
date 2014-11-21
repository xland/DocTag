using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocTag
{
    public class TagDocEntity
    {
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
        public string DocPath
        {
            get;
            set;
        }
        public string DocName
        {
            get;
            set;
        }
        /// <summary>
        /// 0:文件
        /// 1:文件夹
        /// </summary>
        public int DocType
        {
            get;
            set;
        }
        /// <summary>
        /// 同步时间
        /// </summary>
        public int SyncTime
        {
            get;
            set;
        }
    }


}
