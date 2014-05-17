using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFIDA.U8.NE.Attachment
{
    class VoucherInfo
    {
        public string CardNumber
        {
            get;
            set;
        }

        public string HeadTable
        {
            get;
            set;
        }

        public string BodyTable
        {
            get;
            set;
        }

        public string HeadPKField
        {
            get;
            set;
        }

        public string BodyFKField
        {
            get;
            set;
        }

        public string BodyPKField
        {
            get;
            set;
        }
    }
}
