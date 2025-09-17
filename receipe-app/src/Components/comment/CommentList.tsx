import { useParams } from "react-router-dom";
import { useFetchComments } from "../../hooks/RecipeDetailHook";
import { ApiStatus } from "../../types/apiStatus";
import type { Comment } from "../../types/comment";

const CommentList = () => {
  const { id } = useParams();

  if (!id) {
    throw Error("Invalid Recipe Id");
  }
  const recipeId = parseInt(id);
  const { data, status, isSuccess } = useFetchComments(recipeId);

  if (!isSuccess) {
    return <ApiStatus status={status} />;
  }

  if (!data || data.length === 0) {
    return (
      <div className="mt-4 text-muted">
        No comments yet. Be the first to comment!
      </div>
    );
  }

  return (
    <div className="mt-5">
      <h5 className="mb-3">Comments ({data.length})</h5>
      <div className="d-flex flex-column gap-3">
        {data.map((comment: Comment) => (
          <div
            key={comment.id}
            className="p-3 bg-white border rounded shadow-sm"
          >
            <div className="d-flex justify-content-between align-items-center mb-2">
              <span className="fw-bold text-primary">{comment.userName}</span>
              <small className="text-muted">
                {new Date(comment.createdOn).toLocaleString()}
              </small>
            </div>
            <p className="mb-0">{comment.content}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default CommentList;
