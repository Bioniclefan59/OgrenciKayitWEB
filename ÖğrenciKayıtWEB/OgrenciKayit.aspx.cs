using System;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using OgrenciBilgiKayitWEB.OkulDBContext;

namespace OgrenciBilgiKayitWEB
{
    public enum OgrenciCinsiyeti
    {
        Erkek,
        Kadın
    }
    public partial class OgrenciKayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadComboBoxes();
                lblDogumTarihiFormat.Text = "(gg/aa/yyyy)";
                txtDogumTarihi.Attributes["placeholder"] = "gg/aa/yyyy";
            }
        }

        private void LoadComboBoxes()
        {
            // Cinsiyeti doldur
            var cinsiyetValues = Enum.GetValues(typeof(OgrenciCinsiyeti));
            foreach (var value in cinsiyetValues)
            {
                ListItem item = new ListItem(value.ToString(), ((int)value).ToString());
                ddlOgrenciCinsiyeti.Items.Add(item);
            }

            // Bölümü doldur
            using (var dbContext = new OkulDBCntxt())
            {
                var bolumler = dbContext.Bolumler.ToList();
                foreach (var bolum in bolumler)
                {
                    ListItem item = new ListItem(bolum.BolumAdi, bolum.BolumID.ToString());
                    ddlBolum.Items.Add(item);
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Formdaki bilgileri al
                string ogrenciAdi = txtOgrenciAdi.Text;
                string ogrenciSoyadi = txtOgrenciSoyadi.Text;
                OgrenciCinsiyeti cinsiyet = (OgrenciCinsiyeti)Enum.Parse(typeof(OgrenciCinsiyeti), ddlOgrenciCinsiyeti.SelectedValue);
                string bolumAdi = ddlBolum.SelectedItem.Text;
                int sinif = int.Parse(txtSinif.Text);
                string inputDate = txtDogumTarihi.Text.Trim();
                DateTime dogumTarihi;
                DateTime kayitTarihi = DateTime.Now;

                if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dogumTarihi))
                {
                    using (var dbContext = new OkulDBCntxt())
                    {
                        Ogrenciler ogrenci = new Ogrenciler
                        {
                            ad = ogrenciAdi,
                            soyad = ogrenciSoyadi,
                            cinsiyet = cinsiyet.ToString(),
                            bolum = bolumAdi,
                            BolumID = dbContext.Bolumler.FirstOrDefault(b => b.BolumAdi == bolumAdi)?.BolumID ?? 0,
                            sinif = sinif,
                            dogum_tarihi = dogumTarihi,
                            kayit_tarihi = kayitTarihi
                        };

                        // Öğrenciyi ekle ve kaydet
                        dbContext.Ogrenciler.Add(ogrenci);
                        dbContext.SaveChanges();

                        // Başarılı
                        lblStatus.Text = "Öğrenci kaydedildi.";
                        lblStatus.CssClass = "text-success";
                    }
                }
                else
                {
                    // Tarih yanlış girildi
                    lblStatus.Text = "Geçersiz tarih formatı! Tarihi gg/aa/yyyy formatında giriniz.";
                    lblStatus.CssClass = "text-danger";
                }
            }
            catch (DbUpdateException dbEx)
            {
                var innerExceptionMessage = dbEx.InnerException?.Message ?? "No inner exception message available";
                lblStatus.Text = $"Database error: {innerExceptionMessage}";
                lblStatus.CssClass = "text-danger";

            }
        }


        protected void btnIptal_Click(object sender, EventArgs e)
        {

            Response.Redirect("AnaForm.aspx");
        }
    }
}
