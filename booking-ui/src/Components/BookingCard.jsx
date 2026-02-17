import Button from "./Button.jsx"

function BookingCard({booking}){
    const cardRowStyle = {
        display: "flex",
        
        alignItems: "center",
        padding: "15px",
        borderBottom: "1px solid #ccc",
        borderTop: "none", 
        marginLeft: "15%",
        marginRight: "15%"      
    };

    const columnStyle = { flex: 0.5, textAlign: "left" };
    return(
        
        <div style={cardRowStyle}>
        
            <span style={{ flex: 0.5}}>{booking.id}</span>
            <span style={columnStyle}>{booking.user}</span>
            <span style={columnStyle}> {booking.room}</span>
            <span style={{ flex: 1, textAlign:"left"}}>{booking.startTime}</span>
            <span style={{ flex: 1, textAlign:"left"}}> {booking.endTime} </span>
            <span style={columnStyle}><Button label = "Cancel" /></span> 
            
        
        </div>
    );
}
export default BookingCard;