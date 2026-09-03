# API de Gestão de Usuários

API REST para gerenciamento de usuários, desenvolvida com **ASP.NET Core**, **MediatR**, **CQRS**, **Entity Framework Core** e **SQL Server**.

O projeto implementa um CRUD completo de usuários e demonstra uma arquitetura organizada por casos de uso. Em vez de concentrar regras de negócio nos controllers, cada operação é representada por um Command ou uma Query e processada pelo seu próprio Handler por meio do MediatR.

## O que a API faz

A API permite cadastrar, listar, consultar por ID, atualizar e excluir usuários. Cada usuário possui nome, sobrenome, e-mail e CPF, persistidos em um banco SQL Server por meio do Entity Framework Core.

## Arquitetura com CQRS e MediatR

O principal destaque técnico deste projeto é a aplicação do padrão **CQRS (Command Query Responsibility Segregation)** em conjunto com o **MediatR**.

O CQRS separa as operações que alteram o estado da aplicação das operações que apenas consultam dados:

| Tipo | Responsabilidade | Implementações |
| --- | --- | --- |
| Commands | Alterar o estado dos dados | `CreateUserCommand`, `UpdateUserCommand` e `DeleteUserCommand` |
| Queries | Consultar dados sem modificá-los | `GetAllUsersQuery` e `GetByIdUsersQuery` |
| Handlers | Executar um único caso de uso | Um handler específico para cada command ou query |

O MediatR atua como mediador entre a camada HTTP e os casos de uso. O `UsersController` recebe a requisição e envia uma mensagem por meio de `IMediator`. A biblioteca localiza o handler correspondente, que executa a operação no banco de dados.

```text
Cliente HTTP
     │
     ▼
UsersController
     │  envia Command ou Query
     ▼
   MediatR
     │  direciona a mensagem
     ▼
Handler específico
     │
     ▼
Entity Framework Core ──► SQL Server
```

Essa organização reduz o acoplamento do controller, deixa cada classe com uma responsabilidade clara e facilita a evolução e os testes isolados dos casos de uso.

## Tecnologias utilizadas

| Tecnologia | Finalidade |
| --- | --- |
| .NET 10 | Plataforma de desenvolvimento |
| ASP.NET Core | Construção da API REST |
| MediatR | Mediação e despacho de commands e queries |
| CQRS | Separação entre operações de escrita e leitura |
| Entity Framework Core | Mapeamento objeto-relacional e acesso aos dados |
| SQL Server | Persistência relacional dos usuários |
| OpenAPI | Especificação dos endpoints |
| Scalar | Interface interativa para explorar e testar a API |

## Estrutura do projeto

O projeto utiliza organização por funcionalidade, mantendo cada command ou query junto de seu respectivo handler:

```text
GestaoUsuariosApi/
├── Controllers/
│   └── UsersController.cs
├── Data/
│   └── AppDbContext.cs
├── Features/
│   └── Users/
│       ├── Commands/
│       │   ├── Create/
│       │   ├── Update/
│       │   └── Delete/
│       └── Queries/
│           ├── GetAllUsers/
│           └── GetByIdUsers/
├── Migrations/
├── Models/
│   └── User.cs
├── Program.cs
└── appsettings.json
```

## Endpoints

A rota base do recurso é `/api/users`.

| Método | Rota | Ação | Resposta esperada |
| --- | --- | --- | --- |
| `POST` | `/api/users` | Cadastra um usuário | `201 Created` |
| `GET` | `/api/users` | Lista todos os usuários | `200 OK` |
| `GET` | `/api/users/{id}` | Consulta um usuário | `200 OK` ou `404 Not Found` |
| `PUT` | `/api/users` | Atualiza um usuário | `204 No Content` ou `404 Not Found` |
| `DELETE` | `/api/users/{id}` | Exclui um usuário | `204 No Content` ou `404 Not Found` |

## Exemplos de uso

### Cadastrar um usuário

```http
POST /api/users
Content-Type: application/json

{
  "nome": "Ana",
  "sobrenome": "Silva",
  "email": "ana.silva@email.com",
  "cpf": "12345678900"
}
```

### Listar usuários

```http
GET /api/users
```

Exemplo de resposta:

```json
[
  {
    "id": 1,
    "nome": "Ana",
    "sobrenome": "Silva",
    "email": "ana.silva@email.com",
    "cpf": "12345678900"
  }
]
```

### Consultar um usuário

```http
GET /api/users/1
```

### Atualizar um usuário

```http
PUT /api/users
Content-Type: application/json

{
  "id": 1,
  "nome": "Ana Paula",
  "sobrenome": "Silva",
  "email": "ana.paula@email.com",
  "cpf": "12345678900"
}
```

### Excluir um usuário

```http
DELETE /api/users/1
```

## Como executar localmente

### Pré-requisitos

- SDK do .NET 10;
- SQL Server ou SQL Server Express;
- ferramenta `dotnet-ef` para aplicar as migrations.

### Instalação

1. Clone o repositório e entre na pasta da solução:

```bash
git clone <URL-DO-REPOSITORIO>
cd GestaoUsuariosApi
```

2. Configure sua conexão com o SQL Server em `GestaoUsuariosApi/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=BdProd;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

3. Restaure as dependências e atualize o banco:

```bash
dotnet restore
dotnet ef database update --project GestaoUsuariosApi
```

4. Execute a aplicação:

```bash
dotnet run --project GestaoUsuariosApi
```

A configuração de desenvolvimento utiliza os endereços `https://localhost:7291` e `http://localhost:5053`.

Com a aplicação em execução no ambiente de desenvolvimento, a documentação interativa do Scalar fica disponível em `https://localhost:7291/scalar/v1` e o documento OpenAPI em `https://localhost:7291/openapi/v1.json`.

## Decisões técnicas demonstradas

- Controllers enxutos, responsáveis somente pela camada HTTP;
- Casos de uso independentes representados por records do MediatR;
- Um handler por operação, seguindo o princípio da responsabilidade única;
- Separação explícita entre leitura e escrita com CQRS;
- Registro automático dos handlers por assembly;
- Acesso assíncrono ao banco de dados;
- Injeção de dependências do `AppDbContext` e do `IMediator`;
- Versionamento do esquema do banco com migrations.

## Possíveis evoluções

- Adicionar validação de entrada para e-mail e CPF;
- Impedir cadastros duplicados;
- Criar DTOs específicos para as respostas da API;
- Propagar o `CancellationToken` nas operações do Entity Framework Core;
- Adicionar tratamento global de erros;
- Criar testes unitários para os handlers e testes de integração para os endpoints;
- Adicionar autenticação e autorização.

## Objetivo profissional

Este projeto demonstra conhecimentos de desenvolvimento back-end no ecossistema .NET, com ênfase em **organização arquitetural, baixo acoplamento e separação de responsabilidades usando MediatR e CQRS**, além de persistência de dados, migrations, injeção de dependências e documentação de APIs.
