using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SWD392_BloodDonationSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodGroup",
                columns: table => new
                {
                    BloodGroupID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    BloodType = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CanDonateTo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CanReceiveFrom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BloodGroup_pkey", x => x.BloodGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    FormID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FormType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MinQuestion = table.Column<int>(type: "integer", nullable: false),
                    MaxQuestion = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Forms_pkey", x => x.FormID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RoleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Roles_pkey", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SystemSetting",
                columns: table => new
                {
                    SettingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    HospitalName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Website = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageID = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SystemSettings_pkey", x => x.SettingID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CitizenID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CitizenCardFront = table.Column<int>(type: "integer", nullable: true),
                    CitizenCardBack = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<bool>(type: "boolean", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    BloodGroupID = table.Column<int>(type: "integer", nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ward = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HouseNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Longitude = table.Column<int>(type: "integer", nullable: true),
                    Latitude = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_pkey", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "BloodGroup",
                        principalColumn: "BloodGroupID");
                });

            migrationBuilder.CreateTable(
                name: "FormQuestion",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    FormID = table.Column<int>(type: "integer", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    QuestionType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                name: "AuditLog",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    Action = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TargetTable = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TargetID = table.Column<int>(type: "integer", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IPAddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AuditLogs_pkey", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_AuditLogs_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    AuthorID = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Category = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: true),
                    ViewCount = table.Column<int>(type: "integer", nullable: true),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: true),
                    Tags = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Blogs_pkey", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blogs_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "BloodDonation",
                columns: table => new
                {
                    DonationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    BloodGroupID = table.Column<int>(type: "integer", nullable: false),
                    DonationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RedCellUnit = table.Column<int>(type: "integer", nullable: true),
                    PlasmaUnit = table.Column<int>(type: "integer", nullable: true),
                    PlateletUnit = table.Column<int>(type: "integer", nullable: true),
                    FullBloodUnit = table.Column<int>(type: "integer", nullable: true),
                    DonationType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BloodDonations_pkey", x => x.DonationID);
                    table.ForeignKey(
                        name: "FK_BloodDonations_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "BloodGroup",
                        principalColumn: "BloodGroupID");
                    table.ForeignKey(
                        name: "FK_BloodDonations_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "BloodRequest",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RequesterID = table.Column<int>(type: "integer", nullable: false),
                    MatchedDonorID = table.Column<int>(type: "integer", nullable: true),
                    BloodGroupID = table.Column<int>(type: "integer", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    UrgencyLevel = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NeededDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BloodRequests_pkey", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_BloodRequests_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "BloodGroup",
                        principalColumn: "BloodGroupID");
                    table.ForeignKey(
                        name: "FK_BloodRequests_MatchedDonorID",
                        column: x => x.MatchedDonorID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_BloodRequests_RequesterID",
                        column: x => x.RequesterID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "BloodTypeCertificate",
                columns: table => new
                {
                    CertificateID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    ImageProof = table.Column<int>(type: "integer", nullable: true),
                    CitizenID = table.Column<int>(type: "integer", nullable: true),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: false),
                    BloodDonationCenter = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DonatedVolumn = table.Column<int>(type: "integer", nullable: true),
                    SeriNumber = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BloodTypeCertificate_pkey", x => x.CertificateID);
                    table.ForeignKey(
                        name: "FK_BloodTypeCertificate_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "DonationSchedule",
                columns: table => new
                {
                    DonationTime = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    WeekDay = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DonationSchedule_pkey", x => x.DonationTime);
                    table.ForeignKey(
                        name: "FK_DonationSchedule_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MimeType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    URL = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UploadedBy = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Image_pkey", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Image_UploadedBy",
                        column: x => x.UploadedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Reminder",
                columns: table => new
                {
                    ReminderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    LastDonationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    NextEligibleDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsSent = table.Column<bool>(type: "boolean", nullable: true),
                    ReminderType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Reminders_pkey", x => x.ReminderID);
                    table.ForeignKey(
                        name: "FK_Reminders_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ReportType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GeneratedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ToDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: true),
                    FileUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Reports_pkey", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_Reports_GeneratedBy",
                        column: x => x.GeneratedBy,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "UserForm",
                columns: table => new
                {
                    UserFormID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    FormID = table.Column<int>(type: "integer", nullable: false),
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
                name: "UserRole",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    RoleID = table.Column<int>(type: "integer", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserRoles_pkey", x => x.UserRoleID);
                    table.ForeignKey(
                        name: "FK_UserRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                    table.ForeignKey(
                        name: "FK_UserRoles_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "BloodMatchingLog",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RequestID = table.Column<int>(type: "integer", nullable: false),
                    DonorID = table.Column<int>(type: "integer", nullable: false),
                    AppointmentID = table.Column<int>(type: "integer", nullable: true),
                    MatchDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MatchType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BloodMatchingLogs_pkey", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_BloodMatchingLogs_DonorID",
                        column: x => x.DonorID,
                        principalTable: "User",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_BloodMatchingLogs_RequestID",
                        column: x => x.RequestID,
                        principalTable: "BloodRequest",
                        principalColumn: "RequestID");
                });

            migrationBuilder.CreateTable(
                name: "DonationAppointment",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    UserFormID = table.Column<int>(type: "integer", nullable: true),
                    DonationScheduleID = table.Column<int>(type: "integer", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DonationAppointments_pkey", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_DonationAppointments_DonationScheduleID",
                        column: x => x.DonationScheduleID,
                        principalTable: "DonationSchedule",
                        principalColumn: "DonationTime");
                    table.ForeignKey(
                        name: "FK_DonationAppointments_UserID",
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
                    QuestionID = table.Column<int>(type: "integer", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false)
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
                name: "IX_AuditLog_UserID",
                table: "AuditLog",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_AuthorID",
                table: "Blog",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonation_BloodGroupID",
                table: "BloodDonation",
                column: "BloodGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodDonation_UserID",
                table: "BloodDonation",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodMatchingLog_DonorID",
                table: "BloodMatchingLog",
                column: "DonorID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodMatchingLog_RequestID",
                table: "BloodMatchingLog",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequest_BloodGroupID",
                table: "BloodRequest",
                column: "BloodGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequest_MatchedDonorID",
                table: "BloodRequest",
                column: "MatchedDonorID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRequest_RequesterID",
                table: "BloodRequest",
                column: "RequesterID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodTypeCertificate_UserID",
                table: "BloodTypeCertificate",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DonationAppointment_DonationScheduleID",
                table: "DonationAppointment",
                column: "DonationScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_DonationAppointment_UserID",
                table: "DonationAppointment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DonationSchedule_CreatedBy",
                table: "DonationSchedule",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_FormID",
                table: "FormQuestion",
                column: "FormID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UploadedBy",
                table: "Image",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_UserID",
                table: "Reminder",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_GeneratedBy",
                table: "Report",
                column: "GeneratedBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_BloodGroupID",
                table: "User",
                column: "BloodGroupID");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID",
                table: "UserRole",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "BloodDonation");

            migrationBuilder.DropTable(
                name: "BloodMatchingLog");

            migrationBuilder.DropTable(
                name: "BloodTypeCertificate");

            migrationBuilder.DropTable(
                name: "DonationAppointment");

            migrationBuilder.DropTable(
                name: "FormQuestion");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "SystemSetting");

            migrationBuilder.DropTable(
                name: "UserAnswer");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "BloodRequest");

            migrationBuilder.DropTable(
                name: "DonationSchedule");

            migrationBuilder.DropTable(
                name: "UserForm");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BloodGroup");
        }
    }
}
