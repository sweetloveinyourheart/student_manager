using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class KetQuaDAO
    {
        private static KetQuaDAO instance;

        public static KetQuaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KetQuaDAO();
                return instance;
            }
        }

        private KetQuaDAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();

        public List<KetQua> FormLoad()
        {
            List<KetQua> list = new List<KetQua>();

            list = db.tblKET_QUAs.Select(s => new KetQua(
                   s.MaSV,
                   s.HoTen,
                   s.MaLop,
                   s.MaMon,
                   s.DiemTB,
                   s.DiemThiLan1,
                   s.DiemThiLan2,
                   s.DiemTongKet,
                   s.HanhKiem,
                   s.HocKi,
                   s.GhiChu
                )
            ).ToList();

            return list;
        }

        public List<KetQua> FindKQByMSV(string msv, string mamon)
        {
            List<KetQua> list = new List<KetQua>();

            list = db.tblKET_QUAs
                .Where(eq => eq.MaSV == msv && eq.MaMon == mamon)
                .Select(s => new KetQua(
                   s.MaSV,
                   s.HoTen,
                   s.MaLop,
                   s.MaMon,
                   s.DiemTB,
                   s.DiemThiLan1,
                   s.DiemThiLan2,
                   s.DiemTongKet,
                   s.HanhKiem,
                   s.HocKi,
                   s.GhiChu
                )
            ).ToList();

            return list;
        }

        public bool ThemKetQua(
            string masv,
            string malop,
            string mamon, 
            double? diemthilan1,
            double? diemtb, 
            double? diemtongket,
            string hanhkiem, 
            int? hocki,
            string ghichu
            )
        {
            tblSINH_VIEN sv = db.tblSINH_VIENs.Where(eq => eq.MaSv == masv).Select(s => s).FirstOrDefault();
            if (sv == null)
            {
                return false;
            }

            tblKET_QUA newKQ = new tblKET_QUA();

            newKQ.MaSV = masv;
            newKQ.HoTen = sv.HoTen;
            newKQ.MaLop = malop;
            newKQ.MaMon = mamon;
            newKQ.DiemThiLan1 = diemthilan1;
            newKQ.DiemTB = diemtb;
            newKQ.DiemTongKet = diemtongket;
            newKQ.HanhKiem = hanhkiem;
            newKQ.HocKi = hocki;
            newKQ.GhiChu = ghichu;

            db.tblKET_QUAs.InsertOnSubmit(newKQ);

            db.SubmitChanges();

            return true;
        }

        public bool SuaKetQua(
            string masv,
            string malop,
            string mamon,
            double? diemthilan1,
            double? diemtb,
            double? diemtongket,
            string hanhkiem,
            int? hocki,
            string ghichu
            )
        {
            tblKET_QUA kq = db.tblKET_QUAs.Where(eq => eq.MaSV == masv).Select(s => s).FirstOrDefault();
            if (kq == null)
            {
                return false;
            }

            kq.MaSV = masv;
            kq.MaLop = malop;
            kq.MaMon = mamon;
            kq.DiemThiLan1 = diemthilan1;
            kq.DiemTB = diemtb;
            kq.DiemTongKet = diemtongket;
            kq.HanhKiem = hanhkiem;
            kq.HocKi = hocki;
            kq.GhiChu = ghichu;

            db.SubmitChanges();

            return true;
        }

        public bool XoaKetQua(string masv)
        {
            tblKET_QUA deleted = db.tblKET_QUAs.Select(s => s).FirstOrDefault(s => s.MaSV.Equals(masv));

            if (deleted == null)
            {
                return false;
            }

            db.tblKET_QUAs.DeleteOnSubmit(deleted);

            db.SubmitChanges();

            return true;
        }
    }
}
