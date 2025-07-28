using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class HotelApiSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&adults_number=2&page_number=0&children_number=2&include_adjacency=true&children_ages=5%2C0&locale=tr&dest_type=city&filter_by_currency=TRY&dest_id=-553173&order_by=popularity&units=metric&checkout_date=2025-10-15&room_number=1&checkin_date=2025-10-14"),
                Headers =
    {
        { "x-rapidapi-key", "06272128e4msha438ef5f41c84c8p1badccjsn3f82930d95d3" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace=body.Replace(".", "");
                var values=JsonConvert.DeserializeObject<HotelApiSearchModel>(bodyReplace);
                foreach (var item in values.result)
                {
                    if (!string.IsNullOrEmpty(item.url))
                    {
                        item.url = item.url.Replace("www", "www.");
                        item.url = item.url.Replace("html", ".html");
                        item.url = item.url.Replace("com", ".com");
                    }
                }
                return View(values.result);
            }
        }


    }
}
