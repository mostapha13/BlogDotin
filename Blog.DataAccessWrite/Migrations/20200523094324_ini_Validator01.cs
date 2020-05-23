using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataAccessCommand.Migrations
{
    public partial class ini_Validator01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Subjects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Authors",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Authors");
        }
    }
}
