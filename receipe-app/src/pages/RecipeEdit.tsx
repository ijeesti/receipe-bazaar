import { useParams } from "react-router-dom";
import { useUpdateRecipe } from "../hooks/RecipesHook";
import RecipeForm from "../Components/recipe/RecipeForm";
import useFetchRecipeDetail from "../hooks/RecipeDetailHook";
import { ApiStatus } from "../types/apiStatus";

const EditRecipe = () => {
  const { id } = useParams();

  if (!id) {
    throw Error("Invalid ReceipeId!");
  }
  const recipeId = parseInt(id);
  const { data, status } = useFetchRecipeDetail(recipeId);
  const updateMutation = useUpdateRecipe();

  if (status === "pending") {
    return <ApiStatus status="pending" message="Loading recipes..." />;
  }
  if (status === "error") {
    return <ApiStatus status="error" message="Unable to fetch recipe" />;
  }

  const mutationErrorMessage =
    updateMutation.error?.message ??
    updateMutation.failureReason?.message ??
    "Failed to update recipe";

  return (
    <>
      {updateMutation.isPending && (
        <ApiStatus status="pending" message="Updating recipe..." />
      )}

      {updateMutation.isError && (
        <ApiStatus status="error" message={mutationErrorMessage} />
      )}

      {/* Success usually navigates away in your mutation onSuccess.
          If you prefer a brief success toast before navigation, you can keep this */}
      {updateMutation.isSuccess && (
        <ApiStatus status="success" message="Recipe updated" />
      )}
      <RecipeForm
        recipe={data}
        submitted={(r) => updateMutation.mutate(r)}
      ></RecipeForm>
    </>
  );
};

export default EditRecipe;
