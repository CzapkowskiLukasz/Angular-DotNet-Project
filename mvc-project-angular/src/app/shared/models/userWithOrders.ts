import { OrderListItem } from "./order-list-item";
import { UserListItem } from "./user-list-item";

export interface UserWithOrders {
    user: UserListItem,
    orders: OrderListItem[]
}