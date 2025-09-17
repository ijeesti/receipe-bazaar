import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./main/App.tsx";
import "bootstrap/dist/css/bootstrap.min.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const qryClient = new QueryClient();

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <QueryClientProvider client={qryClient}>
      <App />
    </QueryClientProvider>
  </StrictMode>,
);
