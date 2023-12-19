# Doctor-Patient Management Web Application

Welcome to the Doctor-Patient Management Web Application, a .NET 8 web application with two layers: API and Web. This application is built with Razor Pages and utilizes an Azure SQL Database. It is designed to assist doctors in efficiently managing their patients, allowing them to create new patient records, visualize a list of their patients, create medical prescriptions, and remove patients when they relocate to another village or city.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Azure SQL Database](https://azure.microsoft.com/en-us/services/sql-database/)
- [Azure SQL Server](https://azure.microsoft.com/en-us/services/sql-database/)

### Configuration

1. Clone the repository:

   ```
   git clone https://github.com/yourusername/doctor-patient-management.git
   ```

2. Go to the root directory:

   ```
   cd Medana
   ```

3. Update the connection string in the `launchSettings.json` file with your Azure SQL Database credentials:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=<your_server>;Database=<your_database>;User Id=<your_user>;Password=<your_password>;"
   }
   ```

4. Run the application:

   ```
   dotnet run
   ```

5. Open your web browser and navigate to `https://localhost:44365` to access the application. /// to be continued

## Project Structure

The solution is organized into two layers:

- **API Layer:** Contains the backend logic for handling data interactions and business logic.
- **Web Layer:** Utilizes Razor Pages to provide a user interface and interact with the API.

```
doctor-patient-management
│
├── DoctorPatientManagement.Api      # API Layer
│   └── ...                          # API source code
│
└── DoctorPatientManagement.Web      # Web Layer
    └── ...                          # Web source code
```

## Features

### 1. Create New Patient

Doctors can easily create new patient records by providing relevant information such as name, date of birth, contact details, etc. This information is securely stored in the Azure SQL Database.

### 2. Visualize Patient List

Doctors can view a list of their patients, facilitating quick access to patient details and medical history. The application ensures a personalized and organized overview of the doctor's patient base.

### 3. Create Medical Prescriptions

Doctors can create and manage medical prescriptions for their patients. These prescriptions are automatically added to the patient's medical history, providing a comprehensive record of their treatment.

### 4. Remove Patients

When patients relocate to another village or city, doctors can easily remove their records from the database, ensuring an up-to-date and accurate patient list.

## Technologies Used

- .NET 8
- Razor Pages
- Azure SQL Database

## Acknowledgments

- Special thanks to the [.NET](https://dotnet.microsoft.com/) and [Azure](https://azure.microsoft.com/) communities for their valuable resources and documentation.

Feel free to contribute, report issues, or suggest improvements. Happy coding!
```
