using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VerifyParameter.Interface;
using VerifyParameter.Utils.Attribute;

namespace VerifyParameter.Data.AttributeData
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RegularExpressionAttribute : Attribute, IVerifyAttribute
    {
        public RegularExpressionAttribute(string regularExpression, string regularExpressionError = null)
        {
            RegularExpression = regularExpression;
            RegularExpressionError = regularExpressionError;

            FieldInfo fieldInfo = typeof(RegexCommonData).GetField(regularExpression);
            if (fieldInfo == null)
            {
                return;
            }
            object value = fieldInfo.GetValue(null);
            if (value == null)
            {
                return;
            }
            RegularExpression = value.ToString();             
            string displayName = AttributeManage.GetDisplayName(fieldInfo);
            if (string.IsNullOrEmpty(RegularExpressionError))
            {
                RegularExpressionError = displayName + "格式错误";
            }
        }

        public RegularExpressionAttribute(EnumRegexCommonData regularExpression, string regularExpressionError = null) :
            this(regularExpression.ToString(), regularExpressionError)
        {

        }

        public string RegularExpression { get; set; }

        public string RegularExpressionError { get; set; }
    }

    public enum EnumRegexCommonData
    {
        /// <summary>
        /// 验证QQ
        /// </summary> 
        RegxQQ,
        /// <summary>
        /// 验证邮箱
        /// </summary>
        RegxEml,
        /// <summary>
        /// 验证url(http://)
        /// </summary>
        RegxUrl,
        /// <summary>
        /// 验证邮编
        /// </summary> 
        RegxZipCode,
        /// <summary>
        /// 验证身份证号码
        /// </summary>
        RegxIdCode,
        /// <summary>
        /// 验证密码(字母开头，允许5-16字节，允许字母数字下划线)
        /// </summary>
        RegxPwd,
        /// <summary>
        /// 匹配中文
        /// </summary>
        RegxCN,
        /// <summary>
        /// 验证国内电话号码（匹配形式如 0511-4405222 或 0211-87888822 ）
        /// </summary>
        RegxTel,
        /// <summary>
        /// 验证手机号码
        /// </summary>
        RegxPhone,
        /// <summary>
        /// 验证价格
        /// </summary>
        RegxPrice,
        /// <summary>
        /// 匹配正浮点数
        /// </summary>
        RegxPfNum,
        /// <summary>
        /// 匹配非正浮点数
        /// </summary>
        RegxNfNum,
        /// <summary>
        /// 匹配负浮点数
        /// </summary>
        RegxFNum,
        /// <summary>
        /// 匹配正整数
        /// </summary>
        RegxNum
    }

    public class RegexCommonData
    {
        /// <summary>
        /// 验证QQ
        /// </summary>
        [DisplayAttribute("QQ")]
        public const string RegxQQ = "^[1-9][0-9]{4,}$";

        /// <summary>
        /// 验证邮箱
        /// </summary>
        [DisplayAttribute("邮箱")]
        public const string RegxEml = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        /// <summary>
        /// 验证url(http://)
        /// </summary>
        [DisplayAttribute("url")]
        public const string RegxUrl = @"^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$";

        /// <summary>
        /// 验证邮编
        /// </summary>
        [DisplayAttribute("邮编")]
        public const string RegxZipCode = @"^\d{6}$";

        /// <summary>
        /// 验证身份证号码
        /// </summary>
        [DisplayAttribute("身份证号码")]
        public const string RegxIdCode = @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";

        /// <summary>
        /// 验证密码(字母开头，允许5-16字节，允许字母数字下划线)
        /// </summary>
        [DisplayAttribute("密码(字母开头，允许5-16字节，允许字母数字下划线)")]
        public const string RegxPwd = @"^[a-zA-Z][a-zA-Z0-9_]{4,15}$";

        /// <summary>
        /// 匹配中文
        /// </summary>
        [DisplayAttribute("中文")]
        public const string RegxCN = @"^[\u4e00-\u9fa5]+$";

        /// <summary>
        /// 验证国内电话号码（匹配形式如 0511-4405222 或 0211-87888822 ）
        /// </summary>
        [DisplayAttribute("国内电话号码（匹配形式如 0511-4405222 或 0211-87888822 ）")]
        public const string RegxTel = @"^(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}$";

        /// <summary>
        /// 验证手机号码
        /// </summary>
        [DisplayAttribute("手机号码")]
        public const string RegxPhone = @"^((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)$";

        /// <summary>
        /// 验证价格
        /// </summary>
        [DisplayAttribute("价格")]
        public const string RegxPrice = @"^(d*.d{0,2}|d+).*$";

        /// <summary>
        /// 匹配正浮点数
        /// </summary>
        [DisplayAttribute("正数")]
        public const string RegxPfNum = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";

        /// <summary>
        /// 匹配非正浮点数
        /// </summary>
        [DisplayAttribute("非正数")]
        public const string RegxNfNum = @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$";

        /// <summary>
        /// 匹配负浮点数
        /// </summary>
        [DisplayAttribute("负数")]
        public const string RegxFNum = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";

        /// <summary>
        /// 匹配正整数
        /// </summary>
        [DisplayAttribute("正整数")]
        public const string RegxNum = @"^[1-9]\d*$";
    }
}
