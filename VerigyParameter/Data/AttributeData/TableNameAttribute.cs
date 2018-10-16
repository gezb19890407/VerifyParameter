using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VerifyParameter.Interface;

namespace VerifyParameter.Data.AttributeData
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public partial class TableNameAttribute : Attribute, IVerifyAttribute
    {
        public string TableName { get; set; }

        public string TableFullName { get; set; }

        public string DataBase { get; set; }
    }
}
