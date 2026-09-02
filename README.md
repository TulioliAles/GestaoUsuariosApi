# API de Gestão de Usuários

API REST desenvolvida em **ASP.NET Core** para centralizar o cadastro e a persistência de usuários. O projeto demonstra a construção da base de um back-end moderno, com separação entre modelo de domínio e acesso a dados, banco relacional e documentação OpenAPI.

## Visão geral

A aplicação representa usuários por meio dos seguintes dados:

- nome;
- sobrenome;
- e-mail;
- CPF.

Essas informações são mapeadas pelo Entity Framework Core e armazenadas em uma tabela `Usuarios` no SQL Server. A estrutura está preparada para receber operações de cadastro, consulta, atualização e exclusão de usuários.

> **Status atual:** a camada de persistência e a configuração da aplicação estão implementadas. Os endpoints CRUD ainda serão adicionados.

## O que este projeto demonstra

- Desenvolvimento de APIs com **C# e ASP.NET Core**;
- Persistência de dados com **Entity Framework Core**;
- Integração com **SQL Server**;
- Criação e versionamento do banco por meio de **migrations**;
- Injeção de dependências para configuração do `DbContext`;
- Geração da especificação **OpenAPI** em ambiente de desenvolvimento;
- Uso de configurações externas para a conexão com o banco.

## Tecnologias

| Tecnologia | Finalidade |
| --- | --- |
| .NET 10 | Plataforma da aplicação |
| ASP.NET Core | Construção da API web |
| Entity Framework Core | Mapeamento e acesso aos dados |
| SQL Server | Banco de dados relacional |
| OpenAPI | Descrição e descoberta dos endpoints |

## Estrutura do projeto

```text
GestaoUsuariosApi/
├── Data/
│   └── AppDbContext.cs       # Contexto e acesso ao banco
├── Migrations/               # Histórico de criação do banco
├── Models/
│   └── User.cs               # Entidade de usuário
├── Program.cs                 # Configuração e pipeline da API
└── appsettings.json           # Configurações da aplicação
```

## Como executar localmente

### Pré-requisitos

- SDK do .NET 10;
- SQL Server ou SQL Server Express;
- ferramenta `dotnet-ef`, caso precise aplicar as migrations.

### Configuração

1. Clone o repositório:

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

3. Restaure as dependências e aplique a migration:

```bash
dotnet restore
dotnet ef database update --project GestaoUsuariosApi
```

4. Inicie a aplicação:

```bash
dotnet run --project GestaoUsuariosApi
```

Em desenvolvimento, a API utiliza por padrão:

- `https://localhost:7291`
- `http://localhost:5053`
- especificação OpenAPI: `https://localhost:7291/openapi/v1.json`

## Exemplo do recurso de usuário

Este é o formato de dados previsto para as futuras operações da API:

```json
{
  "id": 1,
  "nome": "Ana",
  "sobrenome": "Silva",
  "email": "ana.silva@email.com",
  "cpf": "12345678900"
}
```

## Próximos passos

- Implementar endpoints CRUD para usuários;
- Validar e-mail e CPF;
- Impedir cadastros duplicados;
- Adicionar DTOs para entrada e saída de dados;
- Criar tratamento global de erros;
- Adicionar testes automatizados;
- Proteger dados sensíveis e adicionar autenticação quando necessário;
- Disponibilizar uma interface interativa para a documentação da API.

## Objetivo profissional

Este projeto foi criado para praticar e demonstrar fundamentos de desenvolvimento back-end no ecossistema .NET: modelagem de entidades, configuração de banco de dados, migrations, injeção de dependências e preparação de uma API para evoluir de forma organizada.

