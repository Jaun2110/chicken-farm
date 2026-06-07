export interface EggRecordDto {
  id: number;
  date: string;
  collected: number;
  sold: number;
  pricePerDozen: number;
  customer: string;
  revenue: number;
}

export interface CreateEggRecordRequest {
  date: string;
  collected: number;
  sold: number;
  pricePerDozen: number;
  customer: string;
}