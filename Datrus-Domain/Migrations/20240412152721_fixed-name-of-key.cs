using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datrus_Domain.Migrations
{
    /// <inheritdoc />
    public partial class fixednameofkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "UsersPreferences",
                newName: "UserPreferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPreferenceId",
                table: "UsersPreferences",
                newName: "MatchId");
        }
    }
}
