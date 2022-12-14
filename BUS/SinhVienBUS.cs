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
    public class SinhVienBUS
    {
        private static SinhVienBUS instance;
        public static SinhVienBUS Instance 
        { 
            get 
            {
                if (instance == null)
                    instance = new SinhVienBUS();
                return instance; 
            } 
        }

        private SinhVienBUS() { }

        public void FillSinhVienList(DataGridView dgrDSSV)
        {
            // Đưa ra DataGridView
            dgrDSSV.DataSource = SinhVienDAO.Instance.FormLoad();
        }

        public void FillSinhVienListByMaLop(DataGridView dgrDSSV, ComboBox cboLop)
        {
            // Đưa ra DataGridView
            dgrDSSV.DataSource = SinhVienDAO.Instance.FindSvByMaLop(cboLop.Text);
        }

        public void ThemSinhVien(
            ErrorProvider errorProvider1,
            TextBox txtMaSV,
            TextBox txtHoTen,
            TextBox txtDiaChi,
            MaskedTextBox mskNgaySinh,
            ComboBox cboGioiTinh,
            ComboBox cboMalop
            )      
        {
            bool isSuccess = SinhVienDAO.Instance.ThemSV(
                txtMaSV.Text,
                txtHoTen.Text,
                mskNgaySinh.Text,
                cboGioiTinh.Text,
                txtDiaChi.Text,
                cboMalop.Text
            );

            errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
            }
            else if (cboMalop.Text == "")
            {
                errorProvider1.SetError(cboMalop, "Mã lớp không để trống!");
            }
            else if (!isSuccess)
            {
                MessageBox.Show("Bạn đã nhập trùng mã sinh viên ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
            }

            MessageBox.Show("Thêm mới thành công", "Thông báo!");
        }

        public void XoaSinhVien(
            TextBox txtMaSV
            )
        {
            bool isSuccess = SinhVienDAO.Instance.XoaSV(txtMaSV.Text);
            
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Xoa
                if (!isSuccess)
                {
                    {
                        MessageBox.Show("Bạn phải xóa Mã Sinh viên " + txtMaSV.Text + "từ bảng Kết quả học tập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }

        public void SuaSinhVien(
            ErrorProvider errorProvider1,
            TextBox txtMaSV,
            TextBox txtHoTen,
            TextBox txtDiaChi,
            MaskedTextBox mskNgaySinh,
            ComboBox cboGioiTinh,
            ComboBox cboMalop
            )
        {
            errorProvider1.Clear();
            if (txtMaSV.Text == "")
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
            else if (cboMalop.Text == "")
                errorProvider1.SetError(cboMalop, "Mã lớp không để trống!");


            else
            {
                SinhVienDAO.Instance.SuaSV(
                    txtMaSV.Text,
                    txtHoTen.Text,
                    mskNgaySinh.Text,
                    cboGioiTinh.Text,
                    txtDiaChi.Text,
                    cboMalop.Text
                );
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo!");
            }

        }
    }
}
