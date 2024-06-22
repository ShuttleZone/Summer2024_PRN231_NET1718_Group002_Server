using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userProfileImage : Migration
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
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"),
                column: "ProfileImage",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("40e8ca6a-06c0-4deb-8bec-c3919817b8cf"),
                column: "ProfileImage",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("626d577c-5966-4993-afb8-72e672d16649"),
                column: "ProfileImage",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
                column: "ProfileImage",
                value: null);

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 855, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 855, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 855, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 855, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 855, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 855, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 22, 0, 1, 27, 857, DateTimeKind.Local).AddTicks(7829) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 22, 0, 1, 27, 857, DateTimeKind.Local).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5635), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5636) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5648), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5648) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5612), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5612) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5644), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5644) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5592), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5593) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5607), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5626), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5626) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5621), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5622) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5630), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5639), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5640) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5617), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5618) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5582), new DateTime(2024, 6, 22, 0, 1, 27, 860, DateTimeKind.Local).AddTicks(5583) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 863, DateTimeKind.Local).AddTicks(2350), new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 22, 0, 1, 27, 863, DateTimeKind.Local).AddTicks(2349) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 1, 27, 863, DateTimeKind.Local).AddTicks(2343), new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 22, 0, 1, 27, 863, DateTimeKind.Local).AddTicks(2332) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 874, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 874, DateTimeKind.Local).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 0, 1, 27, 874, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("538c200a-e213-4960-b2c5-0d714f86baaa"), null, "Manager", "MANAGER" },
                    { new Guid("5634a694-1563-41a6-b50f-baea6531613c"), null, "Staff", "STAFF" },
                    { new Guid("b5857177-2f7c-4ef8-a032-0e6c2351be04"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("d4b16e64-9605-45a9-a7bd-2ebbf903613f"), null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("538c200a-e213-4960-b2c5-0d714f86baaa"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5634a694-1563-41a6-b50f-baea6531613c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b5857177-2f7c-4ef8-a032-0e6c2351be04"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d4b16e64-9605-45a9-a7bd-2ebbf903613f"));

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "AspNetUsers");

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
