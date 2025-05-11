# Sistema de Agendamento para Espaços Terapêuticos — SHIVA ANANDA

## 📑 Índice
- [Descrição](#-descrição)
- [Funcionalidades](#-funcionalidades)
- [Fotos do sistema](#-Screensshots)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Como Rodar o Projeto](#-como-rodar-o-projeto)
  - [Pré-requisitos](#-pré-requisitos)
  - [Configuração do SQL Server](#-configuração-do-sql-server)
  - [Criando o Banco de Dados](#-criando-o-banco-de-dados)
  - [Rodando a Aplicação](#-rodando-a-aplicação)

---


## 📋 Descrição
Este é um sistema de agendamento e gestão desenvolvido para o **Espaço Terapêutico Shiva Ananda**, um pequeno negócio real focado em terapias integrativas. O projeto tem fins acadêmicos e também práticos, pois está sendo adotado e utilizado pela proprietária do espaço.

O sistema foi desenvolvido para facilitar o gerenciamento de atendimentos, clientes e estoque no contexto de massoterapias. Ele é voltado para uso local, de forma simples e direta, atendendo às necessidades reais de um espaço terapêutico. 


## ⚙️ Funcionalidades

- Cadastro, visualização e edição de **clientes**
- Cadastro, visualização e edição de **fichas de anamnese**
- Cadastro, visualização e baixa de **produtos vendidos ou utilizados**
- **Controle de estoque** com atualizações automáticas
- Sistema projetado para **uso local** pela responsável do espaço


> **Status do projeto:** Em desenvolvimento contínuo, com base sólida já funcional.

## Screnshots

![Tela Inicial](https://github.com/zequi11/Sistema-Agendamentos-SHIVA/blob/main/Screenshots/Tela_login.png?raw=true)
![Cadastro de Cliente](https://github.com/zequi11/Sistema-Agendamentos-SHIVA/blob/main/Screenshots/Tela_cadastro_clientes.png?raw=true)
![Tela de Agendamentos](https://github.com/zequi11/Sistema-Agendamentos-SHIVA/blob/main/Screenshots/Tela_agendamento.png?raw=true)

---

## 🛠 Tecnologias Utilizadas

- **C#** com Windows Forms
- **SQL Server** para banco de dados

## 🚀 Como Rodar o Projeto

### ⚙️ Pré-requisitos

Antes de começar, você precisa ter instalado em sua máquina:

- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/) com suporte a C# e Windows Forms

---

### 🛠️ Configuração do SQL Server

1. Instale e configure o SQL server de acordo com suas preferências
2. Após a instalação, abra o **SQL Server Management Studio (SSMS)**.
3. Na tela de login:
   - **Servidor:** `.\SQLEXPRESS` ou o nome que você escolheu durante a instalação
   - **Tipo de Autenticação:** Windows Authentication
4. Clique em **Conectar**.

---

### 🧱 Criando o Banco de Dados

1. No **SSMS**, com a conexão já aberta, clique no menu: File > Open > File...
2. Navegue até a pasta de onde clonou o projeto, exemplo: C:\Users\NoobMaster123\SistemaDeAgendamentos\database
3. Dê **duplo clique** no arquivo `criar_banco.sql`.
4. Com o script aberto, pressione **F5** ou clique em **"Execute"** para rodar o script e criar o banco de dados e as tabelas.

---

### 🖥️ Rodando a Aplicação

1. Abra o projeto no **Visual Studio** (`.sln`).
2. Verifique e ajuste a **string de conexão** no arquivo `Conexao.cs` para garantir que aponta para o SQL Server correto.
3. Compile o projeto (Ctrl + Shift + B).
4. Aperte F5 para rodar o sistema.

---

## 🤝 Contribuições

Atualmente o projeto é de uso privado e acadêmico, mas sugestões são bem-vindas por meio de *issues*. 
