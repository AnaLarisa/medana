using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medana.API.Migrations;

/// <inheritdoc />
public partial class ModifiedMedication2 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Dosage",
            table: "Medications",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "Frequency",
            table: "Medications",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            name: "MedicationName",
            table: "Medications",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Dosage",
            table: "Medications");

        migrationBuilder.DropColumn(
            name: "Frequency",
            table: "Medications");

        migrationBuilder.DropColumn(
            name: "MedicationName",
            table: "Medications");
    }
}
