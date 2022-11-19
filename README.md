<h1 align="center"> API Sistema de Gerenciamento de Senhas </h1>

<div align="center">
  <img src="https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-   studio&logoColor=white">
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white">
  <img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white">
  <img src="https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white">
  <img src="https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white">
</div>

<p><p/>

<p align="center"><img src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge">

<p align="center">   Projeto que propõe a criação de uma API utilizando ASP.NET6 com o intuito de demonstrar conhecimento para o treinamento Jovens Profissionais da <b>Indra - Minsait (Formação .Net e Angular)</b>.</p>


<h2>Descrição do projeto</h2>
<p align="justify">Esse projeto em especifico apresenta a implementação de duas API RESTful, citada anteriomente, para um sistema de Gerenciamento de Senhas com funcionalidades basicas, tendo como metodo de requisição HTTP associado com sistema de gerenciamento de banco de dados MySQL. A API "GerenteDeSenha" é responsavel pela criação de usuarios e manipulação dos mesmos, já a API "SenhasAPI" é responsavel pelo CRUD de senhas a partir de um usuário já cadastrado. A criação e conexão com o banco de dados é feita utilizando Entity Framework, como auxilio a visualização da implementação é utilizado o Swagger, para gerenciar os acessos e geração de Tokens foi utilizado o Identity Framework.</p>


<h1>Tecnologias Utilizadas</h1>

<h2>C# / .NET6</h2>>
<p>Linguagem das API's e Framework Utilizado<p>

<h2>Visual Basic</h2>
<p>Foi utilizado a IDE como ambiente de densenvolvimento das API's.</p>

<h3>Pacotes Nuget</h3>
<p>Foram utilizados os seguintes pacotes Nuget, e suas versões, como ferramentas, de forma a auxiliar o desenvolvimento da aplicação em varias frentes.</p>

```
  "AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.0"
	"FluentResults" Version="3.15.0"
	"MailKit" Version="3.4.2"
	"Microsoft.AspNetCore.Identity" Version="2.2.0"
	"Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.11"
	"Microsoft.EntityFrameworkCore" Version="6.0.11"
	"Microsoft.EntityFrameworkCore.Proxies" Version="6.0.11"
	"Microsoft.EntityFrameworkCore.Relational" Version="6.0.11"
  "Microsoft.EntityFrameworkCore.Tools" Version="6.0.11"
  "Microsoft.Extensions.Identity.Stores" Version="6.0.11"
	"MimeKit" Version="3.4.2"
	"Pomelo.EntityFrameworkCore.MySql" Version="6.0.2"
	"Microsoft.EntityFrameworkCore.Design" Version="6.0.11"
  "Swashbuckle.AspNetCore" Version="6.4.0"
  "System.IdentityModel.Tokens.Jwt" Version="6.25.0"
```

<h2>Configurando o projeto</h2>
<p>Para configuração do projeto abra o terminal de sua preferência e no diretorio do projeto execute os comandos abaixo:</p>

```
dotnet user-secrets init
dotnet user-secrets set “EmailSettings:From” “<SEU-EMAIL>”
dotnet user-secrets set “EmailSettings:SmtpServer” “smtp.gmail.com”
dotnet user-secrets set “EmailSettings:Port” “465”
dotnet user-secrets set “EmailSettings:Port” “<SUA-SENHA>”
```
<p>Nos campos "SEU-EMAIL" e "SUA-SENHA" altere para o email e senha que enviará o codigo de verificação de e-mail para os novos usuários.<p>

<h2>Desenvolvedores do projeto</h2>
<img src="https://avatars.githubusercontent.com/u/106783873?v=4" width=115><h5><b>Matheus Araújo<b></h5>

<h2>Licença</h2>
The <a href="https://github.com/mmatheusaraujoo/ProjetoIndraMinsait-GerenteDeSenhasAPI/blob/97752882e6422ad15be1e0c1b61fd281efb26307/LICENSE">[MIT License]</a> (MIT)
<br>Copyright :copyright: 2022 - Matheus Araújo
