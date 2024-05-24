using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Contest_Id",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Club_Id",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Contest");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClubId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContestId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Contest",
                columns: new[] { "Id", "ContestDate", "ContestStatus", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "MaxPlayer", "Policy" },
                values: new object[,]
                {
                    { new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"), new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), 0, new DateTime(2024, 5, 24, 13, 6, 25, 388, DateTimeKind.Local).AddTicks(9110), "Jane Smith", null, null, 10, "No cheating allowed" },
                    { new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"), new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(2024, 5, 24, 13, 6, 25, 388, DateTimeKind.Local).AddTicks(9110), "John Doe", null, null, 8, "Follow the rules" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("80d75090-a1aa-48cb-b3ba-233067001594"), "", "Staff", "staff" },
                    { new Guid("8f42b74b-a7a2-4cd8-b449-5255ff317516"), "", "Customer", "customer" },
                    { new Guid("f221a993-f8ff-40e4-a92f-2552ce67373d"), "", "Owner", "owner" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fullname", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserStatusEnum" },
                values: new object[,]
                {
                    { new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"), 0, "concurrency1", "jane.smith@example.com", false, "Jane Smith", 1, true, null, "JANE.SMITH@EXAMPLE.COM", "JANE.SMITH", "hashedpassword1", "1234567890", true, "stamp1", true, "jane.smith", 0 },
                    { new Guid("40e8ca6a-06c0-4deb-8bec-c3919817b8cf"), 0, "concurrency2", "owner.club.1@example.com", true, "Owner Club 1", 2, true, null, "OWNER.CLUB.1@EXAMPLE.COM", "OWNER.CLUB.1", "hashedpassword2", "0987654321", true, "stamp2", true, "owner.club.1", 0 },
                    { new Guid("626d577c-5966-4993-afb8-72e672d16649"), 0, "concurrency2", "owner.club.2@example.com", true, "Owner Club 2", 2, true, null, "OWNER.CLUB.2@EXAMPLE.COM", "OWNER.CLUB.2", "hashedpassword2", "0987654321", true, "stamp2", true, "owner.club.2", 1 },
                    { new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"), 0, "concurrency1", "john.doe@example.com", false, "John Doe", 1, true, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "hashedpassword1", "1234567890", true, "stamp1", true, "john.doe", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"), new Guid("8f42b74b-a7a2-4cd8-b449-5255ff317516") },
                    { new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"), new Guid("8f42b74b-a7a2-4cd8-b449-5255ff317516") }
                });

            migrationBuilder.InsertData(
                table: "Club",
                columns: new[] { "Id", "CloseTime", "ClubAddress", "ClubDescription", "ClubName", "ClubPhone", "ClubStatusEnum", "Created", "CreatedBy", "LastModifiedBy", "MinDuration", "OpenTime", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"), new TimeOnly(21, 0, 0), "789 Oak St", "A vibrant dance studio.", "Dance Studio C", "555-9012", 0, new DateTime(2024, 5, 24, 13, 6, 25, 384, DateTimeKind.Local).AddTicks(9050), "Admin", "Admin", 2.0, new TimeOnly(8, 0, 0), new Guid("40e8ca6a-06c0-4deb-8bec-c3919817b8cf") },
                    { new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"), new TimeOnly(20, 0, 0), "456 Elm St", "A relaxing yoga center.", "Yoga Center B", "555-5678", 0, new DateTime(2024, 5, 24, 13, 6, 25, 384, DateTimeKind.Local).AddTicks(9040), "Admin", "Admin", 1.0, new TimeOnly(5, 0, 0), new Guid("626d577c-5966-4993-afb8-72e672d16649") },
                    { new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"), new TimeOnly(22, 0, 0), "123 Main St", "A premier fitness club.", "Fitness Club A", "555-1234", 0, new DateTime(2024, 5, 24, 13, 6, 25, 384, DateTimeKind.Local).AddTicks(9020), "Admin", "Admin", 1.5, new TimeOnly(6, 0, 0), new Guid("40e8ca6a-06c0-4deb-8bec-c3919817b8cf") }
                });

            migrationBuilder.InsertData(
                table: "UserContest",
                columns: new[] { "ContestId", "ParticipantsId", "Point", "isCreatedPerson", "isWinner" },
                values: new object[,]
                {
                    { new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"), new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"), 10, false, true },
                    { new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"), new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"), 8, true, false }
                });

            migrationBuilder.InsertData(
                table: "Court",
                columns: new[] { "Id", "ClubId", "CourtStatus", "CourtType", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"), new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), "Club Owner 3", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), "Admin", "Court 1" },
                    { new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"), new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), "Club Owner 3", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), "Admin", "Court 4" },
                    { new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"), new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3440), "Club Owner 1", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450), "Admin", "Court 4" },
                    { new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"), new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), "Club Owner 3", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), "Admin", "Court 3" },
                    { new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"), new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3430), "Club Owner 1", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3430), "Admin", "Court 2" },
                    { new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"), new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3440), "Club Owner 1", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3440), "Admin", "Court 3" },
                    { new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"), new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), "Club Owner 2", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), "Admin", "Court 3" },
                    { new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"), new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450), "Club Owner 2", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450), "Admin", "Court 2" },
                    { new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"), new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), "Club Owner 2", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), "Admin", "Court 4" },
                    { new Guid("abdd9e0b-de08-422b-894d-64f22365c583"), new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), "Club Owner 3", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), "Admin", "Court 2" },
                    { new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"), new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450), "Club Owner 2", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450), "Admin", "Court 1" },
                    { new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"), new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"), 0, 0, new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3420), "Club Owner 1", new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3430), "Admin", "Court 1" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "ClubId", "Comment", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "Rating", "ReviewerId" },
                values: new object[,]
                {
                    { new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"), new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"), "Good", new DateTime(2024, 5, 24, 13, 6, 25, 397, DateTimeKind.Local).AddTicks(120), "John doe", null, null, 0, new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216") },
                    { new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"), new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"), "Bad", new DateTime(2024, 5, 24, 13, 6, 25, 397, DateTimeKind.Local).AddTicks(140), "John doe", null, null, 0, new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216") },
                    { new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"), new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"), "Fair Well", new DateTime(2024, 5, 24, 13, 6, 25, 397, DateTimeKind.Local).AddTicks(140), "John doe", null, null, 0, new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216") }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CourtId", "Created", "CreatedBy", "EndTime", "LastModified", "LastModifiedBy", "Reason", "StartTime" },
                values: new object[,]
                {
                    { new Guid("02d759bf-9408-452f-b920-359df87a0fac"), new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"), new DateTime(2024, 5, 24, 13, 6, 25, 391, DateTimeKind.Local).AddTicks(8010), "Admin", new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, "Out of service 2", new DateTime(2024, 5, 24, 13, 6, 25, 391, DateTimeKind.Local).AddTicks(8010) },
                    { new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"), new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"), new DateTime(2024, 5, 24, 13, 6, 25, 391, DateTimeKind.Local).AddTicks(8010), "Admin", new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), null, null, "Out of service", new DateTime(2024, 5, 24, 13, 6, 25, 391, DateTimeKind.Local).AddTicks(8000) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ClubId",
                table: "Review",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ContestId",
                table: "Reservation",
                column: "ContestId",
                unique: true,
                filter: "[ContestId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Contest_ContestId",
                table: "Reservation",
                column: "ContestId",
                principalTable: "Contest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Club_ClubId",
                table: "Review",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Contest_ContestId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Club_ClubId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ClubId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_ContestId",
                table: "Reservation");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumn: "UserId",
                keyValue: new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumn: "UserId",
                keyValue: new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"));

            migrationBuilder.DeleteData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"));

            migrationBuilder.DeleteData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"));

            migrationBuilder.DeleteData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("80d75090-a1aa-48cb-b3ba-233067001594"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f221a993-f8ff-40e4-a92f-2552ce67373d"));

            migrationBuilder.DeleteData(
                table: "UserContest",
                keyColumns: new[] { "ContestId", "ParticipantsId" },
                keyValues: new object[] { new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"), new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f") });

            migrationBuilder.DeleteData(
                table: "UserContest",
                keyColumns: new[] { "ContestId", "ParticipantsId" },
                keyValues: new object[] { new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"), new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216") });

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"));

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"));

            migrationBuilder.DeleteData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"));

            migrationBuilder.DeleteData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8f42b74b-a7a2-4cd8-b449-5255ff317516"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"));

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("40e8ca6a-06c0-4deb-8bec-c3919817b8cf"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("626d577c-5966-4993-afb8-72e672d16649"));

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClubId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContestId",
                table: "Reservation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                table: "Contest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Contest_Id",
                table: "Reservation",
                column: "Id",
                principalTable: "Contest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Club_Id",
                table: "Review",
                column: "Id",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
