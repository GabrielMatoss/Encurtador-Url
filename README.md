# 🔗 Encurtador de URL

Uma aplicação completa para encurtamento de URLs desenvolvida com **ASP.NET Core Web API**, **Entity Framework Core** e **PostgreSQL**, contendo uma interface web simples para utilização da API e documentação automática com Swagger.

---

# Sobre o Projeto

Este projeto foi desenvolvido com o objetivo de consolidar conhecimentos no ecossistema **.NET**, aplicando conceitos utilizados no desenvolvimento de APIs REST.

Durante o desenvolvimento foram utilizados conceitos como:

- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- Migrations
- DTOs (Data Transfer Objects)
- Swagger / OpenAPI
- User Secrets
- Operações Assíncronas (Async/Await)
- Front-End com HTML, CSS e JavaScript
- Consumo de API utilizando Fetch API
- Redirecionamento HTTP (302 Found)

A aplicação permite criar URLs encurtadas, consultar registros, atualizar informações, excluir URLs e redirecionar automaticamente para a URL original através de um código curto.

---

# Tecnologias Utilizadas

- C#
- ASP.NET Core 9
- Entity Framework Core
- PostgreSQL
- Swagger (Swashbuckle)
- HTML5
- CSS3
- JavaScript
- User Secrets
- Git

---

# Funcionalidades

- ✅ Criar URLs encurtadas
- ✅ Listar URLs cadastradas
- ✅ Buscar URL pelo código
- ✅ Atualizar URL
- ✅ Excluir URL
- ✅ Redirecionar automaticamente para a URL original
- ✅ Interface Web para utilização da API
- ✅ Documentação automática com Swagger

---

# Interface

## Tela Inicial

<img width="1918" height="836" alt="image" src="https://github.com/user-attachments/assets/308578d1-892b-450f-9e2f-1d23c35b90c8" />

---

## Swagger

<img width="1912" height="947" alt="image" src="https://github.com/user-attachments/assets/81f1e9a8-c64a-4744-ad91-a3d7ccb08951" />


---

# Estrutura da API

| Método | Endpoint | Descrição |
|----------|----------|----------|
| POST | `/api/ShortCutUrls` | Criar URL |
| GET | `/api/ShortCutUrls` | Listar URLs |
| GET | `/api/ShortCutUrls/{code}` | Buscar URL |
| PUT | `/api/ShortCutUrls/{code}` | Atualizar URL |
| DELETE | `/api/ShortCutUrls/{code}` | Remover URL |
| GET | `/r/{code}` | Redirecionar para a URL original |

---

# Interface Web

Após iniciar a aplicação, basta acessar:

```text
http://localhost:5120
```

A página inicial permite:

- Inserir uma URL
- Gerar uma URL encurtada
- Copiar a URL gerada para a área de transferência

---

# Documentação da API

A documentação completa da API pode ser acessada através do Swagger:

```text
http://localhost:5120/swagger
```

Todos os endpoints podem ser testados diretamente pelo navegador utilizando a interface do Swagger.

---

# Exemplo de Requisição

## Criar URL

```http
POST /api/ShortCutUrls
```

### Body

```json
{
    "url": "https://www.google.com"
}
```

### Resposta

```json
{
    "shortCode": "abc123",
    "shortUrl": "http://localhost:5120/r/abc123"
}
```

---

# Como Executar o Projeto

## Clonar o repositório

```bash
git clone https://github.com/GabrielMatoss/url-shortener-api.git
```

## Entrar na pasta

```bash
cd url-shortener-api
```

## Restaurar dependências

```bash
dotnet restore
```

## Configurar User Secrets

Inicialize o User Secrets:

```bash
dotnet user-secrets init
```

Configure sua string de conexão:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=shortcuturls;Username=postgres;Password=SUA_SENHA"
```

## Aplicar as Migrations

```bash
dotnet ef database update
```

## Executar a aplicação

```bash
dotnet run
```

Após iniciar, acesse:

```text
Aplicação:
http://localhost:5120

Swagger:
http://localhost:5120/swagger
```

---


### Este projeto foi desenvolvido para praticar:

- Desenvolvimento de APIs REST
- Comunicação entre Front-End e Back-End
- Persistência de dados utilizando Entity Framework Core
- Integração com PostgreSQL
- Organização de projetos ASP.NET Core
- Versionamento com Git
- Documentação automática utilizando Swagger
