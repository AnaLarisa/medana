using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medana.API.Migrations;

/// <inheritdoc />
public partial class ModifiedMedication : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Medication_MedicalHistory_MedicalHistoryId",
            table: "Medication");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Medication",
            table: "Medication");

        migrationBuilder.RenameTable(
            name: "Medication",
            newName: "Medications");

        migrationBuilder.RenameIndex(
            name: "IX_Medication_MedicalHistoryId",
            table: "Medications",
            newName: "IX_Medications_MedicalHistoryId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Medications",
            table: "Medications",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Medications_MedicalHistory_MedicalHistoryId",
            table: "Medications",
            column: "MedicalHistoryId",
            principalTable: "MedicalHistory",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Medications_MedicalHistory_MedicalHistoryId",
            table: "Medications");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Medications",
            table: "Medications");

        migrationBuilder.RenameTable(
            name: "Medications",
            newName: "Medication");

        migrationBuilder.RenameIndex(
            name: "IX_Medications_MedicalHistoryId",
            table: "Medication",
            newName: "IX_Medication_MedicalHistoryId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Medication",
            table: "Medication",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Medication_MedicalHistory_MedicalHistoryId",
            table: "Medication",
            column: "MedicalHistoryId",
            principalTable: "MedicalHistory",
            principalColumn: "Id");
    }
}
