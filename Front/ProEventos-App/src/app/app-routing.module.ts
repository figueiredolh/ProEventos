import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventosDetalheComponent } from './components/eventos/eventos-detalhe/eventos-detalhe.component';
import { EventosListaComponent } from './components/eventos/eventos-lista/eventos-lista.component';

import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { LoginComponent } from './components/user/login/login.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { RegisterComponent } from './components/user/register/register.component';
import { UserComponent } from './components/user/user.component';

const routes: Routes = [
  {path: 'eventos', redirectTo: 'eventos/lista'},
  {
    path: 'eventos', component: EventosComponent,
    children: [
      {path: 'lista', component: EventosListaComponent},
      {path: 'detalhe', component: EventosDetalheComponent}
    ]
  },
  {path: 'palestrantes', component: PalestrantesComponent},
  {path: 'contatos', component: ContatosComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'user', redirectTo: 'user/perfil'},
  {
    path: 'user', component: UserComponent,
    children: [
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegisterComponent},
      {path: 'perfil', component: PerfilComponent}
    ]
  },
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
   declarations: []
})
export class AppRoutingModule { }
