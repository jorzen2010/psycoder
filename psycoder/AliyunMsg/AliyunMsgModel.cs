using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AliyunMsg
{
    public class AliyunSendMsgModel
    {
        public string PhoneNumbers { get; set; }
        public string SignName { get; set; }
        public string TemplateCode { get; set; }
        public string TemplateParam { get; set; }
        public string OutId { get; set; }
    }
}