# TransactionAPI

## Visão Geral

TransactionAPI é uma API desenvolvida em prol de um teste técnico utilizando .NET 9 que gerencia transações financeiras e usuários. Ela permite criar, lista e excluir usuários, além de registrar e listar transações apresentando o balanço total. O sistema segue práticas de arquitetura, incluindo **Repository Pattern** e **Service Layer**.

## Arquitetura

A API segue uma arquitetura modular baseada em **DDD (Domain-Drive-Design)** e seperação de responsabilidades, organizada nos seguintes projetos:

### Estrutura do Projeto

```
TransactionAPI/
│── Transaction.API/            # Camada de apresentação (Controllers)
│── Transaction.Application/    # Camada de aplicação (Services)
│── Transaction.Domain/         # Camada de domínio (Entidades, DTOs e Enums)
│── Transaction.Infra/          # Camada de infraestrutura (Repositorios e banco de dados)
```

## Tecnologias Utilizadas

- .NET 9
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger

## Passos Para Rodar A API Localmente

1. Clone este repositório:

```
git clone https://github.com/diegoNZ04/teste-transacoes.git
cd teste-transactoes/TransactionAPI
```

2. Execute as migrações do banco de dados:

```
dotnet ef database update
```

3. Execute a API:

```
dotnet run --project Transaction.API
```

4. Acesse a API:

```
http://localhost:5123
```

## Endpoints

A API contém os seguintes endpoints:

### UserController (Gerenciamento de Usuários)

POST `/api/users/create-user` - Cria novo usuário. Status Code: 201 Created.

DELETE `/api/users/delete-user/{id}` - Deleta um usuário pelo ID e todas as transações relacionadas a ele. Status Code: 204 No Content / 404 NoFound.

GET `/api/users/get-all-users` - Retorna todos os usuários com o balanço geral de receitas, despesas e saldo, abaixo retorna uma lista com o balanço total do sistema. Status Code: 200 Ok / 404 NotFound.

GET `/api/users/get-by-user-id/{id}` - Retorna um usuário pelo ID com a lista de suas transações. Status Code: 200 Ok / 404 NotFound.

### TradeController (Gerenciamento de Transações)

POST `/api/trades/create-trade` - Cria uma nova transação relacionada ao ID de um usuário. Status Code: 201 Created.

GET `/api/trades/get-all-trades` - Retorna todas as trasações com o ID do usuário relacionado. Status Code: 200 Ok / 204 NoContent.

GET `/api/trades/get-trade-by-id/{id}` - Retorna uma transação pelo ID com o ID do usuário relacionado. Status Code: 200 Ok / 404 NotFound.

## Contatos

Email: diegoamorim03152004@gmail.com

GitHub: github.com/diegoNZ04
