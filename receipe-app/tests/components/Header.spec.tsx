import React from "react";
import { mount } from "@cypress/react18";
import { MemoryRouter } from "react-router-dom"; // Import MemoryRouter
import Header from "../../src/Components/landing/Header";

describe("Header Component", () => {
  it("renders logo and subheader", () => {
    // Wrap the component with MemoryRouter to provide the router context
    mount(
      <MemoryRouter>
        <Header subHeader="Delicious Recipes" />
      </MemoryRouter>,
    );

    // Now your assertions will work correctly
    cy.get("img").should("be.visible");
    cy.contains("Recipe Bazaar").should("be.visible");
    cy.contains("Delicious Recipes").should("be.visible");
    cy.contains("Home").should("be.visible");
    cy.contains("Recipes").should("be.visible");
    cy.contains("About").should("be.visible");
  });
});
