# 🏢 Conference Room Booking System

## 👌 Project Overview   

This project is for a **Conference Room Booking System** that allows employees to book and cancel rooms, for administators to access overall data and resolve conficts, and for rooms to be marked as under maintenance.   
This system can be implemented at any business with a conference room that needs an efficient and easy way to navigate a scheduling application.

---

## 📌 Purpose of This Repository

This repository is used for:
- Version control
- Collaboration between team members
- Creating and reviewing Pull Requests
- Contributing to the booking application


---

Table of Contents
- [Repository Contents](#-repository-contents)
- [Installation](#️-installation)
- [Usage](#-usage)
- [New Features](#-new-features)
- [Contributing](#-contributing)
- [Developer Onboarding](#-developer-onboarding-in-progress)
- [System Context](#️-system-context)
- [License](#-licence)

---

## 🗂 Repository Contents

- Enums.cs: Contains all enums used in the project (room status, booking status, etc.)

- ConferenceRoom.cs: Defines a conference room and its details, such as room number, capacity, and status.

- Booking.cs: Contains the logic and data for room bookings, including start time, end time, and booking status.

- BookingRequest.cs: Represents a request to book a room.

- BookingManager.cs: Handles booking rules such as availability and overlapping bookings.
- BookingDbContext.cs: Entity Framework configuration and Data Seeding logic.


---

## ⚙️ Installation

To access the documents on your local computer:
1. Use your prefered IDE
2. Copy this text into the terminal: 
    ```git clone "https://github.com/ZankeFerreira/ConferenceBookingDomain.git"```
3. Open the folder in the IDE

---
## 🛡️ Database & Integrity

### Entity Relationship
- Booking & User: Each booking is linked to an ApplicationUser via a Foreign Key (UserId).
- Booking & Room: Each booking is linked to a ConferenceRoom via a Foreign Key (RoomId).

### Soft Deletes
- Entity: Booking
- Reasoning: We use soft deletes for bookings to maintain history of bookings. Instead of physically removing a record, we set Status = Cancelled and record a CancelledAt timestamp.

### Data Integrity
- Foreign Keys: Enforced at the database level using SQLite constraints.
- Referential Integrity: Implemented using DeleteBehavior.Restrict. This prevents the deletion of a User or Room if they have active booking records associated with them.
- Navigation Properties: Used for joining of tables 
---

## 🚀 API Usage

The API provides comprehensive management of bookings and room states. You can test these via Postman.
### Filtering and sorting
- By Location: GET api/bookings/location?location=Bloemfontein
- By Date Range: GET api/bookings/dates?Start=2026-02-11T09:00:00&End=2026-06-11T17:00:00
- By Rooms: GET api/bookings/rooms?room=Room A
- By Room Status: GET api/bookings/status?status=Available

### Pagination
To handle large datasets efficiently, list endpoints support the following query parameters:
- page: The page number to retrieve (Default: 1).
- pageSize: Number of records per page (Default: 10).
- Total pages: Responses include totalCount to help frontend components calculate total pages.

### Perfomance Considerations

- AsNoTracking: Read-only queries (like Search and List) use .AsNoTracking() to reduce memory overhead and bypass the Entity Framework change tracker.
- Server-Side Filtering: All Where, Skip, and Take operations are performed at the database level (SQL) rather than in memory.

---
## 💻 How to run the API
1. Navigate to the root directory of the API project in your terminal (where the .csproj file is located).
2. Run the application using:
```
dotnet run
```
3. The API will typically start on http://localhost:5200. You can test the endpoints using tools like Postman or via the Swagger UI available at http://localhost:5200/swagger.

### Example
You can test the API using a POST request to create a new booking.
- Endpoint: POST http://localhost:5200/api/bookings
- Request Body (JSON):
```
{
    "room": {
        "id": 1,
        "roomNumber": "Room A",
        "capacity": 15,
        "status": 0
    },
    "startTime": "2026-06-01T10:00:00",
    "endTime": "2026-06-01T11:00:00"
}
```
- A successfull respons (HTTP Status 200 OK) will display

---
## Schema Reasoning
- Some fields are nullable:
    * CancelledAt (Nullable): This is nullable because a booking is not cancelled when it is first created. It only receives a timestamp if the user explicitly cancels it.
- Certain defaults are chosen
    * CreatedAt: Defaults to DateTime.UtcNow to provide an immutable audit trail of when the record was actually entered
    * BookingStatus: Defaults to Pending as it would need to check the rooms availablity to change to confirmed
---
## 🆕 New Features

- Conflict Checking: Prevents double bookings for the same room and time

- Cancel Bookings: Employees can cancel upcoming bookings

- Booking History: Save and load booking history to a JSON file

- Maintenance Mode: Rooms can be marked unavailable for maintenance

- Visitor Bookings: Receptionists can book rooms for visitors

- Input Validation: Ensures users cannot enter invalid or empty dates/times

---

## 🤝 Contributing

Changes to this repository are made using **Pull Requests**.

Contributors should:
- Create a feature or documentation branch
- Submit changes via a Pull Request
- Clearly describe the intent of the change using the pull request template

---

## 👓 Developer Onboarding (In Progress)

- So far the logic of the application will be coded in C#
- The focus is on domain logic and business rules
- More documentation will be added as the project grows

---
## ⚙️ System Context

The conference Booking System is a conceptual system intended to manage:
- Room booking - allows employees to book room according to their prefernce
- Booking cancelation - employees can cancel an existing reservation
- Conflict resolution - the administator can resolve booking conflicts from their dashboard
- Admnistration interface - allows the administrator to have an overview of the current bookings and access utilisation data 
- Maintenance access - the rooms can be marked for maintenance and the appropriate adjustments will be made
- Visitor's booking - the receptionist can make booking for clients


Implementation details will be added in later modules


## 👜 LICENCE
This project is licensed under the MIT License.

---
