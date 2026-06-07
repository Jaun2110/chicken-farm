import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { OrderService } from '../../services/order.service';
import { OrderDto, CreateOrderRequest, UpdateOrderStatusRequest, OrderStatus } from '../../models/order.model';

@Component({
  selector: 'app-orders',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.scss'
})
export class OrdersComponent implements OnInit {
  private orderService = inject(OrderService);

  orders: OrderDto[] = [];
  loading = true;

  newOrder: CreateOrderRequest = {
    customer: '',
    phone: '',
    dozensOrdered: 1,
    pricePerDozen: 45,
    deliveryDate: new Date().toISOString().split('T')[0]
  };

  statusOptions: OrderStatus[] = ['Open', 'Paid', 'Delivered', 'Cancelled'];

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders(): void {
    this.orderService.getAll().subscribe({
      next: (data) => {
        this.orders = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Failed to load orders', err);
        this.loading = false;
      }
    });
  }

  addOrder(): void {
    this.orderService.create(this.newOrder).subscribe({
      next: () => {
        this.loadOrders();
        this.resetForm();
      },
      error: (err) => console.error('Failed to add order', err)
    });
  }

  updateStatus(id: number, status: OrderStatus): void {
    const request: UpdateOrderStatusRequest = { status };
    this.orderService.updateStatus(id, request).subscribe({
      next: () => this.loadOrders(),
      error: (err) => console.error('Failed to update status', err)
    });
  }

  deleteOrder(id: number): void {
    if (!confirm('Delete this order?')) return;
    this.orderService.delete(id).subscribe({
      next: () => this.loadOrders(),
      error: (err) => console.error('Failed to delete order', err)
    });
  }

  private resetForm(): void {
    this.newOrder = {
      customer: '',
      phone: '',
      dozensOrdered: 1,
      pricePerDozen: 45,
      deliveryDate: new Date().toISOString().split('T')[0]
    };
  }
}