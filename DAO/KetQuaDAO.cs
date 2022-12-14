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
    }
}
