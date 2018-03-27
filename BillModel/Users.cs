using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillModel
{
    public class Users
    {
        /*	UserID int primary key identity(1,1),	--用户ID
	Uname varchar(10) not null ,			--用户名
	Uphone varchar(11) not null,			--用户电话
	Upwd varchar(20) not null,				--用户密码*/
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uname { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Uphone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Upwd { get; set; }
    }
}
