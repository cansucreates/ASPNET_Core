using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCore.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turlers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapTur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RafNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turlers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazarAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BasimYili = table.Column<int>(type: "int", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplars", x => x.id);
                    table.ForeignKey(
                        name: "FK_Kitaplars_Turlers_TurId",
                        column: x => x.TurId,
                        principalTable: "Turlers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplars_TurId",
                table: "Kitaplars",
                column: "TurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplars");

            migrationBuilder.DropTable(
                name: "Turlers");
        }
    }
}
