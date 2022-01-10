import { CartItem } from "./cart-item";

export interface GetCartResponse {
    products: CartItem[],
    sum: number
}