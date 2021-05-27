using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class Crew : Person
    {
        public long MovieId { get; set; }
        public Department Department{get; set;}
        //public long DepartmentId { get; set; }

        //public string DepartmentName { get; set; }

        public Crew() { }

        public Crew(Person person)
        {
            PersonId = person.PersonId;
            GenderId = person.GenderId;
            PersonScenicName = person.PersonScenicName;
            PersonName = person.PersonName;
            BirthDate = person.BirthDate;
            Gender = person.Gender;
            PersonToMovieAwards = person.PersonToMovieAwards;
        }
    }
}
