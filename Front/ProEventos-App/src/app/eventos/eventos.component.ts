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

  public eventos: any = [];
  public eventosFiltrados: any = [];

  public imgWidth: number = 150;
  public imgMaxHeight: number = 100;

  public imgBtnPadding: number = 0;
  public imgBtnFontSize: number = 14;
  public imgBtnFontWeight: string = 'bold';

  public showImage: boolean = true;

  private _filtro: string = '';

  public get filtro(): string {
    return this._filtro;
  }

  public set filtro(value: string){
    this._filtro = value;
    this.eventosFiltrados = this.filtro ? this.filtrarEventos(this.filtro) : this.eventos;
  }

  public filtrarEventos(filtro: string): any{
    return this.eventos.filter((evento: any) => evento.tema.toLowerCase().includes(filtro.toLowerCase()) || evento.local.toLowerCase().includes(filtro.toLowerCase()));
  }

  //public isCollapsed = false;
  public collapseImage(){
    this.showImage = !this.showImage;
  }

  private getEventosFromApi(): void {
    this.client.get('https://localhost:5001/api/ProEventos/eventos').subscribe(
      response => {
        this.eventos = response,
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
  }

}
