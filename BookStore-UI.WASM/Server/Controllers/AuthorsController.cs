using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore_UI.WASM.Server.Contracts;
using BookStore_UI.WASM.Server.Static;
using BookStore_UI.WASM.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore_UI.WASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _repo;
        public AuthorsController(IAuthorRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var authors = await _repo.Get(Endpoints.AuthorsEndpoint);
                return Ok(authors);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            var author = await _repo.Get(Endpoints.AuthorsEndpoint, id);
            return author;
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task Post([FromBody] Author author)
        {
            await _repo.Create(Endpoints.AuthorsEndpoint, author);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Author author)
        {
            await _repo.Update(Endpoints.AuthorsEndpoint, author, id);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repo.Delete(Endpoints.AuthorsEndpoint, id);
        }
    }
}
