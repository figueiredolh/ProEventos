import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/Evento.service';

@Component({
  selector: 'app-eventos-lista',
  templateUrl: './eventos-lista.component.html',
  styleUrls: ['./eventos-lista.component.scss'],
})
export class EventosListaComponent implements OnInit {
  modalRef?: BsModalRef;

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService
  ) {}

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

  public errorMessage: string = '';

  private _filtro: string = '';

  public get filtro(): string {
    return this._filtro;
  }

  public set filtro(value: string) {
    this._filtro = value;
    this.eventosFiltrados = this.filtro
      ? this.filtrarEventos(this.filtro)
      : this.eventos;
  }

  public filtrarEventos(filtro: string): Evento[] {
    return this.eventos.filter(
      (evento: Evento) =>
        evento.tema.toLowerCase().includes(filtro.toLowerCase()) ||
        evento.local.toLowerCase().includes(filtro.toLowerCase())
    );
  }

  //public isCollapsed = false;
  public collapseImage() {
    this.showImage = !this.showImage;
  }

  private getEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos,
        this.eventosFiltrados = this.eventos;
      },
      error: (error) => {
        console.log(error);
        this.errorMessage = "Falha ao carregar eventos!";
      },
      complete: () => {
        setTimeout(() => {
          /** spinner ends after 1 second */
          this.spinnerService.hide();
        }, 1000);
        if(!this.eventos.length) this.errorMessage = "Não existem eventos cadastrados!";
      }
    });
  }

  /* Modal */

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastrService.success(
      'O Evento foi excluído com sucesso',
      'Excluído!',
      this.toastConfig
    );
  }

  decline(): void {
    this.modalRef?.hide();
    this.toastrService.warning(
      'A exclusão do Evento foi abortada',
      'Operação cancelada!',
      this.toastConfig
    );
  }

  /* Toast - Config */

  private toastConfig: any = {
    timeOut: 3000,
    closeButton: true,
    progressBar: true,
    positionClass: 'toast-bottom-right',
  };
}
