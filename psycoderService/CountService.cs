using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using psycoderDal;
using psycoderEntity;
namespace psycoderService
{
    public class CountService
    {
       
        public static int GetPsyUserCount()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int PsyUserCount = 0;
            var PsyUsers = unitOfWork.zixunshiUsersRepository.Get();
            PsyUserCount = PsyUsers.Count();
            return PsyUserCount;
        }

        public static int GetSysUserCount()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int SysUserCount = 0;
            var SysUsers = unitOfWork.sysUsersRepository.Get();
            SysUserCount = SysUsers.Count();
            return SysUserCount;
        }
        public static int GetFensiUserCount()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int FensiUserCount = 0;
            var FensiUsers = unitOfWork.fensiUsersRepository.Get();
            FensiUserCount = FensiUsers.Count();
            return FensiUserCount;
        }

        public static int GetZiyoushuxieReplyCount()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int ZysxReplyCount = 0;

          
            var ZysxReplys = unitOfWork.ziyoushuxieReplyRepository.Get();
            ZysxReplyCount = ZysxReplys.Count();

            return ZysxReplyCount;
        }

        public static int GetZixunReplyCount()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int ZixunReplyCount = 0;
            var ZixunReplys = unitOfWork.ziyoushuxieReplyRepository.Get();
            ZixunReplyCount = ZixunReplys.Count();
            return ZixunReplyCount;
        }

        public static int GetQuestionReplyCount()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int QuestionReplyCount = 0;
            var QustionReplys = unitOfWork.questionReplyRepository.Get();
            QuestionReplyCount = QustionReplys.Count();
            return QuestionReplyCount;
        }

        public static int GetXCXSucaiCount(string type="tuwen")
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int SucaiCount = 0;
            if (type == "tuwen" || type == "shipin" || type == "yinpin")
            {
                var Sucais = unitOfWork.xcxSucaiRepository.Get(filter: u => u.type == type);
                SucaiCount = Sucais.Count();
            }
            else
            {
                var Sucais = unitOfWork.xcxSucaiRepository.Get();
                SucaiCount = Sucais.Count();
            }
            return SucaiCount;
        }

        public static int GetJkSucaiCount(string type = "anli")
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int SucaiCount = 0;
            if (type == "anli" || type == "tupian" || type == "shipin" || type == "yinpin")
            {
                var Sucais = unitOfWork.jkSucaiRepository.Get(filter: u => u.type == type);
                SucaiCount = Sucais.Count();
            }
            else
            {
                var Sucais = unitOfWork.jkSucaiRepository.Get(filter: u => u.type == type);
                SucaiCount = Sucais.Count(); 
            }
            return SucaiCount;
        }



        public static int GetZiyoushuxieReplyCountByPid(int pid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int ZysxReplyCount = 0;

            var ZysxReplys = unitOfWork.ziyoushuxieReplyRepository.Get(filter:u =>u.PsyUser==pid);
            ZysxReplyCount = ZysxReplys.Count();

            return ZysxReplyCount;
        }

        public static int GetZixunReplyCountByPid(int pid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int ZixunReplyCount = 0;
            var ZixunReplys = unitOfWork.zixunReplyRepository.Get(filter: u => u.PsyUser == pid);
            ZixunReplyCount = ZixunReplys.Count();
            return ZixunReplyCount;
        }

        public static int GetQuestionReplyCountByPid(int pid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int QuestionReplyCount = 0;
            var QustionReplys = unitOfWork.questionReplyRepository.Get(filter: u => u.PsyUser == pid);
            QuestionReplyCount = QustionReplys.Count();
            return QuestionReplyCount;
        }

        public static int GetFensiUserCountByPid(int pid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int FensiUserCount = 0;
            var FensiUsers = unitOfWork.fensiUsersRepository.Get(filter: u => u.Zixunshi == pid);
            FensiUserCount = FensiUsers.Count();
            return FensiUserCount;
        }

        public static int GetXCXSucaiSelectedCountByPid(int pid,string type = "tuwen")
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int SucaiCount = 0;
            if (type == "tuwen" || type == "shipin" || type == "yinpin")
            {
                var Sucais = unitOfWork.xcxSucaiSelectedsRepository.Get(filter: u => u.SucaiType == type && u.Zixunshi==pid );
                SucaiCount = Sucais.Count();
            }
            else
            {
                var Sucais = unitOfWork.xcxSucaiSelectedsRepository.Get(filter: u => u.Zixunshi == pid);
                SucaiCount = Sucais.Count();
            }
            return SucaiCount;
        }
    }
}
