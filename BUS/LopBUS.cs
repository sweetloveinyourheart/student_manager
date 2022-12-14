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
    public class LopBUS
    {
        private static LopBUS instance;
        public static LopBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new LopBUS();
                return instance;
            }
        }

        private LopBUS() { }

        public void FillLopList(ComboBox cboLop)
        {
            List<Lop> lops = LopDAO.Instance.FormLoad();
            foreach (Lop lop in lops)
            {
                cboLop.Items.Add(lop.MaLop);
            }
        }

        public void FillLopListMaKhoa(ComboBox cboKhoa, ComboBox cboLop)
        {
            List<Lop> lops = LopDAO.Instance.CBLoadByMaKhoa(cboKhoa.Text);
            cboLop.Items.Clear();
            foreach (Lop lop in lops)
            {
                cboLop.Items.Add(lop.MaLop);
            }
        }
    }
}
