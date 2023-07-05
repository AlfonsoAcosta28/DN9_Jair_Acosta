using GymManager.DataAcces.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using Wkhtmltopdf.NetCore;

namespace GymManager.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly IWebHostEnvironment _enviroment;
        public ReportsController(IGeneratePdf generatePdf, IWebHostEnvironment webHostEnvironment)
        {
            _generatePdf = generatePdf;
            _enviroment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewMembers()
        {
            string path = System.IO.Path.Combine(_enviroment.ContentRootPath, "Reports\\NewMembers.rdlc");
            Stream reportdefinition = System.IO.File.OpenRead(path);

            LocalReport report = new LocalReport();
            report.EnableExternalImages = true;
            report.LoadReportDefinition(reportdefinition);

            MembersDataSet dataSet = new MembersDataSet();
            Random random = new Random();

            string[] membershipTypes = new string[] { "Basic", "Family", "Gold" };

            for (int i = 0; i< 28; i++)
            {
                MembersDataSet.MemberRow row = dataSet.Member.NewMemberRow();
                row.Name = $"Checo Perez {i}";
                double day = random.Next(1, 10) * -1;
                int membershipTypeIndex = random.Next(0,2);

                row.RegisteredOn = DateTime.Today.AddDays(day);
                row.MebershipType = membershipTypes[membershipTypeIndex];

                dataSet.Member.Rows.Add(row);
            }

            byte[] streamBytes = null;
            string mimeType = "";
            string encoding = "";
            string filennameExtension = "";
            string reportName = "NewMembers";
            string[] streamids = null;
            Warning[] warnings = null;

            report.SetParameters(new ReportParameter[] { new ReportParameter("DateForm", DateTime.Today.AddDays(-10).ToString()),new ReportParameter("DateTo", DateTime.Today.ToString())});

            report.DataSources.Add(new ReportDataSource("Members", (System.Data.DataTable)dataSet.Member));

            streamBytes = report.Render("PDF", null, out mimeType, out encoding, out filennameExtension, out streamids, out warnings);

            return File(streamBytes, mimeType, $"{reportName}.{filennameExtension}");
        }
    }
}
