using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medana.API.Migrations
{
    /// <inheritdoc />
    public partial class EliminatedAgeFromPersonalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "PersonalInformation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "PersonalInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
