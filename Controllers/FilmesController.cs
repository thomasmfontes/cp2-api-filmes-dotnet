using Cp2FilmesApi.Data;
using Cp2FilmesApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cp2FilmesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todos os filmes cadastrados.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmes()
        {
            return Ok(await _context.Filmes.ToListAsync());
        }

        /// <summary>
        /// Busca um filme pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Filme>> GetFilmePorId(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
                return NotFound("Filme não encontrado.");

            return Ok(filme);
        }

        /// <summary>
        /// Lista filmes filtrados pelo gênero.
        /// </summary>
        [HttpGet("genero/{genero}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmesPorGenero(string genero)
        {
            var filmes = await _context.Filmes
                .Where(f => f.Genero.ToLower() == genero.ToLower())
                .ToListAsync();

            return Ok(filmes);
        }

        /// <summary>
        /// Cadastra um novo filme.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilmePorId), new { id = filme.Id }, filme);
        }

        /// <summary>
        /// Atualiza os dados de um filme existente.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFilme(int id, Filme filme)
        {
            if (id != filme.Id)
                return BadRequest("O ID da URL é diferente do ID do objeto enviado.");

            var filmeExiste = await _context.Filmes.AnyAsync(f => f.Id == id);

            if (!filmeExiste)
                return NotFound("Filme não encontrado.");

            _context.Entry(filme).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Remove um filme pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
                return NotFound("Filme não encontrado.");

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}