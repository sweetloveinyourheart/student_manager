using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetQua
    {
        private string masv;

        public string MaSv { get { return masv; } set { masv = value; } }

        private string hoten;

        public string HoTen { get { return hoten; } set { hoten = value; } }

        private string malop;

        public string MaLop { get { return malop; } set { malop = value; } }

        private string mamon;

        public string MaMon { get { return mamon; } set { mamon = value; } }

        private string diemtb;

        public string DiemTB { get { return diemtb; } set { diemtb = value; } }

        private string diemthilai1;

        public string DiemThiLai1 { get { return diemthilai1; } set { diemthilai1 = value; } }

        private string diemthilai2;

        public string DiemThiLai2 { get { return diemthilai2; } set { diemthilai2 = value; } }

        private string hanhkiem;

        public string HanhKiem { get { return hanhkiem; } set { hanhkiem = value; } }

        private string hocki;

        public string HocKi { get { return hocki; } set { hocki = value; } }

        private string ghichu;

        public string GhiChu { get { return ghichu; } set { ghichu = value; } }

        public KetQua()
        {
        }

        public KetQua(
            string masv,
            string hoten,
            string malop,
            string mamon,
            string diemtb,
            string diemthilai1,
            string diemthilai2,
            string hanhkiem,
            string hocki,
            string ghichu
            )
        {

            this.masv = masv;
            this.hoten = hoten;
            this.malop = malop;
            this.mamon = mamon;
            this.diemtb = diemtb;
            this.diemthilai1 = diemthilai1;
            this.diemthilai2 = diemthilai2;
            this.hanhkiem = hanhkiem;
            this.hocki = hocki;
            this.ghichu = ghichu;
        }
    }
}
