import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Technician } from '../model/technician';

@Injectable({
  providedIn: 'root'
})
export class TechnicianService extends BaseService<Technician> {
  protected override get controller(): string {
    return 'technician';
  }
  
  constructor(http: HttpClient) { super(http); }
}

