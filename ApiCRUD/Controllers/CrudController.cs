using Api.Business;
using Microsoft.AspNetCore.Mvc;
using Api.Entity;

namespace ApiCRUD.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly IManagerCRUD _manager;
        public CrudController(IManagerCRUD manager)
        {
            _manager = manager;
        }

        [HttpPost("insertPeople")]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        public IActionResult insertPeople([FromBody] EntityPeople people)
        {
            try
            {
                var response = _manager.insertPeople(people);
                if(response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("getPeople")]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        public IActionResult getPeople(int idPeople)
        {
            try
            {
                var response = _manager.getPeople(idPeople);
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("getListPeople")]
        [ProducesResponseType(typeof(Response<bool>), 200)]
        public IActionResult getListPeople()
        {
            try
            {
                var response = _manager.getListPeople();
                if (response == null)
                    return NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
