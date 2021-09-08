using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa
{
    class NGUOI
    {
        public string ma;
        public string hoten;
        public string gioitinh;
        public int tuoi;

        public NGUOI(string ma, string hoten, string gioitinh, int tuoi)
        {
            this.ma = ma;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.tuoi = tuoi;
        }
        public virtual List<string> Xuat()
        {
            List<string> listNg = new List<string>();
            listNg.Add(ma);
            listNg.Add(hoten);
            listNg.Add(gioitinh);
            listNg.Add(tuoi.ToString());
            return listNg;
        }
    }
}
