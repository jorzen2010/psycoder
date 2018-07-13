using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using psycoderEntity;


namespace psycoderDal
{
    public class SkyWebContext : DbContext
    {
        public SkyWebContext()
            : base("SkyWebContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<XCXSucai> XCXSucais { get; set; }
        public DbSet<JkSucai> JkSucais { get; set; }
       
        public DbSet<ZixunshiUser> ZixunshiUsers { get; set; }
        public DbSet<FensiUser> FensiUsers { get; set; }
        public DbSet<Notice> Notices { get; set; }

        public DbSet<DefaultHudongSetting> DefaultHudongSettings { get; set; }
        public DbSet<DefaultGuanggaoSetting> DefaultGuanggaoSettings { get; set; }
        public DbSet<HudongSetting> HudongSettings { get; set; }
        public DbSet<GuanggaoSetting> GuanggaoSettings { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionReply> QuestionReplys { get; set; }
        public DbSet<ZiyoushuxieReply> ZiyoushuxieReplys { get; set; }
        public DbSet<ZixunReply> ZixunReplys { get; set; }

        public DbSet<FensiOrders> FensiOrders { get; set; }
        public DbSet<PsyOrders> PsyOrders { get; set; }

        public DbSet<XCXSucaiSelected> XCXSucaiSelecteds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ZixunshiApp> ZixunshiApps { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<JksucaiChakanTongji> JksucaiChakanTongjis { get; set; }
        public DbSet<JksucaiXihuanTongji> JksucaiXihuanTongjis { get; set; }
        public DbSet<JksucaiShoucangTongji> JksucaiShoucangTongjis { get; set; }
        public DbSet<JksucaiXiazaiTongji> JksucaiXiazaiTongjis { get; set; }



    }
}
