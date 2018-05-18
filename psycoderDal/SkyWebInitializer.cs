using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using psycoderEntity;
using Common;

namespace psycoderDal
{
    public class SkyWebInitializer : DropCreateDatabaseIfModelChanges<SkyWebContext>
    {
        protected override void Seed(SkyWebContext context)
        {
            base.Seed(context);

            #region 初始化配置

            var protocol = new System.Text.StringBuilder(942);
            protocol.AppendLine(@"<p> 当您申请用户时，表示您已经同意遵守本规章。");
            protocol.AppendLine(@"    欢迎您加入本站点参加交流和讨论，本站点为公共论坛，为维护网上公共秩序和社会稳定，请您自觉遵守以下条款：</p>");
            protocol.AppendLine(@"   <ul> ");
            protocol.AppendLine(@"       <li>一、不得利用本站危害国家安全、泄露国家秘密，不得侵犯国家社会集体的和公民的合法权益，不得利用本站制作、复制和传播下列信息：");
            protocol.AppendLine(@"           <ol>");
            protocol.AppendLine(@"               <li>（一）煽动抗拒、破坏宪法和法律、行政法规实施的；</li>");
            protocol.AppendLine(@"               <li>（二）煽动颠覆国家政权，推翻社会主义制度的；</li>");
            protocol.AppendLine(@"               <li>（三）煽动分裂国家、破坏国家统一的；</li>");
            protocol.AppendLine(@"               <li>（四）煽动民族仇恨、民族歧视，破坏民族团结的；</li>");
            protocol.AppendLine(@"               <li>（五）捏造或者歪曲事实，散布谣言，扰乱社会秩序的；</li>");
            protocol.AppendLine(@"               <li>（六）宣扬封建迷信、淫秽、色情、赌博、暴力、凶杀、恐怖、教唆犯罪的；</li>");
            protocol.AppendLine(@"               <li>（七）公然侮辱他人或者捏造事实诽谤他人的，或者进行其他恶意攻击的；</li>");
            protocol.AppendLine(@"               <li>（八）损害国家机关信誉的；</li>");
            protocol.AppendLine(@"               <li>（九）其他违反宪法和法律行政法规的；</li>");
            protocol.AppendLine(@"               <li>（十）进行商业广告行为的。</li>");
            protocol.AppendLine(@"           </ol>");
            protocol.AppendLine(@"       </li>");
            protocol.AppendLine(@"    <li>二、互相尊重，对自己的言论和行为负责。</li>");
            protocol.AppendLine(@"    <li>三、禁止在申请用户时使用相关本站的词汇，或是带有侮辱、毁谤、造谣类的或是有其含义的各种语言进行注册用户，否则我们会将其删除。</li>");
            protocol.AppendLine(@"    <li>四、禁止以任何方式对本站进行各种破坏行为。</li>");
            protocol.AppendLine(@"   <li> 五、如果您有违反国家相关法律法规的行为，本站概不负责，您的登录论坛信息均被记录无疑，必要时，我们会向相关的国家管理部门提供此类信息。</li>");
            protocol.AppendLine(@"   </ul>");

            var copyright = new System.Text.StringBuilder(143);
            copyright.AppendLine(@"Copyright©2008-2011 赵征 Co.,Ltd, All Rights Reserved  版权所有");
            copyright.AppendLine(@"增值电信业务经营许可证京-2-4-20090003 广播电视节目制作经营许可证 文网文 [2009]011号");

            context.Settings.Add(new Setting
            {
                SiteName = "心理咨询师公众平台",
                DomainName = "http://mp.psyweixin.zzd123.com",
                Logo = "Upload/Site/logo.jpg",
                Protocol = protocol.ToString(),
                Title = "心理咨询师公众平台",
                Keywords = "心理咨询师公众平台",
                Description = "心理咨询师公众平台",
                Copyright = copyright.ToString(),
                Statistics = string.Empty,

                FileUploadUrl = "~/File/Upload/",
                ImgUploadUrl = "~/File/Upload/",
                EditorUploadUrl = "~/File/Upload/",
                AvatarUploadUrl = "~/File/Upload/",
                BaseUrl = "~",



                FailedPassword = 5,
                CodeSeconds = 60,
                CodeMinutes = 2,
                LockedMinutes = 5,


                EmailHost = "smtp.126.com",
                EmailPort = 25,
                EmailFrom = "ccvixo@126.com",
                EmailUser = "ccvixo",
                EmailPassword = "1qaz2wsx",
                ActiveMinutes = 30,
                EmailCodeTitle = "验证码邮件",
                EmailCodeContent = "<p>您的验证码是:</p><span style=\"font-size:14px;\">{0}</span>",
                EmailLinkTitle = "激活邮件",
                EmailLinkContent = "<p>点击链接激活:</p><a href=\"{0}\">链接：{1}</a>",
                ResetLinkTitle = "重置邮件",
                ResetLinkContent = "<p>点击链接重置:</p><a href=\"{0}\">链接：{1}</a>",


            });

            context.SaveChanges();

            #endregion 初始化配置

            #region 用户初始化
            var sysUsers = new List<SysUser>
            {
                new SysUser{SysUserName="Tom",SysPassword=CommonTools.ToMd5("111111"),SysEmail="Tom@163.com",SysStatus=true},
                new SysUser{SysUserName="Jerry",SysPassword=CommonTools.ToMd5("111111"),SysEmail="Tom@163.com",SysStatus=true},
                new SysUser{SysUserName="Jeem",SysPassword=CommonTools.ToMd5("1111111"),SysEmail="Tom@163.com",SysStatus=true}
            };
            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();

            #endregion 初始化配置
            #region 默认互动设置
            context.DefaultHudongSettings.Add(
                new DefaultHudongSetting { 
                    ZiyoushuxiePre="每一次的自由书写都是对生命的又一次的重新认识，它会让你更有力量。",
                    ZiyoushuxiePost="你的故事很精彩，如果你希望我回复你，请添加我的微信号：*****，我会和你一起分享爱的力量",
                    QuestionPre="当你回答了这个问题的时候，你就是对这个问题的探索",
                    QuestionSelected="1",
                    QuestionPost = "你的故事很精彩，如果你希望我回复你，请添加我的微信号：*****，我会和你一起分享爱的力量",
                    ZixunPre="你也可以直接留言咨询我，或者添加我的微信号",
                    ZixunPost="感谢你的信任，请添加我的微信号，我会第一时间联系你",

                });
            context.SaveChanges();
            #endregion 默认互动配置

            #region 默认讲课素材

            var JkSucaiList = new List<JkSucai>
            {
                new JkSucai{
                    Title="案例素材",
                    type="anli",
                    Cover="/Resource/img/nophoto.png",
                    Content="案例素材",
                    Info="案例素材",
                    Tags="案例素材",
                    Author="赵征",
                    Provider=0,
                    Price=0,
                    Qanxian=true,
                    IfDelete=false,
                    Ticheng=40,
                    CreateTime=DateTime.Now,
                },
                new JkSucai{
                    Title="图片素材",
                    type="tupian",
                    Cover="/Resource/img/nophoto.png",
                    Content="/Resource/img/nophoto.png",
                    Info="图片素材",
                    Tags="图片素材",
                    Author="赵征",
                    Provider=0,
                    Price=0,
                    Qanxian=true,
                    IfDelete=false,
                    Ticheng=40,
                    CreateTime=DateTime.Now,
                },
                new JkSucai{
                    Title="音频素材",
                    type="yinpin",
                    Cover="/Resource/img/nophoto.png",
                    Content="c80b87bcb00d44c6883950605d798070",
                    Info="音频素材",
                    Tags="音频素材",
                    Author="赵征",
                    Provider=0,
                    Price=0,
                    Qanxian=true,
                    IfDelete=false,
                    Ticheng=40,
                    CreateTime=DateTime.Now,
                },
                new JkSucai{
                    Title="视频素材",
                    type="shipin",
                    Cover="/Resource/img/nophoto.png",
                    Content="6ccf973fe06741e49ab849d4cec017e0",
                    Info="视频素材",
                    Tags="视频素材",
                    Author="赵征",
                    Provider=0,
                    Price=0,
                    Qanxian=true,
                    IfDelete=false,
                    Ticheng=40,
                    CreateTime=DateTime.Now,
                }
            };

            JkSucaiList.ForEach(j => context.JkSucais.Add(j));
            context.SaveChanges();
            #endregion 

            #region 默认讲课素材

            var XCXSucaiList = new List<XCXSucai>
            {
                new XCXSucai{
                    Title="图文素材",
                    type="tuwen",
                    Cover="/Resource/img/nophoto.png",
                    Content="案例素材",
                    Info="案例素材",
                    Tags="案例素材",
                    Author="赵征",
                    Provider=0,
                    Price=0,
                    Qanxian=true,
                    IfDelete=false,
                    Ticheng=40,
                    CreateTime=DateTime.Now,
                },
                new XCXSucai{
                    Title="音频素材",
                    type="yinpin",
                    Cover="/Resource/img/nophoto.png",
                    Content="c80b87bcb00d44c6883950605d798070",
                    Info="音频素材",
                    Tags="音频素材",
                    Author="赵征",
                    Provider=0,
                    Price=0,
                    Qanxian=true,
                    IfDelete=false,
                    Ticheng=40,
                    CreateTime=DateTime.Now,
                },
                new XCXSucai{
                    Title="视频素材",
                    type="shipin",
                    Cover="/Resource/img/nophoto.png",
                    Content="6ccf973fe06741e49ab849d4cec017e0",
                    Info="视频素材",
                    Tags="视频素材",
                    Author="赵征",
                    Provider=0,
                    Price=0,
                    Qanxian=true,
                    IfDelete=false,
                    Ticheng=40,
                    CreateTime=DateTime.Now,
                }
            };

            XCXSucaiList.ForEach(j => context.XCXSucais.Add(j));
            context.SaveChanges();
            #endregion 
        }
    }
}
