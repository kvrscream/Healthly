using System;
using System.ComponentModel.DataAnnotations;

namespace Heathly.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome precisa ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo documento precisa ser preenchido")]
        public string Documento { get; set; }

        public string RG { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool PJ { get; set; }
    }
}
