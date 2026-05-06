using System.ComponentModel.DataAnnotations;

namespace Cp2FilmesApi.Entities
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [StringLength(50)]
        public string Genero { get; set; } = string.Empty;

        [Range(1900, 2100)]
        public int AnoLancamento { get; set; }

        [Range(1, 10)]
        public decimal NotaImdb { get; set; }

        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}