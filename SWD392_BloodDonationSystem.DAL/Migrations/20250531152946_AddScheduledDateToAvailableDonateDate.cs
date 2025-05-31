using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD392_BloodDonationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduledDateToAvailableDonateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledDay",
                table: "AvailableDonateDate");

            migrationBuilder.DropColumn(
                name: "ScheduledMonth",
                table: "AvailableDonateDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "AvailableDonateDate",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "AvailableDonateDate");

            migrationBuilder.AddColumn<string>(
                name: "ScheduledDay",
                table: "AvailableDonateDate",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScheduledMonth",
                table: "AvailableDonateDate",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
