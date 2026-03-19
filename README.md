# 📇 API de Contatos - ASP.NET Core (.NET)

🚀 Projeto desenvolvido com o objetivo de praticar e consolidar conhecimentos em desenvolvimento de APIs utilizando **C# e ASP.NET Core**.

---

## 📌 Sobre o projeto

Esta é uma API simples de gerenciamento de contatos, contendo operações completas de CRUD (Create, Read, Update, Delete).

Além disso, o projeto utiliza **programação assíncrona (async/await)**, seguindo boas práticas modernas de desenvolvimento backend.

---

## 🛠️ Tecnologias utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- SQL Server
- LINQ

---

## ⚙️ Funcionalidades

✅ Criar um novo contato  
✅ Listar todos os contatos  
✅ Buscar contato por ID  
✅ Atualizar contato  
✅ Deletar contato  

---

## ⚡ Conceitos aplicados

- Programação assíncrona com `async/await`
- Boas práticas em Web API
- Integração com banco de dados via Entity Framework

---

## ▶️ Como executar o projeto

### 1. Clone o repositório

```bash
git clone https://github.com/theusmaximiano/api-contatos-dotnet-.git
```

### 2. Acesse a pasta do projeto

```bash
cd api-contatos-dotnet
```

### 3. Configure o banco de dados

- Verifique a string de conexão no arquivo `appsettings.json`
- Certifique-se de que o SQL Server está rodando

### 4. Execute as migrations (se houver)

```bash
dotnet ef database update
```

### 5. Execute o projeto

```bash
dotnet run
```