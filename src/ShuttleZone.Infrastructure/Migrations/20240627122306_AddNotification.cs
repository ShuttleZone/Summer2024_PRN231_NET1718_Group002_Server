using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("05e0e30b-a584-4fe0-868a-52f4cc2a1e17"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("16fe6e61-f71a-456a-a769-1bd884ffd0b5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a6a93284-912f-4cbf-8c76-05f77a926b07"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f3e8e0d7-41be-4ab3-8700-c2f6abbb3904"));

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Wallet",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "PackageStatus",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 711, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 711, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 711, DateTimeKind.Local).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 711, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 711, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 711, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 715, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 715, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2424), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2425) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2443), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2444) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2389), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2437), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2438) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2376), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2377) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2383), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2384) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2411), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2411) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2404), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2405) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2417), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2418) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2431), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2432) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2397), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2398) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2365), new DateTime(2024, 6, 27, 19, 23, 4, 721, DateTimeKind.Local).AddTicks(2366) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 725, DateTimeKind.Local).AddTicks(5139), new DateTime(2024, 6, 27, 19, 23, 4, 725, DateTimeKind.Local).AddTicks(5138) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 27, 19, 23, 4, 725, DateTimeKind.Local).AddTicks(5133), new DateTime(2024, 6, 27, 19, 23, 4, 725, DateTimeKind.Local).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 742, DateTimeKind.Local).AddTicks(7763));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 742, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 19, 23, 4, 742, DateTimeKind.Local).AddTicks(7778));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("436bd7cf-8a5f-4314-b8e6-ac71601fd20c"), null, "Staff", "STAFF" },
                    { new Guid("814a5ac8-3e60-4108-9365-07dfa9a69578"), null, "Customer", "CUSTOMER" },
                    { new Guid("eef861b3-da8b-4d8d-ab86-e7d0eb9e0f05"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("f1d65b6b-96dd-492b-bbbd-6a06ca59eb4f"), null, "Manager", "MANAGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("436bd7cf-8a5f-4314-b8e6-ac71601fd20c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("814a5ac8-3e60-4108-9365-07dfa9a69578"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eef861b3-da8b-4d8d-ab86-e7d0eb9e0f05"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f1d65b6b-96dd-492b-bbbd-6a06ca59eb4f"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Wallet",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PackageStatus",
                table: "Package",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 239, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 239, DateTimeKind.Local).AddTicks(9949));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 239, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 239, DateTimeKind.Local).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 239, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 239, DateTimeKind.Local).AddTicks(9877));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 243, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 243, DateTimeKind.Local).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4869), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4882), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4883) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4846), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4847) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4878), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4837), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4838) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4842), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4860), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4860) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4855), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4856) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4865), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4865) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4874), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4874) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4851), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4852) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4829), new DateTime(2024, 6, 27, 12, 51, 7, 247, DateTimeKind.Local).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 251, DateTimeKind.Local).AddTicks(5992), new DateTime(2024, 6, 27, 12, 51, 7, 251, DateTimeKind.Local).AddTicks(5991) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 27, 12, 51, 7, 251, DateTimeKind.Local).AddTicks(5986), new DateTime(2024, 6, 27, 12, 51, 7, 251, DateTimeKind.Local).AddTicks(5977) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 263, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 263, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 27, 12, 51, 7, 263, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("05e0e30b-a584-4fe0-868a-52f4cc2a1e17"), null, "Customer", "CUSTOMER" },
                    { new Guid("16fe6e61-f71a-456a-a769-1bd884ffd0b5"), null, "Staff", "STAFF" },
                    { new Guid("a6a93284-912f-4cbf-8c76-05f77a926b07"), null, "Manager", "MANAGER" },
                    { new Guid("f3e8e0d7-41be-4ab3-8700-c2f6abbb3904"), null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
