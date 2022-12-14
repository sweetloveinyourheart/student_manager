using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiangVien
    {
        private string magv;

        public string MaGV { get { return magv; } set { magv = value; } }

        private string tengv;

        public string TenGV { get { return tengv; } set { tengv = value; } }

        private string gioitinh;

        public string GioiTinh { get { return gioitinh; } set { gioitinh = value; } }

        private string phone;

        public string Phone { get { return phone; } set { phone = value; } }

        private string email;

        public string Email { get { return email; } set { email = value; } }

        private string phanloaigv;

        public string PhanLoaiGV { get { return phanloaigv; } set { phanloaigv = value; } }

        private string anh;

        public string Anh { get { return anh; } set { anh = value; } }

        public GiangVien()
        {
        }

        public GiangVien(
            string magv,
            string tengv,
            string gioitinh,
            string phone,
            string email,
            string phanloaigv,
            string anh
            )
        {

            this.magv = magv;
            this.tengv = tengv;
            this.gioitinh = gioitinh;
            this.phone = phone;
            this.email = email;
            this.phanloaigv = phanloaigv;
            this.anh = anh;
        }
    }
}
