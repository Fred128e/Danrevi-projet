using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Danrevi.Models
{
    public partial class danrevi_webContext : DbContext
    {
        public danrevi_webContext()
        {
        }

        public danrevi_webContext(DbContextOptions<danrevi_webContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Deadlines> Deadlines { get; set; }
        public virtual DbSet<Migrations> Migrations { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RoleUser> RoleUser { get; set; }
        public virtual DbSet<UserCourse> UserCourse { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'danrevi_web.password_resets'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("SqlConn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.ToTable("articles", "danrevi_web");

                entity.HasIndex(e => e.UserId)
                    .HasName("articles_user_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("longtext");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DateCreated).HasColumnName("date_created");

                entity.Property(e => e.Tags)
                    .IsRequired()
                    .HasColumnName("tags")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("articles_user_id_foreign");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.ToTable("courses", "danrevi_web");

                entity.HasIndex(e => e.UserId)
                    .HasName("courses_user_id_foreign");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.End).HasColumnName("end");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Start).HasColumnName("start");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("courses_user_id_foreign");
            });

            modelBuilder.Entity<Deadlines>(entity =>
            {
                entity.ToTable("deadlines", "danrevi_web");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Migrations>(entity =>
            {
                entity.ToTable("migrations", "danrevi_web");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Batch)
                    .HasColumnName("batch")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Migration)
                    .IsRequired()
                    .HasColumnName("migration")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles", "danrevi_web");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });

                entity.ToTable("role_user", "danrevi_web");

                entity.HasIndex(e => e.UserId)
                    .HasName("role_user_user_id_foreign");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUser)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_user_role_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("role_user_user_id_foreign");
            });

            modelBuilder.Entity<UserCourse>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.UserId });

                entity.ToTable("user_course", "danrevi_web");

                entity.HasIndex(e => e.CourseId)
                    .HasName("user_course_course_id_foreign");

                entity.Property(e => e.CourseId)
                    .HasColumnName("course_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserCourse)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_course_course_id_foreign");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCourse)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_course_user_id_foreign");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "danrevi_web");

                entity.HasIndex(e => e.ApiToken)
                    .HasName("users_api_token_unique")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.ApiToken)
                    .HasColumnName("api_token")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailVerifiedAt).HasColumnName("email_verified_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });
        }
    }
}
