import { Component, EventEmitter, inject, Input, OnChanges, OnDestroy, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { firstValueFrom, map } from 'rxjs';
import { Device, DeviceService, User, UserService } from 'src/api';
import { DefaultDevice } from 'src/app/mocks/device.mock';
import { DefaultUlid as UlidDefault } from 'src/app/mocks/ulid.mock';
import { EntityComponent } from '../entity/entity.component';
import { MatDialog } from '@angular/material/dialog';
import { UserComponent } from '../user/user.component';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.scss']
})
export class DeviceComponent extends EntityComponent<Device> implements OnInit {
  private readonly dialog = inject(MatDialog)
  private readonly userService = inject(UserService);
  private readonly deviceService = inject(DeviceService)

  override async ngOnInit() {
    const currentUser = await firstValueFrom(this.userService.getCurrentUser());
    this.entity.creationUser = currentUser;
    await super.ngOnInit();
  }

  async onClickCreationUser() {
    const creationUser = this.entity?.creationUser;
    if (!creationUser) return;
    const userComponentRef = this.dialog.open(UserComponent, {
      data: creationUser,
      panelClass: 'device-creation-user-dialog'
    });
    await firstValueFrom(userComponentRef.afterClosed());
  }

  protected override async createEntity(entity: Device): Promise<Device> {
    const createdDevice = await firstValueFrom(this.deviceService.createDevice(entity));
    return createdDevice;
  }

  protected override async updateEntity(id: string, entity: Device) {
    const updatedDevice = await firstValueFrom(this.deviceService.updateDevice(id, entity));
    return updatedDevice;
  }

  protected override getEntityId(entity: Device): string | undefined {
    const deviceId = entity.id;
    return deviceId;
  }

  protected override getEntityDefault(): Device {
    const defaultDevice = DefaultDevice;
    return defaultDevice;
  }
}
