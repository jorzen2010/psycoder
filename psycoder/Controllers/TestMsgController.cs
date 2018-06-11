using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunMsg;

namespace psycoder.Controllers
{
    public class TestMsgController : Controller
    {
        //
        // GET: /TestMsg/
        public ActionResult Index()
        {
            AliyunSendMsgModel msg = new AliyunSendMsgModel();
            msg.PhoneNumbers = "17645134197";
            msg.SignName = "心理咨询师平台";
            msg.TemplateCode = "SMS_134245287";
            //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
            msg.TemplateParam = "{\"code\":\"123\"}";
            msg.OutId = "10001";
            SendSmsResponse res=AliyunMsg.AliyunMsg.sendSms(msg);

            return Content(res.Message);
        }
	}
}