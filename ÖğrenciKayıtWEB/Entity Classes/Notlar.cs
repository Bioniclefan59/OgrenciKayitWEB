using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiKayit.Entity_Classes
{
    public class Notlar
    {
        public int ogrenci_no { get; set; }
        public int ders_id { get; set; }
        public int ara_sinav1 { get; set; }
        public int ara_sinav2 { get; set; }
        public int final { get; set; }

        public virtual Dersler Dersler { get; set; }
        public virtual Ogrenciler Ogrenciler { get; set; }
    }
}