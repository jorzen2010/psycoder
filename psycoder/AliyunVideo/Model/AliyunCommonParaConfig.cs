using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AliyunVideo
{
    public class AliyunCommonParaConfig
    {

        public const string ApiUrl = "vod.cn-shanghai.aliyuncs.com";
        public const string Format = "JSON";
        public const string Version = "2017-03-21";
        public const string AccessKeyId = "这里应该写ID，建议写道数据库里";
        public const string AccessKeySecret = "这里应该写密钥，建议写道数据库里";
      
        public const string SignatureVersion = "1.0";

        public const string SignatureMethod = "HMAC-SHA1";


    }
}


