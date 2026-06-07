## Overview

This is a Windows Forms desktop application designed to track personal health metrics such as Body Mass Index (BMI) and Ponderal Index (PI).

The application allows users to manage multiple people, record historical data (weight, height, date), and automatically calculate health indicators with validation and feedback.

---

## Features

* Add and manage multiple persons
* Record weight and height entries with date tracking
* Automatic BMI and PI calculation
* Health category classification (underweight, normal, etc.)
* Weight difference suggestions based on ideal values
* Data stored in a local SQL Server database
* Input validation and error handling
* Dynamic UI resizing for better usability

---

##  Technologies Used

* C# (.NET Framework)
* Windows Forms (WinForms)
* SQL Server (Local Database)
* ADO.NET (SqlConnection, SqlCommand)
* Object-Oriented Programming (OOP)

---

##  Key Concepts Implemented

* Separation of concerns (UI / logic / database)
* Data validation and exception handling
* Parameterized SQL queries (protection against SQL injection)
* Basic domain modeling (Person, BMI/PI calculators)
* Event-driven programming (WinForms)

---

##  Example Workflow

1. Add a new person
2. Select the person from the dropdown
3. Enter weight and height
4. Calculate BMI and PI
5. Save the record
6. View historical data in the table

---

##  Future Improvements

* Add calorie and protein tracking
* Add charts for BMI evolution over time
* Improve UI/UX design
* Export data (CSV or PDF)
* Add search and filtering
* Migrate to a more modern architecture (e.g., WPF or Web API)

---

##  Screenshots
<img width="1920" height="1080" alt="Captură de ecran 2026-04-14 191946" src="https://github.com/user-attachments/assets/cbae01c5-23ec-4b87-8a39-e6b3dacac252" />


<img width="1920" height="1080" alt="Captură de ecran 2026-04-14 191827" src="https://github.com/user-attachments/assets/db7ea7cb-b87e-45b3-bae1-161f375b8539" />


##  How to Run

1. Clone the repository
2. Open the solution in Visual Studio
3. Configure your SQL Server connection string
4. Run the application

---


##  Author

Boboc Alexandru Ioan

##  Notes

This project was built as a personal learning project to practice desktop development, database interaction, and clean code principles.

---
