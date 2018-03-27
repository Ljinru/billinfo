using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BillDAL
{
    public class UsersDal
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static int InsertUser(BillModel.Users users)
        {
            string sqlstr = "insert Users values(@UName, @UPhone, @UPwd)";
            SqlParameter[] p ={
                                    new SqlParameter("@UName",users.Uname),
                                    new SqlParameter("@UPhone",users.Uphone),
                                    new SqlParameter("@UPwd",users.Upwd)
                               };
            return DBHepler.ExecuteNonQuery(sqlstr, p);
        }
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <returns></returns>
        public static List<BillModel.Users> GetUsers()
        {
            List<BillModel.Users> modelList = new List<BillModel.Users>();

            string sqlstr = "select * from Users ";
            SqlDataReader dr = DBHepler.ExecuteReader(sqlstr);
            BillModel.Users model = null;
            while (dr.Read())
            {
                model = new BillModel.Users();
                model.UserID = (int)dr["UserID"];
                model.Uname = dr["UName"].ToString();
                model.Upwd = dr["UPwd"].ToString();
                model.Uphone = dr["Uphone"].ToString();
                modelList.Add(model);
            }
            dr.Close();
            return modelList;
        }

    }
}
