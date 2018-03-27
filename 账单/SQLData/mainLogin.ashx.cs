using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 账单.SQLData
{
    /// <summary>
    /// mainLogin 的摘要说明
    /// </summary>
    public class mainLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if(context.Session["User"] != null)
            {
                string  name  =((BillModel.Users)context.Session["User"]).Uname;
                context.Response.Write(name);
            }
            else
            {
                context.Response.Write(0);
            }
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