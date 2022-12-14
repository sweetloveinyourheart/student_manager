using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KetQua3DAO
    {
        private static KetQua3DAO instance;

        public static KetQua3DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KetQua3DAO();
                return instance;
            }
        }

        private KetQua3DAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();

        public List<KetQua3> FormLoad()
        {
            List<KetQua3> list = new List<KetQua3>();

            list = db.tblKET_QUA3s.Select(s => new KetQua3(
                s.MaSV,
                s.HoTen,
                s.MaLop,
                s.TenMon,
                s.DiemHocLai,
                s.HocKi
                )
            ).ToList();

            return list;
        }

        public bool ThemKetQua3(
            string masv,
            string malop,
            string tenmon,
            double? diemhoclai,
            int? hocki
            )
        {
            tblSINH_VIEN sv = db.tblSINH_VIENs.Where(eq => eq.MaSv == masv).Select(s => s).FirstOrDefault();
            if (sv == null)
            {
                return false;
            }

            tblKET_QUA3 newKQ = new tblKET_QUA3();

            newKQ.MaSV = masv;
            newKQ.HoTen = sv.HoTen;
            newKQ.MaLop = malop;
            newKQ.TenMon = tenmon;
            newKQ.DiemHocLai = diemhoclai;
            newKQ.HocKi = hocki;

            db.tblKET_QUA3s.InsertOnSubmit(newKQ);

            db.SubmitChanges();

            return true;
        }

        public bool SuaKetQua3(
            string masv,
            string malop,
            string tenmon,
            double? diemhoclai,
            int? hocki
            )
        {
            tblKET_QUA3 kq3 = db.tblKET_QUA3s.Where(eq => eq.MaSV == masv).Select(s => s).FirstOrDefault();
            if (kq3 == null)
            {
                return false;
            }

            kq3.MaSV = masv;
            kq3.MaLop = malop;
            kq3.TenMon = tenmon;
            kq3.DiemHocLai = diemhoclai;
            kq3.HocKi = hocki;

            db.SubmitChanges();

            return true;
        }

        public bool XoaKetQua3(string masv)
        {
            tblKET_QUA3 deleted = db.tblKET_QUA3s.Select(s => s).FirstOrDefault(s => s.MaSV.Equals(masv));

            if (deleted == null)
            {
                return false;
            }

            db.tblKET_QUA3s.DeleteOnSubmit(deleted);

            db.SubmitChanges();

            return true;
        }
    }
}
