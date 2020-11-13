using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength=3)]
        public string Nome { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        public string DataInicio { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        public string DataFim { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        [Range(2, 120000, ErrorMessage="O campo {0} deve ter entre 2 e 120000.")]
        public int Quantidade { get; set; }
    }
}