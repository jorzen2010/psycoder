using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class DefaultHudongSetting
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "自由书写前设置")]
        public string ZiyoushuxiePre { get; set; }
        [Display(Name = "自由书写后设置")]
        public string ZiyoushuxiePost { get; set; }
        [Display(Name = "问题引导前设置")]
        public string QuestionPre { get; set; }
        [Display(Name = "问题引导后设置")]
        public string QuestionPost { get; set; }
        [Display(Name = "问题引导选择")]
        public string QuestionSelected { get; set; }
        [Display(Name = "用户咨询前设置")]
        public string ZixunPre { get; set; }
        [Display(Name = "用户咨询后设置")]
        public string ZixunPost { get; set; }

    }
    public class DefaultGuanggaoSetting
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "广告名称")]
        [Required(ErrorMessage = "请输入标题")]
        public string GuanggaoTitle { get; set; }
        [Display(Name = "广告内容")]
        public string GuanggaoContent { get; set; }
        [Display(Name = "广告图片地址")]
        public string GuanggaoImgSrc { get; set; }
        [Display(Name = "广告类型")]
        public string GuanggaoType { get; set; }
        [Display(Name = "广告状态")]
        public bool GuanggaoStatus { get; set; }
    }
    public class HudongSetting
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "用户")]
        public int PsyUserId { get; set; }
        [Display(Name = "自由书写前设置")]
        public string ZiyoushuxiePre { get; set; }
        [Display(Name = "自由书写后设置")]
        public string ZiyoushuxiePost { get; set; }
        [Display(Name = "问题引导前设置")]
        public string QuestionPre { get; set; }
        [Display(Name = "问题引导后设置")]
        public string QuestionPost { get; set; }
        [Display(Name = "问题引导选择")]
        public string QuestionSelected { get; set; }
        [Display(Name = "用户咨询前设置")]
        public string ZixunPre { get; set; }
        [Display(Name = "用户咨询后设置")]
        public string ZixunPost { get; set; }

    }
    public class GuanggaoSetting
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "用户")]
        public int PsyUserId { get; set; }
        [Display(Name = "广告名称")]
        public string GuanggaoTitle { get; set; }
        [Display(Name = "广告内容")]
        public string GuanggaoContent { get; set; }
        [Display(Name = "广告图片地址")]
        public string GuanggaoImgSrc { get; set; }
        [Display(Name = "广告类型")]
        public string GuanggaoType { get; set; }
        [Display(Name = "广告状态")]
        public bool GuanggaoStatus { get; set; }
    }
   

    public class ZiyoushuxieReply
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "咨询师用户")]
        public int PsyUserId { get; set; }
        [Display(Name = "来访者用户")]
        public int UserId { get; set; }
        [Display(Name = "书写内容")]
        public string ReplyContent { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
 
    }
    public class QuestionReply
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "咨询师用户")]
        public int PsyUserId { get; set; }
        [Display(Name = "来访者用户")]
        public int UserId { get; set; }
        [Display(Name = "问题Id")]
        public int QuestionId { get; set; }
        [Display(Name = "书写内容")]
        public string ReplyContent { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

    }

    public class ZixunReply
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "咨询师用户")]
        public int PsyUserId { get; set; }
        [Display(Name = "来访者用户")]
        public int UserId { get; set; }
        [Display(Name = "书写内容")]
        public string ReplyContent { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

    }

    
    
}
