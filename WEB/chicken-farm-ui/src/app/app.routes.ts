import { Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FlockComponent } from './components/flock/flock.component';
import { EggsComponent } from './components/eggs/eggs.component';
import { OrdersComponent } from './components/orders/orders.component';
import { PaddocksComponent } from './components/paddocks/paddocks.component';
import { FeedComponent } from './components/feed/feed.component';
import { ReportsComponent } from './components/reports/reports.component';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'flock', component: FlockComponent },
  { path: 'eggs', component: EggsComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'paddocks', component: PaddocksComponent },
  { path: 'feed', component: FeedComponent },
  { path: 'reports', component: ReportsComponent }
];