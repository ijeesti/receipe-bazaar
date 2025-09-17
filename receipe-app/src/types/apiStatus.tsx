import { useEffect, useState } from "react";

type Props = {
  status: "error" | "success" | "pending" | "others";
  message?: string;
};

export const ApiStatus = ({ status, message }: Props) => {
  const [show, setShow] = useState(false);

  useEffect(() => {
    if (status !== "success") {
      setShow(true);
      const timer = setTimeout(() => setShow(false), 3000); // auto-hide after 3s
      return () => clearTimeout(timer);
    }
  }, [status]);

  if (!show) return null;

  let bg = "bg-secondary";
  if (status === "error") bg = "bg-danger";
  if (status === "pending") bg = "bg-warning";
  if (status === "success") bg = "bg-success";

  return (
    <div
      className="toast-container position-fixed top-0 end-0 p-3"
      style={{ zIndex: 1055 }}
    >
      <div className={`toast align-items-center text-white ${bg} show`}>
        <div className="d-flex">
          <div className="toast-body">
            {message ||
              (status === "error"
                ? "Error communicating with API"
                : status === "pending"
                  ? "Loading..."
                  : status === "success"
                    ? "Operation successful"
                    : "Unknown status")}
          </div>
          <button
            type="button"
            className="btn-close btn-close-white me-2 m-auto"
            onClick={() => setShow(false)}
          />
        </div>
      </div>
    </div>
  );
};
