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

         private GenericRepository<ZixunshiUser> ZixunshiUsersRepository;

         public GenericRepository<ZixunshiUser> zixunshiUsersRepository
         {
             get
             {

                 if (this.ZixunshiUsersRepository == null)
                 {
                     this.ZixunshiUsersRepository = new GenericRepository<ZixunshiUser>(context);
                 }
                 return ZixunshiUsersRepository;
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

         private GenericRepository<FensiOrders> FensiOrdersRepository;

         public GenericRepository<FensiOrders> fensiOrdersRepository
         {
             get
             {

                 if (this.FensiOrdersRepository == null)
                 {
                     this.FensiOrdersRepository = new GenericRepository<FensiOrders>(context);
                 }
                 return FensiOrdersRepository;
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

         private GenericRepository<XCXSucaiSelected> XCXSucaiSelectedsRepository;

         public GenericRepository<XCXSucaiSelected> xcxSucaiSelectedsRepository
         {
             get
             {

                 if (this.XCXSucaiSelectedsRepository == null)
                 {
                     this.XCXSucaiSelectedsRepository = new GenericRepository<XCXSucaiSelected>(context);
                 }
                 return XCXSucaiSelectedsRepository;
             }
         }

         private GenericRepository<Product> ProductsRepository;

         public GenericRepository<Product> productsRepository
         {
             get
             {

                 if (this.ProductsRepository == null)
                 {
                     this.ProductsRepository = new GenericRepository<Product>(context);
                 }
                 return ProductsRepository;
             }
         }

         private GenericRepository<ZixunshiApp> ZixunshiAppsRepository;

         public GenericRepository<ZixunshiApp> zixunshiAppsRepositoryRepository
         {
             get
             {

                 if (this.ZixunshiAppsRepository == null)
                 {
                     this.ZixunshiAppsRepository = new GenericRepository<ZixunshiApp>(context);
                 }
                 return ZixunshiAppsRepository;
             }
         }

         private GenericRepository<Category> CategorysRepository;

         public GenericRepository<Category> categorysRepository
         {
             get
             {

                 if (this.CategorysRepository == null)
                 {
                     this.CategorysRepository = new GenericRepository<Category>(context);
                 }
                 return CategorysRepository;
             }
         }

         private GenericRepository<JksucaiChakanTongji> JksucaiChakanTongjisRepository;

         public GenericRepository<JksucaiChakanTongji> jksucaiChakanTongjisRepository
         {
             get
             {

                 if (this.JksucaiChakanTongjisRepository == null)
                 {
                     this.JksucaiChakanTongjisRepository = new GenericRepository<JksucaiChakanTongji>(context);
                 }
                 return JksucaiChakanTongjisRepository;
             }
         }

         private GenericRepository<JksucaiXihuanTongji> JksucaiXihuanTongjisRepository;

         public GenericRepository<JksucaiXihuanTongji> jksucaiXihuanTongjisRepository
         {
             get
             {

                 if (this.JksucaiXihuanTongjisRepository == null)
                 {
                     this.JksucaiXihuanTongjisRepository = new GenericRepository<JksucaiXihuanTongji>(context);
                 }
                 return JksucaiXihuanTongjisRepository;
             }
         }

         private GenericRepository<JksucaiShoucangTongji> JksucaiShoucangTongjisRepository;

         public GenericRepository<JksucaiShoucangTongji> jksucaiShoucangTongjisRepository
         {
             get
             {

                 if (this.JksucaiShoucangTongjisRepository == null)
                 {
                     this.JksucaiShoucangTongjisRepository = new GenericRepository<JksucaiShoucangTongji>(context);
                 }
                 return JksucaiShoucangTongjisRepository;
             }
         }

         private GenericRepository<JksucaiXiazaiTongji> JksucaiXiazaiTongjisRepository;

         public GenericRepository<JksucaiXiazaiTongji> jksucaiXiazaiTongjisRepository
         {
             get
             {

                 if (this.JksucaiXiazaiTongjisRepository == null)
                 {
                     this.JksucaiXiazaiTongjisRepository = new GenericRepository<JksucaiXiazaiTongji>(context);
                 }
                 return JksucaiXiazaiTongjisRepository;
             }
         }

         private GenericRepository<CeshiResult> CeshiResultsRepository;

         public GenericRepository<CeshiResult> ceshiResultsRepository
         {
             get
             {

                 if (this.CeshiResultsRepository == null)
                 {
                     this.CeshiResultsRepository = new GenericRepository<CeshiResult>(context);
                 }
                 return CeshiResultsRepository;
             }
         }

         private GenericRepository<CeshiFensiUser> CeshiFensiUsersRepository;

         public GenericRepository<CeshiFensiUser> ceshiFensiUsersRepository
         {
             get
             {

                 if (this.CeshiFensiUsersRepository == null)
                 {
                     this.CeshiFensiUsersRepository = new GenericRepository<CeshiFensiUser>(context);
                 }
                 return CeshiFensiUsersRepository;
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