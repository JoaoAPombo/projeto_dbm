## Objetivo do Projeto

O projeto tem como objetivo principal desenvolver uma API utilizando C# para leitura de documentos .csv e importar os dados de usuários para o SQL server, além disso tem como objetivo utilizar Python para ler esses dados e permitir ao usuário do sistema realizar uma busca.

## As tecnologias que foram usadas neste projeto são:

- **C#**  
  Linguagem de programação utilizada para desenvolver a API.

- **.NET Core / ASP.NET Core**  
  Plataforma e framework para criação e execução da API.

- **Entity Framework Core**  
  ORM utilizado para gerenciar as migrações e a comunicação com o banco de dados.

- **SQL Server**  
  Banco de dados utilizado para armazenar os dados do projeto.

- **Python**  
  Linguagem utilizada para desenvolver o cliente que consome a API.

- **Tkinter**  
  Biblioteca padrão do Python para criação de interfaces gráficas.

- **dotnet CLI**  
  Ferramenta de linha de comando para restaurar, compilar e executar o projeto.

- **Batch Scripting (.bat)**  
  Scripts em batch para automação dos comandos do projeto.

- **Git**  
  Sistema de controle de versão para gerenciamento do código-fonte.

- **Visual Studio Code**  
  Editor de código utilizado para o desenvolvimento e execução dos scripts e projetos.

- **POSTMAN**  
  Para testes e envios de dados.


## Passos para execução do projeto C#

- **Entrar no diretório**  
    Primeiro deve-se entrar no diretório `.\projeto_dbm\api-csharp`

- **Verificar e atualizar a connection string**  
    Na pasta `.\appsettings.json` devemos ter certeza que a connection string está com o nome do servidor local, caso não esteja,
    devemos atualizar ela para conter o nome do servidor, "ConexaoPadrao": "Server={NomeDoServidor}\\..."

- **Inicializar A API**  
  Agora temos que rodar o comando  `.\run.bat` no terminal

- **UTILIZAR POSTMAN PARA SUBIR CSV**  
  Usando o PostMan usamos a API com caminho *http://localhost:5268/api/pessoas/importar-csv* para subir o arquivo  
  Lembrando que no PostMan temos que configurar a chamada na Aba Body colocarmos "form-data", no campo Key "arquivoCsv",  
  e em value o arquivo que iremos subir.

- **UTILIZAR POSTMAN PARA TESTAR CHAMADA**  
  Usando o PostMan usamos a API com caminho *http://localhost:5268/api/pessoas/{Id}*, podemos colocar qualquer id presente no banco,  
  para receber dados do usuário em formato JSON.

## Passos para execução do projeto Python

- **Entrar no diretório**  
    Primeiro deve-se entrar no diretório `.\projeto_dbm\cliente-python`

- **Inicializar o programa**  
    Agora já no diretório correto devemos colocar o comando `py main.py` no console para iniciar o programa.

## Exemplos de chamadas das APIS:

- **API POST C#**  ![Imagem1](https://github.com/user-attachments/assets/a5628958-6173-4b06-96fb-001004590afe)

- **RESULTADO**  ![Imagem2](https://github.com/user-attachments/assets/9e413b8f-7f11-40fb-bd71-aa0520c20d4f)

- **API GET C#**  ![Imagem3](https://github.com/user-attachments/assets/20f9a58a-dd98-4578-90da-e272a58b6678)

- **RESULTADO**  ![Imagem4](https://github.com/user-attachments/assets/c001c6b6-ab95-46be-9dfa-2e5a55d398df)


  

