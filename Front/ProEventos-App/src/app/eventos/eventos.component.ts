import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {
  constructor(private client: HttpClient) {
  }

  ngOnInit(): void {
    this.getEventosFromApi();
  }

  public eventos: any;

  private getEventosFromApi(): void {
    this.client.get('https://localhost:5001/api/ProEventos/eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
  }

}
