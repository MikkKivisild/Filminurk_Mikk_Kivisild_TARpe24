using Core.Dto;
using Core.ServiceInterface;
using Data;
using Filminurk_Mikk_Kivisild_TARpe24.Models.Actors;
using Filminurk_Mikk_Kivisild_TARpe24.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
    public class ActorsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IActorServices _actorServices;
        public ActorsController(FilminurkTARpe24Context context, IActorServices actorServices)
        {
            _context = context;
            _actorServices = actorServices;
        }

        public IActionResult Index()
        {
            var actors = _context.Actors.Select(vm => new ActorsIndexViewModel
            {
                ActorID = vm.ActorID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                NickName = vm.NickName,
                PortraitID = vm.PortraitID,
                FirstActed = vm.FirstActed,
                Age = vm.Age,
                Gender = (Models.Actors.Gender?)vm.Gender
            });
            return View(actors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ActorsCreateUpdateViewModel actors = new();
            return View("CreateUpdate", actors);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ActorsCreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new ActorsDTO()
                {
                    ActorID = (Guid)vm.ActorID,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    NickName = vm.NickName,
                    PortraitID = vm.PortraitID,
                    FirstActed = vm.FirstActed,
                    Age = vm.Age,
                    Gender = (Core.Dto.Gender?)vm.Gender,
                    EntryCreatedAt = vm.EntryCreatedAt,
                    EntryModifiedAt = vm.EntryModifiedAt

                };
                var actors = await _actorServices.Create(dto);
                if (actors == null)
                {
                    NotFound();
                }
                if (!ModelState.IsValid)
                {
                    NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var actor = await _actorServices.DetailsAsync(id);
            if (actor == null) { return NotFound(); }

            var vm = new ActorsDetailsViewModel();

            vm.ActorID = actor.ActorID;
            vm.FirstName = actor.FirstName;
            vm.LastName = actor.LastName;
            vm.NickName = actor.NickName;
            vm.PortraitID = vm.PortraitID;
            vm.FirstActed = vm.FirstActed;
            vm.Age = vm.Age;
            vm.Gender = (Models.Actors.Gender?)vm.Gender;
            vm.EntryCreatedAt = vm.EntryCreatedAt;
            vm.EntryModifiedAt = vm.EntryModifiedAt;

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var actor = await _actorServices.DetailsAsync(id);
            if (actor == null) { return NotFound(); }
            
            var vm = new ActorsCreateUpdateViewModel();

            vm.ActorID = actor.ActorID;
            vm.FirstName = actor.FirstName;
            vm.LastName = actor.LastName;
            vm.NickName = actor.NickName;
            vm.PortraitID = vm.PortraitID;
            vm.FirstActed = vm.FirstActed;
            vm.Age = vm.Age;
            vm.Gender = (Models.Actors.Gender?)vm.Gender;
            vm.EntryCreatedAt = vm.EntryCreatedAt;
            vm.EntryModifiedAt = vm.EntryModifiedAt;


            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ActorsCreateUpdateViewModel vm)
        {
            var dto = new ActorsDTO()
            {
                ActorID = (Guid)vm.ActorID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                NickName = vm.NickName,
                PortraitID = vm.PortraitID,
                FirstActed = vm.FirstActed,
                Age = vm.Age,
                Gender = (Core.Dto.Gender?)vm.Gender,
                EntryCreatedAt = vm.EntryCreatedAt,
                EntryModifiedAt = vm.EntryModifiedAt
            };
            var actor = await _actorServices.Update(dto);

            if (actor == null) { return NotFound(); }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var actor = await _actorServices.DetailsAsync(id);

            if (actor == null) { return NotFound(); }

            var vm = new ActorsDeleteViewModel();

            vm.ActorID = actor.ActorID;
            vm.FirstName = actor.FirstName;
            vm.LastName = actor.LastName;
            vm.NickName = actor.NickName;
            vm.PortraitID = actor.PortraitID;
            vm.FirstActed = actor.FirstActed;
            vm.Age = actor.Age;
            vm.Gender = (Models.Actors.Gender?)actor.Gender;
            vm.EntryCreatedAt = actor.EntryCreatedAt;
            vm.EntryModifiedAt = actor.EntryModifiedAt;


            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var actor = await _actorServices.Delete(id);

            if (actor == null) { return NotFound(); }

            return RedirectToAction(nameof(Index));
        }
    }
}
