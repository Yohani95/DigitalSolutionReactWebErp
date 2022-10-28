using ErpApi.Data;
using ErpApi.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ErpApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ErpApiContext _context;
        public UserController(ErpApiContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetAll()
        {
           List<UserModels> users= await _context.usuarios.Include(x=>x.roles).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, users);
        }
        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("ObtenerUsuario/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            UserModels users = _context.usuarios.Include(x=>x.roles).Where(x=>x.id_usuario==id).First();
             
            return StatusCode(StatusCodes.Status200OK, users);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Post([FromBody] UserModels request)
        {
            await _context.usuarios.AddAsync(request);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Ok");
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserModels request)
        {
            if (UserExists(id))
            {
                return NotFound();
            }
            request.id_usuario = id;
            _context.usuarios.Update(request);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Ok");
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        [Route("Eliminar`/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            var user = await _context.usuarios.FindAsync(id);
            _context.usuarios.Remove(user);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Ok");
        }
        private bool UserExists(int id)
        {
            return _context.usuarios.Any(e => e.id_usuario == id);
        }
    }
}
