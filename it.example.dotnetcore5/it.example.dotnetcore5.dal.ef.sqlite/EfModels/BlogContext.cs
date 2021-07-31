using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace it.example.dotnetcore5.dal.ef.sqlite.EfModels
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbScriptMigration> DbScriptMigrations { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbScriptMigration>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("DbScriptMigration");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(38)");

                entity.Property(e => e.MigrationDate)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.MigrationName)
                    .IsRequired()
                    .HasColumnType("varchar(1000)");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(1000)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
