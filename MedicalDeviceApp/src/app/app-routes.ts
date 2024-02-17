import { Routes } from '@angular/router';
import { DeviceComponent } from './pages/device/device.component';
import { LineComponent } from './pages/line/line.component';
import { ModelComponent } from './pages/model/model.component';
import { TechnicianComponent } from './pages/technician/technician.component';


export const AppRoutes: Routes = [
  {
    path: "technician",
    title: "TECHNICIAN",
    component: TechnicianComponent
  },
  {
    path: "model",
    title: "MODEL",
    component: ModelComponent
  },
  {
    path: "line",
    title: "LINE",
    component: LineComponent
  },
  {
    path: "device",
    title: "DEVICE",
    component: DeviceComponent
  }
];
