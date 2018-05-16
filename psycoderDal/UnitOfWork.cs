using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using psycoderEntity;


namespace psycoderDal
{
    public class UnitOfWork : IDisposable
    {
        private SkyWebContext context = new SkyWebContext();

        private GenericRepository<SysUser> SysUsersRepository;

         public GenericRepository<SysUser> sysUsersRepository
        {
            get
            {

                if (this.SysUsersRepository == null)
                {
                    this.SysUsersRepository = new GenericRepository<SysUser>(context);
                }
                return SysUsersRepository;
            }
        }


         private GenericRepository<Setting> SettingsRepository;

         public GenericRepository<Setting> settingsRepository
         {
             get
             {

                 if (this.SettingsRepository == null)
                 {
                     this.SettingsRepository = new GenericRepository<Setting>(context);
                 }
                 return SettingsRepository;
             }
         }

         private GenericRepository<XCXSucai> XCXSucaisRepository;

         public GenericRepository<XCXSucai> xcxSucaiRepository
         {
             get
             {

                 if (this.XCXSucaisRepository == null)
                 {
                     this.XCXSucaisRepository = new GenericRepository<XCXSucai>(context);
                 }
                 return XCXSucaisRepository;
             }
         }

         private GenericRepository<JkSucai> JkSucaisRepository;

         public GenericRepository<JkSucai> jkSucaiRepository
         {
             get
             {

                 if (this.JkSucaisRepository == null)
                 {
                     this.JkSucaisRepository = new GenericRepository<JkSucai>(context);
                 }
                 return JkSucaisRepository;
             }
         }

         private GenericRepository<DefaultHudongSetting> DefalutHudongSettingRepository;

         public GenericRepository<DefaultHudongSetting> defalutHudongSettingRepository
         {
             get
             {

                 if (this.DefalutHudongSettingRepository == null)
                 {
                     this.DefalutHudongSettingRepository = new GenericRepository<DefaultHudongSetting>(context);
                 }
                 return DefalutHudongSettingRepository;
             }
         }

         private GenericRepository<DefaultGuanggaoSetting> DefaultGuanggaoSettingRepository;

         public GenericRepository<DefaultGuanggaoSetting> defaultGuanggaoSettingRepository
         {
             get
             {

                 if (this.DefaultGuanggaoSettingRepository == null)
                 {
                     this.DefaultGuanggaoSettingRepository = new GenericRepository<DefaultGuanggaoSetting>(context);
                 }
                 return DefaultGuanggaoSettingRepository;
             }
         }

         private GenericRepository<PsyUser> PsyUsersRepository;

         public GenericRepository<PsyUser> psyUsersRepository
         {
             get
             {

                 if (this.PsyUsersRepository == null)
                 {
                     this.PsyUsersRepository = new GenericRepository<PsyUser>(context);
                 }
                 return PsyUsersRepository;
             }
         }

         private GenericRepository<FensiUser> FensiUsersRepository;

         public GenericRepository<FensiUser> fensiUsersRepository
         {
             get
             {

                 if (this.FensiUsersRepository == null)
                 {
                     this.FensiUsersRepository = new GenericRepository<FensiUser>(context);
                 }
                 return FensiUsersRepository;
             }
         }

         private GenericRepository<Notice> NoticesRepository;

         public GenericRepository<Notice> noticesRepository
         {
             get
             {

                 if (this.NoticesRepository == null)
                 {
                     this.NoticesRepository = new GenericRepository<Notice>(context);
                 }
                 return NoticesRepository;
             }
         }

         private GenericRepository<HudongSetting> HudongSettingRepository;

         public GenericRepository<HudongSetting> hudongSettingRepository
         {
             get
             {

                 if (this.HudongSettingRepository == null)
                 {
                     this.HudongSettingRepository = new GenericRepository<HudongSetting>(context);
                 }
                 return HudongSettingRepository;
             }
         }

         private GenericRepository<GuanggaoSetting> GuanggaoSettingRepository;

         public GenericRepository<GuanggaoSetting> guanggaoSettingRepository
         {
             get
             {

                 if (this.GuanggaoSettingRepository == null)
                 {
                     this.GuanggaoSettingRepository = new GenericRepository<GuanggaoSetting>(context);
                 }
                 return GuanggaoSettingRepository;
             }
         }

         private GenericRepository<ZiyoushuxieReply> ZiyoushuxieReplyRepository;

         public GenericRepository<ZiyoushuxieReply> ziyoushuxieReplyRepository
         {
             get
             {

                 if (this.ZiyoushuxieReplyRepository == null)
                 {
                     this.ZiyoushuxieReplyRepository = new GenericRepository<ZiyoushuxieReply>(context);
                 }
                 return ZiyoushuxieReplyRepository;
             }
         }

         private GenericRepository<QuestionReply> QuestionReplyRepository;

         public GenericRepository<QuestionReply> questionReplyRepository
         {
             get
             {

                 if (this.QuestionReplyRepository == null)
                 {
                     this.QuestionReplyRepository = new GenericRepository<QuestionReply>(context);
                 }
                 return QuestionReplyRepository;
             }
         }

         private GenericRepository<ZixunReply> ZixunReplyRepository;

         public GenericRepository<ZixunReply> zixunReplyRepository
         {
             get
             {

                 if (this.ZixunReplyRepository == null)
                 {
                     this.ZixunReplyRepository = new GenericRepository<ZixunReply>(context);
                 }
                 return ZixunReplyRepository;
             }
         }

         private GenericRepository<Question> QuestionRepository;

         public GenericRepository<Question> questionRepository
         {
             get
             {

                 if (this.QuestionRepository == null)
                 {
                     this.QuestionRepository = new GenericRepository<Question>(context);
                 }
                 return QuestionRepository;
             }
         }

         private GenericRepository<Orders> OrdersRepository;

         public GenericRepository<Orders> ordersRepository
         {
             get
             {

                 if (this.OrdersRepository == null)
                 {
                     this.OrdersRepository = new GenericRepository<Orders>(context);
                 }
                 return OrdersRepository;
             }
         }

         private GenericRepository<PsyOrders> PsyOrdersRepository;

         public GenericRepository<PsyOrders> psyOrdersRepository
         {
             get
             {

                 if (this.PsyOrdersRepository == null)
                 {
                     this.PsyOrdersRepository = new GenericRepository<PsyOrders>(context);
                 }
                 return PsyOrdersRepository;
             }
         }



       

     
        

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}