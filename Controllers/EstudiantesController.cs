using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiApi.Data;
using MiApi.Models;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstudiantesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Estudiante>> Get()
        {
            return await _context.Estudiantes.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> Get(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            return estudiante == null ? NotFound() : Ok(estudiante);
        }

      
        [HttpPost]
        public async Task<IActionResult> Post(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = estudiante.Id }, estudiante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id) return BadRequest();
            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}