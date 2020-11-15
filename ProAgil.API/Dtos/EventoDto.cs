using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength=3)]
        public string Local { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength=3)]
        public string Tema { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório")]
        [Range(2, 120000, ErrorMessage="O campo {0} deve ter entre 2 e 120000.")]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }

        [Phone(ErrorMessage="Insira um telefone válido.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage="Insira um e-mail válido.")]
        public string Email { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}