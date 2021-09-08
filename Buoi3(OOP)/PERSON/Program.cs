using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERSON
{
    public class Person
    {
        private String hoTen;
        private String gioitinh;
        private int namsinh;
        private String diachi;

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public int Namsinh { get => namsinh; set => namsinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }

        public Person()
        {
        }
        public Person(String HoTen, String Gioitinh, int namsinh, String Diachi)
        {
            this.HoTen = HoTen;
            this.Gioitinh = Gioitinh;
            this.namsinh = namsinh;
            this.Diachi = Diachi;
        }


    }
    public class CongNhan : Person
    {
        public string tenCTY;
       public int ngayVaoLamViec;
       public double heSoLuong;
        public CongNhan() : base()
        {

        }
        public CongNhan(String HoTen, String Gioitinh, int namsinh, String Diachi, string tenCTY, int ngayVaoLamViec, double heSoLuong)
            :base(HoTen, Gioitinh, namsinh, Diachi)
        {
            this.tenCTY = tenCTY;
            this.ngayVaoLamViec = ngayVaoLamViec;
            this.heSoLuong=heSoLuong;

        }
        public void Nhap()
        {
            Console.WriteLine("Nhap thong tin nhan vien");
            Console.WriteLine("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("nhap gioi tinh: ");
            Gioitinh = Console.ReadLine();
            Console.Write("Nhap nam sinh:");
            Namsinh = int.Parse(Console.ReadLine());
            Console.Write("nhap dia chi: ");
            Diachi = Console.ReadLine();
            Console.Write("nhap tenCTY: ");
            tenCTY = Console.ReadLine();
            Console.Write("Nhap ngay vao lam viec: ");
            ngayVaoLamViec = int.Parse(Console.ReadLine());
            Console.Write("nhap he so luong: ");
            heSoLuong = double.Parse(Console.ReadLine());

        }
        public void Xuat()
        {
            Console.WriteLine("__________ Thong tin nhan vien_______");
            Console.WriteLine("Ho ten: " + HoTen);
            Console.WriteLine("gioi tinh: " + Gioitinh);
            Console.WriteLine("Nam sinh: " + Namsinh);
            Console.WriteLine("Dia chi: " + Diachi);
            Console.WriteLine("ten cong ty: " + tenCTY);
            Console.WriteLine("Ngay vao lam viec: " + ngayVaoLamViec);
            Console.WriteLine("He so luong: " + heSoLuong);
        }
        

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<CongNhan> congnhan = new List<CongNhan>();
            Console.WriteLine("Nhap so nhan vien");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                CongNhan CN = new CongNhan();
                CN.Nhap();
                congnhan.Add(CN);
            }
            foreach(CongNhan x in congnhan)
            {
                
                x.Xuat();
            }
            //for(int i = 0; i < n; i++)
            //{
            //    congnhan.Sort();
            //}
          

            double max = congnhan[0].heSoLuong;
           for(int i = 0; i < n; i++)
            {
                if(max<= congnhan[i].heSoLuong)
                {
                    max = congnhan[i].heSoLuong;
                }
            }
            Console.WriteLine("________cong nhan co he so luong cao nhat________");
           for(int i = 0; i < n; i++)
            {
                if (max == congnhan[i].heSoLuong)
                {
                    congnhan[i].Xuat();
                }
            }
            Console.ReadKey();
         }
    }
}
