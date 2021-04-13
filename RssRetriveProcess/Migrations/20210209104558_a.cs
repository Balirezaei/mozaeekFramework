using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RssRetriveProcess.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RssNewses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RssNewses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RssRetriveHistories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RssId = table.Column<long>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    NewsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RssRetriveHistories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RssNewses");

            migrationBuilder.DropTable(
                name: "RssRetriveHistories");
        }
    }
}
