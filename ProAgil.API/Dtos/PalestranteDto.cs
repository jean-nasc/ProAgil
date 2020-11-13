using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class PalestranteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength=3)]
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set; }

        [Phone(ErrorMessage="Insira um telefone válido.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage="Insira um e-mail válido.")]
        public string Email { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<EventoDto> Eventos { get; set; }
    }
}