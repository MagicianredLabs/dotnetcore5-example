using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace it.example.dotnetcore5.dal.ef.sqlserver.EfModels
{
    public partial class MyBlog_02Context : DbContext
    {
        public MyBlog_02Context()
        {
        }

        public MyBlog_02Context(DbContextOptions<MyBlog_02Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DbScriptMigration> DbScriptMigrations { get; set; }
        public virtual DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DbScriptMigration>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("DbScriptMigration");

                entity.Property(e => e.MigrationId).ValueGeneratedNever();

                entity.Property(e => e.MigrationDate).HasColumnType("datetime");

                entity.Property(e => e.MigrationName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
