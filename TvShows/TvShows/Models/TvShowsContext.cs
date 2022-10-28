using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TvShows.Models
{
    public partial class TvShowsContext : DbContext
    {
        public TvShowsContext()
        {
        }

        public TvShowsContext(DbContextOptions<TvShowsContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Character> Characters { get; set; } = null!;
        public virtual DbSet<Episode> Episodes { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<ListGenre> ListGenres { get; set; } = null!;
        public virtual DbSet<TvShow> TvShows { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TvShows;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.IdActor)
                    .HasName("PK__Actors__F86BE7176C96ECFD");

                entity.Property(e => e.IdActor).HasColumnName("id_actor");

                entity.Property(e => e.ActorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("actor_name");

                entity.Property(e => e.Age).HasColumnName("age");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.HasKey(e => e.IdCharacter)
                    .HasName("PK__Characte__CC7A412903A3C747");

                entity.Property(e => e.IdCharacter).HasColumnName("id_character");

                entity.Property(e => e.CharacterName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("character_name");

                entity.Property(e => e.IdActor).HasColumnName("id_actor");

                entity.Property(e => e.IdTvShow).HasColumnName("id_tv_show");

                entity.HasOne(d => d.IdActorNavigation)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.IdActor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Character__id_ac__2A4B4B5E");

                entity.HasOne(d => d.IdTvShowNavigation)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.IdTvShow)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Character__id_tv__2B3F6F97");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.HasKey(e => e.IdEpisode)
                    .HasName("PK__Episodes__ADD8EE5866222E42");

                entity.Property(e => e.IdEpisode).HasColumnName("id_episode");

                entity.Property(e => e.AirDate)
                    .HasColumnType("date")
                    .HasColumnName("air_date");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.EpisodeNumb).HasColumnName("episode_numb");

                entity.Property(e => e.IdTvShow).HasColumnName("id_tv_show");

                entity.Property(e => e.Season).HasColumnName("season");

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.IdTvShowNavigation)
                    .WithMany(p => p.Episodes)
                    .HasForeignKey(d => d.IdTvShow)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Episodes__id_tv___25869641");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => e.IdFavorites)
                    .HasName("PK__Favorite__78018FD84F24738D");

                entity.Property(e => e.IdFavorites).HasColumnName("id_favorites");

                entity.Property(e => e.IdTvShow).HasColumnName("id_tv_show");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdTvShowNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.IdTvShow)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Favorites__id_tv__36B12243");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Favorites__id_us__35BCFE0A");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("PK__Genres__CB767C69A5395BB9");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<ListGenre>(entity =>
            {
                entity.HasKey(e => e.IdListGenres)
                    .HasName("PK__ListGenr__7FD949F26941E9F3");

                entity.Property(e => e.IdListGenres).HasColumnName("id_list_genres");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.IdTvShow).HasColumnName("id_tv_show");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.ListGenres)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ListGenre__id_ge__300424B4");

                entity.HasOne(d => d.IdTvShowNavigation)
                    .WithMany(p => p.ListGenres)
                    .HasForeignKey(d => d.IdTvShow)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__ListGenre__id_tv__30F848ED");
            });

            modelBuilder.Entity<TvShow>(entity =>
            {
                entity.HasKey(e => e.IdTvShow)
                    .HasName("PK__TvShow__0F44FD9752D289FC");

                entity.ToTable("TvShow");

                entity.Property(e => e.IdTvShow).HasColumnName("id_tv_show");

                entity.Property(e => e.Poster)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("poster");

                entity.Property(e => e.ShowDescription)
                    .HasMaxLength(1500)
                    .IsUnicode(false)
                    .HasColumnName("show_description");

                entity.Property(e => e.ShowStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("show_status");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__D2D146378E96E4BD");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("pwd");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
