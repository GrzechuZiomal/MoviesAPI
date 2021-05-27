using System;
using System.Collections.Generic;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class User
    {
        public User()
        {
            MovieReviews = new HashSet<MovieReview>();
            RoleChangeLogSetByUserNavigations = new HashSet<RoleChangeLog>();
            RoleChangeLogUsers = new HashSet<RoleChangeLog>();
            UserActivityLogs = new HashSet<UserActivityLog>();
            VoteReviews = new HashSet<VoteReview>();
        }

        public User(int userId, string username, string password, string firstName, string lastName, string emailAddress, bool registerComplete, DateTime lastLogonTime, decimal userScore, int userRoleId, DateTime registerTime/*, UserRole userRole*/)
        {
            UserId = userId;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            RegisterComplete = registerComplete;
            LastLogonTime = lastLogonTime;
            UserScore = userScore;
            UserRoleId = userRoleId;
            RegisterTime = registerTime;
            //UserRole = userRole;
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool RegisterComplete { get; set; }
        public DateTime LastLogonTime { get; set; }
        public decimal UserScore { get; set; }
        public int UserRoleId { get; set; }
        public DateTime RegisterTime { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
        public virtual ICollection<RoleChangeLog> RoleChangeLogSetByUserNavigations { get; set; }
        public virtual ICollection<RoleChangeLog> RoleChangeLogUsers { get; set; }
        public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; }
        public virtual ICollection<VoteReview> VoteReviews { get; set; }
    }
}
