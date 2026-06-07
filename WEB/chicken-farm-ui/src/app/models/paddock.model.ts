export interface PaddockDto {
  id: number;
  name: string;
  dateIn: string;
  dateOut: string | null;
  notes: string;
  restDays: number;
}

export interface CreatePaddockRequest {
  name: string;
  dateIn: string;
  dateOut: string | null;
  notes: string;
}