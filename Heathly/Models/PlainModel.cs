using System;
using System.ComponentModel.DataAnnotations;

namespace Heathly.Models
{
    public class PlainModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome deve ser preenchido.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo início da vigência deve ser preenchido.")]
        public DateTime InicioVigencia { get; set; }

        [Required(ErrorMessage = "Campo fim da vigência deve ser preenchido.")]
        public DateTime FimVigencia { get; set; }

        public bool PermitePJ { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
