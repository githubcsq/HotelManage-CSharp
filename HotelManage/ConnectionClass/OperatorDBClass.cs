/********************************************************************************
** auth： Kelvin LQ
** date： 2015-05-29 17:05:05
** desc： 对数据库的一些操作
** Ver.:  V1.0.0
** Email:creazylq@163.com
** QQ   :936563422
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HotelManage
{
    class OperatorDBClass
    {
        SqlConnection sqlconn = ConnectionClass.MyConnection();

        //关闭数据库的连接
        public void CloseDatabaseCnn()
        {
            sqlconn.Close();
        }
        public int OperateData(string strSql)
        {
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(strSql, sqlconn);
            int i = (int)cmd.ExecuteNonQuery();
            sqlconn.Close();
            return i;
        }
        /// <summary>
        /// 绑定某条数据到下拉框
        /// </summary>
        /// <param name="strTable">要查询的表名称</param>
        /// <param name="cb">下拉控件名称</param>
        /// <param name="i">列数</param>
        public void BindDropdownlist(string strTable, ComboBox cb, int i)
        {
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand("select * from " + strTable, sqlconn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                cb.Items.Add(sdr[i].ToString());
            }
            sdr.Close();
            sqlconn.Close();
        }
        /// <summary>
        /// 绑定数据到DataGridView控件
        /// </summary>
        /// <param name="dgv">控件名字</param>
        /// <param name="sql">sql语句</param>
        public void BindDataGridView(DataGridView dgv, string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            sqlconn.Close();
            ds.Dispose();
        }
        public void DataBind(DataGridView dgv, string sql, string tableName)
        {
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, sqlconn);
            DataSet ds = new DataSet();
            sda.Fill(ds, tableName);
            dgv.DataSource = ds.Tables[0];

            for (int i = 0; i < dgv.Rows.Count; )
            {
                dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                i += 2;
            }
            sqlconn.Close();
            ds.Dispose();
        }
        /// <summary>
        /// 检测某个表中对应的编号是否存在
        /// </summary>
        /// <param name="tableName">要查找的表名称</param>
        /// <param name="tableId">表中的ID名字</param>
        /// <param name="Id">要查找的名字</param>
        /// <returns></returns>
        public bool FindIdExist(string tableName, string tableId, string Id)
        {
            sqlconn.Open();
            bool is_ixist = false;
            string strsql = "select *from " + tableName + " where " + tableId + " ='" + Id + "'";
            SqlCommand cmd = new SqlCommand(strsql, sqlconn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read() == true)
            {
                is_ixist = true;
            }
            sqlconn.Close();

            return is_ixist;
        }
        /// <summary>
        /// 查找用户的密码
        /// </summary>
        /// <param name="userNmae"></param>
        /// <returns></returns>
        public string FindUserPwd(string userNmae)
        {
            sqlconn.Open();
            string userPwd = "";
            string sql = "select Users_pwd from Users where Users_name = '" + userNmae + "'";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();       //读取数据
            while (dr.Read())
                userPwd = dr["users_pwd"].ToString();
            sqlconn.Close();
            return userPwd;
        }

        public string FindVendorsId(string TableName, string tableIem)
        {
            sqlconn.Open();
            string id = "";
            string sql = "select  Vendors_id" + " from " + TableName + " where Vendors_name = '" + tableIem + "'";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                id = dr["Vendors_id"].ToString();
            sqlconn.Close();
            return id;
        }
        /// <summary>
        /// 商品销售临时表操作，进行数据的更新
        /// </summary>
        /// <param name="tableId">表中的编号</param>
        public void OpProductTemp(string tableId)
        {
            SqlConnection sqlconn2 = ConnectionClass.MyConnection();
            sqlconn.Open();
            sqlconn2.Open();
            string InsertSql = "insert into Products_Temp values(";
            string SearchSql = "select products_id,products_name,products_spec,sealling_price from products where products_id=" + tableId;

            SqlCommand cmd = new SqlCommand(SearchSql, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                InsertSql += dr["products_id"] + ",'" + dr["products_name"].ToString() + "','" + dr["products_spec"] + "','";
                InsertSql += dr["sealling_price"].ToString() + "'," + 1 + ",'" + DateTime.Now.ToString() + "')";
                SqlCommand cmd2 = new SqlCommand(InsertSql, sqlconn2);
                SqlDataReader dr2 = cmd2.ExecuteReader();
            }
            sqlconn.Close();
            sqlconn2.Close();
        }

        /// <summary>
        /// 查找商品的数量
        /// </summary>
        /// <param name="producrs_id">商品条码</param>
        /// <returns></returns>
        public int AddProductsSum(string producrs_id)
        {
            sqlconn.Open();
            string serachSql = "select products_num from Products_Temp where products_id = " + producrs_id;
            int Products_num = 0;
            SqlCommand cmd = new SqlCommand(serachSql, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                Products_num = Convert.ToInt32(dr["products_num"]);
            sqlconn.Close();
            return Products_num;
        }

        /// <summary>
        /// 计算用户购买的商品总价格
        /// </summary>
        /// <returns></returns>
        public string ProductsTotalPrice()
        {
            sqlconn.Open();
            string totalPrice = "";
            string sql = "select SUM( products_num*sealling_price) as totalPrice from products_temp";
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                totalPrice = dr["totalPrice"].ToString();
            sqlconn.Close();
            return totalPrice;
        }
        /// <summary>
        /// 清空某个表中的内容
        /// </summary>
        /// <param name="tableName"></param>
        public void DeleteTableContent(string tableName)
        {
            sqlconn.Open();
            string DeleteSql = "delete from  " + tableName;
            SqlCommand cmd = new SqlCommand(DeleteSql, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();
            sqlconn.Close();
        }
        /// <summary>
        /// 添加商品信息到销售记录表中
        /// </summary>
        /// <param name="id">商品ID</param>
        public void InsertSeall(string id)
        {
            SqlConnection sqlconn2 = ConnectionClass.MyConnection();
            sqlconn.Open();
            sqlconn2.Open();
            Random ran = new Random();
            int RandKey = ran.Next(1000, 999999);

            string searchSql = "select Products_id,sealling_price,products_num,seall_date from Products_temp where Products_id=" + id;
            string insertSql = "insert into Sell_detail values(";
            SqlCommand cmd = new SqlCommand(searchSql, sqlconn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                insertSql += "'" + RandKey + "'," + dr["products_id"] + ",";
                insertSql += dr["sealling_price"] + "," + dr["products_num"] + ",'";
                insertSql += dr["seall_date"].ToString() + "')";

                Console.WriteLine(insertSql);

                SqlCommand cmd2 = new SqlCommand(insertSql, sqlconn2);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                dr2.Close();
            }
            sqlconn.Close();
            sqlconn2.Close();
        }

        /// <summary>
        /// 对商品信息进行统计，即将销售信息填充到总销售表中，一遍后边进行统计分析
        /// </summary>
        /// <param name="id">编号</param>
        public void SellTotal(string id)
        {
            sqlconn.Open();
            string searchSql = "select sell_id,sum(single_sum *bargain_price),sum(single_sum) from Sell_detail where sell_id =" + id + " group by sell_id";

        }

        /// <summary>
        /// 商品入库
        /// </summary>
        /// <param name="goodsId">商品条码</param>
        /// <param name="retail_price">价格</param>
        /// <param name="store_num">数量</param>
        public void StoreManage(string goodsId, string retail_price, string store_num)
        {
            sqlconn.Open();
            int store_id = 1;
            string store_name = "主仓库";
            try
            {
                string InsertSql = "insert into StoreInfo values(" +"'"+ store_name + "',";
                InsertSql += goodsId + "," + retail_price + "," + store_num + ")";
                SqlCommand cmd = new SqlCommand(InsertSql,sqlconn);
                SqlDataReader dr = cmd.ExecuteReader();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                store_id++;
                sqlconn.Close();
            }
        }

        /// <summary>
        /// 返回商品的ID集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ProductsId(string sql)
        {
            List<string> Products_id = new List<string>();

            try
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand(sql,sqlconn);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Products_id.Add(dr["Products_id"].ToString());
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
            return Products_id.ToString();
        }
    }
}
