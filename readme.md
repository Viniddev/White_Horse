# White Horse Inc.

![Badge Status](https://img.shields.io/badge/status-Em%20Desenvolvimento-yellow)
![Next.js](https://img.shields.io/badge/Next.js-%3E%3D%2012.0-blue)
![.NET](https://img.shields.io/badge/.NET-%3E%3D%206.0-blue)
![Licença](https://img.shields.io/badge/licen%C3%A7a-MIT-green)

Este projeto está sendo desenvolvido com o objetivo de criar um blog voltado para estudantes universitários de cursos relacionados à tecnologia. O objetivo é proporcionar um espaço para o compartilhamento de informações sobre estudos, cursos complementares e novidades na área de tecnologia.

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

**White Horse Inc** é um blog desenvolvido para facilitar o compartilhamento de informações relevantes sobre tecnologia entre estudantes universitários. A plataforma permite a publicação de artigos sobre estudos, cursos complementares, novas tendências do setor e demais conteúdos que possam auxiliar no crescimento acadêmico e profissional dos usuários.

A aplicação utiliza **Next.js** para renderização do lado do servidor e otimização de SEO, **TypeScript** para segurança de tipagem, **PrimeReact** para construção da interface do usuário e **ASP.NET Core** para gerenciamento do back-end.

## 🛠 Pré-requisitos

Antes de começar, certifique-se de ter o seguinte instalado:

- [Node.js](https://nodejs.org/) (versão 16 ou superior)
- [Git](https://git-scm.com/) (sempre necessário)
- [WSL](https://www.youtube.com/watch?v=o1_E4PBl30s) (Eu recomendaria uma distro do Debian)
- Editor de código, como [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)
- [SQL Server](https://blog.balta.io/sql-server-docker/) (opcional para banco de dados)
- [Docker](https://www.docker.com/) (opcional para ambientes isolados)

## 📦 Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/Viniddev/White_Horse_Inc.git
   ```
   
2. Abra o bash e execute o comando abaixo (isso irá gerar a sua JWT_KEY):
   ```bash
   openssl rand -base64 32
   ```
   
3. Adicione os user-secrets:
   ```bash
    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=[YOUR_DB];User ID=sa;Password=[YOUR_PASSWORD];TrustServerCertificate=True;Encrypt=True;Trusted_Connection=True;"
    dotnet user-secrets set "JwtKey" "[YOUR_JWT_KEY]"
   ```

## 📦 Estrutura do Projeto

1. Criação da estrutura do Back-End:
   ```bash
   dotnet new sln -n white_horse_inc
   dotnet new classlib -o white_horse_inc_api
   dotnet sln add ./white_horse_inc_api
   ```
   
2. Para rodar o SQL Server com o WSL:
   ```bash
   docker run -v ~/docker --name [YOUR_DB_NAME] -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=[YOUR_PASSWORD]" -p 1433:1433 -d mcr.microsoft.com/mssql/server
   ```

## 🚀 Tecnologias Utilizadas

- **Next.js**: Framework para desenvolvimento do front-end
- **TypeScript**: Superset do JavaScript para tipagem estática
- **ASP.NET Core 6 e .NET 9**: Back-end da aplicação
- **PrimeReact**: Biblioteca de componentes para UI
- **Docker**: Para virtualização de ambientes e banco de dados

## 🤝 Contribuição

Sinta-se à vontade para contribuir com o projeto! Para isso:

1. Faça um fork do repositório
2. Crie uma branch (`git checkout -b minha-feature`)
3. Faça as mudanças necessárias
4. Commit suas alterações (`git commit -m 'Adicionando nova funcionalidade'`)
5. Faça um push para a branch (`git push origin minha-feature`)
6. Abra um Pull Request

## 📜 Licença

Este projeto está sob a licença MIT.

## 📞 Contato

Caso tenha dúvidas ou sugestões, entre em contato:

- **E-mail**: diasvinicius95@outlook.com
- **LinkedIn**: [linkedin.com/in/vinícius-dias-rodrigues/](https://www.linkedin.com/in/vin%C3%ADcius-dias-rodrigues/)

---

Desenvolvido com ❤️ por Vinícius 🚀
