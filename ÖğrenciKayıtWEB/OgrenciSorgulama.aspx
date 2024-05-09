<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OgrenciSorgulama.aspx.cs" Inherits="OgrenciBilgiKayitWEB.OgrenciSorgulama" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Öğrenci Sorgulama</title>
        <script type="text/javascript" src="./Scripts/AutoComplete.js"></script>
    <%--C:\Users\ataberkk\Documents\repos\ÖğrenciKayıtWEB\ÖğrenciKayıtWEB\Scripts\AutoComplete.js--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:TextBox ID="txtOgrenciIsmi" runat="server" CssClass="form-control" oninput="autofillStudentNumber(this.value)" />
        </div>
        <div>
            <label for="txtOgrenciNo">Öğrenci Numarası:</label>
            <input type="text" id="txtOgrenciNo" runat="server" class="form-control" oninput="autofillStudentName(this.value)" />
        </div>
        <div>
            <label for="txtKayitTarihi">Kayıt Tarihi (gg/aa/yyyy):</label>
            <asp:TextBox ID="txtKayitTarihi" runat="server" CssClass="form-control" placeholder="gg/aa/yyyy" oninput="validateDateFormat(this.value)"></asp:TextBox>
            <span id="dateValidationMsg" style="color: red;"></span>
        </div>
        <asp:Button ID="btnSearch" runat="server" Text="Ara" OnClick="btnSearch_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ogrenci_no" HeaderText="Öğrenci No" />
            <asp:BoundField DataField="ad" HeaderText="Adı" />
            <asp:BoundField DataField="soyad" HeaderText="Soyadı" />
            <asp:BoundField DataField="bolum" HeaderText="Bölüm" />
            <asp:BoundField DataField="sinif" HeaderText="Sınıf" />
            <asp:BoundField DataField="dogum_tarihi" HeaderText="Doğum Tarihi" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="cinsiyet" HeaderText="Cinsiyet" />
            <asp:BoundField DataField="kayit_tarihi" HeaderText="Kayıt Tarihi" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="BolumID" HeaderText="Bölüm ID" />
        </Columns>
        </asp:GridView>
    </form>
</body>
</html>

