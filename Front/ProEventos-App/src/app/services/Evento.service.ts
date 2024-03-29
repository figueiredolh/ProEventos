import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(/*{providedIn: 'root'}*/)

export class EventoService {

  constructor(private client: HttpClient) { }

  baseURL: string = 'https://localhost:5001/api/eventos';

  public getEventos(): Observable<Evento[]>{
    return this.client.get<Evento[]>(this.baseURL);
  }

  public getEventosByTema(tema: string): Observable<Evento[]>{
    return this.client.get<Evento[]>(`${this.baseURL}/tema/${tema}`);
  }

  public getEventoById(id: number): Observable<Evento>{
    return this.client.get<Evento>(`${this.baseURL}/evento/${id}`);
  }
}
