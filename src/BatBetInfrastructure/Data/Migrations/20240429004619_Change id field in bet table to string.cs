using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatBetInfrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeidfieldinbettabletostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Game",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(9860),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 16, 20, 28, 57, 877, DateTimeKind.Utc).AddTicks(7892));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(7627),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 16, 20, 28, 57, 877, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bet",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(5457),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 16, 20, 28, 57, 877, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(2333),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 16, 20, 28, 57, 877, DateTimeKind.Utc).AddTicks(574));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Game",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 16, 20, 28, 57, 877, DateTimeKind.Utc).AddTicks(7892),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(9860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 16, 20, 28, 57, 877, DateTimeKind.Utc).AddTicks(5679),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bet",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 16, 20, 28, 57, 877, DateTimeKind.Utc).AddTicks(3570),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(5457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 16, 20, 28, 57, 877, DateTimeKind.Utc).AddTicks(574),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(2333));
        }
    }
}
