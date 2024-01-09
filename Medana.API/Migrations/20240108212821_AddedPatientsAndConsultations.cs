using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medana.API.Migrations;

/// <inheritdoc />
public partial class AddedPatientsAndConsultations : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MedicalHistory",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MedicalConditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                SurgicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ImmunizationHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FamilyMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MedicalHistory", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "PersonalInformation",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Age = table.Column<int>(type: "int", nullable: false),
                Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PersonalInformation", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Consultations",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ConsultationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Prescriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                BloodPressure = table.Column<int>(type: "int", nullable: false),
                HeartRate = table.Column<int>(type: "int", nullable: false),
                RespiratoryRate = table.Column<int>(type: "int", nullable: false),
                Temperature = table.Column<double>(type: "float", nullable: false),
                MedicalHistoryId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Consultations", x => x.Id);
                table.ForeignKey(
                    name: "FK_Consultations_MedicalHistory_MedicalHistoryId",
                    column: x => x.MedicalHistoryId,
                    principalTable: "MedicalHistory",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Medication",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MedicalHistoryId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Medication", x => x.Id);
                table.ForeignKey(
                    name: "FK_Medication_MedicalHistory_MedicalHistoryId",
                    column: x => x.MedicalHistoryId,
                    principalTable: "MedicalHistory",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PersonalInformationId = table.Column<int>(type: "int", nullable: false),
                MedicalHistoryId = table.Column<int>(type: "int", nullable: false),
                InsuranceInformation_InsurancePolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                InsuranceInformation_InsuranceProvider = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.Id);
                table.ForeignKey(
                    name: "FK_Patients_MedicalHistory_MedicalHistoryId",
                    column: x => x.MedicalHistoryId,
                    principalTable: "MedicalHistory",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Patients_PersonalInformation_PersonalInformationId",
                    column: x => x.PersonalInformationId,
                    principalTable: "PersonalInformation",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Consultations_MedicalHistoryId",
            table: "Consultations",
            column: "MedicalHistoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Medication_MedicalHistoryId",
            table: "Medication",
            column: "MedicalHistoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Patients_MedicalHistoryId",
            table: "Patients",
            column: "MedicalHistoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Patients_PersonalInformationId",
            table: "Patients",
            column: "PersonalInformationId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Consultations");

        migrationBuilder.DropTable(
            name: "Medication");

        migrationBuilder.DropTable(
            name: "Patients");

        migrationBuilder.DropTable(
            name: "MedicalHistory");

        migrationBuilder.DropTable(
            name: "PersonalInformation");
    }
}
