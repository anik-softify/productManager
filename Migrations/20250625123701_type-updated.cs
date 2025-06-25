using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace productManager.Migrations
{
    /// <inheritdoc />
    public partial class typeupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypesId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypesId",
                table: "Products",
                column: "TypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_TypesId",
                table: "Products",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_TypesId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypesId",
                table: "Products");
        }
    }
}
