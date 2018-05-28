using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Common;

namespace psycoder.WechatXiaochengxu
{
    public class XiaochengxuAPI
    {
        public static string GetOpenidByWxlogin(string appid, string secret, string js_code,string grant_type)
        {
            string userAgent = System.Web.HttpContext.Current.Request.UserAgent;
            string url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}", appid, secret, js_code, grant_type);

            HttpWebResponse res = HttpWebResponseUtility.CreateGetHttpResponse(url, null, userAgent, null);
            Stream stream = res.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string result = sr.ReadToEnd();
            return result;

        }
    }
}