import type { Recipe } from "../types/recipe";
import config from "../config";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios, { AxiosError, type AxiosResponse } from "axios";
import { useNavigate } from "react-router-dom";

const useFetchRecepies = () => {
  return useQuery<Recipe[], AxiosError>({
    queryKey: ["recipes"],
    queryFn: () =>
      axios.get(`${config.baseApiUrl}/api/recipes`).then((res) => res.data),
  });
};

const useAddRecipe = () => {
  const nav = useNavigate();
  const qryClient = useQueryClient();
  return useMutation<AxiosResponse, AxiosError, Recipe>({
    mutationFn: (r) => axios.post(`${config.baseApiUrl}/api/recipes`, r),
    onSuccess: () => {
      qryClient.invalidateQueries({
        queryKey: ["recipes"],
      });

      nav("/recipes");
    },
  });
};

const useUpdateRecipe = () => {
  const nav = useNavigate();
  const qryClient = useQueryClient();

  return useMutation<Recipe, AxiosError, Recipe>({
    mutationFn: (recipe) =>
      axios
        .put<Recipe>(`${config.baseApiUrl}/api/recipes/${recipe.id}`, recipe)
        .then((res) => res.data),
    onSuccess: (updatedRecipe) => {
      // Invalidate recipe list and optionally individual recipe cache
      //       //qryClient.invalidateQueries({ queryKey: ["recipes"] });
      qryClient.invalidateQueries({ queryKey: ["recipe", updatedRecipe.id] });
      //       // Navigate to the updated recipe detail page
      nav(`/recipes/${updatedRecipe.id}`);
    },
    onError: (error) => {
      // Add something..
      console.error("Update failed:", error);
    },
  });
};

const useDeleteRecipe = () => {
  const nav = useNavigate();
  const qryClient = useQueryClient();
  return useMutation<AxiosResponse, AxiosError, Recipe>({
    mutationFn: (r) => axios.put(`${config.baseApiUrl}/api/recipes${r.id}`),
    onSuccess: (_, recp) => {
      qryClient.invalidateQueries({
        queryKey: ["recipes"],
      });

      nav(`/recipes/${recp.id}`);
    },
  });
};
export default useFetchRecepies;
export { useAddRecipe, useUpdateRecipe, useDeleteRecipe };
