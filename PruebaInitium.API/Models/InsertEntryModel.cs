using Microsoft.AspNetCore.Mvc;
using PruebaInitium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaInitium.API.Models
{
    public class InsertEntryModel
    {
        public decimal Weight { get; set; }
        public EntryType Type { get; set; }
    }
}
