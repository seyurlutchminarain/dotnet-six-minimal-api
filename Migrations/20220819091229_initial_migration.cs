using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixMinApi.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressModels",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplexBuilding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModels", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountModels",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebitDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountModels", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "ClientModels",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentialAddressAddressId = table.Column<int>(type: "int", nullable: false),
                    BankAccountBankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModels", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ClientModels_AddressModels_ResidentialAddressAddressId",
                        column: x => x.ResidentialAddressAddressId,
                        principalTable: "AddressModels",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientModels_BankAccountModels_BankAccountBankId",
                        column: x => x.BankAccountBankId,
                        principalTable: "BankAccountModels",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DependantModels",
                columns: table => new
                {
                    DependantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverAmount = table.Column<double>(type: "float", nullable: false),
                    ClientModelUserId1 = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientModelUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependantModels", x => x.DependantId);
                    table.ForeignKey(
                        name: "FK_DependantModels_ClientModels_ClientModelUserId",
                        column: x => x.ClientModelUserId,
                        principalTable: "ClientModels",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_DependantModels_ClientModels_ClientModelUserId1",
                        column: x => x.ClientModelUserId1,
                        principalTable: "ClientModels",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientModels_BankAccountBankId",
                table: "ClientModels",
                column: "BankAccountBankId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientModels_ResidentialAddressAddressId",
                table: "ClientModels",
                column: "ResidentialAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DependantModels_ClientModelUserId",
                table: "DependantModels",
                column: "ClientModelUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DependantModels_ClientModelUserId1",
                table: "DependantModels",
                column: "ClientModelUserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependantModels");

            migrationBuilder.DropTable(
                name: "ClientModels");

            migrationBuilder.DropTable(
                name: "AddressModels");

            migrationBuilder.DropTable(
                name: "BankAccountModels");
        }
    }
}
