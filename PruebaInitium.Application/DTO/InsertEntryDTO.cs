using PruebaInitium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Application.DTO
{
    public class InsertEntryDTO
    {
        public Guid AthleteId { get; set; }

        public double Weight { get; set; }

        public EntryType Type { get; set; }
    }
}
