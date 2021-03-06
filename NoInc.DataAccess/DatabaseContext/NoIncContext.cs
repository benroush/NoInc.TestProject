using Microsoft.EntityFrameworkCore;
using NoInc.DataAccess.Models;

namespace NoInc.DataAccess.DatabaseContext
{
    public partial class NoIncContext : DbContext
    {
        public NoIncContext()
        {
        }

        public NoIncContext(DbContextOptions<NoIncContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InterestEntity> Interests { get; set; }
        public virtual DbSet<SkillEntity> Skills { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<InterestEntity>(entity =>
            {
                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SkillEntity>(entity =>
            {
                entity.Property(e => e.DateLearned).HasColumnType("date");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}