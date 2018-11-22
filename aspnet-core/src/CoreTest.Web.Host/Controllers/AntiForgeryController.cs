using Microsoft.AspNetCore.Antiforgery;
using CoreTest.Controllers;

namespace CoreTest.Web.Host.Controllers
{
    public class AntiForgeryController : CoreTestControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
