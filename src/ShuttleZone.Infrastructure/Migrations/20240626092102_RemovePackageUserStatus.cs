using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePackageUserStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("595ecaaa-d27e-4246-b40a-a216f2db5bde"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7abbbeb6-a451-499e-89da-8e0bc4ce914b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c5e81a66-2e69-4c31-ba05-f24296593091"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d319181e-4973-4ecb-ba60-a1b11adfa203"));

            migrationBuilder.DropColumn(
                name: "PackageUserStatus",
                table: "PackageUser");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 371, DateTimeKind.Local).AddTicks(3590));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 371, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 371, DateTimeKind.Local).AddTicks(3580));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 371, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 371, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 371, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 372, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 372, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8400), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8410), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8380), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8410), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8360), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8370), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8390), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8390), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8400), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8400), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8410) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8380), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8380) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8360), new DateTime(2024, 6, 26, 16, 21, 2, 373, DateTimeKind.Local).AddTicks(8360) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 375, DateTimeKind.Local).AddTicks(50), new DateTime(2024, 6, 26, 16, 21, 2, 375, DateTimeKind.Local).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 26, 16, 21, 2, 375, DateTimeKind.Local).AddTicks(40), new DateTime(2024, 6, 26, 16, 21, 2, 375, DateTimeKind.Local).AddTicks(40) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 378, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 378, DateTimeKind.Local).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 16, 21, 2, 378, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("58140996-bcdb-4b46-bd9d-221082b86ede"), null, "Customer", "CUSTOMER" },
                    { new Guid("928f98ba-f6ce-4183-be23-1d631dcfcb84"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("9d371ff7-84d7-4982-9c7a-ef047002afce"), null, "Manager", "MANAGER" },
                    { new Guid("faa098b5-ba7f-44c8-9ca0-ccebaa444784"), null, "Staff", "STAFF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("58140996-bcdb-4b46-bd9d-221082b86ede"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("928f98ba-f6ce-4183-be23-1d631dcfcb84"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9d371ff7-84d7-4982-9c7a-ef047002afce"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("faa098b5-ba7f-44c8-9ca0-ccebaa444784"));

            migrationBuilder.AddColumn<int>(
                name: "PackageUserStatus",
                table: "PackageUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 179, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 179, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 179, DateTimeKind.Local).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 179, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 179, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 179, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 180, DateTimeKind.Local).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 180, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5040), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5060), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5020), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5050), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5010), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5020), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5020) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5030), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5030), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5040), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5040) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5050), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5020), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5010), new DateTime(2024, 6, 26, 9, 26, 37, 181, DateTimeKind.Local).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 182, DateTimeKind.Local).AddTicks(7370), new DateTime(2024, 6, 26, 9, 26, 37, 182, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 26, 9, 26, 37, 182, DateTimeKind.Local).AddTicks(7370), new DateTime(2024, 6, 26, 9, 26, 37, 182, DateTimeKind.Local).AddTicks(7360) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 186, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 186, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 26, 9, 26, 37, 186, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("595ecaaa-d27e-4246-b40a-a216f2db5bde"), null, "Staff", "STAFF" },
                    { new Guid("7abbbeb6-a451-499e-89da-8e0bc4ce914b"), null, "Manager", "MANAGER" },
                    { new Guid("c5e81a66-2e69-4c31-ba05-f24296593091"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("d319181e-4973-4ecb-ba60-a1b11adfa203"), null, "Customer", "CUSTOMER" }
                });
        }
    }
}
