using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class XCxSucai
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Display(Name = "封面")]
        public string Cover { get; set; }
        [Display(Name = "摘要")]
        public string Info { get; set; }
        [Display(Name = "作者")]
        public string Author { get; set; }
        [Display(Name = "权限")]
        public string Qanxian { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "是否删除")]
        public bool IfDelete { get; set; }
    }

    public class TuWenSucai:XCxSucai
    {
        
        [Display(Name = "内容")]
        public string Content { get; set; }
    }
    public class AudioCourse : XCxSucai
    {

        [Display(Name = "阿里云Id")]
        public string AudioId { get; set; }
    }
    public class VideoCourse : XCxSucai
    {

        [Display(Name = "阿里云Id")]
        public string VideoId { get; set; }
    }
}
