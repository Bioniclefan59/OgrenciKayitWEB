<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnaForm.aspx.cs" Inherits="OgrenciBilgiKayitWEB.AnaForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AnaForm</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Lütfen yapmak istediğiniz işlemi seçiniz</h1>
        <asp:Button ID="btnOgrenciKayit" runat="server" Text="Öğrenci Kayıt" OnClick="btnOgrenciKayit_Click" />
        <asp:Button ID="btnOgrenciSorgulama" runat="server" Text="Öğrenci Sorgulama" OnClick="btnOgrenciSorgulama_Click" />
        <asp:Button ID="btnDersKaydi" runat="server" Text="Ders Kaydı" OnClick="btnDersKaydi_Click" />
        <asp:Button ID="btnSinavSonuclari" runat="server" Text="Sınav Sonuçları" OnClick="btnSinavSonuclari_Click" />
    </form>
</body>
</html>

