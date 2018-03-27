using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace BillDAL
{
    public class ConsumeDAL
    {
        /// <summary>
        /// 查看数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static List<BillModel.Consume> GetConsumes(string where = null)
        {
            List<BillModel.Consume> List = new List<BillModel.Consume>();
            string sql = " select * from Consume where Userid = 1";
            SqlDataReader dataReader = DBHepler.ExecuteReader(sql);
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    List.Add(new BillModel.Consume() {
                        Cexplain = dataReader["Cexplain"] as string,
                        Cid = (int)dataReader["Cid"],
                        Cimage = dataReader["Cimage"] as string,
                        Cincome = (int)dataReader["Cincome"],
                        Cmoney = (decimal)dataReader["Cmoney"],
                        Cmoneys = (decimal)dataReader["Cmoneys"],
                        Ctime = (DateTime)dataReader["Ctime"],
                        Ctype = dataReader["Ctype"] as string,
                        Userid = (int)dataReader["Userid"] });
                }
            }
            DBHepler.Close();
                return List;
        }

        /// <summary>
        /// 分业
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagenum"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static List<BillModel.Consume> PageGetConsumes(int pageindex, int pagenum, out int pageCount)
        {
            List<BillModel.Consume> list = new List<BillModel.Consume>();
            SqlParameter[] p =
            {
                new SqlParameter ("@pageIndex",pageindex),
                new  SqlParameter("@pageCount",pagenum),
                new SqlParameter("@pageTotalCount",SqlDbType .Int)
            };
            p[2].Direction = ParameterDirection.Output;
            DataSet dataSet = DBHepler.GetDataSet("proc_Users", CommandType.StoredProcedure, p);
            pageCount = Convert.ToInt32(p[2].Value);
            foreach (DataRow item in dataSet.Tables[0].Rows)
            {
                BillModel.Consume consume = new BillModel.Consume();
                consume.Cexplain = item["Cexplain"].ToString();
                consume.Cid = (int)item["Cid"];
                consume.Cimage = item["Cimage"].ToString();
                consume.Cincome = (int)item["Cincome"];
                consume.Cmoney = (decimal)item["Cmoney"];
                consume.Cmoneys = (decimal)item["Cmoneys"];
                consume.Ctime = (DateTime)item["Ctime"];
                consume.Ctype = item["Ctype"].ToString();
                consume.Userid = (int)item["Userid"];
                list.Add(consume);

            }
            return list;
        }
    }
}
