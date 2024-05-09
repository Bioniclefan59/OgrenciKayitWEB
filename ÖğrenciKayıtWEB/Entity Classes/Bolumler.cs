using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciBilgiKayit.Entity_Classes
{
    public class Bolumler
    {
        public int BolumID { get; set; }
        public string BolumAdi { get; set; }

        public virtual ICollection<Dersler> Dersler { get; set; }
    }
}