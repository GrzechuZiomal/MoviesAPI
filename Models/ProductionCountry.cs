using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class ProductionCountry
    {
        public long MovieId { get; set; }
        public string CountryIso { get; set; }

        public virtual Country CountryIsoNavigation { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
