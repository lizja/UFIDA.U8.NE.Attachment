using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.NE.Attachment
{
    class UAPEntity
    {
        private List<string> fieldNames=new List<string>();
        /// <summary>
        /// 附件类型的字段集合
        /// </summary>
        public List<string> FieldNames
        {
            get
            {
                return fieldNames;
            }
        }

        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }

        public string PKName
        {
            get;
            set;
        }

        public string FKName
        {
            get;
            set;
        }

        public bool IsMainTable
        {
            get;
            set;
        }

        /// <summary>
        /// 增加附件类型的字段。
        /// </summary>
        /// <param name="fieldName"></param>
        public void AddFiledName(string fieldName)
        {
            fieldNames.Add(fieldName);
        }

    }
}
