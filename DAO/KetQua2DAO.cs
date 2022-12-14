using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KetQua2DAO
    {
        private static KetQua2DAO instance;

        public static KetQua2DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KetQua2DAO();
                return instance;
            }
        }

        private KetQua2DAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();

        public List<KetQua2> FormLoad()
        {
            List<KetQua2> list = new List<KetQua2>();

            list = db.tblKET_QUA2s.Select(s => new KetQua2(
                s.MaSV,
                s.HoTen,
                s.MaLop,
                s.TenMon,
                s.DiemThiLai,
                s.HocKi
                )
            ).ToList();

            return list;
        }

        public bool ThemKetQua2(
            string masv,
            string malop,
            string tenmon,
            string diemthilai,
            string hocki
            )
        {
            tblSINH_VIEN sv = db.tblSINH_VIENs.Where(eq => eq.MaSv == masv).Select(s => s).FirstOrDefault();
            if (sv == null)
            {
                return false;
            }

            tblKET_QUA2 newKQ = new tblKET_QUA2();

            newKQ.MaSV = masv;
            newKQ.HoTen = sv.HoTen;
            newKQ.MaLop = malop;
            newKQ.TenMon = tenmon;
            newKQ.DiemThiLai = diemthilai;
            newKQ.HocKi = hocki;

            db.tblKET_QUA2s.InsertOnSubmit(newKQ);

            db.SubmitChanges();

            return true;
        }

        public bool SuaKetQua2(
            string masv,
            string malop,
            string tenmon,
            string diemthilai,
            string hocki
            )
        {
            tblKET_QUA2 kq2 = db.tblKET_QUA2s.Where(eq => eq.MaSV == masv).Select(s => s).FirstOrDefault();
            if (kq2 == null)
            {
                return false;
            }

            kq2.MaSV = masv;
            kq2.MaLop = malop;
            kq2.TenMon = tenmon;
            kq2.DiemThiLai = diemthilai;
            kq2.HocKi = hocki;

            db.SubmitChanges();

            return true;
        }

        public bool XoaKetQua2(string masv)
        {
            tblKET_QUA2 deleted = db.tblKET_QUA2s.Select(s => s).FirstOrDefault(s => s.MaSV.Equals(masv));

            if(deleted == null)
            {
                return false;
            }

            db.tblKET_QUA2s.DeleteOnSubmit(deleted);

            db.SubmitChanges();

            return true;
        }
    }
}
