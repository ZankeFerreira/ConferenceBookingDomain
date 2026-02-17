import { useState } from "react";
import Button from "../Button";
import "./BookingForm.css";

function BookingForm({ onAdd }) {
  const [user, setUser] = useState("");
  const [room, setRoom] = useState("Room A");
  const [startTime, setStartTime] = useState("");
  const [endTime, setEndTime] = useState("");

  const handleBooking = (r) => {
    r.preventDefault();
     if (!user || !startTime || !endTime) {
            alert("Please fill in all fields!");
            return;
        }

    
    const newBooking = {
      id: Date.now(),
      user: user,
      room: room,
      startTime: startTime,
      endTime: endTime,

      
    };
    onAdd(newBooking);
    setUser ("");
    setStartTime ("");
    setEndTime ("");


    
  };

  return (
    
    <form onSubmit={handleBooking} className = "form">
      <h2 style = {{margin: 0}}>Make a booking</h2>
      <input
        type="text"
        value={user}
        onChange={(r) => setUser(r.target.value)}
        placeholder="e.g Admin"
      />
      <select value={room} onChange={(e) => setRoom(e.target.value)}>
        <option>Room A</option>
        <option>Room B</option>
        <option>Room C</option>
        <option>Room D</option>
        <option>Room E</option>
      </select>
      <input
        type="datetime-local"
        value={startTime}
        onChange={(r) => setStartTime(r.target.value)}
        placeholder="e.g 2026-06-01 10:00:00"
      />
      <input
        type="datetime-local"
        value={endTime}
        onChange={(r) => setEndTime(r.target.value)}
        placeholder="e.g 2026-06-01 20:00:00"
      />

      <Button label="Book" type = "submit" />
      
    </form>
  );
}
export default BookingForm;
