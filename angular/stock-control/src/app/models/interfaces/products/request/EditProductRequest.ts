export interface EditProductRequest {
    product_id: string;
    name: string;
    description: string;
    price: string;
    amount: number;
    category_id: string;
}