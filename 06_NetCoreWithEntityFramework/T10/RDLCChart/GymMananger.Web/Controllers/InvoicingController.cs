using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class InvoicingController : Controller
    {
        private readonly IGeneratePdf _generatedPDF;
        public InvoicingController(IGeneratePdf generatePdf)
        {
            _generatedPDF = generatePdf;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenereteInvoice()
        {
            return View();
        }

        public async Task<IActionResult> Print()
        {
            return await _generatedPDF.GetPdf("/Views/Invoicing/Print.cshtml");
            //return View();
        }
    }
}
