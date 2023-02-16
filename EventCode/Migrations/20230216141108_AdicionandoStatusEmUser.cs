using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCode.Migrations
{
    public partial class AdicionandoStatusEmUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "tb_users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tb_users");
        }
    }
}
