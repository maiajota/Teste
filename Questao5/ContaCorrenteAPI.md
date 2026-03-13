## 🏦 Questão 5 - API de Controle Bancário
Sistema de API REST desenvolvido em ASP.NET Core 6.0 para gerenciamento de contas correntes, permitindo a realização de movimentações financeiras e consulta de saldos consolidados.

## 📖 Sobre o Projeto

O projeto simula o backend de um banco, onde é necessário processar transações de crédito e débito com regras de negócio rigorosas, garantindo a integridade dos dados e a persistência em um banco de dados leve (SQLite)

## 🛠️ Tecnologias e Arquitetura

O projeto foi construído seguindo padrões de mercado para garantir manutenibilidade e performance:

- Framework: .NET 6.0 Web API

- Banco de Dados: SQLite

- Acesso a Dados (ORM): Dapper (para consultas SQL)

- Documentação: Swagger (OpenAPI)

### Padrões de Projeto:

- Service Layer: Concentra as regras de negócio.

- Repository Pattern: Abstração da camada de dados.

- Dependency Injection: Inversão de controle para desacoplamento.

```
Questao5/
├── Domain/
│   ├── Entities/      # Entidades do banco (ContaCorrente, Movimento)
│   └── Language/      # DTOs de Request e Response
├── Infrastructure/
│   ├── Services/      # Lógica de negócio e Controllers
│   └── Sqlite/        # Scripts de bootstrap e Repositórios
└── database.sqlite    # Arquivo do banco de dados
```

## 🚀 Como Executar

### 1. Pré-requisitos: SDK .NET 6.0

### 2.Clonar o repositório
```bash
git clone https://github.com/maiajota/Teste.git
```

### 3. Entrar na pasta
```bash
cd Questao5
```

### 4. Executar o projeto
```bash
dotnet run
```

### 5. Acessar a documentação
```bash
https://localhost:7140/swagger/index.html
```

## 
