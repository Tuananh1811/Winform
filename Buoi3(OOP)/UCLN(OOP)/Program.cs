using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCLN_OOP_
{
    class Data
    {
      public  int a, b;
       public Data()
        {

        }
        public Data(int a,int b)
        {
            this.a = a;
            this.b = b;

        }
        public int UCLN() //trừ cho 2 số bằng nhau
        {
            while (a != b)
            {

                 if (a > b)
                {
                    b = a - b;
                    a = b;
                   }
                else
                {
                    a = b - a;
                    b = a;

                }
                
            }
            return a;

            
        }

    }
    class PhanSo : Data //kế thừa lớp
    {
        public PhanSo():base(){//kế thừa phương thức
            }
        public PhanSo(int a, int b) : base(a, b)
        {
        }
        public PhanSo rutgon()
        {
            PhanSo res = new PhanSo();
            res.a = a / base.UCLN();
            res.b = b / base.UCLN();
            return res;
        }
        public PhanSo Tong(PhanSo PS1)
        {
            PhanSo kq = new PhanSo();

            kq.a = a * PS1.b + b * PS1.a;
            kq.b = b * PS1.b;
            
            return kq.rutgon();
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            PhanSo Ps1 = new PhanSo(3, 5);
            PhanSo Ps2 = new PhanSo(4, 15);
        }
    }
}
