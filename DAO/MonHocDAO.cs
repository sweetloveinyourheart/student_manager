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
    }
}
