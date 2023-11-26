using PruebaInitium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.Domain.Repositories
{
    public interface IEntryRepository
    {
        Task<Entry> Insert(Entry entry);
    }
}
