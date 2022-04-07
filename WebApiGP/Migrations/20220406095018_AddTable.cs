using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGP.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "AdminFamilys",
                columns: table => new
                {
                    idAdminFamily = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idFamily = table.Column<long>(type: "bigint", nullable: false),
                    idGiaPha = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminFamilys", x => x.idAdminFamily);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    idAdmin = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idGiaPha = table.Column<long>(type: "bigint", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.idAdmin);
                });

            migrationBuilder.CreateTable(
                name: "ClientDeails",
                columns: table => new
                {
                    idClientDetail = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diedDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startus = table.Column<int>(type: "int", nullable: false),
                    idGiaPhaChild = table.Column<long>(type: "bigint", nullable: false),
                    idFamily = table.Column<long>(type: "bigint", nullable: false),
                    idLocationDied = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeails", x => x.idClientDetail);
                });

            migrationBuilder.CreateTable(
                name: "Familys",
                columns: table => new
                {
                    idFamily = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bigIdFamily = table.Column<long>(type: "bigint", nullable: false),
                    idGiaPha = table.Column<long>(type: "bigint", nullable: false),
                    idLocationHome = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familys", x => x.idFamily);
                });

            migrationBuilder.CreateTable(
                name: "idGiaPhas",
                columns: table => new
                {
                    idGiaPha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idGiaPhas", x => x.idGiaPha);
                });

            migrationBuilder.CreateTable(
                name: "LocationDieadDetails",
                columns: table => new
                {
                    idLocationDiedDetail = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    latiude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDieadDetails", x => x.idLocationDiedDetail);
                });

            migrationBuilder.CreateTable(
                name: "LocationDieds",
                columns: table => new
                {
                    idLocationDied = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLocationDiedDetail = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDieds", x => x.idLocationDied);
                });

            migrationBuilder.CreateTable(
                name: "LocationHomes",
                columns: table => new
                {
                    idLocationHome = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    latiude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationHomes", x => x.idLocationHome);
                });

            migrationBuilder.CreateTable(
                name: "ManagerIDGiaPhas",
                columns: table => new
                {
                    idManagerIDGiaPha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idGiaPha = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerIDGiaPhas", x => x.idManagerIDGiaPha);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminFamilys");

            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "ClientDeails");

            migrationBuilder.DropTable(
                name: "Familys");

            migrationBuilder.DropTable(
                name: "idGiaPhas");

            migrationBuilder.DropTable(
                name: "LocationDieadDetails");

            migrationBuilder.DropTable(
                name: "LocationDieds");

            migrationBuilder.DropTable(
                name: "LocationHomes");

            migrationBuilder.DropTable(
                name: "ManagerIDGiaPhas");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    count = table.Column<double>(type: "float", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUser);
                });
        }
    }
}
