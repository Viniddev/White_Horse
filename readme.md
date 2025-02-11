# White Horse Inc.

![Badge Status](https://img.shields.io/badge/status-Em%20Desenvolvimento-yellow)
![Next.js](https://img.shields.io/badge/Next.js-%3E%3D%2012.0-blue)
![.NET](https://img.shields.io/badge/.NET-%3E%3D%206.0-blue)
![Licença](https://img.shields.io/badge/licen%C3%A7a-MIT-green)

Este projeto está sendo desenvolvido com o objetivo de criar um e-commerce de peças de carro de luxo. Durante o desenvolvimento, estamos utilizando as tecnologias mais modernas e robustas para garantir uma experiência de compra premium para os usuários. O projeto é baseado no conceito de oferecer uma plataforma intuitiva e segura, utilizando Next.js, TypeScript, Styled Components e ASP.NET Core.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Contato](#contato)

---

## 🚀 Sobre o Projeto

**White Horse Inc** é um e-commerce especializado em peças de carro de luxo. A ideia é fornecer uma plataforma de fácil navegação onde os usuários podem encontrar peças automotivas exclusivas e acessórios premium para seus veículos de luxo. O projeto foca em uma experiência de compra fluida e segura, utilizando as tecnologias mais atuais para o front-end e back-end.

A aplicação utiliza **Next.js** para renderização do lado do servidor e otimização de SEO, **TypeScript** para segurança de tipagem, **Styled Components** para design de componentes, **PrimeReact** para UI, e **ASP.NET Core** com **ASP.NET Identity** para segurança e gerenciamento de usuários.

## 🛠 Pré-requisitos

Antes de começar, certifique-se de ter o seguinte instalado:

- [Node.js](https://nodejs.org/) (versão 16 ou superior)
- [Git](https://git-scm.com/) (sempre necessario)
- [WSL](https://www.youtube.com/watch?v=o1_E4PBl30s)  (Eu recomendaria uma distro do Debian)
- Editor de código, como [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- [SQL Server](https://blog.balta.io/sql-server-docker/) (opcional para banco de dados)
- [Docker](https://www.docker.com/) (opcional para ambientes isolados)


## 📦 Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/Viniddev/White_Horse_Inc.git
   
2. Abra o bash e execute o comando abaixo (isso irá gerar a sua JWT_KEY):
   ```bash
   openssl rand -base64 32
   
3. Adicione os user-secrets:
   ```bash
    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=[YOUR_DB];User ID=sa;Password=[YOUR_PASSWORD];TrustServerCertificate=True;Encrypt=True;Trusted_Connection=True;"
    dotnet user-secrets set "JwtKey" "[YOUR_JWT_KEY]"


## 📦 Estrutura do Projeto

1. Criação da estrutura do Back-End:
   ```bash
   dotnet new sln -n white_horse_inc
   dotnet new classlib -o white_horse_inc_api
   dotnet sln add ./white_horse_inc_api
   
2. Para rodar o SqlServer com o Wsl:
   ```bash
   docker run -v ~/docker --name [YOUR_DB_NAME] -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=[YOUR_PASSWORD]" -p 1433:1433 -d mcr.microsoft.com/mssql/server