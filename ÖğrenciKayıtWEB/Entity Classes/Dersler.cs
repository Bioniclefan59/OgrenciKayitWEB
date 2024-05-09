using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiKayit.Entity_Classes
{
    public class Dersler
    {
        public int DersID { get; set; }
        public int BolumID { get; set; }
        public string DersKodu { get; set; }
        public string DersAdi { get; set; }
        public int Kredi { get; set; }

        public virtual Bolumler Bolumler { get; set; }
        public virtual ICollection<Notlar> Notlar { get; set; }
        public virtual ICollection<Ogrenciler> Ogrenciler { get; set; }
        public virtual ICollection<OgrenciAtamalari> OgrenciAtamalari { get; set; }
    }
}