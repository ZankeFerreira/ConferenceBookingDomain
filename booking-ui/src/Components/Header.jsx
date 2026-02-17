import '../App.css';
function Header(){
        return(
        <header className ="main-header">
            <h1>Conference Booking Inc  .</h1>
            <nav className = "navigation">
                
                    <a href="">Book</a>
                    <a href="#">About</a>
                    <a href="#">Profile</a>
                
            </nav>
        </header>
    );
}

export default Header;