using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace psycoderEntity
{
    public class JksucaiChakanTongji
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "appId")]
        public string App { get; set; }
        [Display(Name = "用户")]
        public int fensiuser { get; set; }
        [Display(Name = "素材")]
        public int sucai { get; set; }
        [Display(Name = "查看")]
        public bool chakan { get; set; }
        [Display(Name = "查看时间")]
        public DateTime chakantime { get; set; }
        [Display(Name = "取消时间")]
        public DateTime canceltime { get; set; }
       
    }

    public class JksucaiXihuanTongji
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "appId")]
        public string App { get; set; }
        [Display(Name = "用户")]
        public int fensiuser { get; set; }
        [Display(Name = "素材")]
        public int sucai { get; set; }

        [Display(Name = "喜欢")]
        public int xihuan { get; set; }
    
        [Display(Name = "喜欢时间")]
        public DateTime xihuantime { get; set; }

        [Display(Name = "取消时间")]
        public DateTime canceltime { get; set; }

    }

    public class JksucaiShoucangTongji
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "appId")]
        public string App { get; set; }
        [Display(Name = "用户")]
        public int fensiuser { get; set; }
        [Display(Name = "素材")]
        public int sucai { get; set; }

        [Display(Name = "收藏")]
        public bool shoucang { get; set; }
    
        [Display(Name = "收藏时间")]
        public DateTime shoucangtime { get; set; }
        [Display(Name = "取消时间")]
        public DateTime canceltime { get; set; }
    }

    public class JksucaiXiazaiTongji
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "appId")]
        public string App { get; set; }
        [Display(Name = "用户")]
        public int fensiuser { get; set; }
        [Display(Name = "素材")]
        public int sucai { get; set; }

        [Display(Name = "下载")]
        public bool xiazai { get; set; }
     
        [Display(Name = "下载时间")]
        public DateTime xiazaitime { get; set; }
        [Display(Name = "取消时间")]
        public DateTime canceltime { get; set; }
    }



}
