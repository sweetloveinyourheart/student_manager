using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetQua2
    {
        private string masv;

        public string MaSv { get { return masv; } set { masv = value; } }

        private string hoten;

        public string HoTen { get { return hoten; } set { hoten = value; } }

        private string malop;

        public string MaLop { get { return malop; } set { malop = value; } }

        private string tenmon;

        public string TenMon { get { return tenmon; } set { tenmon = value; } }

        private string diemthilai;

        public string DiemThiLai { get { return diemthilai; } set { diemthilai = value; } }

        private string hocki;

        public string HocKi { get { return hocki; } set { hocki = value; } }

        public KetQua2()
        {
        }

        public KetQua2(
            string masv,
            string hoten,
            string malop,
            string tenmon,
            string diemthilai,
            string hocki
            )
        {

            this.masv = masv;
            this.hoten = hoten;
            this.malop = malop;
            this.tenmon = tenmon;
            this.diemthilai = diemthilai;
            this.hocki = hocki;
        }
    }
}
