import { useEffect } from "react";
import "./Header.css";
function Header() {
  useEffect(() => {
    const logging = setInterval(() => {
      console.log("Checking for updates...");
    }, 3000);

    return () => {
      clearInterval(logging);
      console.log("Stopped looking for updates");
    };
  }, []);

  return (
    <header className="main-header">
      <h1>Conference Booking Inc .</h1>
      <nav className="navigation">
        <a href="">Book</a>
        <a href="#">About</a>
        <a href="#">Profile</a>
      </nav>
    </header>
  );
}

export default Header;
