using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Domain.Entities
{
    public class Athlete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual IEnumerable<Entry> Entries { get; set; }

        public decimal Envion 
        { 
            get
            {
                if (Entries is null || Entries.Count() <= 0 || !Entries.Any(x => x.Type == EntryType.ENVION))
                {
                    return 0;
                }

                return Entries.Where(x => x.Type == EntryType.ENVION).Select(x => x.Weight).Max();
            } 
        }

        public decimal Arranque
        {
            get
            {
                if (Entries is null || Entries.Count() <= 0 || !Entries.Any(x => x.Type == EntryType.ARRANQUE))
                {
                    return 0;
                }

                return Entries.Where(x => x.Type == EntryType.ARRANQUE).Select(x => x.Weight).Max();
            }
        }

        public decimal Total
        {
            get
            {
                return Arranque + Envion;
            }
        }
    }
}
