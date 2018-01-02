using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPress.Models
{
    public partial class aspressContext : DbContext
    {
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Meta> Meta { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Terms> Terms { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'roles_users'. Please see the warning messages.
        // Unable to generate entity type for table 'terms_posts'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite(@"DataSource=./aspress.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");

                entity.HasIndex(e => e.PostId)
                    .HasName("comments.fk_comments_1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("VARCHAR(256)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("TINYTEXT");

                entity.Property(e => e.PostId)
                    .HasColumnName("post_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("VARCHAR(16)")
                    .HasDefaultValueSql("'awaiting'");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Meta>(entity =>
            {
                entity.ToTable("meta");

                entity.HasIndex(e => e.Model)
                    .HasName("meta.index2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasColumnType("TINYTEXT");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasColumnType("VARCHAR(45)")
                    .HasDefaultValueSql("'article'");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("posts.fk_posts_1_idx");

                entity.HasIndex(e => e.Type)
                    .HasName("posts.type");

                entity.HasIndex(e => e.Url)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("LONGTEXT");

                entity.Property(e => e.DateCreated)
                    .IsRequired()
                    .HasColumnName("date_created")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateModified)
                    .HasColumnName("date_modified")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.DatePublish)
                    .IsRequired()
                    .HasColumnName("date_publish")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("VARCHAR(128)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("VARCHAR(16)")
                    .HasDefaultValueSql("'draft'");

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasColumnType("TINYTEXT");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("TINYTEXT");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("VARCHAR(64)")
                    .HasDefaultValueSql("'article'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("TINYTEXT");

                entity.Property(e => e.Visibility)
                    .HasColumnName("visibility")
                    .HasColumnType("VARCHAR(16)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Reference)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("TINYTEXT");

                entity.Property(e => e.Permissions)
                    .HasColumnName("permissions")
                    .HasColumnType("LONGTEXT")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasColumnName("reference")
                    .HasColumnType("VARCHAR(128)");
            });

            modelBuilder.Entity<Terms>(entity =>
            {
                entity.ToTable("terms");

                entity.HasIndex(e => e.ParentId)
                    .HasName("terms.fk_terms_1_idx");

                entity.HasIndex(e => e.Url)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.PostType)
                    .HasColumnName("post_type")
                    .HasColumnType("VARCHAR(45)")
                    .HasDefaultValueSql("'article'");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("TINYTEXT");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .IsRequired()
                    .HasColumnName("date_created")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateLastLogin)
                    .IsRequired()
                    .HasColumnName("date_last_login")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("TINYTEXT");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("VARCHAR(128)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("VARCHAR(128)");
            });
        }
    }
}
