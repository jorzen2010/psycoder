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
            var PsyUsers = unitOfWork.zixunReplyRepository.Get();
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
            if (type == "tuwen" || type == "audio" || type == "video")
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
    }
}
