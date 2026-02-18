import { initialBookings } from '../Data/mockData'

export const fetchAllBookings = (signal) => {
  return new Promise((resolve, reject) => {

    const delay = setTimeout(resolve, Math.random() * (2500 - 500) + 500);
    
      const isError = Math.random() < 0.2;

      const timeoutId = setTimeout(() => {
      if(isError){
        reject(new Error("Failed to fetch bookings. Please try again"));
      }
      else{
        resolve(initialBookings);
      }
    }, delay);

    signal?.addEventListener('abort', () => {
      clearTimeout(timeoutId);
      reject(new Error("Aborted"));
    });

    
  });
  
};