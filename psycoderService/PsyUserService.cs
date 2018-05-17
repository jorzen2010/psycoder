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
                username = "官方";
            }
            return username;

        }

        public static bool GetIfSelectSucai(int psyId, int sucaiId)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            bool IfSelect = false;
            var sucaiSelecteds = unitOfWork.xcxSucaiSelectedsRepository.Get(filter: u => u.PsyId == psyId && u.SucaiId == sucaiId &&u.Status==true);
            if (sucaiSelecteds.Count() > 0)
            {
                IfSelect = true;
            }
            return IfSelect;
        }
    }
}
