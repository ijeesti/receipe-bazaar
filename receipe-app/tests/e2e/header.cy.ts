/// <reference types="cypress" />

describe("Header", () => {
  beforeEach(() => {
    cy.visit("http://localhost:3005"); // adjust port if your Vite app runs differently
  });

  it("shows logo and subheader", () => {
    cy.get("img").should("be.visible");
    cy.contains("Recipe Bazaar").should("be.visible");
  });

  it("navigates between pages", () => {
    cy.contains("Recipes").click();
    cy.url().should("include", "/recipes");

    cy.contains("About").click();
    cy.url().should("include", "/about");
  });
});
