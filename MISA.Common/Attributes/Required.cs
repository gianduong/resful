using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Attributes
{   
    [AttributeUsage(AttributeTargets.Property)]
    public class Required:Attribute
    {
        public String msgError = String.Empty;
        public Required(String msg)
        {
            msgError = msg;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        public int MaxLength = 0;
        public String msgError = String.Empty;
        public MISAMaxLength(String msg = "",int MaxLength = 0)
        {
            this.MaxLength = MaxLength;
            msgError = msg;
        }
    }
}
