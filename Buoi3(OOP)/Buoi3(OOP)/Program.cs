using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Buoi3_OOP_
{
  public  class NhanVien
    {
        public String MaNV;
        public String HoTen;
        public double LuongGio;
        public double SoGio;

        public NhanVien()
        {

        }
        public NhanVien(String MaNV, String HoTen, double LuongGio, double SoGio)
        {
            this.MaNV = MaNV;
            this.HoTen = HoTen;
            this.LuongGio = LuongGio;
            this.SoGio = SoGio;
        }
        public void nhap()
        {
            Console.Write("Nhap ma nhan vien: ");
            MaNV = Console.ReadLine();
            Console.Write("Nhap ten nhan vien");
            HoTen = Console.ReadLine();
            Console.Write("Nhap luong 1 gio: ");
            LuongGio = Double.Parse(Console.ReadLine());
            Console.Write("Nhap so gio: ");
            SoGio = Double.Parse(Console.ReadLine());
        }
        public double Luong()
        {
            return LuongGio * SoGio;
        }
        public void Xuat()
        {
            Console.WriteLine("Thong Tin Nhan Vien: ");
            Console.WriteLine("Ma Nhan Vien: " + this.MaNV);
            Console.WriteLine("Ho Ten: " + this.HoTen);
            Console.WriteLine("Luong thang: " + this.Luong());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<NhanVien> nv = new List<NhanVien>();

            Console.WriteLine("Nhap so nhan vien");
            int n = int.Parse(Console.ReadLine());
           
            for(int i = 0; i < n; i++)
            {
                NhanVien nhanvien = new NhanVien();
                nhanvien.nhap();
                nv.Add(nhanvien);
               
               
            }
            foreach(NhanVien x in nv)
            {
                x.Xuat();

            }
            Console.ReadKey();
        }
    }
}
