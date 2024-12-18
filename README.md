# Modelagem de Domínios Rico

Apresentação de uma aplicação web que ilustra a aplicabilidade do DDD, com foco na aplicação prática da modelagem tática. Colocando em prática uma modelagem que o padrão DDD prega, uma camada de dominio, aplicação, apresentação, infraestrutura e dados.

## 🛠️ Construído com

* [Visual Studio 2022](https://learn.microsoft.com/pt-br/visualstudio/windows/?view=vs-2022) - Foi utilizado o Visual Studio como ferramenta de desenvolvimento, que permite realizar todo o ciclo de desenvolvimento em um só lugar.

## 📚 Principais Bibliotecas, Frameworks e Comandos do NuGet Utilizados

* [Microsoft.AspNetCore.Http](https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-core-2-2) - Foi utilizado esse framework multiplataforma de código aberto desenvolvido pela Microsoft para a criação e execução de aplicações modernas, como aplicações web, desktop, móveis e serviços.
```
NuGet\Install-Package Microsoft.AspNetCore.Http -Version 2.2.0
```
* [MediatR](https://medium.com/tableless/mediatr-com-asp-net-core-7b98ba0ca640) - Foi utilizado esse padrão de projeto para promove o baixo acoplamento entre os objetos e a aplicação, permitindo que se comuniquem sem conhecer suas estruturas.
```
NuGet\Install-Package MediatR -Version 7.0.0
```
* [AutoMapper](https://automapper.org/) - Foi utilizada essa biblioteca para o mapeamento de objetos entre as camadas.
```
NuGet\Install-Package AutoMapper -Version 6.1.1
```
* [Microsoft.NET.Test.Sdk](https://automapper.org/) - Foi utilizado este pacote do NuGet do ecossistema .NET para fornecer o suporte necessário para executar testes unitários. Ele é uma parte fundamental do framework de testes para projetos que utilizam ferramentas como o xUnit, NUnit ou MSTest.
```
NuGet\Install-Package Microsoft.NET.Test.Sdk -Version 16.0.1
```
* [FluentValidation](https://docs.fluentvalidation.net/en/latest/) - Foi utilizada essa biblioteca para facilitar a implementação de regras de validação para objetos (como modelos ou DTOs) de maneira limpa, consistente e fácil de manter, separando a lógica de validação da lógica da aplicação ou camada de apresentação.
```
NuGet\Install-Package FluentValidation -Version 8.4.0
```
* [xunit](https://xunit.net/) - Foi utilizada essa ferramenta de teste de unidade gratuita, de código aberto e focada na comunidade para o .NET Framework.
```
NuGet\Install-Package xunit -Version 2.4.0
```
* [Microsoft.EntityFrameworkCore](https://learn.microsoft.com/pt-br/ef/core/get-started/overview/install) - Foi utilizado esse framework com objetivo facilitar o acesso e a manipulação de dados no banco de dados em aplicações .NET.
```
NuGet\Install-Package Microsoft.EntityFrameworkCore -Version 2.2.6
```
## 🚧 Descrição da Estrutura do Projeto

A estrutura do projeto segundo a imagem abaixo é composta da seguinte forma:

![EstruturaDoProjeto](screenshots/Capturar.PNG)

## ⚠️ Atenção

Destinado exclusivamente para fins de estudo.

---
⌨️ por [Byron Doria](https://gist.github.com/lohhans) 😊
