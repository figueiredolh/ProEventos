import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EventosListaComponent } from 'src/app/components/eventos/eventos-lista/eventos-lista.component';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  constructor(private router : Router) { }

  ngOnInit() {
  }

  @Input() title: string | undefined;
  @Input() subtitulo: string = 'Desde 2011';
  @Input() iconClass: string = 'fa fa-user';
  @Input() showButton: boolean = false;

  public listar() : void{
    this.router.navigate([`/${this.title?.toLowerCase()}/lista`]);
  }
}
