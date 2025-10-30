using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Dto;
using Core.ServiceInterface;
using Data;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Services
{
    public class ActorsServices : IActorServices
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IActorServices _actorServices;
        public ActorsServices(FilminurkTARpe24Context context, IActorServices actorServices) 
        {
            _context = context;
            _actorServices = actorServices;
        }


        public async Task<Actor> Create(ActorsDTO dto)
        {
            Actor actor = new Actor();
            actor.ActorID = Guid.NewGuid();
            actor.FirstName = dto.FirstName;
            actor.LastName = dto.LastName;
            actor.NickName = dto.NickName;
            actor.FirstActed = (DateOnly)dto.FirstActed;
            actor.Age = (int)dto.Age;
            actor.Gender = (Core.Domain.Gender)dto.Gender;

            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();

            return actor;
        }
        public async Task<Actor> DetailsAsync(Guid id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.ActorID == id);
            return actor;
        }
        public async Task<Actor> Update(ActorsDTO dto)
        {
            Actor actor = new Actor();
            actor.ActorID = Guid.NewGuid();
            actor.FirstName = dto.FirstName;
            actor.LastName = dto.LastName;
            actor.NickName = dto.NickName;
            actor.FirstActed = (DateOnly)dto.FirstActed;
            actor.Age = (int)dto.Age;
            actor.Gender = (Core.Domain.Gender)dto.Gender;

            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();

            return actor;
        }
        public async Task<Actor> Delete(Guid id)
        {
            var actor = await _context.Actors
                .FirstOrDefaultAsync(x => x.ActorID == id);

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return actor;
        }
    }
    
}
