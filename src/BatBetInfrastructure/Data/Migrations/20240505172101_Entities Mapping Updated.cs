using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BatBetInfrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesMappingUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Game",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(5501));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(3074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "AvailableBet",
                type: "double precision",
                maxLength: 999999999,
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldMaxLength: 999999999);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LimitDate",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFinished",
                table: "AvailableBet",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(162));

            migrationBuilder.AlterColumn<bool>(
                name: "Canceled",
                table: "AvailableBet",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Game",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(7918),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Category",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(5501),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Bet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(3074),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<double>(
                name: "MaxValue",
                table: "AvailableBet",
                type: "double precision",
                maxLength: 999999999,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldMaxLength: 999999999,
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LimitDate",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<bool>(
                name: "IsFinished",
                table: "AvailableBet",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AvailableBet",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 5, 0, 35, 35, 772, DateTimeKind.Utc).AddTicks(162),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 5, 5, 17, 21, 1, 0, DateTimeKind.Utc));

            migrationBuilder.AlterColumn<bool>(
                name: "Canceled",
                table: "AvailableBet",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);
        }
    }
}
