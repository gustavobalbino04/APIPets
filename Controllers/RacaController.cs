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
        /// <summary>
        /// Lista as Raça
        /// </summary>
        /// <returns>Retorna um lista de Raças</returns>
        [HttpGet]
        public List<Raca> Get()
        {
            return repositorio.ListarTodos();
        }

        // GET api/<RacaController>/5
        /// <summary>
        /// lista por Id as raça
        /// </summary>
        /// <param name="id">Pets</param>
        /// <returns>Retorna lista de raça por id</returns>
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return repositorio.BuscarPorID(id);
        }

        // POST api/<RacaController>
        /// <summary>
        /// Cadastra um raça
        /// </summary>
        /// <param name="a">Raça</param>
        [HttpPost]
        public void Post([FromBody] Raca a)
        {
             repositorio.Cadastrar(a);
        }

        // PUT api/<RacaController>/5
        /// <summary>
        /// Altera um raça
        /// </summary>
        /// <param name="id">Raca</param>
        /// <param name="a">Pets</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Raca a )
        {
             repositorio.Alterar(id, a);
        }

        // DELETE api/<RacaController>/5
        /// <summary>
        /// Deleta uma raca
        /// </summary>
        /// <param name="id">Pets</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repositorio.Excluir(id);
        }
    }
}
