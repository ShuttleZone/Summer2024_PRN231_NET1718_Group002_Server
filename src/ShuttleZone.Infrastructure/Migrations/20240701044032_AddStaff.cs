using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClubId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"),
                column: "ClubId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("40e8ca6a-06c0-4deb-8bec-c3919817b8cf"),
                column: "ClubId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("626d577c-5966-4993-afb8-72e672d16649"),
                column: "ClubId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
                column: "ClubId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 774, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 774, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 774, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 774, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 774, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 774, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 1, 11, 40, 31, 777, DateTimeKind.Local).AddTicks(1904) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 1, 11, 40, 31, 777, DateTimeKind.Local).AddTicks(1891) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8135), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8135) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8143), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8144) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8118), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8118) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8140), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8141) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8111), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8111) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8114), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8115) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8128), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8128) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8125), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8125) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8131), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8131) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8137), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8138) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8122), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8122) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8100), new DateTime(2024, 7, 1, 11, 40, 31, 779, DateTimeKind.Local).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 782, DateTimeKind.Local).AddTicks(5188), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 1, 11, 40, 31, 782, DateTimeKind.Local).AddTicks(5187) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 40, 31, 782, DateTimeKind.Local).AddTicks(5180), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 7, 1, 11, 40, 31, 782, DateTimeKind.Local).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 803, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 803, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 7, 1, 11, 40, 31, 803, DateTimeKind.Local).AddTicks(364));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClubId",
                table: "AspNetUsers",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Club_ClubId",
                table: "AspNetUsers",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Club_ClubId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClubId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 697, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 697, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 697, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 697, DateTimeKind.Local).AddTicks(8412));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 697, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 697, DateTimeKind.Local).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 28, 3, 30, 25, 700, DateTimeKind.Local).AddTicks(3992) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 28, 3, 30, 25, 700, DateTimeKind.Local).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7270), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7282), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7283) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7248), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7278), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7279) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7229), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7230) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7244), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7262), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7262) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7257), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7258) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7266), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7266) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7274), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7275) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7253), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7222), new DateTime(2024, 6, 28, 3, 30, 25, 703, DateTimeKind.Local).AddTicks(7223) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 706, DateTimeKind.Local).AddTicks(8549), new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 28, 3, 30, 25, 706, DateTimeKind.Local).AddTicks(8547) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 28, 3, 30, 25, 706, DateTimeKind.Local).AddTicks(8544), new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 28, 3, 30, 25, 706, DateTimeKind.Local).AddTicks(8537) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 716, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 716, DateTimeKind.Local).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 28, 3, 30, 25, 716, DateTimeKind.Local).AddTicks(881));
        }
    }
}
