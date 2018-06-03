using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
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
