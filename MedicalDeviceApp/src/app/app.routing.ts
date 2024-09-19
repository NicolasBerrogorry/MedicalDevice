import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersPage } from './pages/users/users.page';
import { DevicesPage } from './pages/devices/devices.page';
import { TicketsPage } from './pages/tickets/tickets.page';

export const AppRoutes: Routes = [
  {
    path: "",
    title: "Users",
    component: UsersPage
  },
  {
    path: "devices",
    title: "Devices",
    component: DevicesPage
  },
  {
    path: "tickets",
    title: "Tickets",
    component: TicketsPage
  }
];


@NgModule({
  imports: [RouterModule.forRoot(AppRoutes)],
  exports: [RouterModule]
})
export class AppRouting { }
