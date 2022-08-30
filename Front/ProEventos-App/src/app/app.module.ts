import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//Biblioteca para HttpClientModule https://angular.io/api/common/http/HttpClientModule
import { HttpClientModule } from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";

import { EventoService } from './services/Evento.service';
import { DataFormatPipe } from './helpers/DataFormat.pipe';

import { NavComponent } from './shared/nav/nav.component';
import { TituloComponent } from './shared/titulo/titulo.component';

import { EventosComponent } from './components/eventos/eventos.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { EventosListaComponent } from './components/eventos/eventos-lista/eventos-lista.component';
import { EventosDetalheComponent } from './components/eventos/eventos-detalhe/eventos-detalhe.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegisterComponent } from './components/user/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    ContatosComponent,
    DashboardComponent,
    EventosComponent,
    EventosListaComponent,
    PalestrantesComponent,
    PerfilComponent,
    NavComponent,
    TituloComponent,
    DataFormatPipe,
    EventosDetalheComponent,
    UserComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      preventDuplicates: false
    }),
    NgxSpinnerModule,
    FormsModule
  ],
  providers: [EventoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
