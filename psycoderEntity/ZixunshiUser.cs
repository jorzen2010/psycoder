using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class ZixunshiUser
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "用户名")]
        public string PsyUserEmail { get; set; }
        [Display(Name = "头像")]
        public string PsyAvatar { get; set; }
        [Display(Name = "密码")]
        public string PsyPassword { get; set; }
        [Display(Name = "真实姓名")]
        public string PsyRealName { get; set; }
        [Display(Name = "身份证号")]
        public string PsyNumber { get; set; }
        [Display(Name = "证书编号")]
        public string PsyZhengshuNumber { get; set; }
        [Display(Name = "手机号码")]
        public string PsyTelephone { get; set; }
        [Display(Name = "QQ号码")]
        public string PsyQQ { get; set; }
        [Display(Name = "微信号码")]
        public string PsyWechat { get; set; }
        [Display(Name = "联系邮箱")]
        public string PsyEmail { get; set; }
        [Display(Name = "昵称")]
        public string PsyNickName { get; set; }
        [Display(Name = "小程序名称")]
        public string PsyTitle { get; set; }
        [Display(Name = "一句话介绍")]
        public string PsyInfo { get; set; }
        [Display(Name = "自我介绍")]
        public string PsyContent { get; set; }
        [Display(Name = "擅长领域")]
        public string PsyShanchang { get; set; }
        [Display(Name = "是否启用")]
        public bool PsyStatus { get; set; }
        [Display(Name = "注册时间")]
        public DateTime CreateTime { get; set; }
    }
}
