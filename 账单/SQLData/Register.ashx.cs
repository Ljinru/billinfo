using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;

namespace 账单.SQLData
{
    /// <summary>
    /// Image 的摘要说明
    /// </summary>
    public class Image : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            //string id = context.Request["ID"];
            //List<dslfajal> modellist = new List<dslfajal>();
            ////讲数据序列化为json格式字符
            //DataContractJsonSerializer json = new DataContractJsonSerializer(modellist.GetType());
            ////调用前端成功回调函数，并返回数据
            //json.WriteObject(context.Response.OutputStream, modelliist);

            string pwd = context.Request["pwd"];
            string name = context.Request["name"];
            string phone = context.Request["phone"];
            
            try
            {
                BillModel.Users user = new BillModel.Users();
                user.Upwd = pwd;
                user.Uphone = phone;
                user.Uname = name;
                if(BillBLL.UsersBll.InsertUser(user)>0)
                {
                    context.Response.Write(1);
                    return;
                }
                else
                {
                    context.Response.Write(0);
                    return;
                }

            }
            catch (Exception)
            {
                throw;            
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