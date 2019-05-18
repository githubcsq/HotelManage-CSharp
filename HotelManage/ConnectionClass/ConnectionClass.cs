/********************************************************************************
** auth： Kelvin LQ
** date： 2015-05-29 17:00:43
** desc： 实现对数据库的连接
** Ver.:  V1.0.0
** Email:creazylq@163.com
** QQ   :936563422
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace HotelManage
{
    class ConnectionClass
    {
        public static SqlConnection MyConnection()
        {
            string source = "server = 127.0.0.1;database = ShopManage;uid = sa;pwd = 123456";
            return new SqlConnection(source);
        }
    }
}
