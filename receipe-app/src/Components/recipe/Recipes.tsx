import type { Recipe } from "../../types/recipe";
import useFetchRecepies from "../../hooks/RecipesHook";
import { formatDate } from "../../config";
import { ApiStatus } from "../../types/apiStatus";
import { Link, useNavigate } from "react-router-dom";

const Recipes = () => {
  const nav = useNavigate();
  const { data: recipes, status, isSuccess } = useFetchRecepies();

  if (!isSuccess) {
    return <ApiStatus status={status}></ApiStatus>;
  }

  return (
    <div className="container my-5">
      <div className="text-center mb-5">
        <h1 className="fw-bold">Discover, Cook, Enjoy!</h1>
        <p className="text-secondary fs-5">
          Find your next favorite recipe below
        </p>
      </div>

      <div className="d-flex justify-content-between align-items-center mb-4">
        <Link className="btn btn-success btn-lg" to={"/recipes/add"}>
          + Add New Recipe
        </Link>
      </div>

      {/* Recipe cards */}
      <div className="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
        {recipes?.map((recipe: Recipe) => (
          <div key={recipe.id} className="col">
            <div
              className="card h-100 shadow-sm"
              style={{
                cursor: "pointer",
                backgroundColor: "rgba(255, 244, 229, 0.9)",
                color: "#333",
                backdropFilter: "blur(6px)",
                transition: "transform 0.2s, box-shadow 0.2s",
              }}
              onMouseEnter={(e) => {
                const target = e.currentTarget as HTMLDivElement;
                target.style.transform = "translateY(-5px)";
                target.style.boxShadow = "0 8px 20px rgba(0,0,0,0.2)";
              }}
              onMouseLeave={(e) => {
                const target = e.currentTarget as HTMLDivElement;
                target.style.transform = "translateY(0)";
                target.style.boxShadow = "0 4px 12px rgba(0,0,0,0.1)";
              }}
            >
              {recipe.imageUrl && (
                <img
                  src={recipe.imageUrl}
                  className="card-img-top"
                  alt={recipe.title}
                  style={{
                    height: "200px",
                    objectFit: "cover",
                    borderRadius: "4px 4px 0 0",
                  }}
                />
              )}
              <div className="card-body d-flex flex-column">
                <h5 className="card-title fw-semibold">{recipe.title}</h5>
                <p className="text-muted mb-1">
                  Category: <strong>{recipe.categoryName}</strong>
                </p>
                <p className="text-muted mb-1">
                  By: <strong>{recipe.userName}</strong>
                </p>
                <p className="text-muted mb-2">
                  Created: <strong>{formatDate(recipe.createdOn)}</strong>
                </p>
                <p className="card-text text-truncate mb-3">
                  Ingredients: <strong>{recipe.ingredients}</strong>
                </p>
              </div>

              {/* Card footer for actions */}
              <div className="card-footer bg-transparent border-0 d-flex justify-content-between">
                <button
                  onClick={() => nav(`/recipes/${recipe.id}`)}
                  className="btn btn-primary w-50 me-2"
                >
                  View Details
                </button>
                <Link
                  className="btn btn-outline-danger w-50"
                  to={`/recipes/edit/${recipe.id}`}
                >
                  Edit
                </Link>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Recipes;
