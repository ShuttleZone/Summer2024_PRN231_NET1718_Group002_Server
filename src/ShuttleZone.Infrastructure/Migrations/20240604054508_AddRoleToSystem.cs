using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Club_User_OwnerId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_User_CustomerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ReviewerId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContest_User_ParticipantsId",
                table: "UserContest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumn: "UserId",
                keyValue: new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumn: "UserId",
                keyValue: new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("80d75090-a1aa-48cb-b3ba-233067001594"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f221a993-f8ff-40e4-a92f-2552ce67373d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8f42b74b-a7a2-4cd8-b449-5255ff317516"));

            migrationBuilder.RenameTable(
                name: "User",
                newName: "AspNetUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

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
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 4, 12, 45, 8, 232, DateTimeKind.Local).AddTicks(8980) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 4, 12, 45, 8, 232, DateTimeKind.Local).AddTicks(8970) });

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
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 235, DateTimeKind.Local).AddTicks(1940), new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 4, 12, 45, 8, 235, DateTimeKind.Local).AddTicks(1940) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 4, 12, 45, 8, 235, DateTimeKind.Local).AddTicks(1940), new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 4, 12, 45, 8, 235, DateTimeKind.Local).AddTicks(1930) });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_OwnerId",
                table: "Club",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_CustomerId",
                table: "Reservation",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContest_AspNetUsers_ParticipantsId",
                table: "UserContest",
                column: "ParticipantsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_OwnerId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_CustomerId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContest_AspNetUsers_ParticipantsId",
                table: "UserContest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

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

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("80d75090-a1aa-48cb-b3ba-233067001594"), "", "Staff", "staff" },
                    { new Guid("8f42b74b-a7a2-4cd8-b449-5255ff317516"), "", "Customer", "customer" },
                    { new Guid("f221a993-f8ff-40e4-a92f-2552ce67373d"), "", "Owner", "owner" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"), new Guid("8f42b74b-a7a2-4cd8-b449-5255ff317516") },
                    { new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"), new Guid("8f42b74b-a7a2-4cd8-b449-5255ff317516") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Club_User_OwnerId",
                table: "Club",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_User_CustomerId",
                table: "Reservation",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserContest_User_ParticipantsId",
                table: "UserContest",
                column: "ParticipantsId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
