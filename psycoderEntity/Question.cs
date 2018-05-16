using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "问题内容")]
        [Required(ErrorMessage="请输入问题")]
        public string QuestionTitle { get; set; }
        [Display(Name = "问题标签")]
        public string QuestionTags { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "状态")]
        public bool QuestionStatus { get; set; }

    }
}
