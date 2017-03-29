using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebCourse.Models;

namespace WebCourse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("WebCourse.Models.Certificate", b =>
                {
                    b.Property<int>("CertificateID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CertificateNumber")
                        .IsRequired();

                    b.Property<DateTime>("CertificatingDate");

                    b.Property<string>("CreatorID");

                    b.Property<string>("Description");

                    b.Property<int>("InnovativeProductID");

                    b.Property<string>("WhoGave")
                        .IsRequired();

                    b.HasKey("CertificateID");

                    b.HasIndex("InnovativeProductID");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("WebCourse.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<DateTime>("CommentDate");

                    b.Property<int>("CommentParentId");

                    b.Property<string>("CommentText")
                        .IsRequired();

                    b.Property<int>("NewsId");

                    b.Property<int>("Rating");

                    b.HasKey("CommentID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WebCourse.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("Branch");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CreatorID");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<int>("PropertyType");

                    b.Property<string>("Website")
                        .IsRequired();

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WebCourse.Models.InnovativeProduct", b =>
                {
                    b.Property<int>("InnovativeProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Continuity");

                    b.Property<string>("CreatorID");

                    b.Property<string>("Description");

                    b.Property<int>("DevelopmentStage");

                    b.Property<int>("MarketNoveltyDegree");

                    b.Property<int>("MarketShare");

                    b.Property<int>("NoveltyDegree");

                    b.Property<int>("Prevalence");

                    b.Property<int>("ProductionCyclePlace");

                    b.Property<string>("productName")
                        .IsRequired();

                    b.HasKey("InnovativeProductID");

                    b.ToTable("InnovativeProducts");
                });

            modelBuilder.Entity("WebCourse.Models.License", b =>
                {
                    b.Property<int>("LicenseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyID");

                    b.Property<string>("CreatorID");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("LicenseNumber")
                        .IsRequired();

                    b.Property<DateTime>("LicensingDate");

                    b.Property<string>("WhoGave")
                        .IsRequired();

                    b.HasKey("LicenseID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("WebCourse.Models.News", b =>
                {
                    b.Property<int>("NewsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Preview")
                        .IsRequired();

                    b.Property<DateTime>("PublicationDateTime");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("NewsID");

                    b.ToTable("News");
                });

            modelBuilder.Entity("WebCourse.Models.Certificate", b =>
                {
                    b.HasOne("WebCourse.Models.InnovativeProduct")
                        .WithMany("Certificates")
                        .HasForeignKey("InnovativeProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebCourse.Models.License", b =>
                {
                    b.HasOne("WebCourse.Models.Company")
                        .WithMany("Licenses")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
