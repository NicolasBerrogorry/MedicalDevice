import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Device } from '../model/device'
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DeviceService extends BaseService<Device> {
  protected override get controller(): string {
    return 'device';
  }
  
  constructor(http: HttpClient) { super(http); }
}
