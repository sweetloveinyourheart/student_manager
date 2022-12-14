using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace BUS
{
    public class LoginBUS
    {
        private static LoginBUS instance;
        public static LoginBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoginBUS();
                return instance;
            }
        }
        private LoginBUS() { }

        public bool KiemTraAdmin(
            TextBox txtTenDn,
            TextBox txtMatKhau
            )
        {
            bool kiemtraadmin = LoginDAO.Instance.KiemTraAdmin(
                txtTenDn.Text, txtMatKhau.Text);
            return kiemtraadmin;

        }

        public bool KiemTraMember(
            TextBox txtTenDn,
            TextBox txtMatKhau
            )
        {
            bool kiemtramember = LoginDAO.Instance.KiemTraMember(
                txtTenDn.Text, txtMatKhau.Text);
            return kiemtramember;
        }
    }
}
