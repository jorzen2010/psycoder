using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class CeshiResult
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "粉丝")]
        public int ceshiUser { get; set; }
        [Display(Name = "结果")]
        public string result { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
