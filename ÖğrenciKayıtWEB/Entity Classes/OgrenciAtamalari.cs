using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiKayit.Entity_Classes
{
    public class OgrenciAtamalari
    {
        public int AtamaID { get; set; }
        public int ogrenci_no { get; set; }
        public int DersID { get; set; }

        public virtual Dersler Dersler { get; set; }
        public virtual Ogrenciler Ogrenciler { get; set; }
    }
}