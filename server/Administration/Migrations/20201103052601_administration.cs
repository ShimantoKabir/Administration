using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Administration.Migrations
{
    public partial class administration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    oId = table.Column<int>(nullable: false),
                    orgOid = table.Column<int>(nullable: true),
                    projectOid = table.Column<int>(nullable: false),
                    menuName = table.Column<string>(nullable: false),
                    tooltip = table.Column<string>(nullable: true),
                    component = table.Column<string>(nullable: true),
                    path = table.Column<string>(nullable: true),
                    parentOid = table.Column<int>(nullable: false),
                    power = table.Column<int>(nullable: false),
                    ip = table.Column<string>(nullable: true),
                    modifiedBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    oId = table.Column<int>(nullable: false),
                    orgName = table.Column<string>(nullable: false),
                    ip = table.Column<string>(nullable: true),
                    modifiedBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "powers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orgOid = table.Column<int>(nullable: true),
                    powerName = table.Column<string>(nullable: false),
                    powerValue = table.Column<int>(nullable: false),
                    ip = table.Column<string>(nullable: true),
                    modifiedBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_powers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    oId = table.Column<int>(nullable: false),
                    projectName = table.Column<string>(nullable: false),
                    ip = table.Column<string>(nullable: true),
                    modifiedBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "restrictedMenus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    menuOid = table.Column<int>(nullable: false),
                    userInfoOid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restrictedMenus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    oId = table.Column<int>(nullable: false),
                    orgOid = table.Column<int>(nullable: true),
                    power = table.Column<int>(nullable: false),
                    roleName = table.Column<string>(nullable: false),
                    ip = table.Column<string>(nullable: true),
                    modifiedBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userConfigurations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orgOid = table.Column<int>(nullable: false),
                    roleOid = table.Column<int>(nullable: false),
                    projectOid = table.Column<int>(nullable: false),
                    userInfoOid = table.Column<int>(nullable: false),
                    opAccess = table.Column<string>(nullable: true),
                    ip = table.Column<string>(nullable: true),
                    modifiedBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userConfigurations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userInfos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    oId = table.Column<int>(nullable: false),
                    orgOid = table.Column<int>(nullable: true),
                    userId = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    socialLoginId = table.Column<string>(nullable: true),
                    imgUrl = table.Column<string>(nullable: true),
                    ip = table.Column<string>(nullable: true),
                    modifiedBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userInfos", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "userInfos",
                columns: new[] { "id", "createdAt", "email", "imgUrl", "ip", "modifiedBy", "oId", "orgOid", "password", "socialLoginId", "userId", "userName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "developer@mail.com", null, null, null, 1, 0, "3dacbce532ccd48f27fa62e993067b3c35f094f7", null, "developer", "developer" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "qa@mail.com", null, null, null, 2, 0, "d3c583412a36313ab5e24293924c39a36b842c56", null, "qa", "qa" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cto@mail.com", null, null, null, 3, 0, "19f7ca240c1a90751ff47695616871db95411694", null, "cto", "cto" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ceo@mail.com", null, null, null, 4, 0, "9d382342daac150ef51c8383dcf21ff57743b96d", null, "ceo", "ceo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "powers");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "restrictedMenus");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "userConfigurations");

            migrationBuilder.DropTable(
                name: "userInfos");
        }
    }
}
