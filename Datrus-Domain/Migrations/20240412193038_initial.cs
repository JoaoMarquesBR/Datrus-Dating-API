using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datrus_Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikesSent",
                columns: table => new
                {
                    LikesSentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikesSent", x => x.LikesSentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FirstLanguage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "UsersMatches",
                columns: table => new
                {
                    MatchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMatches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "UsersPreferences",
                columns: table => new
                {
                    UserPreferenceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MinAge = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    MaxAge = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPreferences", x => x.UserPreferenceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikesSent");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersMatches");

            migrationBuilder.DropTable(
                name: "UsersPreferences");
        }
    }
}
