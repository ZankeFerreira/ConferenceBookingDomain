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

- BookingLogic.cs: Handles booking rules such as availability and overlapping bookings.


---

## ⚙️ Installation

To access the documents on your local computer:
1. Use your prefered IDE
2. Copy this text into the terminal: 
    ```git clone "https://github.com/ZankeFerreira/ConferenceBookingDomain.git"```
3. Open the folder in the IDE


---

## 🚀 Usage

This repository is currently used for:
- Contributing to the Conference Room Booking application using C#


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
