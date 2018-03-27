using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillBLL
{
    public class ConsumeBll
    {
        /// <summary>
        /// 查看数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static List<BillModel.Consume> GetConsumes(string where = null)
        {
            return BillDAL.ConsumeDAL.GetConsumes(where);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagenum"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public static List<BillModel.Consume> PageGetConsumes(int pageindex, int pagenum, out int pageCount)
        {
            return BillDAL.ConsumeDAL.PageGetConsumes(pageindex, pagenum,out pageCount);
        }

    }
}
