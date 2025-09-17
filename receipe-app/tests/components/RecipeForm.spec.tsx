// cypress/e2e/RecipeForm.spec.tsx
// or cypress/component/RecipeForm.spec.tsx if you are doing component testing

import React from "react";
import { mount } from "@cypress/react18";
import RecipeForm from "../../src/Components/recipe/RecipeForm";
import type { Recipe } from "../../src/types/recipes";

describe("RecipeForm Component", () => {
  const initialRecipe: Recipe = {
    id: 1,
    title: "Test Recipe",
    ingredients: "Ingredient 1\nIngredient 2",
    instructions: "Step 1\nStep 2",
    imageUrl: "http://example.com/image.jpg",
    categoryId: 1,
    categoryName: "Breakfast",
    userId: 101,
    createdOn: "10-10-2001",
  };

  const categories = [
    { id: 1, name: "Breakfast" },
    { id: 2, name: "Lunch" },
    { id: 3, name: "Dinner" },
  ];

  it("should render all form fields and the submit button", () => {
    mount(<RecipeForm recipe={initialRecipe} submitted={() => {}} />);

    cy.get('input[name="title"]').should("be.visible");
    cy.get('textarea[name="ingredients"]').should("be.visible");
    cy.get('textarea[name="instructions"]').should("be.visible");
    cy.get('input[name="image"]').should("be.visible");
    cy.get('select[name="categoryId"]').should("be.visible");
    cy.get('input[name="userId"][value="101"]').should("be.visible"); // User Id input
    cy.get('button[type="submit"], button')
      .contains("Save Recipe")
      .should("be.visible");
  });

  it("should display the initial recipe data in the form fields", () => {
    mount(<RecipeForm recipe={initialRecipe} submitted={() => {}} />);

    cy.get('input[name="title"]').should("have.value", initialRecipe.title);
    cy.get('textarea[name="ingredients"]').should(
      "have.value",
      initialRecipe.ingredients,
    );
    cy.get('textarea[name="instructions"]').should(
      "have.value",
      initialRecipe.instructions,
    );
    cy.get('input[name="image"]').should("have.value", initialRecipe.imageUrl);
    cy.get('select[name="categoryId"]').should(
      "have.value",
      String(initialRecipe.categoryId),
    );
    cy.get('input[name="userId"][value="101"]').should(
      "have.value",
      String(initialRecipe.userId),
    );
  });

  it("should update the form state when a user types into an input field", () => {
    const newTitle = "My New Recipe";
    mount(<RecipeForm recipe={initialRecipe} submitted={() => {}} />);

    cy.get('input[name="title"]').clear().type(newTitle);
    cy.get('input[name="title"]').should("have.value", newTitle);
  });

  it("should call the submitted prop with the updated recipe object on form submission", () => {
    // Cypress provides a way to create a spy function to check if it was called
    const submittedSpy = cy.spy();
    mount(<RecipeForm recipe={initialRecipe} submitted={submittedSpy} />);

    // Define new values for the form fields
    const newRecipe = {
      ...initialRecipe,
      title: "Updated Recipe",
      ingredients: "Updated Ingredients",
      instructions: "Updated Instructions",
      imageUrl: "http://new-image.com",
      categoryId: 2,
      categoryName: "Lunch",
      userId: 202,
    };

    // Fill out the form
    cy.get('input[name="title"]').clear().type(newRecipe.title);
    cy.get('textarea[name="ingredients"]').clear().type(newRecipe.ingredients);
    cy.get('textarea[name="instructions"]')
      .clear()
      .type(newRecipe.instructions);
    cy.get('input[name="image"]').clear().type(newRecipe.imageUrl);
    cy.get('select[name="categoryId"]').select(String(newRecipe.categoryId));
    cy.get('input[value="101"]').clear().type(String(newRecipe.userId));

    // Click the submit button
    cy.get("button").contains("Save Recipe").click();

    // The form has an onSubmit handler on the button, so we need to prevent the default form submission.
    // The provided code uses event.preventDefault(), but it's good practice to ensure.
    // Here we're just checking the spy call.

    // Assert that the submitted function was called with the correct object
    cy.wrap(submittedSpy).should("have.been.calledWithMatch", {
      title: newRecipe.title,
      ingredients: newRecipe.ingredients,
      instructions: newRecipe.instructions,
      imageUrl: newRecipe.imageUrl,
      categoryId: newRecipe.categoryId,
      categoryName: newRecipe.categoryName,
      userId: newRecipe.userId,
    });
  });
});
