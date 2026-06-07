export interface FeedIngredient {
  name: string;
  percentage: number;
  kg: number;
}

export interface FeedCalculationRequest {
  feedType: 'Starter' | 'Grower' | 'Layer';
  totalKg: number;
}

export interface FeedCalculationResult {
  feedType: string;
  totalKg: number;
  ingredients: FeedIngredient[];
}