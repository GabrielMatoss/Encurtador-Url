# Encurtador de URL

API REST para encurtamento de URLs desenvolvida com ASP.NET Core, Entity Framework Core e PostgreSQL.

## Sobre o Projeto

Este projeto foi desenvolvido com o objetivo de revisar e consolidar conceitos da plataforma .NET, incluindo:

- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Migrations
- DTOs
- Swagger/OpenAPI
- Validações com Data Annotations
- User Secrets
- Operações assíncronas (Async/Await)

A aplicação permite criar, consultar, atualizar e remover URLs encurtadas, além de redirecionar para a URL original através do código gerado.


## Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Swagger (Swashbuckle)
- User Secrets
- Git


## Funcionalidades

### Criar URL Encurtada

Cria um novo registro contendo a URL original e um código curto.

### Listar URLs

Retorna todas as URLs cadastradas.

### Buscar URL por Código

Retorna os dados de uma URL encurtada específica.

### Atualizar URL

Permite alterar a URL original associada a um código.

### Remover URL

Exclui uma URL encurtada do sistema.

### Redirecionamento

Redireciona automaticamente para a URL original através do código curto.


## Estrutura da API

| Método | Endpoint | Descrição |
|----------|----------|----------|
| POST | `/api/shorturls` | Criar URL |
| GET | `/api/shorturls` | Listar URLs |
| GET | `/api/shorturls/{code}` | Buscar URL |
| PUT | `/api/shorturls/{code}` | Atualizar URL |
| DELETE | `/api/shorturls/{code}` | Remover URL |
| GET | `/r/{code}` | Redirecionar URL |


## Exemplo de Requisição

### Criar URL

```http
POST /api/shorturls
```

```json
{
  "url": "https://www.google.com"
}
```

### Resposta

```json
{
  "id": 1,
  "originalUrl": "https://www.google.com",
  "shortCode": "abc123",
  "createdAt": "2026-06-14T15:30:00Z"
}
```



## Executando o Projeto

### Clonar Repositório

```bash
git clone https://github.com/GabrielMatoss/url-shortener-api.git
```

### Entrar na Pasta

```bash
cd url-shortener-api
```

### Restaurar Dependências

```bash
dotnet restore
```

### Configurar User Secrets

```bash
dotnet user-secrets init
```

```bash
dotnet user-secrets set \
"ConnectionStrings:DefaultConnection" \
"Host=localhost;Port=5432;Database=shortcuturls;Username=postgres;Password=SUA_SENHA"
```

### Aplicar Migrations

```bash
dotnet ef database update
```

### Executar Aplicação

```bash
dotnet run
```



## Swagger

Após iniciar a aplicação:

```text
http://localhost:5120/swagger
```


## Melhorias Futuras

- Middleware Global de Exceções
- Testes Unitários
- Deploy em ambiente cloud
- Métricas de acesso às URLs


