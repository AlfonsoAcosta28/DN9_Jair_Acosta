using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using WebApi.Cors.Example;

namespace Webcores.Example.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStringLocalizer<IndexModel> _localizer;
        private readonly IHtmlLocalizer<IndexModel> _htmlLocalizer;
        private readonly IHttpClientFactory _httpClientFactory;
        public List<WeatherForecast> WeatherForecasts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, 
            IStringLocalizer<IndexModel> localizer, 
            IHtmlLocalizer<IndexModel> htmlLocalizer,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _localizer = localizer;
            _htmlLocalizer = htmlLocalizer;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            ViewData["ResultMessage"] = _localizer.GetString("SuccessMessage");   
        }


        public async Task OnPostAsync()
        {
            var client = _httpClientFactory.CreateClient("WebApi");

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                Request.Cookies["authname"]);

            var result = await client.GetFromJsonAsync<List<WeatherForecast>>("/WeatherForecast");
        }
    }
}