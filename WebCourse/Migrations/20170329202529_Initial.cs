using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebCourse.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AuthorId = table.Column<string>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentParentId = table.Column<int>(nullable: false),
                    CommentText = table.Column<string>(nullable: false),
                    NewsId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address = table.Column<string>(nullable: false),
                    Branch = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CreatorID = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    PropertyType = table.Column<int>(nullable: false),
                    Website = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "InnovativeProducts",
                columns: table => new
                {
                    InnovativeProductID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Continuity = table.Column<int>(nullable: false),
                    CreatorID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DevelopmentStage = table.Column<int>(nullable: false),
                    MarketNoveltyDegree = table.Column<int>(nullable: false),
                    MarketShare = table.Column<int>(nullable: false),
                    NoveltyDegree = table.Column<int>(nullable: false),
                    Prevalence = table.Column<int>(nullable: false),
                    ProductionCyclePlace = table.Column<int>(nullable: false),
                    productName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnovativeProducts", x => x.InnovativeProductID);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Content = table.Column<string>(nullable: false),
                    Preview = table.Column<string>(nullable: false),
                    PublicationDateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsID);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    LicenseID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    CreatorID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    LicenseNumber = table.Column<string>(nullable: false),
                    LicensingDate = table.Column<DateTime>(nullable: false),
                    WhoGave = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.LicenseID);
                    table.ForeignKey(
                        name: "FK_Licenses_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CertificateNumber = table.Column<string>(nullable: false),
                    CertificatingDate = table.Column<DateTime>(nullable: false),
                    CreatorID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    InnovativeProductID = table.Column<int>(nullable: false),
                    WhoGave = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateID);
                    table.ForeignKey(
                        name: "FK_Certificates_InnovativeProducts_InnovativeProductID",
                        column: x => x.InnovativeProductID,
                        principalTable: "InnovativeProducts",
                        principalColumn: "InnovativeProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_InnovativeProductID",
                table: "Certificates",
                column: "InnovativeProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_CompanyID",
                table: "Licenses",
                column: "CompanyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "InnovativeProducts");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
