using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa
{
    class KHACHHANG :NGUOI
    {
        public string dichvu;
        public string ngaybatdau;
        public double sobuoi;

        public KHACHHANG(string ma, string hoten, string gioitinh, int tuoi,string dichvu, string ngaybatdau, double sobuoi):base(ma,hoten,gioitinh,tuoi)
        {
            this.dichvu = dichvu;
            this.ngaybatdau = ngaybatdau;
            this.sobuoi = sobuoi;
        }
        public override List<string> Xuat()
        {
            List<string> listKH = base.Xuat();
            listKH.Add(dichvu);
            listKH.Add(ngaybatdau);
            listKH.Add(tongtien(dichvu).ToString());
         
            return listKH;
        }
        public double tongtien(string dichvu)
        {
            double total=0;
            if (dichvu == "Chăm sóc da")
            {
                total += 400000 * sobuoi;
            }
            if (dichvu == "Chăm sóc vùng mắt")
            {
                total = 300000 * sobuoi;
            }
            if (dichvu == "Giảm mỡ bụng")
            {
                total += 500000 * sobuoi;
            }
            if (dichvu == "Trị nám")
            {
                total += 200000 * sobuoi;
            }

            return total;
        }
    }
}
