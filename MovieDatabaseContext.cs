using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MoviesAPI.Models
{
    public partial class MovieDatabaseContext : DbContext
    {
        public MovieDatabaseContext()
        {
        }

        public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<Award> Awards { get; set; }
        public virtual DbSet<AwardType> AwardTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieAward> MovieAwards { get; set; }
        public virtual DbSet<MovieCast> MovieCasts { get; set; }
        public virtual DbSet<MovieCompany> MovieCompanies { get; set; }
        public virtual DbSet<MovieCrew> MovieCrews { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<MovieKeyword> MovieKeywords { get; set; }
        public virtual DbSet<MovieLanguage> MovieLanguages { get; set; }
        public virtual DbSet<MovieReview> MovieReviews { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonToMovieAward> PersonToMovieAwards { get; set; }
        public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public virtual DbSet<ProductionCountry> ProductionCountries { get; set; }
        public virtual DbSet<RoleChangeLog> RoleChangeLogs { get; set; }
        public virtual DbSet<RoleToPrivilege> RoleToPrivileges { get; set; }
        public virtual DbSet<TopMovie> TopMovies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }
        public virtual DbSet<UserPrivilege> UserPrivileges { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<VoteReview> VoteReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-ODHDV0AR;Database=MovieDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.ToTable("activity_type");

                entity.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");

                entity.Property(e => e.ActivityTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("activity_type_name");
            });

            modelBuilder.Entity<Award>(entity =>
            {
                entity.ToTable("awards");

                entity.Property(e => e.AwardId)
                    .ValueGeneratedNever()
                    .HasColumnName("award_id");

                entity.Property(e => e.AwardName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("award_name");
            });

            modelBuilder.Entity<AwardType>(entity =>
            {
                entity.ToTable("award_type");

                entity.Property(e => e.AwardTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("award_type_id");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryIso);

                entity.ToTable("country");

                entity.Property(e => e.CountryIso)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country_iso")
                    .IsFixedLength(true);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.GenderId)
                    .ValueGeneratedNever()
                    .HasColumnName("gender_id");

                entity.Property(e => e.Gender1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("gender");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("genre_name");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.ToTable("keywords");

                entity.Property(e => e.KeywordId).HasColumnName("keyword_id");

                entity.Property(e => e.KeywordName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("keyword_name");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.Iso6391);

                entity.ToTable("language");

                entity.Property(e => e.Iso6391)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("iso_639_1")
                    .IsFixedLength(true);

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("language_name");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.Budget)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("budget");

                entity.Property(e => e.Homepage)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("homepage");

                entity.Property(e => e.MovieStatus)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("movie_status");

                entity.Property(e => e.Overview)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("overview");

                entity.Property(e => e.Popularity)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("popularity");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.Revenue)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("revenue");

                entity.Property(e => e.Runtime).HasColumnName("runtime");

                entity.Property(e => e.Tagline)
                    .HasMaxLength(1000)
                    .HasColumnName("tagline");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("title");

                entity.Property(e => e.VotesAvg)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("votes_avg");

                entity.Property(e => e.VotesCount).HasColumnName("votes_count");
            });

            modelBuilder.Entity<MovieAward>(entity =>
            {
                entity.HasKey(e => e.MovieAwardsId);

                entity.ToTable("movie_awards");

                entity.Property(e => e.MovieAwardsId)
                    .ValueGeneratedNever()
                    .HasColumnName("movie_awards_id");

                entity.Property(e => e.AwardId).HasColumnName("award_id");

                entity.Property(e => e.AwardTypeId).HasColumnName("award_type_id");

                entity.Property(e => e.MovieAwardsDatetime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("movie_awards_datetime");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Award)
                    .WithMany(p => p.MovieAwards)
                    .HasForeignKey(d => d.AwardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_awards_awards");

                entity.HasOne(d => d.AwardType)
                    .WithMany(p => p.MovieAwards)
                    .HasForeignKey(d => d.AwardTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_awards_award_type");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieAwards)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_awards_movie");
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_cast");

                entity.Property(e => e.CharacterName)
                    .HasMaxLength(300)
                    .HasColumnName("character_name");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_movie_cast_movie");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_cast_person");
            });

            modelBuilder.Entity<MovieCompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Company)
                    .WithMany()
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_company_production_company");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_movie_company_movie");
            });

            modelBuilder.Entity<MovieCrew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_crew");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_crew_department");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_movie_crew_movie");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_crew_person");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_genre_genre");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_movie_genre_movie");
            });

            modelBuilder.Entity<MovieKeyword>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_keywords");

                entity.Property(e => e.KeywordId).HasColumnName("keyword_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Keyword)
                    .WithMany()
                    .HasForeignKey(d => d.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_keywords_keywords");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_movie_keywords_movie");
            });

            modelBuilder.Entity<MovieLanguage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_languages");

                entity.Property(e => e.IsOriginal).HasColumnName("is_original");

                entity.Property(e => e.Iso6391)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("iso_639_1")
                    .IsFixedLength(true);

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Iso6391Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.Iso6391)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_languages_language");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_movie_languages_movie");
            });

            modelBuilder.Entity<MovieReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.ToTable("movie_review");

                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("review_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.ReviewDatetime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("review_datetime");

                entity.Property(e => e.ReviewDescription)
                    .HasColumnType("text")
                    .HasColumnName("review_description");

                entity.Property(e => e.ReviewRating)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("review_rating");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserScore)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("user_score");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieReviews)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_movie_review_movie");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MovieReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movie_review_users");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("birth_date");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.PersonName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("person_name");

                entity.Property(e => e.PersonScenicName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("person_scenic_name");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_gender");
            });

            modelBuilder.Entity<PersonToMovieAward>(entity =>
            {
                entity.HasKey(e => e.PersonToMovieAwardsId);

                entity.ToTable("person_to_movie_award");

                entity.Property(e => e.PersonToMovieAwardsId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_to_movie_awards_id");

                entity.Property(e => e.MovieAwardsId).HasColumnName("movie_awards_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.MovieAwards)
                    .WithMany(p => p.PersonToMovieAwards)
                    .HasForeignKey(d => d.MovieAwardsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_to_movie_award_movie_awards");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonToMovieAwards)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_person_to_movie_award_person");
            });

            modelBuilder.Entity<ProductionCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("production_company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("company_name");
            });

            modelBuilder.Entity<ProductionCountry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("production_country");

                entity.Property(e => e.CountryIso)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country_iso")
                    .IsFixedLength(true);

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.CountryIsoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CountryIso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_production_country_country");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_production_country_movie");
            });

            modelBuilder.Entity<RoleChangeLog>(entity =>
            {
                entity.ToTable("role_change_log");

                entity.Property(e => e.RoleChangeLogId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_change_log_id");

                entity.Property(e => e.ChangeRoleFrom).HasColumnName("change_role_from");

                entity.Property(e => e.ChangeRoleTo).HasColumnName("change_role_to");

                entity.Property(e => e.EventTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("event_time");

                entity.Property(e => e.SetByUser).HasColumnName("set_by_user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ChangeRoleFromNavigation)
                    .WithMany(p => p.RoleChangeLogChangeRoleFromNavigations)
                    .HasForeignKey(d => d.ChangeRoleFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_role_change_log_user_roles");

                entity.HasOne(d => d.ChangeRoleToNavigation)
                    .WithMany(p => p.RoleChangeLogChangeRoleToNavigations)
                    .HasForeignKey(d => d.ChangeRoleTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_role_change_log_user_roles1");

                entity.HasOne(d => d.SetByUserNavigation)
                    .WithMany(p => p.RoleChangeLogSetByUserNavigations)
                    .HasForeignKey(d => d.SetByUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_role_change_log_users1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleChangeLogUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_role_change_log_users");
            });

            modelBuilder.Entity<RoleToPrivilege>(entity =>
            {
                entity.ToTable("role_to_privileges");

                entity.Property(e => e.RoleToPrivilegeId)
                    .ValueGeneratedNever()
                    .HasColumnName("role_to_privilege_id");

                entity.Property(e => e.UserPrivilegeId).HasColumnName("user_privilege_id");

                entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

                entity.HasOne(d => d.UserPrivilege)
                    .WithMany(p => p.RoleToPrivileges)
                    .HasForeignKey(d => d.UserPrivilegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_role_to_privileges_role_to_privileges1");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.RoleToPrivileges)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_role_to_privileges_user_roles");
            });

            modelBuilder.Entity<TopMovie>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TopMovies");

                entity.Property(e => e.MovieId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("movie_id");

                entity.Property(e => e.Popularity)
                    .HasColumnType("decimal(12, 4)")
                    .HasColumnName("popularity");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("title");

                entity.Property(e => e.VotesAvg)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("votes_avg");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastLogonTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("last_logon_time");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.RegisterComplete).HasColumnName("register_complete");

                entity.Property(e => e.RegisterTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("register_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

                entity.Property(e => e.UserScore)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("user_score");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_user_roles");
            });

            modelBuilder.Entity<UserActivityLog>(entity =>
            {
                entity.HasKey(e => e.ActivityId);

                entity.ToTable("user_activity_log");

                entity.Property(e => e.ActivityId)
                    .ValueGeneratedNever()
                    .HasColumnName("activity_id");

                entity.Property(e => e.ActivityDatetime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("activity_datetime");

                entity.Property(e => e.ActivityDescription)
                    .HasColumnType("text")
                    .HasColumnName("activity_description");

                entity.Property(e => e.ActivityTypeId).HasColumnName("activity_type_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.UserActivityLogs)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_activity_log_activity_type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserActivityLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_activity_log_users");
            });

            modelBuilder.Entity<UserPrivilege>(entity =>
            {
                entity.ToTable("user_privileges");

                entity.Property(e => e.UserPrivilegeId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_privilege_id");

                entity.Property(e => e.PrivilegeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("privilege_name");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_roles");

                entity.Property(e => e.UserRoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_role_id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<VoteReview>(entity =>
            {
                entity.ToTable("vote_review");

                entity.Property(e => e.VoteReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("vote_review_id");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserScore)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("user_score");

                entity.Property(e => e.VoteDatetime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("vote_datetime");

                entity.Property(e => e.VoteReviewDescription)
                    .HasColumnType("text")
                    .HasColumnName("vote_review_description");

                entity.Property(e => e.VoteReviewRating)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("vote_review_rating");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.VoteReviews)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vote_review_movie_review");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VoteReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vote_review_users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
