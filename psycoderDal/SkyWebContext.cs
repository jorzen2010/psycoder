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
        public DbSet<DefaultHudongSetting> DefaultHudongSettings { get; set; }
        public DbSet<DefaultGuanggaoSetting> DefaultGuanggaoSettings { get; set; }
        public DbSet<PsyUser> PsyUsers { get; set; }


    }
}
