using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class managerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Managers_ManagerName",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ManagerName",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ID_Manager",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerName",
                table: "Managers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID_Manager",
                table: "Managers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "ID_Manager");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ID_Manager",
                table: "Projects",
                column: "ID_Manager");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Managers_ID_Manager",
                table: "Projects",
                column: "ID_Manager",
                principalTable: "Managers",
                principalColumn: "ID_Manager",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Managers_ID_Manager",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ID_Manager",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "ID_Manager",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ID_Manager",
                table: "Managers");

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerName",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "ManagerName");

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
    }
}
