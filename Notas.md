# Instalação Angular - Notas 02/07/2022

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


# Instalação Ngx Bootstrap/Font Awesome - Notas 09/07/2022

- Versão @fortawesome/fontawesome-free utilizada: 6.1.1
    - Instalação npm: npm i --save @fortawesome/fontawesome-free
    - Link em: https://www.npmjs.com/package/@fortawesome/fontawesome-free/
    - Adição de @import '../node_modules/@fortawesome/fontawesome-free/css/all.min.css' em styles.scss

- Versão do ngx bootstrap utilizada: 7.1.2 (Adicionado automaticamente)
    - Instalação npm: ng add ngx-bootstrap
    - Adição automática de arquivo scss bootstrap e datepicker em styles.scss

# Uso de FormsModule para filtragem de dados - ngModel - Notas 13/07/2022

- https://angular.io/api/forms/FormsModule


