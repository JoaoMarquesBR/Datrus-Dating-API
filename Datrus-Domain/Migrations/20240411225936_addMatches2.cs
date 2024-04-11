using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datrus_Domain.Migrations
{
    /// <inheritdoc />
    public partial class addMatches2 : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikesSent");
        }
    }
}
