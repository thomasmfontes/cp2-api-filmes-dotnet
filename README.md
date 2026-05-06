# CP2 - API de Filmes e Avaliações

## Descrição do Projeto

Este projeto consiste em uma API RESTful desenvolvida em ASP.NET Core .NET 8, utilizando Controllers, Entity Framework Core, banco de dados Oracle e documentação com Swagger.

A API permite o gerenciamento de filmes e avaliações, oferecendo operações completas de CRUD para as duas entidades principais.

---

## Componentes Utilizados

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Oracle Database
- Swagger / OpenAPI
- Visual Studio 2022

---

## Como Rodar o Projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/thomasmfontes/cp2-api-filmes-dotnet.git
```

### 2. Entrar na pasta do projeto

```bash
cd Cp2FilmesApi
```

### 3. Restaurar os pacotes

```bash
dotnet restore
```

### 4. Configurar a conexão Oracle

Editar o arquivo:

```txt
appsettings.json
```

Preencher a connection string:

```json
"ConnectionStrings": {
  "OracleConnection": "CONFIGURAR_CONNECTION_STRING_AQUI"
}
```

### 5. Executar as migrations

```bash
dotnet ef database update
```

### 6. Rodar o projeto

```bash
dotnet run
```

### 7. Abrir o Swagger

```txt
https://localhost:7033/swagger
```

---

## Exemplos de Requisição (JSON)

### Cadastro de Filme

```json
{
  "titulo": "Interestelar",
  "genero": "Ficção Científica",
  "anoLancamento": 2014,
  "notaImdb": 8.7
}
```

### Cadastro de Avaliação

```json
{
  "usuario": "Eduardo",
  "comentario": "Excelente filme.",
  "nota": 5,
  "filmeId": 1
}
```

---

## Endpoints Disponíveis

### Filmes

| Método | Endpoint | Descrição |
|---|---|---|
| GET | /api/Filmes | Lista todos os filmes |
| GET | /api/Filmes/{id} | Busca filme por ID |
| GET | /api/Filmes/genero/{genero} | Busca filmes por gênero |
| POST | /api/Filmes | Cadastra um filme |
| PUT | /api/Filmes/{id} | Atualiza um filme |
| DELETE | /api/Filmes/{id} | Remove um filme |

---

### Avaliações

| Método | Endpoint | Descrição |
|---|---|---|
| GET | /api/Avaliacoes | Lista todas as avaliações |
| GET | /api/Avaliacoes/{id} | Busca avaliação por ID |
| GET | /api/Avaliacoes/filme/{filmeId} | Lista avaliações de um filme |
| POST | /api/Avaliacoes | Cadastra uma avaliação |
| PUT | /api/Avaliacoes/{id} | Atualiza uma avaliação |
| DELETE | /api/Avaliacoes/{id} | Remove uma avaliação |

---

## Estrutura do Projeto

```txt
/Controllers
    FilmesController.cs
    AvaliacoesController.cs

/Entities
    Filme.cs
    Avaliacao.cs

/Data
    AppDbContext.cs

/Migrations

README.md
Program.cs
appsettings.json
```

---

## Funcionalidades Implementadas

- CRUD completo de filmes
- CRUD completo de avaliações
- Integração com Oracle Database
- Migrations com Entity Framework Core
- Documentação automática com Swagger
- Validação com Data Annotations
- Relacionamento entre entidades
- Status codes HTTP apropriados

---

## Status Codes Utilizados

- 200 OK
- 201 Created
- 204 No Content
- 400 Bad Request
- 404 Not Found

---

## Integrantes

- Thomas Mineu Fontes - RM: 562254
