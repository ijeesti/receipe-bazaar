export interface Recipe {
  id: number;
  title: string;
  description?: string;
  ingredients: string;
  instructions: string;
  imageUrl?: string;
  categoryId: number;
  categoryName?: string;
  userId: number;
  userName?: string;
  createdOn: string;
}
