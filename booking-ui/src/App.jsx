import { useState, useEffect, useCallback } from "react";
import "./App.css";
import Header from "./Components/Header/Header";
import Footer from "./Components/Footer/Footer";
import BookingList from "./Components/BookingList";
import BookingForm from "./Components/BookingForm/BookingForm";
import { initialBookings } from "./Data/mockData";
import { fetchAllBookings } from "./API/bookingService";

function App() {
  const [bookings, setBookings] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);

  const getBookings = useCallback(async () => {
    setIsLoading(true);
    setError(null);

    try {
      const [data] = await Promise.all(
        [
            fetchAllBookings(),
            new Promise ((resolve) => setTimeout(resolve, 1000))
      
        ]
      );
        
      setBookings(data);
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
          <div>
            <h2>Total bookings: {bookings.length}</h2>
          </div>
          <BookingForm onAdd={addBooking} />
          <BookingList bookings={bookings} />
        </>
      )}

      <Footer />
    </div>
  );
}

export default App;
