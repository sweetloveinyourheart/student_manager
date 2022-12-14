using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Lop
    {
        private string makhoa;

        public string MaKhoa { get { return makhoa; } set { makhoa = value; } }

        private string malop;

        public string MaLop { get { return malop; } set { malop = value; } }

        private string tenlop;

        public string Tenlop { get { return tenlop; } set { tenlop = value; } }

        public Lop()
        {
        }

        public Lop(
            string makhoa, 
            string malop,
            string tenlop
            )
        {

            this.makhoa = makhoa;
            this.malop = malop;
            this.tenlop = tenlop;
        }
    }
}
