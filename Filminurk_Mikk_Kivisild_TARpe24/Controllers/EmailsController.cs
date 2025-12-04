using Core.Dto;
using Core.ServiceInterface;
using Filminurk_Mikk_Kivisild_TARpe24.Models.Emails;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailServices _emailServices;
        public EmailsController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel vm)
        {
            var dto = new EmailDTO()
            {
                SendToThisAddress = vm.SendToThisAddress,
                EmailSubject = vm.EmailSubject,
                EmailContent = vm.EmailContent,
            };
            _emailServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
        //HW
    }
}
