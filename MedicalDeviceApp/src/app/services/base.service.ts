import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export const MedicalDeviceBaseUrl = "http://localhost:5243";

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService<T> {
  protected abstract get controller(): string;

  constructor(protected http: HttpClient) { }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(`${MedicalDeviceBaseUrl}/${this.controller}`);
  }

  getById(id: string): Observable<T> {
    return this.http.get<T>(`${MedicalDeviceBaseUrl}/${this.controller}/${id}`);
  }

  create(item: T): Observable<T> {
    return this.http.post<T>(`${MedicalDeviceBaseUrl}/${this.controller}`, item);
  }

  update(id: string, item: T): Observable<T> {
    return this.http.put<T>(`${MedicalDeviceBaseUrl}/${this.controller}/${id}`, item);
  }

  delete(id: string): Observable<T> {
    return this.http.delete<T>(`${MedicalDeviceBaseUrl}/${this.controller}/${id}`);
  }
}