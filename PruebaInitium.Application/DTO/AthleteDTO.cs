using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Application.DTO
{
    public class AthleteDTO
    {
        public Guid Id { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }

        public decimal Envion { get; set; }

        public decimal Arranque { get; set; }

        public decimal Total { get; set; }
    }
}
