using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class managerListMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ManagerName",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ManagerName = table.Column<string>(nullable: false),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ManagerName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ManagerName",
                table: "Projects",
                column: "ManagerName");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Managers_ManagerName",
                table: "Projects",
                column: "ManagerName",
                principalTable: "Managers",
                principalColumn: "ManagerName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Managers_ManagerName",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ManagerName",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
