using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonHoc
    {
        private string mamon;

        public string MaMon { get { return mamon; } set { mamon = value; } }

        private string tenmon;

        public string TenMon { get { return tenmon; } set { tenmon = value; } }

        private string sodvht;

        public string SoDVHT { get { return sodvht; } set { sodvht = value; } }

        private string magv;

        public string MaGV { get { return magv; } set { magv = value; } }

        private string hocki;

        public string HocKi { get { return hocki; } set { hocki = value; } }

        private string makhoa;

        public string Makhoa { get { return makhoa; } set { makhoa = value; } }

        public MonHoc()
        {
        }

        public MonHoc(
            string mamon,
            string tenmon,
            string sodvht,
            string magv,
            string hocki,
            string makhoa
            )
        {
            this.mamon = mamon;
            this.tenmon = tenmon;
            this.sodvht = sodvht;
            this.magv = magv;
            this.hocki = hocki;
            this.makhoa = makhoa;
        }
    
}
}
