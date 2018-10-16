using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VerifyParameter.Data.ResultData
{
    public class AttributeData
    {
        public string AttributeCode { get; set; }

        public string AttributeName { get; set; }

        public bool Status { get; set; }

        private List<string> _ErrorList;
        public List<string> ErrorList
        {
            get
            {
                if (_ErrorList == null)
                {
                    _ErrorList = new List<string>();
                }
                return _ErrorList;
            }
            set
            {
                _ErrorList = value;
            }
        }
    }
}
