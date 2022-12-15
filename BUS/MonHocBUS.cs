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
    public class MonHocBUS
    {
        private static MonHocBUS instance;
        public static MonHocBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new MonHocBUS();
                return instance;
            }
        }

        private MonHocBUS() { }

        public void FillMonDGR(DataGridView dgrMon)
        {
            List<MonHoc> monhocs = MonHocDAO.Instance.FormLoad();
            dgrMon.DataSource = monhocs;
        }

        public void FillMonList(ComboBox cboKhoa)
        {
            List<MonHoc> monhocs = MonHocDAO.Instance.FormLoad();
            cboKhoa.Items.Clear();
            foreach (MonHoc mon in monhocs)
            {
                cboKhoa.Items.Add(mon.TenMon);
            }
        }

        public void FillCBByMaKhoa(ComboBox cboKhoa, ComboBox cboMonHoc)
        {
            List<tblMON> monhocs = MonHocDAO.Instance.CBLoadByName(cboKhoa.Text);
            cboMonHoc.Items.Clear();
            foreach (tblMON mon in monhocs)
            {
                cboMonHoc.Items.Add(mon.MaMon);
            }
        }

        public void FillCBByHocKy(ComboBox cboHocKy, ComboBox cboMonHoc)
        {
            List<tblMON> monhocs = MonHocDAO.Instance.CBLoadByHocKy(cboHocKy.Text);
            cboMonHoc.Items.Clear();
            foreach (tblMON mon in monhocs)
            {
                cboMonHoc.Items.Add(mon.MaMon);
            }
        }
    }
}
