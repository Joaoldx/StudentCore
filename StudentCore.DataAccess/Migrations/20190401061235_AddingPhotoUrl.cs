using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentCore.DataAccess.Migrations
{
    public partial class AddingPhotoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Students");
        }
    }
}
