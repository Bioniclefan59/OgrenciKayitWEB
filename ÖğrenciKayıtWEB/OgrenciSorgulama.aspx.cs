using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Script.Serialization;
using OgrenciBilgiKayitWEB.OkulDBContext;

namespace OgrenciBilgiKayitWEB
{
    public partial class OgrenciSorgulama : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.TextBox txtOgrenciIsmi;
        protected System.Web.UI.HtmlControls.HtmlInputText txtOgrenciNo;
        protected System.Web.UI.WebControls.TextBox txtKayitTarihi;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               // LoadStudentData();
            }
        }
        protected string GetStudentNamesJson()
        {
            List<string> studentNames = new List<string>();
            using (var dbContext = new OkulDBCntxt())
            {
                var students = dbContext.Ogrenciler.ToList();
                foreach (var student in students)
                {
                    studentNames.Add($"{student.ad} {student.soyad}");
                }
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(studentNames);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string studentName = txtOgrenciIsmi.Text.Trim();
            string studentNumber = txtOgrenciNo.Value.Trim();
            DateTime? registrationDate = ParseDate(txtKayitTarihi.Text.Trim());

            if (string.IsNullOrEmpty(studentName) && string.IsNullOrEmpty(studentNumber) && registrationDate == null)
            {
                Response.Write("Arama yapabilmek için en az bir alanın dolu olması gerekmektedir.");
                return;
            }

            using (var dbContext = new OkulDBCntxt())
            {
                var query = dbContext.Ogrenciler.AsQueryable(); // Start with all students

                // Apply filters based on user input
                if (!string.IsNullOrEmpty(studentNumber))
                {
                    // Check if the input in the student number field is numeric
                    if (int.TryParse(studentNumber, out int studentNo))
                    {
                        query = query.Where(s => s.ogrenci_no == studentNo);
                    }
                    else
                    {
                        // Invalid Öğrenci No format, handle accordingly
                        Response.Write("Öğrenci No geçersiz.");
                        return;
                    }
                }

                // Check if registrationDate is not null and has a value before using it in the LINQ query
                if (registrationDate != null)
                {
                    query = query.Where(s => System.Data.Entity.Core.Objects.EntityFunctions.TruncateTime(s.kayit_tarihi) == EntityFunctions.TruncateTime(registrationDate.Value));
                }

                // Check if Öğrenci İsmi is provided
                if (!string.IsNullOrEmpty(studentName))
                {
                    query = query.Where(s => (s.ad + " " + s.soyad).Contains(studentName));
                }

                // Assuming registrationDate is of type DateTime? and properly initialized
                var students = query
                    .Select(s => new
                    {
                        s.ogrenci_no,
                        s.ad,
                        s.soyad,
                        s.bolum,
                        s.sinif,
                        s.dogum_tarihi,
                        s.cinsiyet,
                        s.kayit_tarihi,
                        s.BolumID
                    })
                    .ToList();

                // Check if there are no students in the result
                if (students.Count == 0)
                {
                    Response.Write("Böyle bir öğrenci kayıtlı değil.");
                    return;
                }

                GridView1.DataSource = students;
                GridView1.DataBind();
            }
        }

        private DateTime? ParseDate(string dateStr)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(dateStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }
            return null; // Return null if parsing fails
        }




        private void LoadStudentData()
        {
            using (var dbContext = new OkulDBCntxt())
            {
                var students = dbContext.Ogrenciler.ToList();
                GridView1.DataSource = students;
                GridView1.DataBind();
            }
        }
    }
}
