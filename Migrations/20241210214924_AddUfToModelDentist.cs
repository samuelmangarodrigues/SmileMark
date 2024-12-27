using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileMarks.Migrations
{
    /// <inheritdoc />
    public partial class AddUfToModelDentist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Dentist",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Dentist");
        }
    }
}
