using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAO
{
    public class GiangVienDAO
    {
        private static GiangVienDAO instance;

        public static GiangVienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiangVienDAO();
                return instance;
            }
        }

        private GiangVienDAO() { }

        QuanLyDiemDataContext db = new QuanLyDiemDataContext();
        public List<GiangVien> FormLoad()
        {
            List<GiangVien> list = new List<GiangVien>();

            list = db.tblGIANG_VIENs.Select(s => new GiangVien(
                s.MaGV,
                s.TenGV,
                s.GioiTinh,
                s.Phone,
                s.Email,
                s.PhanLoaiGV,
                s.Anh
                )
            ).ToList();

            return list;
        }
    }
}
