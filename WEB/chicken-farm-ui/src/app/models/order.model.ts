export type OrderStatus = 'Open' | 'Paid' | 'Delivered' | 'Cancelled';

export interface OrderDto {
  id: number;
  customer: string;
  phone: string;
  dozensOrdered: number;
  pricePerDozen: number;
  total: number;
  deliveryDate: string;
  status: OrderStatus;
}

export interface CreateOrderRequest {
  customer: string;
  phone: string;
  dozensOrdered: number;
  pricePerDozen: number;
  deliveryDate: string;
}

export interface UpdateOrderStatusRequest {
  status: OrderStatus;
}