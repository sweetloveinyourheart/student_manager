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

        public void FormLoad(DataGridView dgrLogin)
        {
            dgrLogin.DataSource = LoginDAO.Instance.FormLoad();
        }

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

        public bool isValidAccount(
            TextBox txtAccount,
            TextBox txtOldPass
            )
        {
            bool isvalid = LoginDAO.Instance.isValidAccount(txtAccount.Text, txtOldPass.Text);
            return isvalid;
        }

        public bool UpdateUser(
            ErrorProvider error,
            TextBox txtAccount,
            TextBox txtOldPassword,
            TextBox txtNewPassword,
            TextBox txtConfirmPassword,
            ComboBox cbRole
            )
        {
            error.Clear();
            if (txtAccount.Text == "")
            {
                error.SetError(txtAccount, "Tên tài khoản không  để trống !");
                txtAccount.Focus();
                return false;
            }
            else if (txtOldPassword.Text == "")
            {
                error.SetError(txtOldPassword, "Bạn chưa nhập mật khẩu cũ!");
                txtOldPassword.Focus();
                return false;
            }
            else if (txtNewPassword.Text == "")
            {
                error.SetError(txtNewPassword, "Bạn chưa nhập mật khẩu !");
                txtNewPassword.Focus();
                return false;
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Bạn nhập lại mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!LoginDAO.Instance.isValidAccount(txtAccount.Text, txtOldPassword.Text))
            {
                error.SetError(txtAccount, "Tài khoản không tồn tại!");
                return false;
            }
            else
            {
                LoginDAO.Instance.UpdateUser(txtAccount.Text, txtNewPassword.Text, txtOldPassword.Text, cbRole.Text);
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                return true;
            }

        }
        public void ThemNguoiDung(
            ErrorProvider errorProvider1,
            TextBox txtTaikhoan,
            TextBox txtMK,
            TextBox txtConfimMk,
            TextBox txtHoTen,
            ComboBox cboGioiTinh,
            MaskedTextBox mskPhone,
            TextBox txtEmail,
            ComboBox cboQuyen
            )
        {
            errorProvider1.Clear();
            if (txtTaikhoan.Text == "")
            {
                errorProvider1.SetError(txtTaikhoan, "Tên tài khoản không  để trống !");
                txtTaikhoan.Focus();
            }
            else if (txtMK.Text == "")
            {
                errorProvider1.SetError(txtMK, "Bạn chưa nhập mật khẩu !");
                txtMK.Focus();
            }
            else if (txtConfimMk.Text == "")
            {
                errorProvider1.SetError(txtConfimMk, "Bạn chưa nhập lại mật khẩu !");
                txtConfimMk.Focus();
            }
            else if (txtConfimMk.Text != txtMK.Text)

                MessageBox.Show("Bạn nhập lại mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (!LoginDAO.Instance.ThemNguoiDung(
                txtTaikhoan.Text, 
                txtMK.Text, 
                txtHoTen.Text, 
                cboGioiTinh.Text,
                mskPhone.Text,
                txtEmail.Text,
                cboQuyen.Text
                ))
            {
                MessageBox.Show("Tài khoản " + txtTaikhoan.Text + " đã tồn tại", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaikhoan.Focus();
             
            }
            else
            {

                MessageBox.Show("Thêm mới thành công", "Thông báo!");

            }
        }

        public void XoaNguoiDung(
            TextBox txtTaikhoan
            )
        {
            LoginDAO.Instance.XoaSV(txtTaikhoan.Text);
        }

        public void SuaNguoiDung(
            ErrorProvider errorProvider1,
            TextBox txtTaikhoan,
            TextBox txtMK,
            TextBox txtHoTen,
            ComboBox cboGioiTinh,
            MaskedTextBox mskPhone,
            TextBox txtEmail,
            ComboBox cboQuyen
            )
        {
            errorProvider1.Clear();
            if (txtTaikhoan.Text == "")
                errorProvider1.SetError(txtTaikhoan, "Tên tài khoản không để trống!");
            else
            {
                LoginDAO.Instance.SuaNguoiDung(
                    txtTaikhoan.Text,
                    txtMK.Text,
                    txtHoTen.Text,
                    cboGioiTinh.Text,
                    mskPhone.Text,
                    txtEmail.Text,
                    cboQuyen.Text
                    );
            }
        }
    }
}
