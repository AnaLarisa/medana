﻿// <auto-generated />
using System;
using Medana.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Medana.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240211230135_ModifiedMedication2")]
    partial class ModifiedMedication2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Medana.API.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BloodPressure")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConsultationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HeartRate")
                        .HasColumnType("int");

                    b.Property<int?>("MedicalHistoryId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientCNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prescriptions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RespiratoryRate")
                        .HasColumnType("int");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<string>("TreatmentPlan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Medana.API.Entities.InsuranceInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InsurancePolicyNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CNP")
                        .IsUnique();

                    b.ToTable("InsuranceInformation");
                });

            modelBuilder.Entity("Medana.API.Entities.MedicalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AllergiesJson")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Allergies");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FamilyMedicalHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImmunizationHistoryJson")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImmunizationHistory");

                    b.Property<string>("MedicalConditionsJson")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MedicalConditions");

                    b.Property<string>("SurgicalHistoryJson")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SurgicalHistory");

                    b.HasKey("Id");

                    b.HasIndex("CNP")
                        .IsUnique();

                    b.ToTable("MedicalHistory");
                });

            modelBuilder.Entity("Medana.API.Entities.Medication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MedicalHistoryId")
                        .HasColumnType("int");

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("Medana.API.Entities.Patient", b =>
                {
                    b.Property<string>("CNP")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CNP");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Medana.API.Entities.PersonalInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CNP")
                        .IsUnique();

                    b.ToTable("PersonalInformation");
                });

            modelBuilder.Entity("Medana.API.Entities.Consultation", b =>
                {
                    b.HasOne("Medana.API.Entities.MedicalHistory", null)
                        .WithMany("Consultations")
                        .HasForeignKey("MedicalHistoryId");
                });

            modelBuilder.Entity("Medana.API.Entities.InsuranceInformation", b =>
                {
                    b.HasOne("Medana.API.Entities.Patient", "Patient")
                        .WithOne("InsuranceInformation")
                        .HasForeignKey("Medana.API.Entities.InsuranceInformation", "CNP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Medana.API.Entities.MedicalHistory", b =>
                {
                    b.HasOne("Medana.API.Entities.Patient", "Patient")
                        .WithOne("MedicalHistory")
                        .HasForeignKey("Medana.API.Entities.MedicalHistory", "CNP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Medana.API.Entities.Medication", b =>
                {
                    b.HasOne("Medana.API.Entities.MedicalHistory", null)
                        .WithMany("MedicationAndDosages")
                        .HasForeignKey("MedicalHistoryId");
                });

            modelBuilder.Entity("Medana.API.Entities.PersonalInformation", b =>
                {
                    b.HasOne("Medana.API.Entities.Patient", "Patient")
                        .WithOne("PersonalInformation")
                        .HasForeignKey("Medana.API.Entities.PersonalInformation", "CNP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Medana.API.Entities.MedicalHistory", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("MedicationAndDosages");
                });

            modelBuilder.Entity("Medana.API.Entities.Patient", b =>
                {
                    b.Navigation("InsuranceInformation")
                        .IsRequired();

                    b.Navigation("MedicalHistory")
                        .IsRequired();

                    b.Navigation("PersonalInformation")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
