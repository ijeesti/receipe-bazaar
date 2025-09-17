import { Link } from "react-router-dom";
import logo from "./logo.png";

type Args = {
  subHeader: string;
};

const Header = ({ subHeader }: Args) => {
  return (
    <nav
      className="navbar navbar-expand-lg shadow-sm"
      style={{
        borderBottom: "1px solid rgba(220, 220, 220, 0.7)",

        padding: "0.8rem 1rem",
      }}
    >
      <div className="container d-flex align-items-center justify-content-between">
        {/* Brand */}
        <a className="navbar-brand d-flex align-items-center" href="/">
          <img
            src={logo}
            alt="Recipe Bazaar Logo"
            style={{
              height: "50px",
              marginRight: "12px",
              objectFit: "contain",
            }}
          />
          <div>
            <div className="fw-bold" style={{ fontSize: "1.5rem" }}>
              Recipe Bazaar
            </div>
            <small
              className="fst-bold"
              style={{ color: "#fff", fontSize: "0.9rem" }}
            >
              {subHeader}
            </small>
          </div>
        </a>

        {/* Toggle for mobile */}
        <button
          className="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
        >
          <span className="navbar-toggler-icon"></span>
        </button>

        {/* Links */}
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav ms-auto">
            <li className="nav-item">
              <Link className="nav-link fw-semibold" to="/">
                Home
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link fw-semibold" to="/recipes/">
                Recipes
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link fw-semibold" to="/about">
                About
              </Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Header;
