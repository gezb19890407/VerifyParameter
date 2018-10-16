using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VerifyParameter.Interface;

namespace VerifyParameter.Data.AttributeData
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public partial class PrimaryKeyAttribute : Attribute, IVerifyAttribute
    {
        public bool IsPrimaryKey
        {
            get;
            set;
        }
    }
}
