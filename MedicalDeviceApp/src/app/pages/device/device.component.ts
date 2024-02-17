import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Device } from 'src/app/model/device';
import { DeviceSize } from 'src/app/model/device-size';
import { DeviceStep } from 'src/app/model/device-step';
import { DefaultBlob } from 'src/app/model/blob';
import { DeviceService } from 'src/app/services/device.service';
import { ModelService } from 'src/app/services/model.service';
import { DefaultGuid, GuidValidator } from 'src/app/model/guid';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.scss']
})
export class DeviceComponent {
  readonly devices = this.deviceService.getAll();
  readonly models = this.modelService.getAll();

  readonly device = this.formBuilder.group({
    id: this.formBuilder.control(DefaultGuid, [GuidValidator]),
    modelId: this.formBuilder.control(DefaultGuid, [GuidValidator]),
    deviceSteps: this.formBuilder.array<DeviceStep>([]),
    model: this.formBuilder.group({
      id: this.formBuilder.control(DefaultGuid, [GuidValidator]),
      name: this.formBuilder.control("Model"),
      description: this.formBuilder.control("Please select a valid model"),
      size: this.formBuilder.control(DeviceSize.LARGE),
      photo: this.formBuilder.control(DefaultBlob)
    })
  });

  constructor(private formBuilder: FormBuilder, private readonly deviceService: DeviceService, private readonly modelService: ModelService) {
  }

  onSelect(device: Device) {
    this.device.setValue(device);
  }

  onSave() {

  }

  onCancel() {

  }
}
