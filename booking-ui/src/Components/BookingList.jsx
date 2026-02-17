import BookingCard from "./BookingCard";
import { mockData } from "./mockData";

function BookingList(){
    return(
        <div>
            <h2>Current Bookings</h2>
            {mockData.map(r=> <BookingCard key={r.id} booking= {r}/>)}
            <p>Displaying 1-{mockData.length} out of {mockData.length}</p>
        </div>

    );
}

export default BookingList;