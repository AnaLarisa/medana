using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medana.API.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Patients",
            columns: table => new
            {
                CNP = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Patients", x => x.CNP);
            });

        migrationBuilder.CreateTable(
            name: "InsuranceInformation",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                InsuranceProvider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                InsurancePolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CNP = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InsuranceInformation", x => x.Id);
                table.ForeignKey(
                    name: "FK_InsuranceInformation_Patients_CNP",
                    column: x => x.CNP,
                    principalTable: "Patients",
                    principalColumn: "CNP",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "MedicalHistory",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                SurgicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImmunizationHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MedicalConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                FamilyMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CNP = table.Column<string>(type: "nvarchar(450)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                table.ForeignKey(
                    name: "FK_MedicalHistory_Patients_CNP",
                    column: x => x.CNP,
                    principalTable: "Patients",
                    principalColumn: "CNP",
                    onDelete: ReferentialAction.Cascade);
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
                CNP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                table.ForeignKey(
                    name: "FK_PersonalInformation_Patients_CNP",
                    column: x => x.CNP,
                    principalTable: "Patients",
                    principalColumn: "CNP",
                    onDelete: ReferentialAction.Cascade);
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
                PatientCNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

        migrationBuilder.CreateIndex(
            name: "IX_Consultations_MedicalHistoryId",
            table: "Consultations",
            column: "MedicalHistoryId");

        migrationBuilder.CreateIndex(
            name: "IX_InsuranceInformation_CNP",
            table: "InsuranceInformation",
            column: "CNP",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_MedicalHistory_CNP",
            table: "MedicalHistory",
            column: "CNP",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Medication_MedicalHistoryId",
            table: "Medication",
            column: "MedicalHistoryId");

        migrationBuilder.CreateIndex(
            name: "IX_PersonalInformation_CNP",
            table: "PersonalInformation",
            column: "CNP",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Consultations");

        migrationBuilder.DropTable(
            name: "InsuranceInformation");

        migrationBuilder.DropTable(
            name: "Medication");

        migrationBuilder.DropTable(
            name: "PersonalInformation");

        migrationBuilder.DropTable(
            name: "MedicalHistory");

        migrationBuilder.DropTable(
            name: "Patients");
    }
}
