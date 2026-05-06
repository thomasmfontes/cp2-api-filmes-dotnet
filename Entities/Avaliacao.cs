using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cp2FilmesApi.Entities
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [StringLength(80)]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O comentário é obrigatório.")]
        [StringLength(500)]
        public string Comentario { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Nota { get; set; }

        [Required]
        public int FilmeId { get; set; }

        [ForeignKey(nameof(FilmeId))]
        [JsonIgnore]
        public Filme? Filme { get; set; }
    }
}