using ParameterVerify.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using VerifyParameter.Data.ResultData;
using VerifyParameter.VerifyManage;

namespace ParameterVerify
{
    public partial class VerifyDemo : Form
    {
        public VerifyDemo()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            VerifyParameterManage.EventVerifyParameter += VerifyParameterManage_EventVerifyParameter;
            VerifyParameterManage.EventVerifyParameter += VerifyParameterManage_EventVerifyParameter1;
            VerifyParameterManage.EventVerifyParameter += VerifyParameterManage_EventVerifyParameter2;
            Book b = new Book()
            {
                Name = "测试文档",
                Price = (decimal)18.52
            };
            try
            {
                var result = VerifyParameterManage.Verigy(b, true);
            }
            catch (Exception ex)
            {
            }
        }

        private void VerifyParameterManage_EventVerifyParameter2(PropertyInfo propertity, object value, AttributeData attributeBaseData, List<AttributeData> attributeDataList)
        {
            attributeDataList.Add(new AttributeData()
            {
                AttributeCode = "Name",
                AttributeName = "书名",
                ErrorList = new List<string>() { "测试3" }
            });
        }

        private void VerifyParameterManage_EventVerifyParameter1(PropertyInfo propertity, object value, AttributeData attributeBaseData, List<AttributeData> attributeDataList)
        {
            attributeDataList.Add(new AttributeData()
            {
                AttributeCode = "Name",
                AttributeName = "书名",
                ErrorList = new List<string>() { "测试2" }
            });
        }

        private void VerifyParameterManage_EventVerifyParameter(PropertyInfo propertity, object value, AttributeData attributeBaseData, List<AttributeData> attributeDataList)
        {
            attributeDataList.Add(new AttributeData()
            {
                AttributeCode = "Name",
                AttributeName = "书名",
                ErrorList = new List<string>() { "测试1" }
            });
        }
    }
}
