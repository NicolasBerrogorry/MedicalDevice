import { Component } from '@angular/core';
import { AppRoutes } from './app-routes';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'MedicalDeviceApp';
  routes = AppRoutes;
}
