# EstacionamentoApp

Sistema de gerenciamento de estacionamento desenvolvido em **C#** como projeto de estudo de **Programação Orientada a Objetos (POO)** e organização de código em camadas.

O sistema permite cadastrar veículos, registrar entradas e saídas do estacionamento, controlar vagas disponíveis e gerar histórico de estadias com cálculo automático de preço.

---

# Funcionalidades

* Cadastro de veículos
* Registro de entrada no estacionamento
* Registro de saída com cálculo de valor
* Controle de vagas disponíveis e ocupadas
* Listagem de veículos estacionados
* Histórico de estadias

---

# Tecnologias Utilizadas

* C#
* .NET
* LINQ
* Programação Orientada a Objetos (POO)
* Console Application

---

# Conceitos Aplicados

Durante o desenvolvimento deste projeto foram aplicados diversos conceitos importantes de desenvolvimento em C#:

### Programação Orientada a Objetos

* Herança (`Veiculo` → `Carro`, `Moto`, `Caminhao`)
* Encapsulamento
* Abstração
* Polimorfismo

### Organização de Código

Separação de responsabilidades em camadas:

* **Models** → Representação das entidades do sistema
* **Services** → Regras de negócio e lógica da aplicação
* **Enums** → Tipos fixos utilizados no sistema
* **Interfaces** → Contratos de comportamento

### Estruturas e recursos da linguagem

* `enum`
* `List<T>`
* LINQ (`Where`, `Any`, `Select`, `OrderBy`)
* `TimeSpan`
* `DateTime`
* `override ToString()`

---

# Estrutura do Projeto

```
EstacionamentoApp
│
├── Enums
│   └── TipoVeiculo
│
├── Interfaces
│   └── ICobravel
│
├── Models
│   ├── Veiculo
│   ├── Carro
│   ├── Moto
│   ├── Caminhao
│   ├── Vaga
│   └── Estadia
│
├── Services
│   ├── EstacionamentoService
│   └── PagamentoService
│
└── Program.cs
```

---

# O que eu aprendi com este projeto

Durante o desenvolvimento deste sistema eu aprendi a:

* Modelar um problema do mundo real em código
* Organizar um projeto em camadas
* Utilizar herança para especializar comportamentos
* Criar e utilizar `enum` para evitar uso de strings
* Aplicar LINQ para consultas em coleções
* Trabalhar com datas e tempo utilizando `DateTime` e `TimeSpan`
* Implementar regras de negócio separadas da interface do usuário
* Utilizar `override ToString()` para melhorar a exibição de dados
* Criar um fluxo completo de entrada e saída de dados em uma aplicação console

---

# Possíveis melhorias futuras

Este projeto pode evoluir para algo mais completo com as seguintes melhorias:

### Persistência de dados

Atualmente os dados ficam apenas em memória. Futuramente poderia ser adicionado:

* Entity Framework
* SQLite ou SQL Server

Para salvar os dados permanentemente.

---

### Transformar em API

Criar uma versão web utilizando:

* ASP.NET Web API
* Entity Framework

Permitindo que outros sistemas ou aplicações consumam o serviço.

---

### Interface gráfica

Adicionar uma interface mais amigável:

* Web (ASP.NET MVC / React / Blazor)
* Desktop (WPF ou WinForms)

---

### Melhorias de arquitetura

* Implementar **Repository Pattern**
* Implementar **Dependency Injection**
* Separar melhor a camada de apresentação da lógica

---

# Objetivo do Projeto

O objetivo deste projeto é **praticar conceitos fundamentais de desenvolvimento em C#** e melhorar a organização de código seguindo boas práticas de programação.

---
