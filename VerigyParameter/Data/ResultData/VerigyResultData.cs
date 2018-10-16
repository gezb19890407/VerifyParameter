using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VerifyParameter.Data.ResultData
{
    public partial class VerigyResultData
    {
        public bool Status { get; set; }

        private List<AttributeData> _InfoList;

        public List<AttributeData> InfoList
        {
            get
            {
                if (_InfoList == null)
                {
                    _InfoList = new List<AttributeData>();
                }
                return _InfoList;
            }
            set
            {
                _InfoList = value;
            }
        }

        public string InfoString { get; set; }
    }
}
