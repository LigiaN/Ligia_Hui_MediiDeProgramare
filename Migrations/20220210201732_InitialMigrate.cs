using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligia_Hui.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departament",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dep = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Magazin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    mag = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepMag",
                columns: table => new
                {
                    DepMagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdusID = table.Column<int>(nullable: false),
                    DepartamentID = table.Column<int>(nullable: false),
                    MagazinID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepMag", x => x.DepMagID);
                    table.ForeignKey(
                        name: "FK_DepMag_Departament_DepartamentID",
                        column: x => x.DepartamentID,
                        principalTable: "Departament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepMag_Magazin_MagazinID",
                        column: x => x.MagazinID,
                        principalTable: "Magazin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numeangajat = table.Column<string>(maxLength: 30, nullable: false),
                    post = table.Column<string>(maxLength: 30, nullable: false),
                    DepartamentID = table.Column<int>(nullable: false),
                    MagazinID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produs_Departament_DepartamentID",
                        column: x => x.DepartamentID,
                        principalTable: "Departament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produs_Magazin_MagazinID",
                        column: x => x.MagazinID,
                        principalTable: "Magazin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepMag_DepartamentID",
                table: "DepMag",
                column: "DepartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_DepMag_MagazinID",
                table: "DepMag",
                column: "MagazinID");

            migrationBuilder.CreateIndex(
                name: "IX_Produs_DepartamentID",
                table: "Produs",
                column: "DepartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Produs_MagazinID",
                table: "Produs",
                column: "MagazinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepMag");

            migrationBuilder.DropTable(
                name: "Produs");

            migrationBuilder.DropTable(
                name: "Departament");

            migrationBuilder.DropTable(
                name: "Magazin");
        }
    }
}
