using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DoTuanAnh224
{
   
    class DataProcessing
    {
        DBConnect dataconn = new DBConnect();
        public DataTable ShowInfor()
        {
            String sql = "select *from QLKhachSan224";
            DataTable dataTable = new DataTable();
            dataTable = dataconn.GetDataTable(sql);
            return dataTable;
        }
        public void InsertKH(String makh,String tenkh,Boolean gt,string cmnd,int sophong,string ngaycheckin)
        {
            string sql= "Insert into QLKhachSan224 values('"+makh+ "','" + tenkh + "','" + gt + "','" + cmnd + "','" + sophong + "','" + ngaycheckin + "')";
            dataconn.ExecutenonQuery(sql);
        }
        public void Update(String makh, String tenkh, Boolean gt, string cmnd, int sophong, string ngaycheckin)
        {
            string sql = "UPDATE QLKhachSan224 set Makh='" + makh + "',Tenkh='" + tenkh + "',Gt='" + gt + "',SoCMND='" + cmnd + "',SoPhong='" + sophong + "',NgayCheckIn='" + ngaycheckin + "'where Makh='"+ makh+"'";
            dataconn.ExecutenonQuery(sql);
        }
        public void DELETE (string makh)
        {
            string sql = "delete from QLKhachSan224 where Makh='" + makh + "'";
            dataconn.ExecutenonQuery(sql);
        }
    }
}
