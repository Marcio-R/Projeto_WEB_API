using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_WEB_API.Data;
using Projeto_WEB_API.Models;

namespace Projeto_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly Projeto_WEB_APIContext _context;

        public CursosController(Projeto_WEB_APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return _context.Curso;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCursoId(int id)
        {
            Curso curso = await _context.Curso.FirstOrDefaultAsync(c => c.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> CriarCurso(Curso curso)
        {
            if (curso == null)
            {

                return BadRequest();
            }
            _context.Add(curso);
            _context.SaveChanges();
            return CreatedAtAction("GetCursos", new { id = curso.Id }, curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }
            _context.Update(curso);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            Curso curso = await _context.Curso.FindAsync(id);

            if (curso == null)
            {
                return BadRequest();
            }
            _context.Curso.Remove(curso);
            _context.SaveChanges();
            return NoContent();

        }

    }
}
