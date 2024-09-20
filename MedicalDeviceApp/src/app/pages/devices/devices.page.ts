import { Component, inject } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { Device, DeviceService, User, UserService } from 'src/api';
import { EntityListPage } from '../entity-list/entity-list.page';
import { DefaultDevice } from 'src/app/mocks/device.mock';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.page.html',
  styleUrls: ['./devices.page.scss']
})
export class DevicesPage extends EntityListPage<Device> {
  private readonly devices = inject(DeviceService)

  protected override async getAllEntities(): Promise<Device[]> {
    const allDevices = await firstValueFrom(this.devices.getAllDevices());
    return allDevices;
  }

  protected override getNewEntity(): Device {
    const newDevice = DefaultDevice;
    return newDevice;
  }

  protected override getEntityId(entity: Device): string | undefined {
    const deviceId = entity?.id;
    return deviceId;
  }
}
