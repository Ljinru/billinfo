using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillModel
{
    public class Consume
    {

        /*	Cid int primary key identity(1,1),		--消费ID
        Cincome int default(0),					--消费收入 0消费 1收入
        Cmoney money not null,					--消费金额
        Cmoneys money not null,					--总金额
        Ctime datetime not null,				--消费时间
        Cexplain varchar(255) not null,			--消费说明
        Ctype varchar(20) not null,				--支付方式
        Cimage varchar(100) not null ,			--图片
        Userid int references Users(UserID)		--用户ID*/

        /// <summary>
        /// ID
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 消费或收入 0消费 1收入
        /// </summary>
        public int Cincome { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Cmoney { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal Cmoneys { get; set; }
        /// <summary>
        /// 消费时间
        /// </summary>
        public  DateTime Ctime { get; set; }
        /// <summary>
        /// 消费说明
        /// </summary>
        public string Cexplain { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string Ctype { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Cimage { get; set; }
        /// <summary>
        /// 关联Users ID
        /// </summary>
        public int Userid { get; set; }
    }
}
