using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatBetInfrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Moreadjustmentstothetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Game",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(7918),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(9860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(5501),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(3074),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(5457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(162),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.AddColumn<bool>(
                name: "Canceled",
                table: "AvailableBet",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "HighestBet",
                table: "AvailableBet",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "AvailableBet",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WinnerId",
                table: "AvailableBet",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Canceled",
                table: "AvailableBet");

            migrationBuilder.DropColumn(
                name: "HighestBet",
                table: "AvailableBet");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "AvailableBet");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AvailableBet");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "AvailableBet");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Game",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(9860),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(7627),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(5501));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(5457),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(3074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 0, 46, 18, 982, DateTimeKind.Utc).AddTicks(2333),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(162));
        }
    }
}
