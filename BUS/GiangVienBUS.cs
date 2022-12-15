using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAO;

namespace BUS
{
    public class GiangVienBUS
    {
        private static GiangVienBUS instance;
        public static GiangVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiangVienBUS();
                return instance;
            }
        }

        private GiangVienBUS() { }

        public void FillGiangVienDGR(DataGridView dgrGiangVien)
        {
            List<GiangVien> GiangViens = GiangVienDAO.Instance.FormLoad();
            dgrGiangVien.DataSource = GiangViens;
        }

        public void ThemGiangVien(
            ErrorProvider errorProvider1,
            TextBox txtMaGV,
            TextBox txtHoTen,
            ComboBox cboGioiTinh,
            MaskedTextBox mskPhone,
            TextBox txtEmail,
            ComboBox cboPhanloai
            )
        {
            errorProvider1.Clear();
            if (txtMaGV.Text == "")
            {
                errorProvider1.SetError(txtMaGV, "Mã giảng viên không để trống!");
            }

            else if (!GiangVienDAO.Instance.ThemGiangVien(
                txtMaGV.Text,
                txtHoTen.Text,
                cboGioiTinh.Text,
                mskPhone.Text,
                txtEmail.Text,
                cboPhanloai.Text
                ))
            {
                MessageBox.Show("Bạn đã nhập trùng mã giảng viên", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaGV.Focus();
            }
            else
            {
                MessageBox.Show("Thêm mới thành công", "Thông báo!");
            }
        }

        public void SuaGiangVien(
            ErrorProvider errorProvider1,
            TextBox txtMaGV,
            TextBox txtHoTen,
            ComboBox cboGioiTinh,
            MaskedTextBox mskPhone,
            TextBox txtEmail,
            ComboBox cboPhanloai
            )
        {
            errorProvider1.Clear();
            if (txtMaGV.Text == "")
                errorProvider1.SetError(txtMaGV, "Mã giảng viên không để trống!");
            else
            {
                GiangVienDAO.Instance.SuaGiangVien(
                 txtMaGV.Text,
                 txtHoTen.Text,
                 cboGioiTinh.Text,
                 mskPhone.Text,
                 txtEmail.Text,
                 cboPhanloai.Text
                 );
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        public void XoaGiangVien(
             TextBox txtMaGV
            )
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Thuc hien xoa du lieu
                GiangVienDAO.Instance.XoaGiangVien(txtMaGV.Text);
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");

            }
        }
    }
}
