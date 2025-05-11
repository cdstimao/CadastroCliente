# Cadastro de Clientes

Este é um sistema completo de cadastro de clientes desenvolvido com **Angular** no front-end e **.NET 8 (Web API)** no back-end, utilizando boas práticas de arquitetura como **DDD**, **CQRS** e **Event Sourcing**. O projeto está preparado para execução via **Docker Compose**, com banco de dados **SQL Server**.

---

## 🚀 Tecnologias Utilizadas

### Backend (.NET 8)
- ASP.NET Core 8 Web API
- Entity Framework Core
- DDD (Domain Driven Design)
- CQRS (Command Query Responsibility Segregation)
- Event Sourcing
- FluentValidation
- Testes unitários (xUnit)
- Docker

### Frontend (Angular)
- Angular 17+
- Reactive Forms
- Validações reativas
- Comunicação com a API via HttpClient
- Angular CLI
- Docker

### Banco de Dados
- SQL Server 2022 (container Docker)

---

## 🧱 Arquitetura

- **DDD**: Separação em camadas (Domínio, Aplicação, Infraestrutura e API)
- **CQRS**: Separação entre comandos (escrita) e queries (leitura)
- **Event Sourcing**: Cada ação importante no sistema gera um evento
- **Validações**: Usando `FluentValidation` no back-end e Reactive Forms no front-end

---

## 🐳 Como Executar com Docker Compose

### Pré-requisitos
- Docker e Docker Compose instalados

### Passos

1. Clone o repositório:

```bash
git clone https://github.com/cdstimao/CadastroCliente.git
cd CadastroCliente
