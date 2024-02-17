import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Model } from '../model/model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ModelService extends BaseService<Model> {
  protected override get controller(): string {
    return 'model';
  }

  constructor(http: HttpClient) { super(http); }

}
