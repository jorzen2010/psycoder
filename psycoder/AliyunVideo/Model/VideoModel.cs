using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AliyunVideo
{
    //以下两个是为了使用playauth的模型
    public class VideoInfo
    {
        public string RequestId { get; set; }
        public VideoMeta VideoMeta { get; set; }
        public string PlayAuth { get; set; }
        
    }
    public class VideoMeta
    {
        public string RequestId { get; set; }
        public string Status { get; set; }
        public string VideoId { get; set; }
        public string Duration { get; set; }
        public string Title { get; set; }

    
    }
    //以下是为了使用videourl的模型
    public class VideoUrlInfo
    {
        public string RequestId { get; set; }
        public VideoBase VideoBase { get; set; }
        public PlayInfoList PlayInfoList { get; set; }
    }
    public class PlayInfoList 
    {
        public List<PlayInfo> PlayInfo { get; set; }
    }
    public class VideoBase
    {
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
         public string CoverURL { get; set; }
         public string Status { get; set; }
         public string MediaType { get; set; }
         public string CreationTime { get; set; }
    }
     public class PlayInfo
    {
        public string Bitrate { get; set; }
        public string Definition { get; set; }
        public string Duration { get; set; }
         public string Encrypt { get; set; }
         public string PlayURL { get; set; }
         public string Format { get; set; }
         public string StreamType { get; set; }
         public string Fps { get; set; }
         public string Height { get; set; }
         public string Size { get; set; }
         public string Width { get; set; }
         public string JobId { get; set; }
    }

   
     //获取时长： @Math.Floor(Math.Ceiling(float.Parse(videoUrlfo.VideoBase.Duration)) / 60) 分 @(Math.Ceiling(float.Parse(videoUrlfo.VideoBase.Duration)) % 60) 秒

}