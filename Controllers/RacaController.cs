using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetsApi.Domains;
using PetsApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        RacaRepositories repositorio = new RacaRepositories();
        // GET: api/<RacaController>
        [HttpGet]
        public List<Raca> Get()
        {
            return repositorio.ListarTodos();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return repositorio.BuscarPorID(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public void Post([FromBody] Raca a)
        {
             repositorio.Cadastrar(a);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Raca a )
        {
             repositorio.Alterar(id, a);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repositorio.Excluir(id);
        }
    }
}
