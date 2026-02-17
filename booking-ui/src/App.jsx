import { useState } from 'react'
import './App.css'
import Header from './Components/Header'
import Footer from './Components/Footer'
import BookingList from './Components/BookingList'

function App() {
    return (
    <div>
      <Header/>
      <BookingList/>
      <Footer/>
    </div>
  );
}

export default App;
