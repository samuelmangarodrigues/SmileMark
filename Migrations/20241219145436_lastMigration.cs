using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmileMarks.Migrations
{
    /// <inheritdoc />
    public partial class lastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Patient_Email",
                table: "Patient",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dentist_Cro",
                table: "Dentist",
                column: "Cro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dentist_Email",
                table: "Dentist",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patient_Email",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Dentist_Cro",
                table: "Dentist");

            migrationBuilder.DropIndex(
                name: "IX_Dentist_Email",
                table: "Dentist");
        }
    }
}
