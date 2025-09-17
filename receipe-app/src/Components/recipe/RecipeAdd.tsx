import { useAddRecipe } from "../../hooks/RecipesHook";
import type { Recipe } from "../../types/recipe";
import RecipeForm from "./RecipeForm";

const AddRecipe = () => {
  const addRecipeMutation = useAddRecipe();
  const recipe: Recipe = {
    id: 0,
    title: "",
    description: "",
    ingredients: "",
    instructions: "",
    imageUrl: "",
    categoryId: 0, // required
    categoryName: "Breakfast",
    userId: 0,
    userName: "",
    createdOn: "",
  };

  return (
    <RecipeForm
      recipe={recipe}
      submitted={(r) => addRecipeMutation.mutate(r)}
    ></RecipeForm>
  );
};

export default AddRecipe;
