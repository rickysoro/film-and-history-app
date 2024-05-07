export interface Events {
    year: number;
    month: number;
    day: number;
    event: string;
    
  }

  export interface EventsResponseDTO {
    page: number;
    results: Events[];
  }