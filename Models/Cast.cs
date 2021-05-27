using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class Cast : Person
    {
        public long MovieId { get; set; }
        public long DepartmentId { get; set; }

        public string CharacterName { get; set; }

        public Cast() { }

        public Cast(Person person)
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
