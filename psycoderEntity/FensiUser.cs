using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class FensiUser
    {
        [Key]
        public int Id { get; set; }
        public string openid { get; set; }
        [Display(Name = "咨询师Id")]
        public int Zixunshi { get; set; }
        [Display(Name = "昵称")]
        public string nickName { get; set; }
        [Display(Name = "性别")]
        public int gender { get; set; }
        [Display(Name = "头像")]
        public string avatarUrl { get; set; }
        [Display(Name = "省份")]
        public string province { get; set; }
        [Display(Name = "城市")]
        public string city { get; set; }
        [Display(Name = "手机号")]
        public string FensiTelephone { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "是否启用")]
        public bool FensiStatus { get; set; }
    }
}
