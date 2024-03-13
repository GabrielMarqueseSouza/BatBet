using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BatBetInfrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", maxLength: 15, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 30, 23, 38, 0, 158, DateTimeKind.Utc).AddTicks(651)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "text", maxLength: 70, nullable: false),
                    Country = table.Column<string>(type: "text", maxLength: 80, nullable: false),
                    Address = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "text", maxLength: 30, nullable: false),
                    StateAcronym = table.Column<string>(type: "text", maxLength: 2, nullable: true),
                    Complement = table.Column<string>(type: "text", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "integer", maxLength: 3, nullable: false),
                    DocumentNumber = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    Balance = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 30, 23, 38, 0, 158, DateTimeKind.Utc).AddTicks(9812)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    BlockReason = table.Column<string>(type: "text", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 30, 23, 38, 0, 158, DateTimeKind.Utc).AddTicks(4154)),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvailableBet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    MinValue = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.01),
                    MaxValue = table.Column<double>(type: "double precision", maxLength: 999999999, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 30, 23, 38, 0, 157, DateTimeKind.Utc).AddTicks(2568)),
                    LimitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableBet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableBet_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(type: "double precision", maxLength: 999999999, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PlatformFee = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 1, 30, 23, 38, 0, 157, DateTimeKind.Utc).AddTicks(7238)),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bet_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bet_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableBet_GameId",
                table: "AvailableBet",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GameId",
                table: "Bet",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserId",
                table: "Bet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_CategoryId",
                table: "Game",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableBet");

            migrationBuilder.DropTable(
                name: "Bet");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
