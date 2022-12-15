using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class MonHocDAO
    {
        private static MonHocDAO instance;

        public static MonHocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MonHocDAO();
                return instance;
            }
        }

        private MonHocDAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();
        public List<MonHoc> FormLoad()
        {
            List<MonHoc> list = new List<MonHoc>();

            list = db.tblMONs.Select(s => new MonHoc(
                s.MaMon,
                s.TenMon,
                s.SoDVHT,
                s.MaGV,
                s.HocKi,
                s.MaKhoa
                )
            ).ToList();

            return list;
        }

        public List<tblMON> CBLoadByName(string makhoa)
        {
            List<tblMON> list = new List<tblMON>();

            list = db.tblMONs.Select(s => s).Where(eq => eq.MaKhoa == makhoa).ToList();

            return list;
        }

        public List<tblMON> CBLoadByHocKy(string hocky)
        {
            List<tblMON> list = new List<tblMON>();

            list = db.tblMONs.Select(s => s).Where(eq => eq.HocKi == hocky).ToList();

            return list;
        }

        public bool ThemMonHoc(
            string mamon,
            string tenmon, 
            int? soDVHT, 
            string magv,
            string hocki, 
            string makhoa
            )
        {
            MonHoc sv = db.tblMONs.Where(eq => eq.MaMon == mamon).Select(s => new MonHoc()).FirstOrDefault();
            if (sv != null)
            {
                return false;
            }

            tblMON newMon = new tblMON();

            newMon.MaMon = mamon;
            newMon.TenMon = tenmon;
            newMon.SoDVHT = soDVHT;
            newMon.MaKhoa = makhoa;
            newMon.MaGV = magv;
            newMon.HocKi = hocki;

            db.tblMONs.InsertOnSubmit(newMon);

            db.SubmitChanges();

            return true;
        }

        public bool SuaMonHoc(
            string mamon,
            string tenmon,
            int? soDVHT,
            string magv,
            string hocki,
            string makhoa
            )
        {
            tblMON mon = db.tblMONs.Where(eq => eq.MaMon == mamon).Select(s => s).FirstOrDefault();
            if (mon == null)
            {
                return false;
            }

            mon.MaMon = mamon;
            mon.TenMon = tenmon;
            mon.SoDVHT = soDVHT;
            mon.MaKhoa = makhoa;
            mon.MaGV = magv;
            mon.HocKi = hocki;

            db.SubmitChanges();

            return true;
        }

        public bool XoaMonHoc(
            string mamon
            )
        {
            tblMON mon = db.tblMONs.Where(eq => eq.MaMon == mamon).Select(s => s).FirstOrDefault();
            if (mon == null)
            {
                return false;
            }

            db.tblMONs.DeleteOnSubmit(mon);

            db.SubmitChanges();

            return true;
        }
    }
}
