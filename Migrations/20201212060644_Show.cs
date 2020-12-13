using Microsoft.EntityFrameworkCore.Migrations;

namespace TVLibraryAPI.Migrations
{
    public partial class Show : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false),
                    Schedule = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Netflix" },
                    { 2, "Prime" },
                    { 3, "Hotstar" },
                    { 4, "Zee5" },
                    { 5, "Voot" }
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "PlatformId", "Schedule", "Summary", "Title" },
                values: new object[] { 1, 1, "Season", "The witcher Geralt, a mutated monster hunter, struggles to find his place in a world in which people often prove more wicked than beasts.", "The Witcher" });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "PlatformId", "Schedule", "Summary", "Title" },
                values: new object[] { 2, 2, "Season", "Akhandanand Tripathi made millions exporting carpets and became the mafia boss of Mirzapur. His son Munna, an unworthy, power-hungry heir, stops at nothing to continue his father's legacy.", "Mirzapur" });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "PlatformId", "Schedule", "Summary", "Title" },
                values: new object[] { 3, 3, "Weekly", "Chuck Rhoades, a sincere but ruthless US attorney, engages in an egoistic battle with hedge fund kingpin Bobby 'Axe' Axelrod as they try to outdo each other in the competitive financial market.", "Billions" });

            migrationBuilder.CreateIndex(
                name: "IX_Shows_PlatformId",
                table: "Shows",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
