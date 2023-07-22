using GymManager.Core.Entities;
using GymManager.Core.Members;
using GymManager.Core.MembershipTypes;
using GymManager.DataAcces;
using GymManager.DataAcces.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Wkhtmltopdf.NetCore;

namespace GymManager.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly IWebHostEnvironment _enviroment;
        private readonly ApiController apiController;
        private readonly QuerysController queryController;
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
            
            List<Attendance> attendances = apiController.GetAttendances();

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var attendancesThisMonth = attendances.Where(a => a.CheckIn >= firstDayOfMonth && a.CheckIn <= lastDayOfMonth).ToList();

            Dictionary<int, List<Attendance>> attendancesById = attendances.GroupBy(a => a.Member.Id)
              .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var kvp in attendancesById)
            {
                Member member = apiController.GetMemberById(kvp.Key); 

                AttendanceDataSet.AttendanceRow row = dataSet.Attendance.NewAttendanceRow();
                AttendanceDataSet.WeekRow rowWeek = dataSet.Week.NewWeekRow();

                row.Name = member.Name + " " + member.LastName;

                int attendanceCount = kvp.Value.Count;
                row.Attendance = (uint)attendanceCount;
                row.Id = member.Id + "";

                dataSet.Attendance.Rows.Add(row);
            }

            DateTime today = DateTime.Today;
            DateTime lastWeek = today.AddDays(-7).Date; 

            var attendancesLastWeek = attendances.Where(a => a.CheckIn.Date >= lastWeek && a.CheckIn.Date <= today).ToList();
            Dictionary<string, int> attendancesByDayOfWeek = new Dictionary<string, int>();
            string[] daysOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            foreach (var day in daysOfWeek)
            {
                attendancesByDayOfWeek.Add(day, 0);
            }

            foreach (var attendance in attendancesLastWeek)
            {
                string dayOfWeek = attendance.CheckIn.ToString("dddd", CultureInfo.CurrentCulture);
                attendancesByDayOfWeek[dayOfWeek] += 1;
            }
            int j = 1;
            foreach (var kvp in attendancesByDayOfWeek)
            {
                AttendanceDataSet.WeekRow row = dataSet.Week.NewWeekRow();

                row.Idweek = (j).ToString();
                row.Day = kvp.Key;
                row.Attendance = kvp.Value;

                dataSet.Week.Rows.Add(row);
                j++;
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
