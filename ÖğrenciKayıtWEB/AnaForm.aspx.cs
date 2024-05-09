using System;
using System.Web.UI;

namespace OgrenciBilgiKayitWEB
{
    public partial class AnaForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOgrenciKayit_Click(object sender, EventArgs e)
        {
            Response.Redirect("OgrenciKayit.aspx");
        }

        protected void btnOgrenciSorgulama_Click(object sender, EventArgs e)
        {
            Response.Redirect("OgrenciSorgulama.aspx");
        }

        protected void btnDersKaydi_Click(object sender, EventArgs e)
        {
            Response.Redirect("DersKaydi.aspx");
        }

        protected void btnSinavSonuclari_Click(object sender, EventArgs e)
        {
            Response.Redirect("SinavSonuclari.aspx");
        }
    }
}
