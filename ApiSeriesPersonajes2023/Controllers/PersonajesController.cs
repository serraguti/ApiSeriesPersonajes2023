using ApiSeriesPersonajes2023.Models;
using ApiSeriesPersonajes2023.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeriesPersonajes2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repo;

        public PersonajesController(RepositorySeries repo) 
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajes()
        {
            return this.repo.GetPersonajes();
        }

        [HttpGet("{id}")]
        public ActionResult<Personaje> FindPersonaje(int id)
        {
            return this.repo.FindPersonaje(id);
        }

        [HttpPut]
        [Route("[action]/{idpersonaje}/{idserie}")]
        public async Task<ActionResult> UpdatePersonajeSerie
            (int idpersonaje, int idserie)
        {
            await this.repo.UpdatePersonajeSerie(idpersonaje, idserie);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonaje(Personaje personaje)
        {
            await this.repo.InsertPersonaje(personaje.IdPersonaje
                , personaje.Nombre, personaje.Imagen
                , personaje.IdSerie);
            return Ok();
        }
    }
}
