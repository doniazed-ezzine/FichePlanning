using AutoMapper;
using Domain.Command;
using Domain.DTO;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Fiche.Planning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public UtilisateurController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Standard CRUD methods
        [HttpGet]
        public async Task<IEnumerable<UtilisateurDTO>> GetAll()
        {
            return _mediator.Send(new GetListGenericQuery<Utilisateur>(condition: x => x.IsActif.Equals(true)
            , includes: x => x.Include(x => x.Fonction)))
                            .Result.Select(t => _mapper.Map<UtilisateurDTO>(t)).OrderBy(x => x.Fonction);
        }


        [HttpPost]
        public async Task<string> Post(Utilisateur user)
        {
            return await _mediator.Send(new AddGenericCommand<Utilisateur>(user));
        }


        [HttpPut]
        public async Task<string> Put(Utilisateur user)
        {
            return await _mediator.Send(new PutGenericCommand<Utilisateur>(user));
        }

        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new RemoveGenericCommand<Utilisateur>(id));
        }
        #endregion
    }

}