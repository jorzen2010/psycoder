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
            UnitOfWork unitOfWork = new UnitOfWork();
            string username = string.Empty;
            ZixunshiUser zixunshi = unitOfWork.zixunshiUsersRepository.GetByID(id);
            if (zixunshi == null)
            {
                username = "官方提供";
            }
            else
            {
                
                username = zixunshi.PsyNickName;
 
            }
            return username;

        }

        public static string GetProductNameById(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            string ProductName = string.Empty;
            Product product = unitOfWork.productsRepository.GetByID(id);
            if (product == null)
            {
                ProductName = "默认VIP会员订单";
            }
            else
            {
               
                ProductName = product.ProductName;

            }
            return ProductName;

        }

        public static string GetFensiUserNameById(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            string username = string.Empty;
           
                FensiUser fensi = unitOfWork.fensiUsersRepository.GetByID(id);
                if (fensi == null)
                {
                    username = "未知用户";
                }
                else
                {
                    username = fensi.nickName;
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
