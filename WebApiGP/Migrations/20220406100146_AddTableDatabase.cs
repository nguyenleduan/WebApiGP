using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGP.Migrations
{
    public partial class AddTableDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDeails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManagerIDGiaPhas",
                table: "ManagerIDGiaPhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationHomes",
                table: "LocationHomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationDieds",
                table: "LocationDieds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationDieadDetails",
                table: "LocationDieadDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_idGiaPhas",
                table: "idGiaPhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Familys",
                table: "Familys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admins",
                table: "admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminFamilys",
                table: "AdminFamilys");

            migrationBuilder.RenameTable(
                name: "ManagerIDGiaPhas",
                newName: "ManagerIDGiaPha");

            migrationBuilder.RenameTable(
                name: "LocationHomes",
                newName: "LocationHome");

            migrationBuilder.RenameTable(
                name: "LocationDieds",
                newName: "LocationDied");

            migrationBuilder.RenameTable(
                name: "LocationDieadDetails",
                newName: "LocationDieadDetail");

            migrationBuilder.RenameTable(
                name: "idGiaPhas",
                newName: "idGiaPha");

            migrationBuilder.RenameTable(
                name: "Familys",
                newName: "Family");

            migrationBuilder.RenameTable(
                name: "admins",
                newName: "admin");

            migrationBuilder.RenameTable(
                name: "AdminFamilys",
                newName: "AdminFamily");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManagerIDGiaPha",
                table: "ManagerIDGiaPha",
                column: "idManagerIDGiaPha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationHome",
                table: "LocationHome",
                column: "idLocationHome");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationDied",
                table: "LocationDied",
                column: "idLocationDied");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationDieadDetail",
                table: "LocationDieadDetail",
                column: "idLocationDiedDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_idGiaPha",
                table: "idGiaPha",
                column: "idGiaPha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Family",
                table: "Family",
                column: "idFamily");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admin",
                table: "admin",
                column: "idAdmin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminFamily",
                table: "AdminFamily",
                column: "idAdminFamily");

            migrationBuilder.CreateTable(
                name: "ClientDeail",
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
                    idLocationDied = table.Column<long>(type: "bigint", nullable: false),
                    idLocationHome = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeail", x => x.idClientDetail);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDeail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ManagerIDGiaPha",
                table: "ManagerIDGiaPha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationHome",
                table: "LocationHome");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationDied",
                table: "LocationDied");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationDieadDetail",
                table: "LocationDieadDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_idGiaPha",
                table: "idGiaPha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Family",
                table: "Family");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminFamily",
                table: "AdminFamily");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admin",
                table: "admin");

            migrationBuilder.RenameTable(
                name: "ManagerIDGiaPha",
                newName: "ManagerIDGiaPhas");

            migrationBuilder.RenameTable(
                name: "LocationHome",
                newName: "LocationHomes");

            migrationBuilder.RenameTable(
                name: "LocationDied",
                newName: "LocationDieds");

            migrationBuilder.RenameTable(
                name: "LocationDieadDetail",
                newName: "LocationDieadDetails");

            migrationBuilder.RenameTable(
                name: "idGiaPha",
                newName: "idGiaPhas");

            migrationBuilder.RenameTable(
                name: "Family",
                newName: "Familys");

            migrationBuilder.RenameTable(
                name: "AdminFamily",
                newName: "AdminFamilys");

            migrationBuilder.RenameTable(
                name: "admin",
                newName: "admins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManagerIDGiaPhas",
                table: "ManagerIDGiaPhas",
                column: "idManagerIDGiaPha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationHomes",
                table: "LocationHomes",
                column: "idLocationHome");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationDieds",
                table: "LocationDieds",
                column: "idLocationDied");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationDieadDetails",
                table: "LocationDieadDetails",
                column: "idLocationDiedDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_idGiaPhas",
                table: "idGiaPhas",
                column: "idGiaPha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Familys",
                table: "Familys",
                column: "idFamily");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminFamilys",
                table: "AdminFamilys",
                column: "idAdminFamily");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admins",
                table: "admins",
                column: "idAdmin");

            migrationBuilder.CreateTable(
                name: "ClientDeails",
                columns: table => new
                {
                    idClientDetail = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diedDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idFamily = table.Column<long>(type: "bigint", nullable: false),
                    idGiaPhaChild = table.Column<long>(type: "bigint", nullable: false),
                    idLocationDied = table.Column<long>(type: "bigint", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDeails", x => x.idClientDetail);
                });
        }
    }
}
