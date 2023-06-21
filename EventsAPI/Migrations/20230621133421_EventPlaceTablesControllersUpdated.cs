using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsAPI.Migrations
{
    public partial class EventPlaceTablesControllersUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Tickets");

            migrationBuilder.AddColumn<decimal>(
                name: "TicketPrice",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TicketQuantity",
                table: "Tickets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PlacePhotoUrl",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "EventCoverUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketQuantity",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PlacePhotoUrl",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "EventCoverUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
