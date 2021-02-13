using System;
using System.Collections.Generic;

namespace Heathly.Models
{
    public class ClientPlainsModel
    {
        public int Id { get; set; }

        public virtual PersonModel Client { get; set; }

        public virtual PlainModel Planos { get; set; }
    }
}
