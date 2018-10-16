using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VerifyParameter.Interface;

namespace VerifyParameter.Data.AttributeData
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public partial class StringAttribute : ObjectAttribute
    {


        public bool IsEmptyOrNull { get; set; }

        public bool IsEqualDefault { get; set; }

        public string DefaultValue { get; set; }
    }
}
