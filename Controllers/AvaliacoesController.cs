using Cp2FilmesApi.Data;
using Cp2FilmesApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cp2FilmesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AvaliacoesController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todas as avaliações cadastradas.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoes()
        {
            var avaliacoes = await _context.Avaliacoes.ToListAsync();

            return Ok(avaliacoes);
        }

        /// <summary>
        /// Busca uma avaliação pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Avaliacao>> GetAvaliacaoPorId(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);

            if (avaliacao == null)
                return NotFound("Avaliação não encontrada.");

            return Ok(avaliacao);
        }

        /// <summary>
        /// Lista avaliações vinculadas a um filme.
        /// </summary>
        [HttpGet("filme/{filmeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacoesPorFilme(int filmeId)
        {
            var avaliacoes = await _context.Avaliacoes
                .Where(a => a.FilmeId == filmeId)
                .ToListAsync();

            return Ok(avaliacoes);
        }

        /// <summary>
        /// Cadastra uma nova avaliação para um filme existente.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var filmeExiste = await _context.Filmes.AnyAsync(f => f.Id == avaliacao.FilmeId);

            if (!filmeExiste)
                return BadRequest("O filme informado não existe.");

            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAvaliacaoPorId), new { id = avaliacao.Id }, avaliacao);
        }

        /// <summary>
        /// Atualiza os dados de uma avaliação existente.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAvaliacao(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.Id)
                return BadRequest("O ID da URL é diferente do ID do objeto enviado.");

            var avaliacaoExiste = await _context.Avaliacoes.AnyAsync(a => a.Id == id);

            if (!avaliacaoExiste)
                return NotFound("Avaliação não encontrada.");

            var filmeExiste = await _context.Filmes.AnyAsync(f => f.Id == avaliacao.FilmeId);

            if (!filmeExiste)
                return BadRequest("O filme informado não existe.");

            _context.Entry(avaliacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Remove uma avaliação pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);

            if (avaliacao == null)
                return NotFound("Avaliação não encontrada.");

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}