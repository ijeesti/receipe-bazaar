import React, { useState } from "react";
import type { Recipe } from "../../types/recipe";
import { categories } from "../../types/categories";

type Props = {
  recipe: Recipe;
  submitted: (recipe: Recipe) => void;
};

const RecipeForm = ({ recipe, submitted }: Props) => {
  const [recipeState, setRecipeState] = useState<Recipe>({ ...recipe });

  const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (
    event,
  ) => {
    event.preventDefault();
    submitted(recipeState);
  };

  return (
    <form
      className="p-4 shadow-sm rounded"
      style={{ backgroundColor: "rgba(255, 244, 229, 0.85)" }}
    >
      <div className="mb-3">
        <label className="form-label">Title</label>
        <input
          type="text"
          name="title"
          value={recipeState.title}
          onChange={(e) =>
            setRecipeState({ ...recipeState, title: e.target.value })
          }
          className="form-control"
          required
        />
      </div>

      <div className="mb-3">
        <label className="form-label">Ingredients</label>
        <textarea
          name="ingredients"
          value={recipeState.ingredients}
          onChange={(e) =>
            setRecipeState({ ...recipeState, ingredients: e.target.value })
          }
          className="form-control"
          rows={3}
          required
        />
      </div>

      <div className="mb-3">
        <label className="form-label">Instructions</label>
        <textarea
          name="instructions"
          value={recipeState.instructions}
          onChange={(e) =>
            setRecipeState({ ...recipeState, instructions: e.target.value })
          }
          className="form-control"
          rows={4}
          required
        />
      </div>

      <div className="mb-3">
        <label className="form-label">Image URL</label>
        <input
          type="text"
          name="image"
          value={recipeState.imageUrl || ""}
          onChange={(e) =>
            setRecipeState({ ...recipeState, imageUrl: e.target.value })
          }
          className="form-control"
        />
      </div>

      <div className="mb-3">
        <label className="form-label">Category</label>
        <select
          name="categoryId"
          value={recipeState.categoryId}
          onChange={(e) => {
            const selectedId = parseInt(e.target.value);
            const selectedCategory = categories.find(
              (c) => c.id === selectedId,
            );

            setRecipeState({
              ...recipeState,
              categoryId: selectedId,
              categoryName: selectedCategory ? selectedCategory.name : "",
            });
          }}
          className="form-select"
          required
        >
          <option value={0}>Select category</option>
          {categories.map((cat) => (
            <option key={cat.id} value={cat.id}>
              {cat.name}
            </option>
          ))}
        </select>
      </div>

      <div className="mb-3">
        <label className="form-label">User Id</label>
        <input
          type="text"
          name="userId"
          value={recipeState.userId}
          onChange={(e) => {
            const userId = e.target.value ? parseInt(e.target.value) : 0; // Or a different default value
            setRecipeState({ ...recipeState, userId });
          }}
          className="form-control"
          required
        />
      </div>

      <button onClick={onSubmit} className="btn btn-primary w-100">
        Save Recipe
      </button>
    </form>
  );
};

export default RecipeForm;
