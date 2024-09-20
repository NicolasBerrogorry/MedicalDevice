import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { AppRoutes } from '../../app.routing';

@Component({
  selector: 'app-root',
  templateUrl: './root.page.html',
  styleUrls: ['./root.page.scss']
})
export class RootPage {
  private readonly router = inject(Router)

  title = 'MedicalDeviceApp';
  routes = AppRoutes;
}
