using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using VerifyParameter.Data.AttributeData;
using VerifyParameter.Data.ResultData;
using VerifyParameter.Interface;
using VerifyParameter.Utils.Attribute;

namespace VerifyParameter.VerifyManage
{
    public class VerifyParameterManage
    {
        public static VerigyResultData Verigy<T>(T entity, bool isReturnMessage)
        {
            StringBuilder sb = new StringBuilder();
            VerigyResultData result = Verigy(entity);
            if (!result.Status && isReturnMessage)
            {
                foreach (var errorInfo in result.InfoList)
                {
                    sb.AppendFormat(@"{1}{2}！",
                        errorInfo.AttributeCode,
                        errorInfo.AttributeName,
                        errorInfo.ErrorList.Aggregate((a, b) => a + "，" + b));
                }
                result.InfoString = sb.ToString();
            }
            return result;
        }

        public static VerigyResultData Verigy<T>(T entity)
        {
            Type t = entity.GetType();
            var properties = t.GetProperties();
            string columnMappingName;
            VerigyResultData result = new VerigyResultData();
            List<AttributeData> attributeDataList = new List<AttributeData>();
            AttributeData attributeData;
            object value;
            foreach (var propertity in properties)
            {
                value = propertity.GetValue(entity, null);
                if (value == null)
                {

                }
                columnMappingName = propertity.Name;
                var displayAttributes = propertity.GetCustomAttributes(typeof(DisplayAttribute), false);
                if (displayAttributes.GetLength(0) > 0)
                {
                    columnMappingName = ((DisplayAttribute)displayAttributes[0]).Name;
                }
                attributeData = new AttributeData();
                attributeData.AttributeCode = propertity.Name;
                attributeData.AttributeName = columnMappingName;

                //验证基础属性
                VerigyObjectAttribute(propertity, value, attributeData, attributeDataList);

                //验证正则表达式
                VerigyRegularExpressionAttribute(propertity, value, attributeData, attributeDataList);

                //验证其它属性
                VerigyAttributeQueue(propertity, value, attributeData, attributeDataList);

            }
            if (attributeDataList.Count > 0)
            {
                attributeDataList = attributeDataList.GroupBy(p => new { p.AttributeCode, p.AttributeName })
                    .Select(p => new AttributeData()
                    {
                        AttributeCode = p.Key.AttributeCode,
                        AttributeName = p.Key.AttributeName,
                        ErrorList = p.SelectMany(q => q.ErrorList).ToList()
                    }).ToList();
                result.InfoList.AddRange(attributeDataList);
            }
            if (result.InfoList.Count == 0)
            {
                result.Status = true;
            }
            return result;
        }

        private static void VerigyObjectAttribute(PropertyInfo propertity, object value, AttributeData attributeBaseData, List<AttributeData> attributeDataList)
        {
            AttributeData attributeData;
            int valueLength;
            var objectAttributes = propertity.GetCustomAttributes(typeof(ObjectAttribute), false);
            if (objectAttributes.GetLength(0) > 0)
            {
                attributeData = new AttributeData();
                attributeData.AttributeCode = attributeBaseData.AttributeCode;
                attributeData.AttributeName = attributeBaseData.AttributeName;

                foreach (ObjectAttribute objectAttribute in objectAttributes)
                {
                    if (objectAttribute.IsNotNull && value == null)
                    {
                        attributeData.ErrorList.Add("不能为空值");
                        break;
                    }
                    valueLength = System.Text.Encoding.Default.GetBytes(value.ToString()).Length;
                    if (objectAttribute.MinLength > 0 && valueLength < objectAttribute.MinLength)
                    {
                        objectAttribute.MinLengthError = objectAttribute.MinLengthError ?? "最小长度必须大于" + objectAttribute.MinLength;
                        attributeData.ErrorList.Add(objectAttribute.MinLengthError);
                    }
                    if (objectAttribute.MaxLength > 0 && valueLength > objectAttribute.MaxLength)
                    {
                        objectAttribute.MaxLengthError = objectAttribute.MaxLengthError ?? "最大长度必须小于" + objectAttribute.MaxLength;
                        attributeData.ErrorList.Add(objectAttribute.MaxLengthError);
                    }
                }
                if (attributeData.ErrorList.Count > 0)
                {
                    attributeDataList.Add(attributeData);
                }
            }
        }

        private static void VerigyRegularExpressionAttribute(PropertyInfo propertity, object value, AttributeData attributeBaseData, List<AttributeData> attributeDataList)
        {
            if (value == null)
            {
                return;
            }
            AttributeData attributeData;
            var attributeRegexs = propertity.GetCustomAttributes(typeof(RegularExpressionAttribute), false);
            if (attributeRegexs.GetLength(0) > 0)
            {
                attributeData = new AttributeData();
                attributeData.AttributeCode = attributeBaseData.AttributeCode;
                attributeData.AttributeName = attributeBaseData.AttributeName;

                foreach (RegularExpressionAttribute attributeRegex in attributeRegexs)
                {
                    if (!Regex.IsMatch(value.ToString(), attributeRegex.RegularExpression))
                    {
                        attributeData.ErrorList.Add(attributeRegex.RegularExpressionError);
                    }
                }
                if (attributeData.ErrorList.Count > 0)
                {
                    attributeDataList.Add(attributeData);
                }
            }
        }

        public static void VerigyAttributeQueue(PropertyInfo propertity, object value, AttributeData attributeBaseData, List<AttributeData> attributeDataList)
        {
            VerifyParameterManage.EventVerifyParameter(propertity, value, attributeBaseData, attributeDataList);
        }

        public delegate void InvokeVerigyAttribut(PropertyInfo propertity, object value, AttributeData attributeBaseData, List<AttributeData> attributeDataList);

        public static event InvokeVerigyAttribut EventVerifyParameter;
    }
}
