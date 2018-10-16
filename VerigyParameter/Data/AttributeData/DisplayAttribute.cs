using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VerifyParameter.Interface;

namespace VerifyParameter.Data.AttributeData
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public partial class DisplayAttribute : Attribute, IVerifyAttribute
    {
        public DisplayAttribute()
        {
        }

        public DisplayAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
