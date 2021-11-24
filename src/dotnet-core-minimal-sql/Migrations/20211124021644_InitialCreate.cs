using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "dbo",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailNickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvince1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvince2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvince3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExt1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExt2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneExt3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredCommunicationMethod = table.Column<byte>(type: "tinyint", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ActiveDirectoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    JobTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailNickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MobilePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastModifiedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "dbo",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    ActiveDirectoryGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastModifiedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGroupAssoc",
                schema: "dbo",
                columns: table => new
                {
                    EmployeeGroupAssocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastModifiedUtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGroupAssoc", x => x.EmployeeGroupAssocId);
                    table.ForeignKey(
                        name: "FK_EmployeeGroupAssoc_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeGroupAssoc_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "dbo",
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGroupAssoc_EmployeeId",
                schema: "dbo",
                table: "EmployeeGroupAssoc",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGroupAssoc_GroupId",
                schema: "dbo",
                table: "EmployeeGroupAssoc",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeGroupAssoc",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "dbo");
        }
    }
}
