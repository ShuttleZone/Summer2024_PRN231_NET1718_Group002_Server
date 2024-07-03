using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePackageUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageUser",
                table: "PackageUser");

            migrationBuilder.AddColumn<int>(
                name: "PackageUserStatus",
                table: "PackageUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageUser",
                table: "PackageUser",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 649, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 649, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 649, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 649, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 649, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 649, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 651, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 651, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5600), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5610), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5580), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5610), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5570), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5570), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5590), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5590) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5590), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5590) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5590), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5600), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5580), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5580) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5560), new DateTime(2024, 7, 3, 17, 32, 18, 653, DateTimeKind.Local).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 655, DateTimeKind.Local).AddTicks(1690), new DateTime(2024, 7, 3, 17, 32, 18, 655, DateTimeKind.Local).AddTicks(1690) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 3, 17, 32, 18, 655, DateTimeKind.Local).AddTicks(1680), new DateTime(2024, 7, 3, 17, 32, 18, 655, DateTimeKind.Local).AddTicks(1680) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 658, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 658, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 17, 32, 18, 658, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.CreateIndex(
                name: "IX_PackageUser_PackageId",
                table: "PackageUser",
                column: "PackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageUser",
                table: "PackageUser");

            migrationBuilder.DropIndex(
                name: "IX_PackageUser_PackageId",
                table: "PackageUser");

            migrationBuilder.DropColumn(
                name: "PackageUserStatus",
                table: "PackageUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageUser",
                table: "PackageUser",
                columns: new[] { "PackageId", "UserId" });

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 240, DateTimeKind.Local).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 240, DateTimeKind.Local).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 240, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 240, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 240, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 240, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 243, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 243, DateTimeKind.Local).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4754), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4755) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4765), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4766) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4733), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4733) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4762), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4762) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4725), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4725) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4729), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4729) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4745), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4742), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4742) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4749), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4758), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4758) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4738), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4738) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4716), new DateTime(2024, 7, 3, 10, 52, 26, 246, DateTimeKind.Local).AddTicks(4717) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 249, DateTimeKind.Local).AddTicks(8966), new DateTime(2024, 7, 3, 10, 52, 26, 249, DateTimeKind.Local).AddTicks(8964) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 3, 10, 52, 26, 249, DateTimeKind.Local).AddTicks(8960), new DateTime(2024, 7, 3, 10, 52, 26, 249, DateTimeKind.Local).AddTicks(8952) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 258, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 258, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 7, 3, 10, 52, 26, 258, DateTimeKind.Local).AddTicks(8271));
        }
    }
}
