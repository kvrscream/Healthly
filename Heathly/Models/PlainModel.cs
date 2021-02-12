using System;
namespace Heathly.Models
{
    public class PlainModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime InicioVigencia { get; set; }

        public DateTime FimVigencia { get; set; }

        public bool PermitePJ { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
