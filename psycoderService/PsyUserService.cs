using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
