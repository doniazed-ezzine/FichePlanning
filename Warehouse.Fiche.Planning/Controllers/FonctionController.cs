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
    public class FonctionController : ControllerBase
    {

        private readonly IGenericRepository<Fonction> repository;

        public FonctionController(IGenericRepository<Fonction> repository)
        {
            this.repository = repository;
        }

        // GET: API/Fonction
        [HttpGet]
        public async Task<IEnumerable<Fonction>> GetFonctions()
        {
            var query = new GetListGenericQuery<Fonction>(condition: null, includes: null);
            var handler = new GetListGenericHandler<Fonction>(repository);
            return await handler.Handle(query, new CancellationToken());
        }

        // GET: API/Fonction/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Fonction>> GetFonctionById(Guid id)
        {
            var query = new GetGenericQuery<Fonction>(condition: x => x.Id.Equals(id));
            var handler = new GetGenericHandler<Fonction>(repository);
            var Fonction = await handler.Handle(query, new CancellationToken());

            if (Fonction == null)
                return NotFound();

            return Fonction;
        }

        // POST: API/Fonction
        [HttpPost]
        public async Task<ActionResult<String>> CreateFonction([FromBody] Fonction Fonction)
        {
            var command = new AddGenericCommand<Fonction>(Fonction);
            var handler = new AddGenericHandler<Fonction>(repository);
            var result = await handler.Handle(command, new CancellationToken());

            return result;
        }

        // PUT: API/Fonction/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFonction(Guid id, [FromBody] Fonction Fonction)
        {
            if (!id.Equals(Fonction.Id))
                return BadRequest();

            var command = new PutGenericCommand<Fonction>(Fonction);
            var handler = new PutGenericHandler<Fonction>(repository);
            var result = await handler.Handle(command, new CancellationToken());

            if (!string.IsNullOrEmpty(result))
                return NotFound();

            return NoContent();
        }

        // DELETE: API/Fonction/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFonction(Guid id)
        {
            var command = new RemoveGenericCommand<Fonction>(id);
            var handler = new RemoveGenericHandler<Fonction>(repository);
            var result = await handler.Handle(command, new CancellationToken());

            if (!string.IsNullOrEmpty(result))
                return NotFound();

            return NoContent();
        }
    }
}
