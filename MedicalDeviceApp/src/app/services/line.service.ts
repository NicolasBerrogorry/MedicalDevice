import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Line } from '../model/line';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LineService extends BaseService<Line> {
  protected override get controller(): string {
    return 'line';
  }
  
  constructor(http: HttpClient) { super(http); }
}
