import Button from "./Button.jsx"

function BookingCard({booking}){
    const cardRowStyle = {
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        padding: "15px",
        borderBottom: "1px solid #ccc",
        borderTop: "none", 
        marginLeft: "50px",
        marginRight: "50px"      
    };

    const columnStyle = { flex: 1, textAlign: "left" };
    return(
        
        <div style={cardRowStyle}>
        
            <span style={{ flex: 0.3}}>{booking.id}</span>
            <span style={columnStyle}>{booking.user}</span>
            <span style={columnStyle}> {booking.room}</span>
            <span style={columnStyle}>{booking.startTime}</span>
            <span style={columnStyle}> {booking.endTime} </span>
            <span style={{ flex: 0.4}}><Button label = "Cancel"/></span> 
            
        
        </div>
    );
}
export default BookingCard;