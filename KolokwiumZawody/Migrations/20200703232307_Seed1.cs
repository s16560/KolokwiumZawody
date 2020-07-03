using Microsoft.EntityFrameworkCore.Migrations;

namespace KolokwiumZawody.Migrations
{
    public partial class Seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "IdChampionship", "OfficialName", "Year" },
                values: new object[,]
                {
                    { 1, "pilka", 1990 },
                    { 2, "siatkowka", 1994 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "IdTeam", "MaxAge", "TeamName" },
                values: new object[,]
                {
                    { 1, 12, "Misie" },
                    { 2, 15, "Ptysie" },
                    { 3, 18, "Rysie" }
                });

            migrationBuilder.InsertData(
                table: "ChampionshipTeams",
                columns: new[] { "IdTeam", "IdChampionship", "Score" },
                values: new object[] { 1, 1, 70f });

            migrationBuilder.InsertData(
                table: "ChampionshipTeams",
                columns: new[] { "IdTeam", "IdChampionship", "Score" },
                values: new object[] { 2, 1, 60f });

            migrationBuilder.InsertData(
                table: "ChampionshipTeams",
                columns: new[] { "IdTeam", "IdChampionship", "Score" },
                values: new object[] { 2, 2, 40f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChampionshipTeams",
                keyColumns: new[] { "IdTeam", "IdChampionship" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ChampionshipTeams",
                keyColumns: new[] { "IdTeam", "IdChampionship" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ChampionshipTeams",
                keyColumns: new[] { "IdTeam", "IdChampionship" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "IdTeam",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Championships",
                keyColumn: "IdChampionship",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Championships",
                keyColumn: "IdChampionship",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "IdTeam",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "IdTeam",
                keyValue: 2);
        }
    }
}
