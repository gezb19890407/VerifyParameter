using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VerifyParameter.Data.AttributeData;

namespace VerifyParameter.Utils.Attribute
{
    public class AttributeManage
    {
        public static string GetDisplayName(PropertyInfo propertyInfo)
        {
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.GetLength(0) > 0)
            {
                return ((DisplayAttribute)attributes[0]).Name;
            }
            return string.Empty;
        }

        public static string GetDisplayName(FieldInfo fieldInfo)
        {
            object[] attributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.GetLength(0) > 0)
            {
                return ((DisplayAttribute)attributes[0]).Name;
            }
            return string.Empty;
        }

        public static string GetDisplayName<T>(T entity, string propertyName)
        {
            var propertyInfo = entity.GetType().GetProperty(propertyName);
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.GetLength(0) > 0)
            {
                return ((DisplayAttribute)attributes[0]).Name;
            }
            return string.Empty;
        }
    }
}
