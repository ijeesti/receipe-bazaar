import type { Recipe } from "../types/recipe";
import config from "../config";
import { useQuery } from "@tanstack/react-query";
import type { Comment } from "../types/comment";
import axios, { AxiosError } from "axios";

const useFetchRecipeDetail = (recipeId: number) => {
  return useQuery<Recipe, AxiosError>({
    queryKey: ["recipes", recipeId],
    queryFn: () =>
      axios
        .get(`${config.baseApiUrl}/api/recipes/${recipeId}`)
        .then((res) => res.data),
  });
};

const useFetchComments = (recipeId: number) => {
  return useQuery<Comment[], AxiosError>({
    queryKey: ["comments"],
    queryFn: () =>
      axios
        .get(`${config.baseApiUrl}/api/recipes/${recipeId}/comments`)
        .then((res) => res.data),
  });
};

export default useFetchRecipeDetail;
export { useFetchComments };
