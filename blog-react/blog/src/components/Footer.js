import React from "react";

function Footer() {
  return (
    <div className="footer">
      <footer class="py-3 bg-dark fixed-bottom">
        <div class="container">
          <p class="m-0 text-center text-white">
            © Jared Holgate {new Date().getFullYear()}
          </p>
        </div>
      </footer>
    </div>
  );
}

export default Footer;