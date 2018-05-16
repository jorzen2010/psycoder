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
        [Display(Name = "咨询师Id")]
        public int PsyUserId { get; set; }
        [Display(Name = "昵称")]
        public string FensiWechatName { get; set; }
        [Display(Name = "手机号")]
        public string FensiTelephone { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "是否启用")]
        public bool FensiStatus { get; set; }
    }
}
