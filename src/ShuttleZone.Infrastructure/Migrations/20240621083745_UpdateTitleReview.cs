using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTitleReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("103aa131-0766-4f8f-a7ac-670b58b46a00"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b84a1414-0d4d-4f97-a71b-dae89375fec3"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ec0df0d7-18e5-4193-ad1d-c82c806af4df"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f84c51eb-d0f2-44b3-a456-3b7b16e69148"));

            migrationBuilder.AddColumn<string>(
                name: "ReplyTitle",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 21, 15, 37, 45, 112, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 21, 15, 37, 45, 112, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 21, 15, 37, 45, 112, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 21, 15, 37, 45, 112, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 21, 15, 37, 45, 112, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 21, 15, 37, 45, 112, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 21, 15, 37, 45, 113, DateTimeKind.Local).AddTicks(4510) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 21, 15, 37, 45, 113, DateTimeKind.Local).AddTicks(4510) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7030), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7040), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7010), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7040), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7000), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7000), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7000) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7020), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7020) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7030), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7030) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7030), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7040) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7010), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(6990), new DateTime(2024, 6, 21, 15, 37, 45, 114, DateTimeKind.Local).AddTicks(6990) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 115, DateTimeKind.Local).AddTicks(8320), new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 21, 15, 37, 45, 115, DateTimeKind.Local).AddTicks(8320) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 115, DateTimeKind.Local).AddTicks(8320), new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 21, 15, 37, 45, 115, DateTimeKind.Local).AddTicks(8320) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                columns: new[] { "Created", "ReplyTitle", "Title" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 121, DateTimeKind.Local).AddTicks(4510), null, null });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                columns: new[] { "Created", "ReplyTitle", "Title" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 121, DateTimeKind.Local).AddTicks(4510), null, null });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                columns: new[] { "Created", "ReplyTitle", "Title" },
                values: new object[] { new DateTime(2024, 6, 21, 15, 37, 45, 121, DateTimeKind.Local).AddTicks(4520), null, null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1a8b57e2-66da-4d8a-a2ce-ecaca8cad41b"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("24fb879c-acc7-42e1-9fd3-5b13a76fb55a"), null, "Customer", "CUSTOMER" },
                    { new Guid("5bb26beb-c2ec-48dc-a706-952bc2329d37"), null, "Staff", "STAFF" },
                    { new Guid("c599ece3-8f6e-4631-88f3-abaebbb361d2"), null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("1a8b57e2-66da-4d8a-a2ce-ecaca8cad41b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("24fb879c-acc7-42e1-9fd3-5b13a76fb55a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5bb26beb-c2ec-48dc-a706-952bc2329d37"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c599ece3-8f6e-4631-88f3-abaebbb361d2"));

            migrationBuilder.DropColumn(
                name: "ReplyTitle",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Review");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 502, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 502, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 502, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 502, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 502, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 502, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 19, 13, 39, 11, 503, DateTimeKind.Local).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 19, 13, 39, 11, 503, DateTimeKind.Local).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8730), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8750), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8710), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8740), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8700), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8710), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8720), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8720), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8730), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8740), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8720), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8700), new DateTime(2024, 6, 19, 13, 39, 11, 504, DateTimeKind.Local).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 506, DateTimeKind.Local).AddTicks(1370), new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 19, 13, 39, 11, 506, DateTimeKind.Local).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 39, 11, 506, DateTimeKind.Local).AddTicks(1360), new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 19, 13, 39, 11, 506, DateTimeKind.Local).AddTicks(1360) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 509, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 509, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 19, 13, 39, 11, 509, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("103aa131-0766-4f8f-a7ac-670b58b46a00"), null, "Manager", "MANAGER" },
                    { new Guid("b84a1414-0d4d-4f97-a71b-dae89375fec3"), null, "Staff", "STAFF" },
                    { new Guid("ec0df0d7-18e5-4193-ad1d-c82c806af4df"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("f84c51eb-d0f2-44b3-a456-3b7b16e69148"), null, "Customer", "CUSTOMER" }
                });
        }
    }
}
