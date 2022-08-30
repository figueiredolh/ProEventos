# 02/07/2022

## Instalação Angular

- Versão do Angular CLI utilizada no projeto: v12.2.17

  - Versão do Node.js compatíveis com este CLI: "^12.14.1 || ^14.0.0"

    - descrito em "engines" https://unpkg.com/browse/@angular/core@12.0.0/package.json

  - Instalação do NVM para gerenciamento de versões Node

    - download em https://github.com/coreybutler/nvm-windows

  - Instalação da versão do Node 14.17.06

    - nvm install 14.17.6 (sem zero)

  - Utilização da versão no projeto

    - No Powershell (administrador): cd 'C:\Users\ubira\Desktop\Desenvolvimento Web\Curso Angular\ProEventos'
    - nvm use 14.17.6

  - Por fim, a instalação do Angular propriamente dita
    - npm i -g @angular/cli@12

- Para rodar comandos do Angular (ng) no PowerShell, é necessário executar o seguinte comando:
  - Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

## Extensões utilizadas VsCode

- Angular Essentials
- Angular Files
- Angular Snippets
- Angular Language Service

- Auto Rename Tag
- EsLint
- TsLint\*
- Peacock
- Prettier\*

# 09/07/2022

## Instalação Ngx Bootstrap/Font Awesome

- Versão @fortawesome/fontawesome-free utilizada: 6.1.1

  - Instalação npm: npm i --save @fortawesome/fontawesome-free
  - Link em: https://www.npmjs.com/package/@fortawesome/fontawesome-free/
  - Adição de @import '../node_modules/@fortawesome/fontawesome-free/css/all.min.css' em styles.scss

- Versão do ngx bootstrap utilizada: 7.1.2 (Adicionado automaticamente)
  - Instalação npm: ng add ngx-bootstrap
  - Adição automática de arquivo scss bootstrap e datepicker em styles.scss

# 13/07/2022

## Uso de FormsModule para filtragem de dados - ngModel - Notas 13/07/2022

- https://angular.io/api/forms/FormsModule

## Regras de negócio da aplicação - Interface IProEventosPersistence

- Comuns (a cada entidade)

  - Adicionar
  - Atualizar
  - Remover
  - Remover vários
  - Salvar mudanças (EF Core)

- Eventos

  - Retornar todos os eventos por Tema (com ou sem palestrantes)
  - Retornar todos os eventos (com ou sem palestrantes)
  - Retornar evento por Id (com ou sem palestrantes)

- Palestrantes
  - Retornar todos os palestrantes por Nome (com ou sem eventos)
  - Retornar todos os palestrantes (com ou sem eventos)
  - Retornar evento por Id (com ou sem eventos)

# 04/08/2022

## Uso de Providers (para um service):

- 1ª forma (mais usual): Declarar service (EventoService) <em>app.module.ts</em>

  - Permite o uso do Service para os componentes e módulos que estiverem descritos neste arquivo, presente nos campos declarations e imports, respectivamente. <strong>É declarado no campo providers<strong>.

      <code>
          @NgModule({
              declarations: [
                  AppComponent,
                  EventosComponent,
                  NavComponent
              ],
          imports: [
              BrowserModule,
              AppRoutingModule,
              HttpClientModule,
              BrowserAnimationsModule,
              CollapseModule.forRoot(),
              FormsModule
          ],
          providers: [EventoService],
          bootstrap: [AppComponent]
          })
      </code>

- 2ª forma: Declarar/Injetar Service no próprio componente (ex: eventos)

  - Declaração em @Component, provider presente em cada component. <strong>É declarado em providers</strong>

      <code>
          @Component({
              selector: 'app-eventos',
              templateUrl: './eventos.component.html',
              styleUrls: ['./eventos.component.scss'],
              providers: [EventoService]
          })
      </code>

- 3ª forma: Declarar/Injetar Service na raiz (root)
  - Declarado no próprio Service, em @Injectable. Permite o uso do Service para todos os componentes, de forma geral.

# 08/08/2022:

## Criação de DataPipe para formatar data no formato dd/MM/yyyy hh:mm

- Criar pasta helpers e gerar um novo pipe nele (sugestão: DataFormat)
- Importar o pipe em @ngModule, no campo declarations, em app.module.ts
- Estender a classe DatePipe com esta nova classe (DataFormatPipe)
- Em return null, alterar para return super.transform(value, 'dd/MM/yyyy hh:mm'). Ps: O método transform() está presente na classe pai DatePipe,
  sendo necessário a chamada da palavra super (papel semelhante ao base de C#);

## Uso de Tooltip, Dropdown e Modal:

- Tooltip para a indicação dos botões Editar e Excluir (https://valor-software.com/ngx-bootstrap/old/7.1.2/#/tooltip)
- Dropdown para o item de menu (https://valor-software.com/ngx-bootstrap/old/7.1.2/#/dropdowns)
- Modal como confirmação na exclusão de evento (https://valor-software.com/ngx-bootstrap/old/7.1.2/#/modals#confirm-window - importar ModalModule em app.module.ts e módulos javascript de Confirm Window no componente)

## Instalação e Uso de Ngx Toastr e Ngx Spinner:

- ngx-toastr

  - Objetivo/Uso: Alertar o usuário (front-end) do resultado de uma ação de forma interativa
  - Instalação e Uso em: https://www.npmjs.com/package/ngx-toastr
  - Configurações utilizadas:
    <code>
    Individual:
    {
    timeOut: 3000,
    closeButton: true,
    progressBar: true,
    positionClass: 'toast-bottom-right'
    }

          Global:
          {
              preventDuplicates: false;
          }

      </code>

- ngx-spinner
  - Objetivo/Uso: Identificar ao usuário (front-end) o processo de carregamento dos resultados
  - Instalação e Uso em: https://www.npmjs.com/package/ngx-spinner

## Atualizar versão do Angular

- Comando: ng update @angular/core @angular/

# 10/08/2022:

## Desafio Titulo

- Criar pasta shared
- Criar um componente para o Titulo e adicionar nela
- Declarar o componente em app.module.ts, no campo declarations

- Implementar Decorator @Input em titulo.components.ts (@Input() title: string | undefined)
- Formatar titulo.component.html com as devidas tags e data binding no seu conteúdo (Ex: {{title}})

- Dentro do componente a inserir o nome do titulo (title), adicionar o atributo title na tag app-titulo.

## Criação de novos componentes

- Palestrantes
- Dashboard
- Contatos
- Perfil

- Criação da pasta 'components' em app para uma melhor organização, a fim de abrigar todos os componentes

# 21/08/2022:

- Modificação de componente Titulo
- Criação de novo layout de Filtro - Mudar estilo do input
- Criação de botão para adicionar Evento
- Tornar tabelas mais responsivas
- Criação de SubComponentes e SubRotas para o componente Titulo
- Criação de novo layout de Filtro - Adicionar hover em linha da tabela (Adicionar mais registros BD)

# 28/08/2022 - 30/08/2022

- Criação de component User e subcomponentes Login e Register
- Moção de componente Perfil para User
- Criação de HTML básico de exemplo para Login
- Criação de HTML básico de exemplo para Register
- Ocultação da barra de menu para Login
