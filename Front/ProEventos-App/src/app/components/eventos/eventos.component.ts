import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/Evento.service';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;

  constructor(private eventoService: EventoService, private modalService: BsModalService,
              private toastrService: ToastrService, private spinnerService: NgxSpinnerService) {
  }

  ngOnInit(): void {
    this.getEventos();

    /* Spinner */
    this.spinnerService.show();
  }

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

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

  public filtrarEventos(filtro: string): Evento[]{
    return this.eventos.filter((evento: Evento) => evento.tema.toLowerCase().includes(filtro.toLowerCase()) || evento.local.toLowerCase().includes(filtro.toLowerCase()));
  }

  //public isCollapsed = false;
  public collapseImage(){
    this.showImage = !this.showImage;
  }

  private getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos,
        this.eventosFiltrados = this.eventos
      },
      error: error => console.log(error),
      complete: () => setTimeout(() => {
                        /** spinner ends after 1 second */
                        this.spinnerService.hide();
                      }, 1000)
    });
  }

  /* Modal */

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastrService.success('O Evento foi excluído com sucesso', 'Excluído!', this.toastConfig);
  }

  decline(): void {
    this.modalRef?.hide();
    this.toastrService.warning('A exclusão do Evento foi abortada', 'Operação cancelada!', this.toastConfig);
  }

  /* Toast - Config */

  private toastConfig: any = {
    timeOut: 3000,
    closeButton: true,
    progressBar: true,
    positionClass: 'toast-bottom-right'
  }
}
