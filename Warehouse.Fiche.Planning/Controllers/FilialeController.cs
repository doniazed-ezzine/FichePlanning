using Domain.Command;
using Domain.Handlers;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Fiche.Planning.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FilialeController : ControllerBase
    {

        private readonly IGenericRepository<Filiale> repository;

        public FilialeController(IGenericRepository<Filiale> repository)
        {
            this.repository = repository;
        }

        // GET: API/Filiales
        [HttpGet]
        public async Task<IEnumerable<Filiale>> GetFiliales()
        {
            var query = new GetListGenericQuery<Filiale>(condition: null, includes: null);
            var handler = new GetListGenericHandler<Filiale>(repository);
            return await handler.Handle(query, new CancellationToken());
        }

        // GET: API/Filiales/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Filiale>> GetFiliale(Guid id)
        {
            var query = new GetGenericQuery<Filiale>(condition: x => x.Id.Equals(id), includes: null);
            var handler = new GetGenericHandler<Filiale>(repository);
            var filiale = await handler.Handle(query, new CancellationToken());

            if (filiale == null)
                return NotFound();

            return filiale;
        }

        // POST: API/Filiales
        [HttpPost]
        public async Task<ActionResult<String>> CreateFiliale([FromBody] Filiale filiale)
        {
            var command = new AddGenericCommand<Filiale>(filiale);
            var handler = new AddGenericHandler<Filiale>(repository);
            var result = await handler.Handle(command, new CancellationToken());

            return result;
        }

        // PUT: API/Filiales/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFiliale(Guid id, [FromBody] Filiale filiale)
        {
            if (!id.Equals(filiale.Id))
                return BadRequest();

            var command = new PutGenericCommand<Filiale>(filiale);
            var handler = new PutGenericHandler<Filiale>(repository);
            var result = await handler.Handle(command, new CancellationToken());

            if (!string.IsNullOrEmpty(result))
                return NotFound();

            return NoContent();
        }

        // DELETE: API/Filiales/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiliale(Guid id)
        {
            var command = new RemoveGenericCommand<Filiale>(id);
            var handler = new RemoveGenericHandler<Filiale>(repository);
            var result = await handler.Handle(command, new CancellationToken());

            if (!string.IsNullOrEmpty(result))
                return NotFound();

            return NoContent();
        }
    }
}