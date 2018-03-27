using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillBLL
{
    public class UsersBll
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static int InsertUser(BillModel.Users users)
        {
            return BillDAL.UsersDal.InsertUser(users);
        }
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <returns></returns>
        public static List<BillModel.Users> GetUsers()
        {
            return BillDAL.UsersDal.GetUsers();
        }
    }
}
