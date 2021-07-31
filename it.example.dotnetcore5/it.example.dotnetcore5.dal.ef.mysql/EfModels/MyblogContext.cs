using Microsoft.EntityFrameworkCore;

#nullable disable

namespace it.example.dotnetcore5.dal.ef.mysql.EfModels
{
    public partial class MyblogContext : DbContext
    {
        public MyblogContext()
        {
        }

        public MyblogContext(DbContextOptions<MyblogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dbscriptmigration> Dbscriptmigrations { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Posttag> Posttags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Dbscriptmigration>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("dbscriptmigration");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(38)
                    .IsFixedLength(true);

                entity.Property(e => e.MigrationName)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.CategoryId, "FK_Posts_CategoryId");

                entity.Property(e => e.Author).HasMaxLength(200);

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("posts_ibfk_1");
            });

            modelBuilder.Entity<Posttag>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId })
                    .HasName("PRIMARY");

                entity.ToTable("posttags");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
