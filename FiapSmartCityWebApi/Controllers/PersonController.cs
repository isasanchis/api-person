using Microsoft.AspNetCore.Mvc;
using FiapSmartCityWebApi.Repository;

namespace FiapSmartCityWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Person : ControllerBase
    {
        [HttpGet]
        [Route("GetPerson")]
        public IActionResult Get()
        {
            try
            {
                return Ok(new PersonRepository().GetAll());
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetPerson/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                PersonRepository dto = new PersonRepository();
                Models.Person Person = dto.GetById(id);
                return Ok(Person);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost(Name = "GetPerson")]
        public IActionResult Post([FromBody] Models.Person Person)
        {
            try
            {
                // Cria o objeto DAL
                PersonRepository dto = new PersonRepository();
                // Insere a informação do banco de dados
                dto.Create(Person);

                // Cria uma propriedade para efetuar a consulta da informação cadastrada
                string location = "https://localhost:7236/Person";

                return Created(new Uri(location), Person);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete(Name = "GetPerson")]
        public IActionResult Delete(int id)
        {
            try
            {
                PersonRepository dto = new PersonRepository();
                dto.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut(Name = "GetPerson")]
        public IActionResult Put([FromBody] Models.Person Person)
        {
            try
            {
                PersonRepository dto = new PersonRepository();
                dto.Update(Person);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
