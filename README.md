# Poc-EntityFrameworkCore
Projeto de console usando EntityFrameworkCore para o desenvolvimento de um sistema de pedidos. 
<br>
<em>Curso realizado por Rafael Almeida - desenvolvimento.io.</em>

## Conceitos Introdutórios

### O que é um ORM?
O ORM (Object Relational Mpping) possibilita o mapeamento das classes do projeto com as tabelas de um banco de dados. Ele tem a responsabilidade de gerar os comandos e interagir com o banco de dados.

### Orientação a Objetos x Modelo Relacional e uso do ORM
A <b>Orientação a Objetos</b> pode representar a estrutura de dados em diferentes formas: herança, polimorfismo e composição são algumas delas. Já o <b>Modelo Relacional</b> tem o principal objetivo de ser um repositório para armazenar e entregar os dados para o consumidor. <b>O ORM é a fonte entre o mundo real da POO (Programação Orientada a Objetos) e o mundo relacional. Ele manipula os objetos e os transformam em comandos que serão executados em um banco de dados.</b>

Lembrando que o mundo relacional foi apresentado por Edgard Frank em 1970 e a cardinalidade é um dos principais princípios. É através da <b>cardinalidade</b> que é decidido o grau de relação entre duas tabelas. Pode ser representado por 1:1, 1:N e N:N.

### O que é o Entity FrameworkCore?
O papel que o Entity Framework Core (EFC) desempenha é o de um ORM. Ele nos permite focar exatamente nas regras de negócios, abstraindo totalmente a camada de acesso ao banco de dados, ou seja, você não precisa escrever nenhum comando SQL em sua aplicação.

#### Vantagens: 
<ul>
  <li>Permitir que os desenvolvedores escrevam o acesso de banco de dados de uma forma mais rápida: escrever menos código, não se preocupar com a camada de acesso a dados e ter uma única interface para pode ser comunicar com qualquer banco de dados que seja suportado pelo o ORM;</li>
  <li>Aumentar a produtividade do desenvolvimento;</li>
  <li>Multiplataforma</li>
</ul>

## Conceitos Principais EFC

### Code First:
Recurso do EFC que permite o mapeamento/persistência de classes que, posteriormente, irão se materializar em tabelas do banco de dados. O CodeFirst permite o mapeamento necessário como customizar o nome das tabelas, o nome dos campos, criar índice e relacionamentos. Caso seja necessário adicionar outro campo na solução, não é necessário até ir à base de dados. Basta adicionar uma nova propriedade na classe, gera uma nova migração e essa propriedade será refletida como novo campo da tabela.

### Database First:
Diferente do conceito de CodeFirst, no DatabaseFirst primeiramente é criado o banco de dados tabelas, campos e índices. 

### DbContext:
É a combinação dos padrões Repository e UoW (Unit-of-Work), que contém um conjunto de métodos responsáveis por gravar e ler informações do banco de dados. O DbContext é a classe principal e mais importante que você terá acesso. O objetivo da classe é simplificar  a interação da aplicação com o banco de dados. 

### Migração:
A migração é um recurso do EFC de versionamento para o modelo de dados. Neste processo é gerado um arquivo contendo as últimas alterações que foram feitas no modelo de dados. 

## O projeto

### Tecnologias Usadas No Projeto:
- <a href="https://dotnet.microsoft.com/">.NET Core SDK</a>: Caso você tenha o Visual Studio 2019 em sua máquina, é possível que já tenha instalado o SDK do .NET Core. Caso contrário, é necessário fazer a instalação. 
- <a href="https://docs.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15">SQL Server LocalDb</a>: Escolha SQL Server Express 2019 e após baixar o arquivo, escolha a opção Download Mídia e em seguida, LocalDB.

### Pacotes utilizados na aplicação: 
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design

### Cenário:
- O objetivo é realizar um pequeno sistema para cadastro de pedidois. Para isso, teremos as classes de Pedido, outra de Itens do Pedido, Cadastro de Clientes e de Produtos; 
- Os métodos criados têm como finalidade: inserir registros, inserir registros em massa, consultar dados, atualizar e remover registros;
- O provider utilizado na aplicação foi informado por meio do método OnConfiguring(DbContextOptionsBuilder optionsBuilder);
- A configuração do modelo de dados foi informada por meio do método OnModelCreating(ModelBuilder modelbuilder);
- Comando para rodar a migração: Add-Migration Nome_da_Migração;
- Rollback de migrações: caso tenha feito alguma alteração no banco de dados e deseja reverter a migração, é necessário atualizar o database para a versão anterior (update-database Primeira Migração) da última alteração e depois remover a última alteração (Remove-Migration Ultima Migração);
- Para listar todas as migrações: Get-Migration.
