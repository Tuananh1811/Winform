using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Xây dựng lớp NhanVien gồm các thuộc tính Họ tên nhân viên, Giới tính,
//Ngày sinh, Hệ số lương, Lương cơ bản, trong đó Lương cơ bản dùng 
//chung cho tất cả các nhân viên trong công ty (thuộc tính tĩnh, mặc định là 1.000.000).
namespace ontap
{
    class NhanVien
    {
        public string HoTen;
        public string GioiTinh;
        public string NgaySinh;
        public double HeSo;
        public static double luongcb = 1000000;
       
    }
}
