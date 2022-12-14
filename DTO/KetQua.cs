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

        private double? diemtb;

        public double? DiemTB { get { return diemtb; } set { diemtb = value; } }

        private double? diemthilai1;

        public double? DiemThiLai1 { get { return diemthilai1; } set { diemthilai1 = value; } }

        private double? diemthilai2;

        public double? DiemThiLai2 { get { return diemthilai2; } set { diemthilai2 = value; } }

        private double? diemtongket;

        public double? DiemTongKet { get { return diemtongket; } set { diemtongket = value; } }

        private string hanhkiem;

        public string HanhKiem { get { return hanhkiem; } set { hanhkiem = value; } }

        private int? hocki;

        public int? HocKi { get { return hocki; } set { hocki = value; } }

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
            double? diemtb,
            double? diemthilai1,
            double? diemthilai2,
            double? diemtongket,
            string hanhkiem,
            int? hocki,
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
            this.diemtongket = diemtongket;
            this.hanhkiem = hanhkiem;
            this.hocki = hocki;
            this.ghichu = ghichu;
        }
    }
}
