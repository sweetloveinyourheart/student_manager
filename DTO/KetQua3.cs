using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetQua3
    {
        private string masv;

        public string MaSv { get { return masv; } set { masv = value; } }

        private string hoten;

        public string HoTen { get { return hoten; } set { hoten = value; } }

        private string malop;

        public string MaLop { get { return malop; } set { malop = value; } }

        private string tenmon;

        public string TenMon { get { return tenmon; } set { tenmon = value; } }

        private float diemhoclai;

        public float DiemHocLai { get { return diemhoclai; } set { diemhoclai = value; } }

        private int hocki;

        public int HocKi { get { return hocki; } set { hocki = value; } }

        public KetQua3()
        {
        }

        public KetQua3(
            string masv,
            string hoten,
            string malop,
            string tenmon,
            float diemhoclai,
            int hocki
            )
        {

            this.masv = masv;
            this.hoten = hoten;
            this.malop = malop;
            this.tenmon = tenmon;
            this.diemhoclai = diemhoclai;
            this.hocki = hocki;
        }
    }
}
