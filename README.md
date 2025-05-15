# 🚗 Car Rental Application

![Ekran görüntüsü 2025-03-09 223925](https://github.com/user-attachments/assets/ac5a1a8b-8443-4f3c-9ba6-3c2b10cec159)

---

## Project Overview

This Car Rental Application is a Windows Forms desktop app written in C# with a local Microsoft SQL Server backend. It enables rental agencies to manage vehicle inventory, customer profiles, and reservations through an intuitive GUI, complete with stored procedures, triggers, and reporting.

---

## ER Diagram & DB Schema

The logical structure is captured by an ER diagram and implemented as a relational schema:

* **Entities**: `Cars`, `Customers`, `Reservations`, `Payments`, etc.
* **Keys & Relationships**:

  * `CarID` (PK) in `Cars`
  * `CustomerID` (PK) in `Customers`
  * `ReservationID` (PK) in `Reservations` with FKs to `Cars` and `Customers`

---

## Graphical User Interface

The Windows Forms UI provides:

* **Vehicle Tab**: add/edit/search inventory
* **Customer Tab**: manage profiles
* **Reservation Tab**: book or cancel rentals
* **Reports**: daily/weekly summaries

---

## Installation & Running

1. **Prerequisites**

   * Windows 10+
   * .NET Framework 4.8
   * SQL Server Express

2. **Clone & Build**

   ```
   git clone https://github.com/your-username/CarRentalApp.git
   cd CarRentalApp
   ```

   Open `CarRentalApp.sln` in Visual Studio, restore NuGet packages and build.

3. **Configure DB**

   * Run the SQL scripts in SSMS to create `CarRentalDB`.
   * In `App.config`, set your `<connectionStrings>`:

   ```xml
   <connectionStrings>
     <add name="CarRentalDb"
          connectionString="Server=.\SQLEXPRESS;Database=CarRentalDB;Trusted_Connection=True;"
          providerName="System.Data.SqlClient"/>
   </connectionStrings>
   ```

4. **Launch**
   Press **F5** (Debug) or **Ctrl+F5** to start the application.

---

## Contributors

* [@canomercik](https://github.com/canomercik) – C# UI design & backend integration
* [@Draster2k](https://github.com/Draster2k) – Database design & ER modeling
* [@iremsilalp](https://github.com/iremsilalp) – Stored procedures & triggers

---

## License

Released under the **MIT License**. See [LICENSE](LICENSE) for full text.
