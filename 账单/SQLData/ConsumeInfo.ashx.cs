using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace 账单.SQLData
{
    /// <summary>
    /// ConsumeInfo 的摘要说明
    /// </summary>
    public class ConsumeInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageindex = int.Parse(context.Request["pageindex"]);
            int pagenumber = int.Parse(context.Request["pagenumber"]);
            int pageCount = 0;
            List<BillModel.Consume> consumes = BillBLL.ConsumeBll.PageGetConsumes(pageindex, pagenumber, out pageCount);
            Dictionary<object, object> keyValuePairs = new Dictionary<object, object>();
            keyValuePairs.Add("result", consumes);
            keyValuePairs.Add("PageCount", pageCount);
            string dcjson = (new JavaScriptSerializer()).Serialize(keyValuePairs);
            context.Response.Write(dcjson);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}