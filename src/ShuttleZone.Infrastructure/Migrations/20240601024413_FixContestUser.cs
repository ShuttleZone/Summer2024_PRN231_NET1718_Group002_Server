using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixContestUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 1, 9, 44, 13, 352, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 1, 9, 44, 13, 352, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 1, 9, 44, 13, 352, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 1, 9, 44, 13, 353, DateTimeKind.Local).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 1, 9, 44, 13, 353, DateTimeKind.Local).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4010), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4020), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3990), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4020), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3980), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3980), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4000), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4000), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4000), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4010), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3990), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3970), new DateTime(2024, 6, 1, 9, 44, 13, 355, DateTimeKind.Local).AddTicks(3980) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 356, DateTimeKind.Local).AddTicks(7760), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 1, 9, 44, 13, 356, DateTimeKind.Local).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 1, 9, 44, 13, 356, DateTimeKind.Local).AddTicks(7750), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 1, 9, 44, 13, 356, DateTimeKind.Local).AddTicks(7750) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 1, 9, 44, 13, 360, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 1, 9, 44, 13, 360, DateTimeKind.Local).AddTicks(3550));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 1, 9, 44, 13, 360, DateTimeKind.Local).AddTicks(3560));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 5, 24, 13, 6, 25, 384, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 5, 24, 13, 6, 25, 384, DateTimeKind.Local).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 5, 24, 13, 6, 25, 384, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 24, 13, 6, 25, 388, DateTimeKind.Local).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 24, 13, 6, 25, 388, DateTimeKind.Local).AddTicks(9110) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3440), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3430), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3440), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3460) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3420), new DateTime(2024, 5, 24, 13, 6, 25, 390, DateTimeKind.Local).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 391, DateTimeKind.Local).AddTicks(8010), new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 24, 13, 6, 25, 391, DateTimeKind.Local).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 5, 24, 13, 6, 25, 391, DateTimeKind.Local).AddTicks(8010), new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 5, 24, 13, 6, 25, 391, DateTimeKind.Local).AddTicks(8000) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 5, 24, 13, 6, 25, 397, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 5, 24, 13, 6, 25, 397, DateTimeKind.Local).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 5, 24, 13, 6, 25, 397, DateTimeKind.Local).AddTicks(140));
        }
    }
}
