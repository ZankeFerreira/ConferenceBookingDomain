import { initialBookings } from '../Data/mockData'

export const fetchAllBookings = () => {
  return new Promise((resolve, reject) => {

    const delay = setTimeout(resolve, Math.random() * (2500 - 500) + 500);
    setTimeout(() => {
      const isError = Math.random() < 0.2;

      if(isError){
        reject(new Error("Failed to fetch bookings. Please try again"));
      }
      else{
        resolve(initialBookings);
      }
    }, delay);

    
  });
  
}