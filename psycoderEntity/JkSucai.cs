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
        [Required(ErrorMessage="请输入标题")]
        public string Title { get; set; }
        [Display(Name = "封面")]
        public string Cover { get; set; }
        [Display(Name = "摘要")]
        public string Info { get; set; }
        [Display(Name = "标签")]
        public string Tags { get; set; }
        [Display(Name = "分类")]
        public string Category { get; set; }
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
        [Display(Name = "内容")]
        public string Content { get; set; }
        [Display(Name = "类型")]
        public string type { get; set; }
    }
}
