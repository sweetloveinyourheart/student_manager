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
    public class KetQuaBUS
    {
        private static KetQuaBUS instance;
        public static KetQuaBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KetQuaBUS();
                return instance;
            }
        }

        private KetQuaBUS() { }

        public void FillKetQuaList(DataGridView dgr)
        {
            List<KetQua> ketQuas = KetQuaDAO.Instance.FormLoad();
            // Đưa ra DataGridView
            dgr.DataSource = ketQuas;
        }

        public void FillKQListByMSV(
            DataGridView dgr,
            TextBox msv,
            ComboBox cboMonHoc
            )
        {
            List<KetQua> ketQuas = KetQuaDAO.Instance.FindKQByMSV(msv.Text, cboMonHoc.Text);
            // Đưa ra DataGridView
            dgr.DataSource = ketQuas;
        }

        public void ThemKetQua(
           ErrorProvider errorProvider1,
           DataGridView dgrDiem,
           TextBox txtMaSV,
           ComboBox cboLop,
           ComboBox cboMonHoc,
           TextBox txtDiemThi1,
           TextBox txtDiemTB,
           TextBox txtDiemTK,
           ComboBox cboHanhKiem,
           ComboBox cboHocKi,
           TextBox txtGhiChu
           )
        {
            errorProvider1.Clear();
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
                txtMaSV.Focus();
            }
            else if (txtMaSV.Text == dgrDiem.CurrentRow.Cells[0].Value.ToString() && cboMonHoc.Text == dgrDiem.CurrentRow.Cells[3].Value.ToString())
            {
                {
                    MessageBox.Show("Sinh viên này đã được nhập điểm môn: " + cboMonHoc.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();

                }
            }
            else if (cboLop.Text == "")
            {
                errorProvider1.SetError(cboLop, "Mã lớp không để trống!");
                cboLop.Focus();
            }
            else if (cboHocKi.Text == "")
            {
                errorProvider1.SetError(cboHocKi, "Học kỳ không để trống!");
                cboHocKi.Focus();
            }
            else if (cboMonHoc.Text == "")
            {
                errorProvider1.SetError(cboMonHoc, "Mã môn không để trống!");
                cboMonHoc.Focus();
            }
            else if (KetQuaDAO.Instance.ThemKetQua(
                txtMaSV.Text,
                cboLop.Text,
                cboMonHoc.Text,
                Double.Parse(txtDiemThi1.Text),
                Double.Parse(txtDiemTB.Text),
                Double.Parse(txtDiemTK.Text),
                cboHanhKiem.Text,
                int.Parse(cboHocKi.Text),
                txtGhiChu.Text
                ))
            {
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");
            }
            else
            {
                MessageBox.Show("Nhập mã sinh viên không chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
            }
        }

        public void SuaKetQua(
           ErrorProvider errorProvider1,
           DataGridView dgrDiem,
           TextBox txtMaSV,
           ComboBox cboLop,
           ComboBox cboMonHoc,
           TextBox txtDiemThi1,
           TextBox txtDiemTB,
           TextBox txtDiemTK,
           ComboBox cboHanhKiem,
           ComboBox cboHocKi,
           TextBox txtGhiChu
           )
        {
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Mã sinh viên không để trống!");
            }
            else
            {
                KetQuaDAO.Instance.SuaKetQua(
                    txtMaSV.Text,
                    cboLop.Text,
                    cboMonHoc.Text,
                    Double.Parse(txtDiemThi1.Text),
                    Double.Parse(txtDiemTB.Text),
                    Double.Parse(txtDiemTK.Text),
                    cboHanhKiem.Text,
                    int.Parse(cboHocKi.Text),
                    txtGhiChu.Text
                );
                MessageBox.Show("Nhập thông tin thành công", "Thông báo!");
            }
        }

        public void XoaKetQua(TextBox txtMaSV)
        {
            if (KetQuaDAO.Instance.XoaKetQua(txtMaSV.Text))
            {
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo!");
            }

        }
    }
}
