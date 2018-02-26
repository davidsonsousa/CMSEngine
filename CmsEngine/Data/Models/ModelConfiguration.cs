using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CmsEngine.Data.Models
{
    public static class ModelConfiguration
    {
        public static void ConfigureWebsite(EntityTypeBuilder<Website> b)
        {
            // Fields
            b.HasKey(model => model.Id);

            b.Property(model => model.Name)
                .HasMaxLength(200)
                .IsRequired();

            b.Property(model => model.Description)
                .HasMaxLength(200);

            b.Property(model => model.Culture)
                .HasMaxLength(5)
                .IsRequired();

            b.Property(model => model.UrlFormat)
                .HasMaxLength(100)
                .IsRequired();

            b.Property(model => model.DateFormat)
                .HasMaxLength(10)
                .IsRequired();

            b.Property(model => model.SiteUrl)
                .HasMaxLength(250)
                .IsRequired();

            b.Property(model => model.UserCreated)
                .HasMaxLength(20);

            b.Property(model => model.UserModified)
                .HasMaxLength(20);

            b.Property(model => model.VanityId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newid()");

            // Relationships
            b.HasMany(model => model.Posts);
            b.HasMany(model => model.Pages);
            b.HasMany(model => model.Tags);
            b.HasMany(model => model.Categories);
        }

        public static void ConfigurePage(EntityTypeBuilder<Page> b)
        {
            // Fields
            b.HasKey(model => model.Id);

            b.Property(model => model.Title)
                .HasMaxLength(100)
                .IsRequired();

            b.Property(model => model.Slug)
                .HasMaxLength(25)
                .IsRequired();

            b.Property(model => model.Description)
                .HasMaxLength(150)
                .IsRequired();

            //b.Property(model => model.DocumentContent)
            //    .IsRequired();

            b.Property(model => model.Author)
                .HasMaxLength(20)
                .IsRequired();

            b.Property(model => model.PublishedOn)
                .IsRequired();

            b.Property(model => model.UserCreated)
                .HasMaxLength(20);

            b.Property(model => model.UserModified)
                .HasMaxLength(20);

            b.Property(model => model.UserCreated)
                .HasMaxLength(20);

            b.Property(model => model.UserModified)
                .HasMaxLength(20);

            b.Property(model => model.VanityId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newid()");

            // Relationships
            b.HasOne(model => model.Website)
                .WithMany(model => model.Pages);
        }

        public static void ConfigurePost(EntityTypeBuilder<Post> b)
        {
            // Fields
            b.HasKey(model => model.Id);

            b.Property(model => model.Title)
                .HasMaxLength(100)
                .IsRequired();

            b.Property(model => model.Slug)
                .HasMaxLength(25)
                .IsRequired();

            b.Property(model => model.Description)
                .HasMaxLength(150)
                .IsRequired();

            //b.Property(model => model.DocumentContent)
            //    .IsRequired();

            b.Property(model => model.Author)
                .HasMaxLength(20)
                .IsRequired();

            b.Property(model => model.PublishedOn)
                .IsRequired();

            b.Property(model => model.UserCreated)
                .HasMaxLength(20);

            b.Property(model => model.UserModified)
                .HasMaxLength(20);

            b.Property(model => model.UserCreated)
                .HasMaxLength(20);

            b.Property(model => model.UserModified)
                .HasMaxLength(20);

            b.Property(model => model.VanityId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newid()");

            // Relationships
            b.HasOne(model => model.Website)
                .WithMany(model => model.Posts);
        }

        public static void ConfigureCategory(EntityTypeBuilder<Category> b)
        {
            // Fields
            b.HasKey(model => model.Id);

            b.Property(model => model.Name)
                .HasMaxLength(25)
                .IsRequired();

            b.Property(model => model.Slug)
                .HasMaxLength(25)
                .IsRequired();

            b.Property(model => model.Description)
                .HasMaxLength(200);

            b.Property(model => model.UserCreated)
                .HasMaxLength(20);

            b.Property(model => model.UserModified)
                .HasMaxLength(20);

            b.Property(model => model.VanityId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newid()");
        }

        public static void ConfigureTag(EntityTypeBuilder<Tag> b)
        {
            // Fields
            b.HasKey(model => model.Id);

            b.Property(model => model.Name)
                .HasMaxLength(25)
                .IsRequired();

            b.Property(model => model.Slug)
                .HasMaxLength(25)
                .IsRequired();

            b.Property(model => model.UserCreated)
                .HasMaxLength(20);

            b.Property(model => model.UserModified)
                .HasMaxLength(20);

            b.Property(model => model.VanityId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newid()");
        }

        // Many to many

        public static void ConfigurePostCategory(EntityTypeBuilder<PostCategory> b)
        {
            b.HasKey(model => new { model.PostId, model.CategoryId });
        }

        public static void ConfigurePostTag(EntityTypeBuilder<PostTag> b)
        {
            b.HasKey(model => new { model.PostId, model.TagId });

            b.HasOne(model => model.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(model => model.PostId);

            b.HasOne(model => model.Tag)
                .WithMany(c => c.PostTags)
                .HasForeignKey(model => model.TagId);
        }
    }
}
