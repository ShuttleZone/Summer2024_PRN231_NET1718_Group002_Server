using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("15df863e-f8fc-4939-9f85-ee7092f7fa31"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3cea104b-67d9-4e19-a516-8aee3e46869b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d974bc46-4556-4650-acc0-eda4f9797e12"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ec7844f0-8099-4356-86b2-b99e8c3fa36c"));

            migrationBuilder.AddColumn<string>(
                name: "TransactionDate",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransactionNo",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TxnRef",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                columns: new[] { "ClubStatusEnum", "Created" },
                values: new object[] { 2, new DateTime(2024, 6, 18, 22, 32, 12, 58, DateTimeKind.Local).AddTicks(8832) });

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                columns: new[] { "ClubStatusEnum", "Created" },
                values: new object[] { 1, new DateTime(2024, 6, 18, 22, 32, 12, 58, DateTimeKind.Local).AddTicks(8817) });

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                columns: new[] { "ClubStatusEnum", "Created" },
                values: new object[] { 2, new DateTime(2024, 6, 18, 22, 32, 12, 58, DateTimeKind.Local).AddTicks(8795) });

            migrationBuilder.InsertData(
                table: "Club",
                columns: new[] { "Id", "CloseTime", "ClubAddress", "ClubDescription", "ClubName", "ClubPhone", "ClubStatusEnum", "Created", "CreatedBy", "LastModifiedBy", "MinDuration", "OpenTime", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"), new TimeOnly(21, 0, 0), "456 Oak Ave", "A state-of-the-art health club.", "Health Club B", "555-5678", 1, new DateTime(2024, 6, 18, 22, 32, 12, 58, DateTimeKind.Local).AddTicks(8847), "Admin", "Admin", 1.0, new TimeOnly(5, 30, 0), new Guid("626d577c-5966-4993-afb8-72e672d16649") },
                    { new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"), new TimeOnly(20, 0, 0), "789 Pine St", "A peaceful yoga center.", "Yoga Center C", "555-7890", 2, new DateTime(2024, 6, 18, 22, 32, 12, 58, DateTimeKind.Local).AddTicks(8861), "Admin", "Admin", 2.0, new TimeOnly(7, 0, 0), new Guid("626d577c-5966-4993-afb8-72e672d16649") },
                    { new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"), new TimeOnly(22, 30, 0), "321 Elm St", "A club with excellent swimming facilities.", "Swimming Club D", "555-3210", 2, new DateTime(2024, 6, 18, 22, 32, 12, 58, DateTimeKind.Local).AddTicks(8875), "Admin", "Admin", 1.5, new TimeOnly(6, 30, 0), new Guid("40e8ca6a-06c0-4deb-8bec-c3919817b8cf") }
                });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 18, 22, 32, 12, 62, DateTimeKind.Local).AddTicks(7258) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 18, 22, 32, 12, 62, DateTimeKind.Local).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4366), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4366) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4380), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4381) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4339), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4339) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4375), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4376) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4328), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4333), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4334) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4355), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4356) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4350), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4351) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4360), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4361) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4371), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4371) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4345), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4345) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4316), new DateTime(2024, 6, 18, 22, 32, 12, 68, DateTimeKind.Local).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 73, DateTimeKind.Local).AddTicks(3549), new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 18, 22, 32, 12, 73, DateTimeKind.Local).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 18, 22, 32, 12, 73, DateTimeKind.Local).AddTicks(3542), new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 18, 22, 32, 12, 73, DateTimeKind.Local).AddTicks(3534) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 18, 22, 32, 12, 85, DateTimeKind.Local).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 18, 22, 32, 12, 85, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 18, 22, 32, 12, 85, DateTimeKind.Local).AddTicks(2597));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3afe07f2-1a93-4c2e-8066-e25e8e71482f"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("85e4ca4c-c7d0-405f-a8ad-e1e063fad493"), null, "Staff", "STAFF" },
                    { new Guid("eb8f05fe-b41c-4c7f-b1ac-d7f36cfc26c1"), null, "Manager", "MANAGER" },
                    { new Guid("f8108772-e11b-486e-beef-cf92545c5212"), null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"));

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"));

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3afe07f2-1a93-4c2e-8066-e25e8e71482f"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("85e4ca4c-c7d0-405f-a8ad-e1e063fad493"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eb8f05fe-b41c-4c7f-b1ac-d7f36cfc26c1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f8108772-e11b-486e-beef-cf92545c5212"));

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionNo",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TxnRef",
                table: "Transaction");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                columns: new[] { "ClubStatusEnum", "Created" },
                values: new object[] { 0, new DateTime(2024, 6, 7, 19, 33, 28, 402, DateTimeKind.Local).AddTicks(625) });

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                columns: new[] { "ClubStatusEnum", "Created" },
                values: new object[] { 0, new DateTime(2024, 6, 7, 19, 33, 28, 402, DateTimeKind.Local).AddTicks(593) });

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                columns: new[] { "ClubStatusEnum", "Created" },
                values: new object[] { 0, new DateTime(2024, 6, 7, 19, 33, 28, 402, DateTimeKind.Local).AddTicks(549) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 7, 19, 33, 28, 407, DateTimeKind.Local).AddTicks(3206) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 7, 19, 33, 28, 407, DateTimeKind.Local).AddTicks(3197) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(576), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(577) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(597), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(599) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(464), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(465) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(590), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(448), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(456), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(560), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(561) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(479), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(568), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(569) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(583), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(472), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(434), new DateTime(2024, 6, 7, 19, 33, 28, 414, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 421, DateTimeKind.Local).AddTicks(4017), new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 7, 19, 33, 28, 421, DateTimeKind.Local).AddTicks(4014) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 7, 19, 33, 28, 421, DateTimeKind.Local).AddTicks(4001), new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 7, 19, 33, 28, 421, DateTimeKind.Local).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 7, 19, 33, 28, 435, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 7, 19, 33, 28, 435, DateTimeKind.Local).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 7, 19, 33, 28, 435, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("15df863e-f8fc-4939-9f85-ee7092f7fa31"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("3cea104b-67d9-4e19-a516-8aee3e46869b"), null, "Manager", "MANAGER" },
                    { new Guid("d974bc46-4556-4650-acc0-eda4f9797e12"), null, "Customer", "CUSTOMER" },
                    { new Guid("ec7844f0-8099-4356-86b2-b99e8c3fa36c"), null, "Staff", "STAFF" }
                });
        }
    }
}
