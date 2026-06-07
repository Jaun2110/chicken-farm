export interface FlockDto {
  id: number;
  name: string;
  arrivalDate: string; // DateOnly serializes as "YYYY-MM-DD"
  startBirds: number;
  currentBirds: number;
  breed: string;
  notes: string;
  ageWeeks: number;
  stage: string;
}

export interface CreateFlockRequest {
  name: string;
  arrivalDate: string;
  startBirds: number;
  currentBirds: number;
  breed: string;
  notes: string;
}