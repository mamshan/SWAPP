using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWAPP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "amount",
                table: "dep_cheq_trn",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "pdno",
                table: "dep_cheq_trn",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "bank",
                table: "dep_cheq_mas",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "refno",
                table: "dep_cheq_mas",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "sdate",
                table: "dep_cheq_mas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "dep_cheq_trn");

            migrationBuilder.DropColumn(
                name: "pdno",
                table: "dep_cheq_trn");

            migrationBuilder.DropColumn(
                name: "bank",
                table: "dep_cheq_mas");

            migrationBuilder.DropColumn(
                name: "refno",
                table: "dep_cheq_mas");

            migrationBuilder.DropColumn(
                name: "sdate",
                table: "dep_cheq_mas");
        }
    }
}
