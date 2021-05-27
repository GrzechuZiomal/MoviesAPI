using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class MovieCrew
    {
        public long MovieId { get; set; }
        public long PersonId { get; set; }
        public long DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Movie Movie { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
    }
}
