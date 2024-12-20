# Clean Code

Boas práticas na escrita de software que você pode aplicar para obter uma maior legibilidade e manutenabilidade do seu código.

## 🛠️ Construído com 

* [Visual Studio 2022](https://learn.microsoft.com/pt-br/visualstudio/windows/?view=vs-2022) - Foi utilizado o Visual Studio como ferramenta de desenvolvimento, que permite realizar todo o ciclo de desenvolvimento em um só lugar.

## 📚 Principais Bibliotecas, Frameworks e Comandos do NuGet Utilizados

* [net8.0](https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-8/overview) - Foi utilizado com objetivo de aproveitar as melhorias de desempenho, segurança e produtividade proporcionadas pela nova versão dessa plataforma de desenvolvimento.
```
NuGet\Install-Package Microsoft.NET.Workload.Emscripten.net6.Manifest-8.0.100 -Version 8.0.0
```
* [log4net]() - Foi utilizado com objetivo de fornecer uma solução robusta e flexível para registrar logs em aplicações .NET
```
NuGet\Install-Package log4net -Version 2.0.17
```
* [Microsoft.NET.Test.Sdk]() - Foi utilizado com objetivo de fornecer o suporte necessário para executar testes automatizados em projetos .NET.
```
NuGet\Install-Package Microsoft.NET.Test.Sdk -Version 17.10.0
```
* [NetArchTest.Rules]() -  Foi utilizado com objetivo de fornecer um conjunto de regras para facilitar a validação da arquitetura de software em projetos .NET
```
NuGet\Install-Package NetArchTest.Rules -Version 1.3.2 
```
* [Xunit]() - Foi utilizado com objetivo de fornecer um framework de testes unitários para aplicações .NET
```
NuGet\Install-Package xunit -Version 2.9.0
```
## 🚧 Descrição da Estrutura do Projeto

A estrutura do projeto segundo a imagem abaixo é composta da seguinte forma:

![EstruturaDoProjeto](screenshots/estrutura.png)

## ⚠️ Atenção

Destinado exclusivamente para fins de estudo.

---
⌨️ por [Byron Doria](https://gist.github.com/lohhans) 😊
