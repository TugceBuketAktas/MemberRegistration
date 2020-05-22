using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MemberRegistration.Data.Models
{
    public partial class MemberRegistrationContext : DbContext
    {
        public MemberRegistrationContext()
        {
        }

        public MemberRegistrationContext(DbContextOptions<MemberRegistrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=BUKETSPC;Database=MemberRegistration;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserCity)
                    .HasColumnName("user_city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserFullname)
                    .HasColumnName("user_fullname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserJob)
                    .HasColumnName("user_job")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserNeighborhood)
                    .HasColumnName("user_neighborhood")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPasswd)
                    .IsRequired()
                    .HasColumnName("user_passwd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPermission).HasColumnName("user_permission");

                entity.Property(e => e.UserPhone)
                    .HasColumnName("user_phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserRegistration)
                    .HasColumnName("user_registration")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserSalary)
                    .HasColumnName("user_salary")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.UserUrl)
                    .HasColumnName("user_url")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserUsername)
                    .IsRequired()
                    .HasColumnName("user_username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
