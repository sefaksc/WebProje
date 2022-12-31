using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class ProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Kategori_CategoryId",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_CategoryId",
                table: "Urunler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Urunler");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Urunler",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Kategori",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_Name",
                table: "Urunler",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Kategori_Name",
                table: "Urunler",
                column: "Name",
                principalTable: "Kategori",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Kategori_Name",
                table: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Urunler_Name",
                table: "Urunler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Urunler");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Kategori",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_CategoryId",
                table: "Urunler",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Kategori_CategoryId",
                table: "Urunler",
                column: "CategoryId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
