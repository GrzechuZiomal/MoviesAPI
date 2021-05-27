using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class Person
    {
        public Person()
        {
            PersonToMovieAwards = new HashSet<PersonToMovieAward>();
        }

        public long PersonId { get; set; }
        public short GenderId { get; set; }
        public string GenderName { get => GetGenderName(GenderId); }
        public string PersonScenicName { get; set; }
        public string PersonName { get; set; }
        public DateTime? BirthDate { get; set; }

        [NotMapped]
        public ICollection<MovieCrew> WorkedIn { get; set; }

        [NotMapped]
        public ICollection<MovieCast> PlayedIn { get;  set; }
 

        [JsonIgnore]
        public virtual Gender Gender { get; set; }
        [JsonIgnore]
        public virtual ICollection<PersonToMovieAward> PersonToMovieAwards { get; set; }


        public string GetGenderName(short gender)
        {
            switch (gender)
            {
                case 2:
                    return "Female";
                case 3:
                    return "Male";
                case 4:
                    return "Non binary";
                default:
                    return "Unknown";
            }
        }
    }
}
