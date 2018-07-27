using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class CustomerUser 
    {
        
        public string openid { get; set; }
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
        [Display(Name = "语言")]
        public string language { get; set; }
        [Display(Name = "国家")]
        public string country { get; set; }
        [Display(Name = "手机号")]
        public string FensiTelephone { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "是否启用")]
        public bool FensiStatus { get; set; }
   
    }
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
        [Display(Name = "语言")]
        public string language { get; set; }
        [Display(Name = "国家")]
        public string country { get; set; }
        [Display(Name = "手机号")]
        public string FensiTelephone { get; set; }
        [Display(Name = "密码")]
        public string FensiPassword { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "是否启用")]
        public bool FensiStatus { get; set; }
    }

    public class CeshiFensiUser : CustomerUser
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "邀请人")]
        public int SharePerson { get; set; }
        [Display(Name = "密码")]
        public string Password { get; set; }
        
    }
}
