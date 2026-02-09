# Persistence
## Why in-memory storage is not suitable for production
In-memory storage is temporary and resets every time the server restarts, wiping all user data.
## What DbContext represents
DbContext is the connection between the code and the database. It is a way for us to access and query to the database.
## How EF Core fits into your architecture
EF Core uses the IBookingStore interface and not the BookingManager, in order to keep the manager only for logic and not cluttering it with database code.
## How this prepares your system for:
### Relationships
By using a real database, we can use Foreign Keys to link Bookings to specific Rooms.
### Ownership
The database stores the CreatedBy ID for every record. The system can then verify the person logged in against the owner in the database to ensure users only modify their own bookings.
### Frontend usage
The frontend can use the UI more easily as the database can deal with the ID, while the user can just click on the bookings.
