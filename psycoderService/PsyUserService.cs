using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using psycoderDal;
using psycoderEntity;
using Common;

namespace psycoderService
{
    public class PsyUserService
    {

        public static string GetPsyUserNameById(int id)
        {
            string username = string.Empty;
            if (id == 0)
            {
                username = "官方提供";
            }
            return username;

        }

        public static string GetXCXSucaiTitleById(int id)
        {
            string title = string.Empty;
            UnitOfWork unitOfWork = new UnitOfWork();
            XCXSucai sucai = unitOfWork.xcxSucaiRepository.GetByID(id);
            if (sucai == null)
            {
                title = "Id有误，素材可能被删除了";
            }
            else
            {
                title = sucai.Title;
            }
            return title;

        }

        public static bool GetIfSelectSucai(int psyId, int sucaiId)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            bool IfSelect = false;
            var sucaiSelecteds = unitOfWork.xcxSucaiSelectedsRepository.Get(filter: u => u.Zixunshi == psyId && u.Sucai == sucaiId &&u.Status==true);
            if (sucaiSelecteds.Count() > 0)
            {
                IfSelect = true;
            }
            return IfSelect;
        }
    }
}
