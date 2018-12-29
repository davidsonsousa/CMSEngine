﻿// <auto-generated />
using System;
using CmsEngine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CmsEngine.Migrations
{
    [DbContext(typeof(CmsEngineContext))]
    partial class CmsEngineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CmsEngine.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Surname");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "2be0d553-bc1d-4074-872d-846c60a24863", AccessFailedCount = 0, ConcurrencyStamp = "96244ec4-bd54-492b-922e-873e774611cd", Email = "john@doe.com", EmailConfirmed = true, LockoutEnabled = false, Name = "John", NormalizedEmail = "JOHN@DOE.COM", NormalizedUserName = "JOHN@DOE.COM", PasswordHash = "AQAAAAEAACcQAAAAEGIUaLe7RWZGw8Tr5/xoUMOooAzJsLFw550fDqZkrbk8CD+urHQzYjK1xY8vcDMekw==", PhoneNumberConfirmed = false, SecurityStamp = "NBTDBYKTNLGHKQ3HI7YFEHPQN5YRXWQC", Surname = "Doe", TwoFactorEnabled = false, UserName = "john@doe.com" }
                    );
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("UserCreated")
                        .HasMaxLength(20);

                    b.Property<string>("UserModified")
                        .HasMaxLength(20);

                    b.Property<Guid>("VanityId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("WebsiteId");

                    b.HasKey("Id");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), IsDeleted = false, Name = "Category example", Slug = "category-example", VanityId = new Guid("93313739-ef6f-4a08-8866-67dcf70c89e7"), WebsiteId = 1 }
                    );
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("DocumentContent");

                    b.Property<string>("HeaderImagePath");

                    b.Property<string>("HeaderImagePathThumb");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("PublishedOn");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserCreated")
                        .HasMaxLength(20);

                    b.Property<string>("UserModified")
                        .HasMaxLength(20);

                    b.Property<Guid>("VanityId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("WebsiteId");

                    b.HasKey("Id");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Pages");

                    b.HasData(
                        new { Id = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "This is a sample page from a sample website", DocumentContent = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed risus libero, egestas vel tempus id, venenatis nec tellus. Nullam hendrerit id magna quis venenatis. Pellentesque rhoncus leo vitae turpis tristique, nec placerat tellus scelerisque. Aenean vitae rhoncus urna, non posuere elit. Nullam quam libero, porttitor in lectus convallis, pellentesque finibus libero. Suspendisse potenti. Fusce quis purus egestas, malesuada massa sed, dignissim purus. Curabitur vitae rhoncus nulla, sit amet dignissim quam.</p>
                                       <p>Mauris lorem urna, convallis in enim nec, tristique ullamcorper nisl. Fusce nec tellus et arcu imperdiet ullamcorper vestibulum vitae mi. Sed bibendum molestie dolor sit amet rhoncus.Duis consectetur convallis auctor. In hac habitasse platea dictumst.Duis lorem nibh, mattis ut purus interdum, scelerisque molestie est. Nullam molestie a est vel ornare. Maecenas rhoncus accumsan ligula, at pretium purus tempus ut. Aliquam erat nulla, pretium vel eros vitae, blandit aliquam nibh. Nulla tincidunt, justo et ullamcorper dictum, augue lectus dictum ligula, eget rutrum sem nibh non felis.Aenean elementum, sem sit amet pulvinar tempus, neque eros faucibus turpis, quis molestie nisi libero quis purus.</p>
                                       <p>Donec quam massa, tincidunt eu lacus in, lacinia hendrerit urna. Pellentesque pretium orci a felis tincidunt, sit amet volutpat est dapibus. Donec laoreet, massa in imperdiet laoreet, enim ligula auctor est, non imperdiet nisi diam vitae quam. Integer nec porttitor ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Morbi non pretium risus, a lobortis eros. Etiam blandit diam tortor. Ut feugiat eros id erat auctor, ut vehicula odio vestibulum.</p>
                                       <p>Nunc sed ex sed diam euismod eleifend. Proin blandit lorem sed placerat fermentum. Curabitur non gravida felis, ac sollicitudin nibh. Morbi ornare sapien vitae nisl condimentum cursus.Vivamus bibendum condimentum metus, ut gravida orci bibendum maximus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Duis varius, tortor ac placerat faucibus, lectus mauris bibendum elit, id eleifend leo diam ac nulla.Aenean egestas urna facilisis purus ullamcorper vestibulum.Etiam commodo suscipit turpis, quis lobortis metus posuere sed.</p>
                                       <p>Praesent in augue sit amet tortor ultricies maximus eu ac dui.Pellentesque et congue elit. Suspendisse potenti. Donec facilisis eu magna nec bibendum. Nullam in dignissim elit. Integer laoreet odio massa, vel vestibulum mauris varius et. Ut non ex sit amet nisl mollis laoreet. </p> ", IsDeleted = false, PublishedOn = new DateTime(2018, 12, 29, 18, 49, 52, 930, DateTimeKind.Local), Slug = "sample-page", Status = 0, Title = "Sample page", VanityId = new Guid("fb747abc-0700-4066-9c01-19dface272d3"), WebsiteId = 1 }
                    );
                });

            modelBuilder.Entity("CmsEngine.Data.Models.PageApplicationUser", b =>
                {
                    b.Property<int>("PageId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("PageId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("PageAspNetUser");

                    b.HasData(
                        new { PageId = 1, ApplicationUserId = "2be0d553-bc1d-4074-872d-846c60a24863" }
                    );
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("DocumentContent");

                    b.Property<string>("HeaderImagePath");

                    b.Property<string>("HeaderImagePathThumb");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("PublishedOn");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserCreated")
                        .HasMaxLength(20);

                    b.Property<string>("UserModified")
                        .HasMaxLength(20);

                    b.Property<Guid>("VanityId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("WebsiteId");

                    b.HasKey("Id");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Posts");

                    b.HasData(
                        new { Id = 1, DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Lorem ipsum dolor sit amet", DocumentContent = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed risus libero, egestas vel tempus id, venenatis nec tellus. Nullam hendrerit id magna quis venenatis. Pellentesque rhoncus leo vitae turpis tristique, nec placerat tellus scelerisque. Aenean vitae rhoncus urna, non posuere elit. Nullam quam libero, porttitor in lectus convallis, pellentesque finibus libero. Suspendisse potenti. Fusce quis purus egestas, malesuada massa sed, dignissim purus. Curabitur vitae rhoncus nulla, sit amet dignissim quam.</p>
                                       <p>Mauris lorem urna, convallis in enim nec, tristique ullamcorper nisl. Fusce nec tellus et arcu imperdiet ullamcorper vestibulum vitae mi. Sed bibendum molestie dolor sit amet rhoncus.Duis consectetur convallis auctor. In hac habitasse platea dictumst.Duis lorem nibh, mattis ut purus interdum, scelerisque molestie est. Nullam molestie a est vel ornare. Maecenas rhoncus accumsan ligula, at pretium purus tempus ut. Aliquam erat nulla, pretium vel eros vitae, blandit aliquam nibh. Nulla tincidunt, justo et ullamcorper dictum, augue lectus dictum ligula, eget rutrum sem nibh non felis.Aenean elementum, sem sit amet pulvinar tempus, neque eros faucibus turpis, quis molestie nisi libero quis purus.</p>
                                       <p>Donec quam massa, tincidunt eu lacus in, lacinia hendrerit urna. Pellentesque pretium orci a felis tincidunt, sit amet volutpat est dapibus. Donec laoreet, massa in imperdiet laoreet, enim ligula auctor est, non imperdiet nisi diam vitae quam. Integer nec porttitor ante. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Morbi non pretium risus, a lobortis eros. Etiam blandit diam tortor. Ut feugiat eros id erat auctor, ut vehicula odio vestibulum.</p>
                                       <p>Nunc sed ex sed diam euismod eleifend. Proin blandit lorem sed placerat fermentum. Curabitur non gravida felis, ac sollicitudin nibh. Morbi ornare sapien vitae nisl condimentum cursus.Vivamus bibendum condimentum metus, ut gravida orci bibendum maximus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Duis varius, tortor ac placerat faucibus, lectus mauris bibendum elit, id eleifend leo diam ac nulla.Aenean egestas urna facilisis purus ullamcorper vestibulum.Etiam commodo suscipit turpis, quis lobortis metus posuere sed.</p>
                                       <p>Praesent in augue sit amet tortor ultricies maximus eu ac dui.Pellentesque et congue elit. Suspendisse potenti. Donec facilisis eu magna nec bibendum. Nullam in dignissim elit. Integer laoreet odio massa, vel vestibulum mauris varius et. Ut non ex sit amet nisl mollis laoreet. </p> ", IsDeleted = false, PublishedOn = new DateTime(2018, 12, 29, 18, 49, 52, 931, DateTimeKind.Local), Slug = "lorem-ipsum", Status = 0, Title = "Lorem Ipsum", VanityId = new Guid("1aabfb13-b246-42e9-ae34-02c25e8859a5"), WebsiteId = 1 }
                    );
                });

            modelBuilder.Entity("CmsEngine.Data.Models.PostApplicationUser", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("PostId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("PostAspNetUser");

                    b.HasData(
                        new { PostId = 1, ApplicationUserId = "2be0d553-bc1d-4074-872d-846c60a24863" }
                    );
                });

            modelBuilder.Entity("CmsEngine.Data.Models.PostCategory", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("CategoryId");

                    b.HasKey("PostId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PostCategory");

                    b.HasData(
                        new { PostId = 1, CategoryId = 1 }
                    );
                });

            modelBuilder.Entity("CmsEngine.Data.Models.PostTag", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("TagId");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTag");
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("UserCreated")
                        .HasMaxLength(20);

                    b.Property<string>("UserModified")
                        .HasMaxLength(20);

                    b.Property<Guid>("VanityId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<int>("WebsiteId");

                    b.HasKey("Id");

                    b.HasIndex("WebsiteId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Website", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(250);

                    b.Property<int>("ArticleLimit");

                    b.Property<string>("Culture")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("DateFormat")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("Facebook")
                        .HasMaxLength(20);

                    b.Property<string>("FacebookApiVersion")
                        .HasMaxLength(10);

                    b.Property<string>("FacebookAppId")
                        .HasMaxLength(30);

                    b.Property<string>("HeaderImagePath");

                    b.Property<string>("HeaderImagePathThumb");

                    b.Property<string>("Instagram")
                        .HasMaxLength(20);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("SiteUrl")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Tagline")
                        .HasMaxLength(200);

                    b.Property<string>("Twitter")
                        .HasMaxLength(20);

                    b.Property<string>("UrlFormat")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserCreated")
                        .HasMaxLength(20);

                    b.Property<string>("UserModified")
                        .HasMaxLength(20);

                    b.Property<Guid>("VanityId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.HasKey("Id");

                    b.ToTable("Websites");

                    b.HasData(
                        new { Id = 1, ArticleLimit = 10, Culture = "en-US", DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), DateFormat = "MM/dd/yyyy", DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "This is a sample website", IsDeleted = false, Name = "Sample Website", SiteUrl = "cmsengine.test", UrlFormat = "http://[site_url]/[type]/[slug]", VanityId = new Guid("fcac06d3-c2ba-4e0a-8876-23c14d80eb98") }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Category", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.Website", "Website")
                        .WithMany("Categories")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Page", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.Website", "Website")
                        .WithMany("Pages")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsEngine.Data.Models.PageApplicationUser", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("PageApplicationUsers")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsEngine.Data.Models.Page", "Page")
                        .WithMany("PageApplicationUsers")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Post", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.Website", "Website")
                        .WithMany("Posts")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsEngine.Data.Models.PostApplicationUser", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("PostApplicationUsers")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsEngine.Data.Models.Post", "Post")
                        .WithMany("PostApplicationUsers")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsEngine.Data.Models.PostCategory", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsEngine.Data.Models.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsEngine.Data.Models.PostTag", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsEngine.Data.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CmsEngine.Data.Models.Tag", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.Website", "Website")
                        .WithMany("Tags")
                        .HasForeignKey("WebsiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CmsEngine.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CmsEngine.Data.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
