using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExpiredTimeToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("009c86e1-e784-4f58-81cd-d929596364f9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("391718ee-e342-4805-b229-318a9e4ba767"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("75f650de-0be5-4453-9285-b42fc0023117"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c08f9961-2fef-4221-b962-61d0f4e7bc1d"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredTime",
                table: "Reservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 7, 19, 33, 28, 402, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 7, 19, 33, 28, 402, DateTimeKind.Local).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 7, 19, 33, 28, 402, DateTimeKind.Local).AddTicks(549));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ExpiredTime",
                table: "Reservation");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 5, 8, 43, 56, 873, DateTimeKind.Local).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 5, 8, 43, 56, 873, DateTimeKind.Local).AddTicks(2971));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 5, 8, 43, 56, 873, DateTimeKind.Local).AddTicks(2949));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 5, 8, 43, 56, 876, DateTimeKind.Local).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 5, 8, 43, 56, 876, DateTimeKind.Local).AddTicks(4968) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3893), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3894) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3908), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3909) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3867), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3868) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3903), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3904) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3857), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3858) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3863), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3863) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3883), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3878), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3879) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3887), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3888) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3898), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3899) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3873), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3874) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3842), new DateTime(2024, 6, 5, 8, 43, 56, 880, DateTimeKind.Local).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 884, DateTimeKind.Local).AddTicks(2574), new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 5, 8, 43, 56, 884, DateTimeKind.Local).AddTicks(2572) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 5, 8, 43, 56, 884, DateTimeKind.Local).AddTicks(2567), new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 5, 8, 43, 56, 884, DateTimeKind.Local).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 5, 8, 43, 56, 893, DateTimeKind.Local).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 5, 8, 43, 56, 893, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 5, 8, 43, 56, 893, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("009c86e1-e784-4f58-81cd-d929596364f9"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("391718ee-e342-4805-b229-318a9e4ba767"), null, "Manager", "MANAGER" },
                    { new Guid("75f650de-0be5-4453-9285-b42fc0023117"), null, "Staff", "STAFF" },
                    { new Guid("c08f9961-2fef-4221-b962-61d0f4e7bc1d"), null, "Customer", "CUSTOMER" }
                });
        }
    }
}
