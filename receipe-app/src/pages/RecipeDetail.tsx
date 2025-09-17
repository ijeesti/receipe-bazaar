import { Button, Card } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";
import useFetchRecipeDetail from "../hooks/RecipeDetailHook";
import { ApiStatus } from "../types/apiStatus";
import { formatDate } from "../config";
import CommentList from "../Components/comment/CommentList";

const RecipeDetail = () => {
  const { id } = useParams();
  const nav = useNavigate();

  if (!id) {
    throw Error("Invalid Recipe Id");
  }
  var recipeId = parseInt(id);
  const { data, status, isSuccess } = useFetchRecipeDetail(recipeId);

  if (!isSuccess) {
    return <ApiStatus status={status}></ApiStatus>;
  }

  if (!data) {
    return <div>Recipe not found</div>;
  }

  return (
    <div className="container my-5">
      <Card className="shadow-lg border-0 rounded-3 overflow-hidden">
        <div className="row g-0">
          {/* Image column */}
          <div className="col-md-5">
            <Card.Img
              src={data?.imageUrl}
              alt={data?.title}
              className="h-100 w-100"
              style={{ objectFit: "cover", maxHeight: "400px", margin: "5px" }}
            />
          </div>

          {/* Content column */}
          <div className="col-md-7 d-flex flex-column">
            <Card.Body className="p-4">
              <h2 className="fw-bold mb-3">{data?.title}</h2>
              <h5 className="text-primary mb-2">{data?.categoryName}</h5>
              <p className="text-muted">{formatDate(data.createdOn)}</p>

              <h5 className="mt-4">Ingredients</h5>
              <p className="mb-3">{data.ingredients}</p>

              <h5>Instructions</h5>
              <p className="mb-4">{data.instructions}</p>

              <div className="mt-auto">
                <Button
                  variant="primary"
                  onClick={() => nav("/")}
                  className="px-4 py-2"
                >
                  Back to Recipes
                </Button>
              </div>
            </Card.Body>
          </div>
        </div>
      </Card>

      <CommentList></CommentList>
    </div>
  );
};

export default RecipeDetail;
