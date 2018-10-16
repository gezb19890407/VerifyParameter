using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VerifyParameter.Interface;

namespace VerifyParameter.Data.AttributeData
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ObjectAttribute : Attribute, IVerifyAttribute
    {
        public ObjectAttribute()
        {

        }

        public int MaxLength { get; set; }

        public string MaxLengthError { get; set; }

        public int MinLength { get; set; }

        public string MinLengthError { get; set; }

        public void Range(int minLength, int maxLength)
        {
            MaxLength = minLength;
            MinLength = maxLength;
        }

        public bool IsNotNull { get; set; }

        public string IsNotNullError { get; set; }
    }
}
