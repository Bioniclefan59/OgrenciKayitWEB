using OgrenciBilgiKayit.Entity_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Ogrenciler
{
    [Key]
    public int ogrenci_no { get; set; }
    public string ad { get; set; }
    public string soyad { get; set; }
    public string bolum { get; set; }
    public int sinif { get; set; }
    public DateTime dogum_tarihi { get; set; }
    public string cinsiyet { get; set; }
    public DateTime kayit_tarihi { get; set; }
    public int BolumID { get; set; }

    public virtual ICollection<Dersler> Dersler { get; set; }
    public virtual ICollection<Notlar> Notlar { get; set; }
    public virtual ICollection<OgrenciAtamalari> OgrenciAtamalari { get; set; }
}