using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseAuditableAllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "TotalHours",
                table: "Reservation");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Maintenance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Court",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Contest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Club",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 21, 9, 49, 992, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 21, 9, 49, 992, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 21, 9, 49, 992, DateTimeKind.Local).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 21, 9, 49, 996, DateTimeKind.Local).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 21, 9, 49, 996, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7492), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7492) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7506), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7464), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7465) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7501), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7454), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7454) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7459), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7481), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7482) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7476), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7486), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7487) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7496), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7497) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7471), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7472) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7428), new DateTime(2024, 6, 4, 21, 9, 50, 0, DateTimeKind.Local).AddTicks(7442) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 7, DateTimeKind.Local).AddTicks(1458), new DateTime(2024, 6, 4, 21, 9, 50, 7, DateTimeKind.Local).AddTicks(1457) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 21, 9, 50, 7, DateTimeKind.Local).AddTicks(1450), new DateTime(2024, 6, 4, 21, 9, 50, 7, DateTimeKind.Local).AddTicks(1413) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 21, 9, 50, 17, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 21, 9, 50, 17, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 4, 21, 9, 50, 17, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("27b5383b-9518-4410-9f18-c0ad50fd2f5b"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("33381ecf-eb42-4cdc-a875-b00c62a68fd6"), null, "Staff", "STAFF" },
                    { new Guid("5402291c-e4f3-41e8-851f-aa2bd063faaa"), null, "Manager", "MANAGER" },
                    { new Guid("bfba7d10-2f5e-4c2d-9e26-3edf50a4c165"), null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("27b5383b-9518-4410-9f18-c0ad50fd2f5b"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("33381ecf-eb42-4cdc-a875-b00c62a68fd6"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5402291c-e4f3-41e8-851f-aa2bd063faaa"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bfba7d10-2f5e-4c2d-9e26-3edf50a4c165"));

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Maintenance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Court",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Contest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Club",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3391), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3403), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3404) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3371), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3372) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3399), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3400) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(2706), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3364) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3367), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3368) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3383), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3383) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3379), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3380) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3386), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3387) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3395), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3395) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3375), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(3376) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(2688), new DateTime(2024, 6, 4, 17, 28, 44, 512, DateTimeKind.Local).AddTicks(2697) });

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
    }
}
