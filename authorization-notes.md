# Authorization

## Why authorization should not live in controllers
The controllers are reserved for handling endpoints, the business logic should be kept seperate. 
Controller should remain thin and  also not be over cluttered, the authorization would inlude unecassary if state and try-catches. 
It is also easier to test authentication with running the http requests everytime. 

## Why roles belong in tokens
Roles are included under claims in the token service class. This helps to improve performance because then the datatbase won't need to be queried after every request as the permissions is stored in the token.

## How this design prepares the system
### Database relationships
By using the User ID from the token, we can link every booking to a specific user in the database. This creates a clear connection between the AspNetUsers table and our Bookings table.

### Booking ownership
Since the token contains the User ID, the system can compare the person logged in to the person who created the booking. This means the user can only delete the booking they made.

### Frontend integration
The frontend can decode the token to see the user's role and ID. This makes it easy to show or hide buttons (like the "Delete" button) based on whether the user is an Admin or a regular Employee.
