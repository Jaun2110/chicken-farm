import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive, RouterOutlet],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {
  navItems = [
    { path: '/dashboard', label: 'Dashboard' },
    { path: '/flock', label: 'Flock' },
    { path: '/eggs', label: 'Eggs & Sales' },
    { path: '/orders', label: 'Orders' },
    { path: '/paddocks', label: 'Paddocks' },
    { path: '/feed', label: 'Feed Calculator' },
    { path: '/reports', label: 'Reports' }
  ];
}