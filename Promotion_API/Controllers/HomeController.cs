using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Pos.Model.Model.Comon;
using Promotion.Application.Services;

namespace PosAPI.Controllers
{
    [Authorize]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;
        public HomeController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        [Route("Test")]
        public JsonResult Test()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];
            var StoreId = _loginService.getStoreIdByToken(accessToken);

            return Json(new { accessToken, StoreId });
        }
    }
}
