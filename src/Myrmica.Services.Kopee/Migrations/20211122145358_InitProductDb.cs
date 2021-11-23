using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Myrmica.Services.Kopee.Migrations
{
    public partial class InitProductDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CLIENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Demo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demo", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SERVICE_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TITLE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICE_TYPE", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SETTING_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TITLE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SETTING_TYPE", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BRANCH",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IMAGE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MAP = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CLIENT_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CLIENTID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANCH", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BRANCH_CLIENT_CLIENTID",
                        column: x => x.CLIENTID,
                        principalTable: "CLIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CONTACT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FULLNAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PHONENUMBER = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LOCATION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTENT = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CLIENT_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CLIENTID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTACT_CLIENT_CLIENTID",
                        column: x => x.CLIENTID,
                        principalTable: "CLIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MENU",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TITLE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROUTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ORDER = table.Column<int>(type: "int", nullable: false),
                    MENU_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    CLIENT_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CLIENTID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PARENT_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PARENT_MENUID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MENU_CLIENT_CLIENTID",
                        column: x => x.CLIENTID,
                        principalTable: "CLIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MENU_MENU_PARENT_MENUID",
                        column: x => x.PARENT_MENUID,
                        principalTable: "MENU",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROUTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CATEGORY_PARENT_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PARENT_CATEGORYID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BANNER_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CLIENT_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CLIENTID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SERVICE_TYPE_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SERVICE_TYPEID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CATEGORY_CATEGORY_PARENT_CATEGORYID",
                        column: x => x.PARENT_CATEGORYID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CATEGORY_CLIENT_CLIENTID",
                        column: x => x.CLIENTID,
                        principalTable: "CLIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CATEGORY_SERVICE_TYPE_SERVICE_TYPEID",
                        column: x => x.SERVICE_TYPEID,
                        principalTable: "SERVICE_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CLIENT_SETTINGS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    KEY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VALUE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CLIENT_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CLIENTID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SETTING_TYPE_ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SETTING_TYPEID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENT_SETTINGS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CLIENT_SETTINGS_CLIENT_CLIENTID",
                        column: x => x.CLIENTID,
                        principalTable: "CLIENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CLIENT_SETTINGS_SETTING_TYPE_SETTING_TYPEID",
                        column: x => x.SETTING_TYPEID,
                        principalTable: "SETTING_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NEWS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TITLE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROUTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTENT = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHORT_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FULL_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IS_SPECIAL = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BANNER_SPECIAL_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BANNER_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CATEGORY_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CATEGORYID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEWS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NEWS_CATEGORY_CATEGORYID",
                        column: x => x.CATEGORYID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PRICE = table.Column<double>(type: "double", nullable: false),
                    ROUTE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SHORT_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FULL_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTENT = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IS_HOT = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_NEW = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_SPECIAL = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_DISCOUNT = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    THUMBNAIL_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    BANNER_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    SLIDE_IMAGE_IDS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CATEGORY_ID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CATEGORYID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY_CATEGORYID",
                        column: x => x.CATEGORYID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BRANCH_CLIENTID",
                table: "BRANCH",
                column: "CLIENTID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_CLIENTID",
                table: "CATEGORY",
                column: "CLIENTID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_PARENT_CATEGORYID",
                table: "CATEGORY",
                column: "PARENT_CATEGORYID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_SERVICE_TYPEID",
                table: "CATEGORY",
                column: "SERVICE_TYPEID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_SETTINGS_CLIENTID",
                table: "CLIENT_SETTINGS",
                column: "CLIENTID");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENT_SETTINGS_SETTING_TYPEID",
                table: "CLIENT_SETTINGS",
                column: "SETTING_TYPEID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTACT_CLIENTID",
                table: "CONTACT",
                column: "CLIENTID");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_CLIENTID",
                table: "MENU",
                column: "CLIENTID");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_PARENT_MENUID",
                table: "MENU",
                column: "PARENT_MENUID");

            migrationBuilder.CreateIndex(
                name: "IX_NEWS_CATEGORYID",
                table: "NEWS",
                column: "CATEGORYID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_CATEGORYID",
                table: "PRODUCT",
                column: "CATEGORYID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BRANCH");

            migrationBuilder.DropTable(
                name: "CLIENT_SETTINGS");

            migrationBuilder.DropTable(
                name: "CONTACT");

            migrationBuilder.DropTable(
                name: "Demo");

            migrationBuilder.DropTable(
                name: "MENU");

            migrationBuilder.DropTable(
                name: "NEWS");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "SETTING_TYPE");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "CLIENT");

            migrationBuilder.DropTable(
                name: "SERVICE_TYPE");
        }
    }
}
