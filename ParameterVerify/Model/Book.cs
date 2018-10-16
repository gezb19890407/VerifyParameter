using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VerifyParameter.Data.AttributeData;

namespace ParameterVerify.Model
{
    public class Book
    {
        [DisplayAttribute("书名")]
        [RegularExpressionAttribute(EnumRegexCommonData.RegxCN)]
        [ObjectAttribute(IsNotNull = true, MaxLength = 20, MinLength = 10)]
        public string Name { get; set; }


        [ObjectAttribute(IsNotNull = true)]
        public decimal Price { get; set; }


    }
}
