import { useState, useEffect } from 'react'
import './App.css'
import Header from './Components/Header/Header'
import Footer from './Components/Footer/Footer'
import BookingList from './Components/BookingList'
import BookingForm from './Components/BookingForm/BookingForm'
import { initialBookings } from './Data/mockData'

function App() {
  const [bookings, setBookings] = useState(() => {
    const savedBookings = localStorage.getItem('myBookings');
    return savedBookings ? JSON.parse(savedBookings) : initialBookings;
  });

  useEffect(() => {
    localStorage.setItem('myBookings', JSON.stringify(bookings));
  }, [bookings]);

  const addBooking = (newBooking) => {
    setBookings([...bookings, newBooking]);
  };

  return (
    <div>
      <Header />
      <div>
        <h2>Total bookings: {bookings.length}</h2>
      </div>
      <BookingForm onAdd={addBooking} />
      <BookingList bookings={bookings} />
      <Footer />
    </div>
  );
}

export default App;
