# Computer-Science-Academy

A Windows Forms desktop app for a computer science academy library: users log in, then manage the book catalog (add, update, delete and search books) inside an MDI main window. Data is stored in a SQL Server LocalDB database accessed with ADO.NET.

## Tech Stack

- .NET Core 3.1 (`netcoreapp3.1`), Windows Forms
- ADO.NET with `System.Data.SqlClient` 4.8
- SQL Server LocalDB (`.mdf` file attached at runtime)

## Project Structure

The solution `DekstopApp/DekstopApp.sln` contains one project, `DekstopApp`:

| File | Description |
| --- | --- |
| `Form1.cs` | Login form. Checks the user name and password against the `RegistrationInfo` table and opens the main window. |
| `MDIParent1.cs` | MDI main window with window layout commands (cascade, tile, arrange, close all) and a menu entry that opens the book form. |
| `Library.cs` | Book management form: lists books in a grid, inserts, updates and deletes books, and searches by book name, subject or author. |

## Features

- Login against the `RegistrationInfo` table.
- Book catalog stored in the `BookInfo` table (`ISBN`, `Book_Name`, `Subject`, `Author`, `Price`, `quantity`, `publisher`, `Branch`).
- Add, update (by ISBN) and delete (by ISBN) books.
- Live search while typing in the search box.
- MDI window layout options.

## Getting Started

### Prerequisites

- Windows
- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1) (or Visual Studio 2019 with the .NET desktop workload)
- SQL Server Express LocalDB

### Database

The forms connect to a LocalDB database file with this connection string (in `Form1.cs` and `Library.cs`):

```
Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin lenovo\Documents\LibraryProject.mdf;Integrated Security=True;Connect Timeout=30
```

Create a `LibraryProject.mdf` database with the `RegistrationInfo` and `BookInfo` tables, then change `AttachDbFilename` in both files to its location on your machine.

### Run

Open `DekstopApp/DekstopApp.sln` in Visual Studio and start the project, or:

```bash
cd DekstopApp
dotnet run
```

### Known limitations

- The application entry point (`Program.cs`) and the registration form (`Registration_Form`) used by the login screen are not included in this repository, so they must be added before the project builds.
- SQL queries are built by string concatenation; use parameterized queries before using this with real data.
