using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVien
    {
        private string masv;

        public string MaSv { get { return masv; } set { masv = value; } }

        private string hoten;

        public string HoTen { get { return hoten; } set { hoten = value; } }

        private string ngaysinh;

        public string NgaySinh { get { return ngaysinh; } set { ngaysinh = value; } }

        private string gioitinh;

        public string GioiTinh { get { return gioitinh; } set { gioitinh = value; } }

        private string diachi;

        public string DiaChi { get { return diachi; } set { diachi = value; } }

        private string malop;

        public string MaLop { get { return malop; } set { malop = value; } }

        public SinhVien()
        {
        }

        public SinhVien(
            string masv, 
            string hoten, 
            string ngaysinh, 
            string gioitinh, 
            string diachi,
            string malop
            )
        {
            this.masv = masv;
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.malop = malop;
        }
    }
}
