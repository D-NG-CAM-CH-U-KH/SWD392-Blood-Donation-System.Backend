using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SWD392_BloodDonationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAvailableDonateDateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableDonateDate",
                columns: table => new
                {
                    AvailableDateID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    ScheduledMonth = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ScheduledDay = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    AcceptEmergency = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AvailableDonateDates_pkey", x => x.AvailableDateID);
                    table.ForeignKey(
                        name: "FK_AvailableDonateDates_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDonateDate_UserID",
                table: "AvailableDonateDate",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableDonateDate");
        }
    }
}
