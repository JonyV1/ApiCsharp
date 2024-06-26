using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApi1.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly DbinventarioContext dbContext;

        public EmpleadoController(DbinventarioContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        
        public async Task<IActionResult> Get()
        {
            var listaEmpleado = await dbContext.Empeados.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, listaEmpleado);
        }

        [HttpGet]
        [Route("Obtener/{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            var empleado = await dbContext.Empeados.FirstOrDefaultAsync(e => e.IdEmpleado == id);
            return StatusCode(StatusCodes.Status200OK, empleado);
        }

        [HttpPost]
        [Route("Nuevo")]
        public async Task<IActionResult> Nuevo([FromBody]Empeado objeto)
        {
            await dbContext.Empeados.AddAsync(objeto);
            await dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new { mensaje="ok" });
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Empeado objeto)
        {
            dbContext.Empeados.Update(objeto);
            await dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            var empleado = await dbContext.Empeados.FirstOrDefaultAsync(e => e.IdEmpleado == id);

            dbContext.Empeados.Remove(empleado);
            await dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
        }

    }
}
