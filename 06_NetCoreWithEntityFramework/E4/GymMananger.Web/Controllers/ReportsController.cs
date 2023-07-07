using GymManager.Core.MembershipTypes;
using GymManager.DataAcces;
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
        private readonly ApiController apiController;
        public ReportsController(IGeneratePdf generatePdf, IWebHostEnvironment webHostEnvironment, GymManagerContext gymManager)
        {
            _generatePdf = generatePdf;
            _enviroment = webHostEnvironment;
            apiController = new ApiController(gymManager);
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

        public IActionResult Attendance()
        {
            string path = System.IO.Path.Combine(_enviroment.ContentRootPath, "Reports\\Attendance.rdlc");
            Stream reportdefinition = System.IO.File.OpenRead(path);

            LocalReport report = new LocalReport();
            report.EnableExternalImages = true;
            report.LoadReportDefinition(reportdefinition);

            AttendanceDataSet dataSet = new AttendanceDataSet();
            
            Random random = new Random();

            List<MembershipType> membershipTypes = apiController.GetMembershipTypes();

            string[] names = new string[] { "Jair", "Luis", "Gina", "Diana", "Jonathan", "Maria", "Pedro", "Ana", "Carlos", "Laura", "Diego", "Sofia", "Daniel", "Valeria", "Alejandro", "Camila", "Fernando", "Isabella", "Miguel", "Natalia" };
            string[] lastnames = new string[] { "Acosta", "Duran", "Gonzales", "Lopez", "Perez", "Rodriguez", "Garcia", "Martinez", "Fernandez", "Sanchez" };
            string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            for (int i = 0; i < 7; i++)
            {
                AttendanceDataSet.WeekRow row = dataSet.Week.NewWeekRow();

                row.Idweek = (i+1).ToString();
                row.Day = daysOfWeek[i];
                row.Attendance = random.Next(1,100);

                dataSet.Week.Rows.Add(row);
            }
          
            for (int i = 0; i < 20; i++)
            {
                AttendanceDataSet.AttendanceRow row = dataSet.Attendance.NewAttendanceRow();
                AttendanceDataSet.WeekRow rowWeek = dataSet.Week.NewWeekRow();

                row.Name = $"{names[random.Next(names.Length)]} {lastnames[random.Next(lastnames.Length)]}";

                int membershipTypeIndex = random.Next(0,membershipTypes.Count);

                row.Attendance = (uint)random.Next(1, 30);
                row.MembershipType = membershipTypes[membershipTypeIndex].Name;
                row.Id = (i+1).ToString();

                dataSet.Attendance.Rows.Add(row);
            }

            byte[] streamBytes = null;
            string mimeType = "";
            string encoding = "";
            string filennameExtension = "";
            string reportName = "Attendance";
            string[] streamids = null;
            Warning[] warnings = null;

            report.SetParameters(new ReportParameter[] {
                new ReportParameter("DateForm", DateTime.Today.AddDays(-30).ToString()),
                new ReportParameter("DateTo", DateTime.Today.ToString())
            });
            report.DataSources.Add(new ReportDataSource("Attendance", (System.Data.DataTable)dataSet.Attendance));
            report.DataSources.Add(new ReportDataSource("Week", (System.Data.DataTable)dataSet.Week));

            streamBytes = report.Render("PDF", null, out mimeType, out encoding, out filennameExtension, out streamids, out warnings);

            return File(streamBytes, mimeType, $"{reportName}.{filennameExtension}");
        }
    }
}
