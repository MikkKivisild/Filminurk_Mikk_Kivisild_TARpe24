using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
    public class RChatController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
