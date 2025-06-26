export interface GetAllProductResponse {
    id: string;
    name: string;
    amount: number;
    description: string;
    price: number;
    category: {
        id: string;
        name: string;
    }
    
}