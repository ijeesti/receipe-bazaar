import { Route, Routes } from "react-router-dom";
import Recipes from "./recipe/Recipes";
import AddRecipe from "./recipe/RecipeAdd";
import EditRecipe from "../pages/RecipeEdit";
import About from "../pages/About";
import RecipeDetail from "../pages/RecipeDetail";

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<Recipes />} />
      <Route path="/recipes" element={<Recipes />} />
      <Route path="/recipes/:id" element={<RecipeDetail />} />
      <Route path="/recipes/add" element={<AddRecipe />} />
      <Route path="/recipes/edit/:id" element={<EditRecipe />} />
      <Route path="/about" element={<About />} />
    </Routes>
  );
};

export default AppRoutes;
