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
    public class FichePlanningController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public FichePlanningController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Standard CRUD methods
        [HttpGet]
        public async Task<IEnumerable<FichePlanDTO>> GetAll()
        {
            return _mediator.Send(new GetListGenericQuery<FichePlanning>(condition: x => x.IsActif.Equals(true)
            , includes: x => x.Include(x  => x.Utilisateur).Include(x=>x.Periodes)
            .Include(x => x.Filiale))).Result.Select(t => _mapper.Map<FichePlanDTO>(t));
        }

        [HttpPost]
        public async Task<string> Post(FichePlanning planning)
        {
            return await _mediator.Send(new AddGenericCommand<FichePlanning>(planning));
        }


        [HttpPut]
        public async Task<string> Put(FichePlanning planning)
        {
            return await _mediator.Send(new PutGenericCommand<FichePlanning>(planning));
        }

        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new RemoveGenericCommand<FichePlanning>(id));
        }
        #endregion
    }

}
