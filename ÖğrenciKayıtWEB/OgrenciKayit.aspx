<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OgrenciKayit.aspx.cs" Inherits="OgrenciBilgiKayitWEB.OgrenciKayit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ogrenci Kayit</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Ogrenci Kayit Formu</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblStatus" runat="server" CssClass="text-success"></asp:Label>
            <br /><br />
            <asp:Label ID="lblOgrenciAdi" runat="server" Text="Öğrenci Adı:"></asp:Label>
            <asp:TextBox ID="txtOgrenciAdi" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblOgrenciSoyadi" runat="server" Text="Öğrenci Soyadı:"></asp:Label>
            <asp:TextBox ID="txtOgrenciSoyadi" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblOgrenciCinsiyeti" runat="server" Text="Öğrenci Cinsiyeti:"></asp:Label>
            <asp:DropDownList ID="ddlOgrenciCinsiyeti" runat="server"></asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblBolum" runat="server" Text="Bölüm:"></asp:Label>
            <asp:DropDownList ID="ddlBolum" runat="server"></asp:DropDownList>
            <br /><br />
            <asp:Label ID="lblSinif" runat="server" Text="Sınıf:"></asp:Label>
            <asp:TextBox ID="txtSinif" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblDogumTarihiFormat" runat="server" Text="(gg/aa/yyyy)" CssClass="text-muted"></asp:Label>
            <asp:TextBox ID="txtDogumTarihi" runat="server" CssClass="form-control"></asp:TextBox>
            <br /><br />
            <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
            <asp:Button ID="btnIptal" runat="server" Text="İptal" OnClick="btnIptal_Click" />
        </div>
    </form>
</body>
</html>
