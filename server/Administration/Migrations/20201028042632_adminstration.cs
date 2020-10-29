using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Administration.Migrations
{
    public partial class adminstration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    orgId = table.Column<int>(nullable: true),
                    projectId = table.Column<int>(nullable: false),
                    menuName = table.Column<string>(nullable: false),
                    tooltip = table.Column<string>(nullable: true),
                    component = table.Column<string>(nullable: true),
                    path = table.Column<string>(nullable: true),
                    parentId = table.Column<int>(nullable: false),
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
                name: "projects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    menuId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
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
                    orgId = table.Column<int>(nullable: true),
                    roleId = table.Column<int>(nullable: true),
                    projectId = table.Column<int>(nullable: true),
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
                    orgId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    socialLoginId = table.Column<string>(nullable: true),
                    opAccess = table.Column<string>(nullable: true),
                    imgUrl = table.Column<string>(nullable: true),
                    ip = table.Column<string>(nullable: true),
                    modifiedBy = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userInfos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menus");

            migrationBuilder.DropTable(
                name: "organizations");

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
