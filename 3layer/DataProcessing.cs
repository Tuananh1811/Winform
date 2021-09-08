using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _3layer
{
    class DataProcessing
    {
        DBConnect DBConnect = new DBConnect();
        public DataTable ShowDB()
        {
            string sql = "select Product.ProductCode,Product.DescriptionPro,Product.UnitPrice,Product.OnhandQuantity,Category.CategoryName from Product inner join Category on Product.CategoryID = Category.CategoryID";
            DataTable dataTable = new DataTable();
            dataTable = DBConnect.GetDataTable(sql);
            return dataTable;
            
        }
        public DataTable LoadComboBox()
        {
            string sql = "select *from Category";
            DataTable dataTable = new DataTable();
            dataTable = DBConnect.GetDataTable(sql);
            return dataTable;

        }
        public void InsertSACH(string ms,string td,int gia,string soluong,string ls)
        {
            string sql = "Insert into Product values ('" + ms + "','" + td + "','" + gia + "','" + soluong + "','" + ls + "') ";
            DBConnect.getExecuteNonQuery(sql);

        }
    }
}
