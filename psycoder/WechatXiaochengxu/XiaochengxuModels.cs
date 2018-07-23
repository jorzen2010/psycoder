using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace psycoder.WechatXiaochengxu
{
    public class WechatError
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }


    public class XCXUserInfo
    {
        public string avatarUrl { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int gender { get; set; }
        public string language { get; set; }
        public string nickName { get; set; }
        public string province { get; set; }
    }
}