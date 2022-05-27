using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSS_Assignment_Ebube.Migrations
{
    public partial class FV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Players");
        }
    }
}
