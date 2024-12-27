using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileMarks.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecializationAndCategoryToDentist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Dentist",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Dentist",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Dentist");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Dentist");
        }
    }
}
