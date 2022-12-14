using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

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

        public void FillSinhVienList(DataGridView dgr)
        {
            // Đưa ra DataGridView
            dgr.DataSource = KetQuaDAO.Instance.FormLoad();
        }

        public void FillKQListByMSV(
            DataGridView dgr,
            TextBox msv,
            ComboBox cboMonHoc
            )
        {
            // Đưa ra DataGridView
            dgr.DataSource = KetQuaDAO.Instance.FindKQByMSV(msv.Text, cboMonHoc.Text);
        }
    }
}
