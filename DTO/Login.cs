using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Login
    {
        private string tendn;

        public string TenDN { get { return tendn; } set { tendn = value; } }

        private string matkhau;

        public string MatKhau { get { return matkhau; } set { matkhau = value; } }

        private string hoten;

        public string HoTen { get { return hoten; } set { hoten = value; } }

        private string gioitinh;

        public string GioiTinh { get { return gioitinh; } set { gioitinh = value; } }

        private string phone;

        public string Phone { get { return phone; } set { phone = value; } }

        private string email;

        public string Email { get { return email; } set { email = value; } }

        private string quyen;

        public string Quyen { get { return quyen; } set { quyen = value; } }

        public Login()
        {
        }

        public Login(
            string tendn,
            string matkhau,
            string hoten,
            string gioitinh,
            string phone,
            string email,
            string quyen
            )
        {

            this.tendn = tendn;
            this.matkhau = matkhau;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.phone = phone;
            this.email = email;
            this.quyen = quyen;
        }
    }
}
