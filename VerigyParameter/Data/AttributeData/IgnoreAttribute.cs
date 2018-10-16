using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VerifyParameter.Interface;

namespace VerifyParameter.Data.AttributeData
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public partial class IgnoreAttribute : Attribute, IVerifyAttribute
    {
        public bool IgnoreAll { get; set; }

        public bool IgnoreInsert { get; set; }

        public bool IgnoreUpdate { get; set; }
    }
}
