using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class Gender
    {
        public Gender()
        {
            People = new HashSet<Person>();
        }

        public short GenderId { get; set; }
        public string Gender1 { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
