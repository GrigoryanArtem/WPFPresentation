using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddDoubleField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desription",
                table: "Something");

            migrationBuilder.AlterColumn<int>(
                name: "IntField",
                table: "Something",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Something",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DoubleField",
                table: "Something",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Something");

            migrationBuilder.DropColumn(
                name: "DoubleField",
                table: "Something");

            migrationBuilder.AlterColumn<string>(
                name: "IntField",
                table: "Something",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Desription",
                table: "Something",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
