using AutoMapper;
using Domain.Command;
using Domain.DTO;
using Domain.Handlers;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Warehouse.Fiche.Planning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodeController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public PeriodeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Standard CRUD methods
        [HttpGet]
        public async Task<IEnumerable<PeriodeDTO>> GetAll()
        {
            return _mediator.Send(new GetListGenericQuery<Periode>(condition: x => x.FichePlanning.IsActif.Equals(true)
            , includes: x => x.Include(x => x.FichePlanning).ThenInclude(x=>x.Utilisateur).ThenInclude(x=>x.Fonction)
            .Include(x=>x.FichePlanning.Filiale)))
                            .Result.Select(t => _mapper.Map<PeriodeDTO>(t)).OrderBy(x => x.DatePlanning);
        }


        [HttpPost]
        public async Task<string> Post(Periode periode)
        {
            return await _mediator.Send(new AddGenericCommand<Periode>(periode));
        }


        [HttpPut]
        public async Task<string> Put(Periode periode)
        {
            return await _mediator.Send(new PutGenericCommand<Periode>(periode));
        }

        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new RemoveGenericCommand<Periode>(id));
        }
        #endregion
    }

}
