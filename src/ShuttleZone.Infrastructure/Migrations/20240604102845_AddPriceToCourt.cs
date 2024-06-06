using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToCourt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("58337a16-6f73-4422-9018-605c63b6e214"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("afadd484-57e4-44e2-8ae6-7ee0434c2b99"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f1d4c171-2024-4ba5-8edb-9de92d9c1056"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f37d5174-5010-4935-bb04-83a64b2cb3be"));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Court",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 17, 28, 44, 507, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 17, 28, 44, 507, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 17, 28, 44, 507, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 17, 28, 44, 509, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 17, 28, 44, 509, DateTimeKind.Local).AddTicks(5559));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3391), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3391), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3403), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3404), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3371), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3372), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3399), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3400), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(2706), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3364), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3367), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3368), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3383), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3383), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3379), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3380), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3386), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3387), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3395), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3395), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3375), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3376), 100.0 });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified", "Price" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(2688), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(2697), 100.0 });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 514, DateTimeKind.Local).AddTicks(6188), new DateTime(2024, 6, 4, 17, 28, 44, 514, DateTimeKind.Local).AddTicks(6186) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 514, DateTimeKind.Local).AddTicks(6183), new DateTime(2024, 6, 4, 17, 28, 44, 514, DateTimeKind.Local).AddTicks(6173) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 17, 28, 44, 520, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 17, 28, 44, 520, DateTimeKind.Local).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 17, 28, 44, 520, DateTimeKind.Local).AddTicks(2985));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("75cf04ce-7bc5-48af-91eb-2e8aeab01ff5"), null, "Staff", "STAFF" },
                    { new Guid("ad4a9d0f-3c15-49c0-97eb-72e869bec3f6"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("e04edbc8-4043-443b-8b3d-ce9672eae893"), null, "Customer", "CUSTOMER" },
                    { new Guid("eed4c7dc-1102-4158-baf7-f7cc96666ef8"), null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("75cf04ce-7bc5-48af-91eb-2e8aeab01ff5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ad4a9d0f-3c15-49c0-97eb-72e869bec3f6"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e04edbc8-4043-443b-8b3d-ce9672eae893"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eed4c7dc-1102-4158-baf7-f7cc96666ef8"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Court");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 12, 45, 8, 231, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 12, 45, 8, 231, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 12, 45, 8, 231, DateTimeKind.Local).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 12, 45, 8, 232, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 12, 45, 8, 232, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(870), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(880), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(850), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(870), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(840), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(850), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(860), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(860), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(860), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(870), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(870) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(850), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(830), new DateTime(2024, 6, 4, 12, 45, 8, 234, DateTimeKind.Local).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 235, DateTimeKind.Local).AddTicks(1940), new DateTime(2024, 6, 4, 12, 45, 8, 235, DateTimeKind.Local).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 235, DateTimeKind.Local).AddTicks(1940), new DateTime(2024, 6, 4, 12, 45, 8, 235, DateTimeKind.Local).AddTicks(1930) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 12, 45, 8, 237, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 12, 45, 8, 237, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 12, 45, 8, 237, DateTimeKind.Local).AddTicks(8800));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("58337a16-6f73-4422-9018-605c63b6e214"), null, "Staff", "STAFF" },
                    { new Guid("afadd484-57e4-44e2-8ae6-7ee0434c2b99"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("f1d4c171-2024-4ba5-8edb-9de92d9c1056"), null, "Customer", "CUSTOMER" },
                    { new Guid("f37d5174-5010-4935-bb04-83a64b2cb3be"), null, "Manager", "MANAGER" }
                });
        }
    }
}
