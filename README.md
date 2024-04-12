
# Biblioteca API 📚

Esta API teve como objetivo realizar um controle de empréstimos de uma biblioteca, onde teremos dois tipos de usuários com finalidades diferentes.
- O Administrador irá gerenciar o sistema, realizando CRUD de Livros, Cópias de livros e Empréstimos;
- O Cliente poderá acessar o sistema para solicitar seus empréstimos de livros.

## Executar

Após baixar o repositório, abra o terminal na pasta onde foi baixado e execute os seguintes comandos:

Entrando na pasta do projeto

```bash
  cd api-library-app
```

Executando a aplicação

```bash
  dotnet run
```
    
## Variáveis de Ambiente

Para rodar esse projeto, você vai precisar adicionar as seguintes variáveis de ambiente no arquivo `env.json` que deve ser criado.

`BibliotecaApiDb` --> String de conexão com o banco de dados (SQL SERVER);

`SecretKey` --> String contendo sua chave secreta para criptografia de informações;

Dentro do projeto possui um arquivo `env.example.json` de exemplo.
## Tecnologias utilizadas

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white)



