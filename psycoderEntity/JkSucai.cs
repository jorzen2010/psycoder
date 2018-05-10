using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class JkSucai
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "标题")]
        public string Title { get; set; }
        [Display(Name = "封面")]
        public string Cover { get; set; }
        [Display(Name = "摘要")]
        public string Info { get; set; }
         [Display(Name = "标签")]
        public string Tags { get; set; }
        [Display(Name = "作者")]
        public string Author { get; set; }
        [Display(Name = "提供者")]
        public int Provider { get; set; }
        [Display(Name = "权限")]
        public bool Qanxian { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "是否删除")]
        public bool IfDelete { get; set; }
        [Display(Name = "价格")]
        public float Price { get; set; }
        [Display(Name = "提成")]
        public int Ticheng { get; set; }
    }

    public class SucaiAnli:JkSucai
    {
        
        [Display(Name = "内容")]
        public string Content { get; set; }

    }

    public class SucaiTupian : JkSucai
    {

        [Display(Name = "图片地址")]
        public string ImageSrc { get; set; }

    }

    public class SucaiAudio : JkSucai
    {

        [Display(Name = "阿里云音频Id")]
        public string AudioId { get; set; }

    }
    public class SucaiVideo : JkSucai
    {

        [Display(Name = "阿里云视频Id")]
        public string VideoId { get; set; }
    }
}
