using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model.Data;
using API.Model.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomethingController : ControllerBase
    {
        protected readonly IRepository<Something> _repository;

        public SomethingController(IRepository<Something> repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<ICollection<Something>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<Something>> Get(int id)
        {
            var entity = await _repository.Get(id);

            if (entity is null)
                return NotFound();

            return entity;
        }

        // PUT: api/[controller]/5
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody]Something entity)
        {

            try
            {
                await _repository.Update(entity);
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public virtual async Task<ActionResult<Something>> Post([FromBody]Something entity)
        {
            await _repository.Add(entity);

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]
        [HttpDelete]
        public virtual async Task<ActionResult<Something>> Delete([FromBody]Something entity)
        {
            var removed = await _repository.Remove(entity);

            if (removed is null)
                return NoContent();

            return removed;
        }
    }
}
