import { useState, useEffect, useCallback } from "react";
import "./App.css";
import Header from "./Components/Header/Header";
import Footer from "./Components/Footer/Footer";
import BookingList from "./Components/BookingList";
import BookingForm from "./Components/BookingForm/BookingForm";
import { fetchAllBookings } from "./API/bookingService";
import toast, {Toaster} from "react-hot-toast";

function App() {
  const [bookings, setBookings] = useState([]);
  const [filteredBookings, setFileterBookings] = useState([]);
  const [selectedRoom, setSelectedRoom] = useState("All");
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const getBookings = useCallback(async () => {
    setIsLoading(true);
    setError(null);

    try {
      const data = await fetchAllBookings();
      setBookings(data);
      toast.success("Data Sync Successful!")
      
    } catch (error) {
      setError("Failed to load bookings");
    } finally {
      setIsLoading(false);
    }
  }, []);

  useEffect(() => {
    getBookings();
  }, [getBookings]);

  useEffect(() => {
    localStorage.setItem("myBookings", JSON.stringify(bookings));
  }, [bookings]);

  useEffect(() => {
    if(selectedRoom === "All"){
      setFileterBookings(bookings);
    }
    else{
      const filtered = bookings.filter(r => r.room === selectedRoom);
      setFileterBookings(filtered);
    }
  }, [bookings, selectedRoom]);

  const addBooking = (newBooking) => {
    setBookings([...bookings, newBooking]);
  };

  return (
    <div>
      <Header />
    
      {isLoading && <div className = "spinner"> Loading bookings...</div>}

      {error && (
        
        <div>
        <p> {error}</p>
        <button onClick =  {getBookings}>Retry</button>
        </div>
      )

      }

      {!isLoading && !error && (
        <>
          <Toaster position="top-right" reverseOrder={false} />
          <div>
            <h2>Total bookings: {bookings.length}</h2>
          </div>
          <BookingForm onAdd={addBooking} />
          <div>
              <label>Filter by Room: </label>
        <select value={selectedRoom} onChange={(e) => setSelectedRoom(e.target.value)}>
          <option value="All">All Rooms</option>
          <option value="Room A">Room A</option>
          <option value="Room B">Room B</option>
          <option value="Room C">Room C</option>
          <option value="Room D">Room D</option>
          <option value="Room E">Room E</option>
        </select>
          </div>
          <BookingList bookings={filteredBookings} />
        </>
      )}

      <Footer />
    </div>
  );
}

export default App;
