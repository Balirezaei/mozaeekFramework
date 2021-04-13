using Microsoft.EntityFrameworkCore.Migrations;

namespace MozaeekCore.Persistense.EF.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Label_Label_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Label",
                columns: new[] { "Id", "ParentId", "Title" },
                values: new object[] { 1L, null, "label1" });

            migrationBuilder.InsertData(
                table: "Label",
                columns: new[] { "Id", "ParentId", "Title" },
                values: new object[] { 2L, 1L, "LabelChild" });

            migrationBuilder.CreateIndex(
                name: "IX_Label_ParentId",
                table: "Label",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Label");
        }
    }
}
