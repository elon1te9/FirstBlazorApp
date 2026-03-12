using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Practice1BlazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genre",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "id_genre",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id_genre = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id_genre);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_id_genre",
                table: "Movies",
                column: "id_genre");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_id_genre",
                table: "Movies",
                column: "id_genre",
                principalTable: "Genres",
                principalColumn: "id_genre",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_id_genre",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Movies_id_genre",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "id_genre",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "genre",
                table: "Movies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
