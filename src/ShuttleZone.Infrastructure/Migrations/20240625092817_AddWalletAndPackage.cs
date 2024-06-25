﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShuttleZone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWalletAndPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5b653431-149d-480f-95f0-859e613b1e24"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8092858e-02cf-4bd8-84bc-58d04e0a536d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("88e43d97-f0c5-401e-b8f8-7c4de3984b9f"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bce1c4f9-4465-4421-8e5b-93536ea5b387"));

            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageUser_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageUser_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("26a7cc4e-3f9b-4923-809e-2f9b771d994f"),
                column: "WalletId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("40e8ca6a-06c0-4deb-8bec-c3919817b8cf"),
                column: "WalletId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("626d577c-5966-4993-afb8-72e672d16649"),
                column: "WalletId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
                column: "WalletId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 629, DateTimeKind.Local).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 629, DateTimeKind.Local).AddTicks(7824));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 629, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 629, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 629, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 629, DateTimeKind.Local).AddTicks(7771));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 25, 16, 28, 15, 632, DateTimeKind.Local).AddTicks(5504) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 25, 16, 28, 15, 632, DateTimeKind.Local).AddTicks(5500) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7615), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7615) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7628), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7582), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7582) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7624), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7624) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7574), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7578), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7578) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7594), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7594) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7590), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7591) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7598), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7598) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7620), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7620) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7586), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7586) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7567), new DateTime(2024, 6, 25, 16, 28, 15, 635, DateTimeKind.Local).AddTicks(7568) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 638, DateTimeKind.Local).AddTicks(8327), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 25, 16, 28, 15, 638, DateTimeKind.Local).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 25, 16, 28, 15, 638, DateTimeKind.Local).AddTicks(8321), new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 25, 16, 28, 15, 638, DateTimeKind.Local).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 645, DateTimeKind.Local).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 645, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 25, 16, 28, 15, 645, DateTimeKind.Local).AddTicks(9291));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4a8981e6-2280-4472-913c-c42aa9ccfa05"), null, "Staff", "STAFF" },
                    { new Guid("7101e959-4404-4045-8ab7-2e56c5a5554a"), null, "Manager", "MANAGER" },
                    { new Guid("898b1026-da40-4549-a9ac-d25086960a30"), null, "Customer", "CUSTOMER" },
                    { new Guid("b73e3f68-7d34-4a99-9ef7-a17e2d8baa5a"), null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageUser_PackageId",
                table: "PackageUser",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageUser_TransactionId",
                table: "PackageUser",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageUser_UserId",
                table: "PackageUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_UserId",
                table: "Wallet",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageUser");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4a8981e6-2280-4472-913c-c42aa9ccfa05"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7101e959-4404-4045-8ab7-2e56c5a5554a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("898b1026-da40-4549-a9ac-d25086960a30"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b73e3f68-7d34-4a99-9ef7-a17e2d8baa5a"));

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("1c9e8457-4a2d-4b93-b71b-1b6876cbcf78"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 820, DateTimeKind.Local).AddTicks(5220));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("3d7a6244-e920-4e9e-9e97-5c6f0a5d539e"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 820, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 820, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 820, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("7ac14b60-7e89-4e2a-a6ad-6ff6de3d88e7"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 820, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Club",
                keyColumn: "Id",
                keyValue: new Guid("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 820, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 22, 9, 52, 12, 821, DateTimeKind.Local).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "Contest",
                keyColumn: "Id",
                keyValue: new Guid("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                columns: new[] { "ContestDate", "Created" },
                values: new object[] { new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 22, 9, 52, 12, 821, DateTimeKind.Local).AddTicks(7990) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1650), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1650) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1660), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("472b9b48-30d2-4f3e-a01f-527db703525b"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1630), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("6699976f-f3ca-42a0-9948-41fae24efa03"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1660), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1620), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1620), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("94a75cc3-7553-4281-b527-107f6f4369c5"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1640), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1640) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1630), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1640), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1640) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("abdd9e0b-de08-422b-894d-64f22365c583"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1650), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1650) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("ac15834d-74a2-463c-81ce-22400a1048f9"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1630), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "Court",
                keyColumn: "Id",
                keyValue: new Guid("e47d75fe-d045-4149-9b14-0cff4a752893"),
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1610), new DateTime(2024, 6, 22, 9, 52, 12, 823, DateTimeKind.Local).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("02d759bf-9408-452f-b920-359df87a0fac"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 824, DateTimeKind.Local).AddTicks(3020), new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 22, 9, 52, 12, 824, DateTimeKind.Local).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: new Guid("2d3476e2-526b-4a65-89f8-9561981c947e"),
                columns: new[] { "Created", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 6, 22, 9, 52, 12, 824, DateTimeKind.Local).AddTicks(3020), new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 6, 22, 9, 52, 12, 824, DateTimeKind.Local).AddTicks(3010) });

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("83196436-d386-48b4-bfac-d5b08d8cf604"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 829, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 829, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("fde0842b-3182-432a-b567-1c4aad77bac9"),
                column: "Created",
                value: new DateTime(2024, 6, 22, 9, 52, 12, 829, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5b653431-149d-480f-95f0-859e613b1e24"), null, "Customer", "CUSTOMER" },
                    { new Guid("8092858e-02cf-4bd8-84bc-58d04e0a536d"), null, "Staff", "STAFF" },
                    { new Guid("88e43d97-f0c5-401e-b8f8-7c4de3984b9f"), null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("bce1c4f9-4465-4421-8e5b-93536ea5b387"), null, "Manager", "MANAGER" }
                });
        }
    }
}
