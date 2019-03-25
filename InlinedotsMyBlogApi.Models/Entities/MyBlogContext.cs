using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InlinedotsMyBlogApi.Models.Entities
{
    public partial class MyBlogContext : DbContext
    {
        public MyBlogContext()
        {
        }

        public MyBlogContext(DbContextOptions<MyBlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseMySQL("server="IP-ADDRESS";port="PORT";user="USERNAME";password="PW";database="DBNAME");
    }
    //            }
    //        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog", "MyBlog");

                entity.HasIndex(e => e.EntityId)
                    .HasName("FK_Blog_Entity_Id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BodyText)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EntityId).HasColumnType("int(11)");

                entity.Property(e => e.HeadLine)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Entity)
                    .WithMany(p => p.Blog)
                    .HasForeignKey(d => d.EntityId)
                    .HasConstraintName("FK_Blog_Entity_Id");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("Entity", "MyBlog");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Deleted).HasColumnType("tinyint(1)");
            });
        }
    }
}
