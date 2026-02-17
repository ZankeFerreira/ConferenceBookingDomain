import BookingCard from "./BookingCard";
import { mockData } from "../Data/mockData";

function BookingList(){
    const rowStyle = {
        display: "flex",
        
        alignItems: "center",
        padding: "15px",
        fontWeight: "bold",        
        marginLeft: "15%",
        marginRight: "15%"   
    }
    const columnStyle = {flex:0.5, textAlign: "left"};
    return(
        <div >
            <h2>Current Bookings</h2>
            <div style = {rowStyle}>
                <span style={{ flex: 0.5, textAlign:"left"}}>Booking ID</span>
                <span style={columnStyle}>User</span>
                <span style={columnStyle}>Room</span>
                <span style={{ flex: 1, textAlign:"left"}}>Start Time</span>
                <span style={{ flex: 1, textAlign:"left"}}>End Time</span>
                <span style={columnStyle}>Action</span>
                
            </div>

            {mockData.map(r=> <BookingCard key={r.id} booking= {r}/>)}
            <p>Displaying 1-{mockData.length} out of {mockData.length}</p>
        </div>
    );
}

export default BookingList;