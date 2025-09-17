export interface Comment {
  id: number;
  userId: number;
  userName?: string; // optional, can be populated from UserEntity
  recipeId: number;
  content: string;
  createdOn: string;
}
