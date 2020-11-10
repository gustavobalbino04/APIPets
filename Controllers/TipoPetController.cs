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
    public class TipoPetController : ControllerBase
    {
        TipoPetRepositories repositorio = new TipoPetRepositories();

        // GET: api/<TipoPetController>
        /// <summary>
        /// Listada os tipos de pets cadastrado
        /// </summary>
        /// <returns>retorna a lista de tipo pets</returns>
        [HttpGet]
        public List<TipoPet> Get()
        {
            return repositorio.ListarTodos();
        }

        // GET api/<TipoPetController>/5
        /// <summary>
        /// Listada de tipos pets pelo id
        /// </summary>
        /// <param name="id">Id TiposPets</param>
        /// <returns>Retorna a lista de TiposPets pelo Id</returns>
        [HttpGet("{id}")]
        public TipoPet Get(int id)
        {
            return repositorio.BuscarPorID(id);
        }

        // POST api/<TipoPetController>
        /// <summary>
        /// Cadastra um tipo de pet
        /// </summary>
        /// <param name="a">novo tipoPtes</param>
        /// <returns>Cadastro de TipoPet</returns>
        [HttpPost]
        public TipoPet Post([FromBody] TipoPet a)
        {
            return repositorio.Cadastrar(a);
        }

        // PUT api/<TipoPetController>/5
        /// <summary>
        /// Altera o tipopet
        /// </summary>
        /// <param name="id">Pet</param>
        /// <param name="a">TipoPet</param>
        /// <returns>Retorna o tipoPet alterado</returns>
        [HttpPut("{id}")]
        public TipoPet Put(int id, [FromBody] TipoPet a)
        {
            return repositorio.Alterar(id, a);
        }

        // DELETE api/<TipoPetController>/5
        /// <summary>
        /// Exclui um TipoPet
        /// </summary>
        /// <param name="id">TipoPet</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repositorio.Excluir(id);
        }
    }
}
