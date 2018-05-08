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