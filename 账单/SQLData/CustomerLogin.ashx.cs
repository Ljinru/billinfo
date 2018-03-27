using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 账单.SQLData
{
    /// <summary>
    /// CustomerLogin 的摘要说明
    /// </summary>
    public class CustomerLogin : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string LoginName = context.Request["Name"];
            string PassWord = context.Request["Pwd"];
            //context.Response.Write(LoginName+PassWord);
            context.Session["User"] = null;
            BillModel.Users users = null;
            try
            {
                 users  = BillDAL.UsersDal.GetUsers().Where(U => U.Uphone == LoginName && U.Upwd == PassWord).First();
                 context.Session["User"] = users;
                 context.Response.Write(1);
                return;
            }
            catch (Exception)
            {
                context.Response.Write(0);
                return;
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