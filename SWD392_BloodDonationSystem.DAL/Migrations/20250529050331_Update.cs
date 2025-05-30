using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SWD392_BloodDonationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonationSchedule_CreatedBy",
                table: "DonationSchedule");

            migrationBuilder.DropTable(
                name: "FormQuestion");

            migrationBuilder.DropTable(
                name: "UserAnswer");

            migrationBuilder.DropTable(
                name: "UserForm");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropIndex(
                name: "IX_BloodMatchingLog_RequestID",
                table: "BloodMatchingLog");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "UserFormID",
                table: "DonationAppointment",
                newName: "DonationFormID");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "User",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "DonationSchedule",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SeriNumber",
                table: "BloodTypeCertificate",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImageProof",
                table: "BloodTypeCertificate",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DonatedVolumn",
                table: "BloodTypeCertificate",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "BloodTypeCertificate",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CitizenID",
                table: "BloodTypeCertificate",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ViewCount",
                table: "Blog",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Blog",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                table: "Blog",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DonationForm",
                columns: table => new
                {
                    DonationFormID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    IsDonated = table.Column<bool>(type: "boolean", nullable: false),
                    Illness = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DangerousIllness = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TwelveMonthProblem = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SixMonthProblem = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    OneMonthProblem = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FourteenDayProblem = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SevenDayProblem = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    WomanProblem = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DonationForms_pkey", x => x.DonationFormID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationAppointment_DonationFormID",
                table: "DonationAppointment",
                column: "DonationFormID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodMatchingLog_AppointmentID",
                table: "BloodMatchingLog",
                column: "AppointmentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodMatchingLog_RequestID",
                table: "BloodMatchingLog",
                column: "RequestID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BloodMatchingLogs_AppointmentID",
                table: "BloodMatchingLog",
                column: "AppointmentID",
                principalTable: "DonationAppointment",
                principalColumn: "AppointmentID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DonationAppointments_DonationFormID",
                table: "DonationAppointment",
                column: "DonationFormID",
                principalTable: "DonationForm",
                principalColumn: "DonationFormID");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationSchedule_CreatedBy",
                table: "DonationSchedule",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodMatchingLogs_AppointmentID",
                table: "BloodMatchingLog");

            migrationBuilder.DropForeignKey(
                name: "FK_DonationAppointments_DonationFormID",
                table: "DonationAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_DonationSchedule_CreatedBy",
                table: "DonationSchedule");

            migrationBuilder.DropTable(
                name: "DonationForm");

            migrationBuilder.DropIndex(
                name: "IX_DonationAppointment_DonationFormID",
                table: "DonationAppointment");

            migrationBuilder.DropIndex(
                name: "IX_BloodMatchingLog_AppointmentID",
                table: "BloodMatchingLog");

            migrationBuilder.DropIndex(
                name: "IX_BloodMatchingLog_RequestID",
                table: "BloodMatchingLog");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "User",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "DonationFormID",
                table: "DonationAppointment",
                newName: "UserFormID");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "User",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "User",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "DonationSchedule",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "SeriNumber",
                table: "BloodTypeCertificate",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ImageProof",
                table: "BloodTypeCertificate",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DonatedVolumn",
                table: "BloodTypeCertificate",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "BloodTypeCertificate",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "CitizenID",
                table: "BloodTypeCertificate",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ViewCount",
                table: "Blog",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPublished",
                table: "Blog",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                table: "Blog",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    FormID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FormType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MaxQuestion = table.Column<int>(type: "integer", nullable: false),
                    MinQuestion = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Forms_pkey", x => x.FormID);
                });

            migrationBuilder.CreateTable(
                name: "FormQuestion",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    FormID = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    QuestionType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FormQuestion_pkey", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_FormQuestion_FormID",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "FormID");
                });

            migrationBuilder.CreateTable(
                name: "UserForm",
                columns: table => new
                {
                    UserFormID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    FormID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserForms_pkey", x => x.UserFormID);
                    table.ForeignKey(
                        name: "FK_UserForms_FormID",
                        column: x => x.FormID,
                        principalTable: "Form",
                        principalColumn: "FormID");
                    table.ForeignKey(
                        name: "FK_UserForms_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserAnswer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserFormID = table.Column<int>(type: "integer", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    QuestionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserAnswers_pkey", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_UserAnswers_UserFormID",
                        column: x => x.UserFormID,
                        principalTable: "UserForm",
                        principalColumn: "UserFormID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodMatchingLog_RequestID",
                table: "BloodMatchingLog",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_FormID",
                table: "FormQuestion",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserFormID",
                table: "UserAnswer",
                column: "UserFormID");

            migrationBuilder.CreateIndex(
                name: "IX_UserForm_FormID",
                table: "UserForm",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_UserForm_UserID",
                table: "UserForm",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_DonationSchedule_CreatedBy",
                table: "DonationSchedule",
                column: "CreatedBy",
                principalTable: "User",
                principalColumn: "UserID");
        }
    }
}
