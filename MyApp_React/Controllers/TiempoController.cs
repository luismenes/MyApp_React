using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp_React.Data;
using Microsoft.AspNetCore.Mvc;
using MyApp_React.Models;

namespace MyApp_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiempoController : ControllerBase
    {
        private readonly TiempoRepository _repository;

        public TiempoController(TiempoRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/Tiempo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiempo>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/Tiempo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiempo>> Get(int id)
        {
            var response = await _repository.GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/Tiempo
        [HttpPost]
        public async Task Post([FromBody] Tiempo tiempo)
        {
            await _repository.Insert(tiempo);
        }

        // PUT api/Tiempo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string tiempo)
        {
        }

        // DELETE api/Tiempo/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _repository.DeleteById(id);
        }
    }
}
