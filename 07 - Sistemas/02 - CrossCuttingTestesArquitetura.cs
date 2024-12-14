using MeuProjeto.Dominio;
using MeuProjeto.Infraestrutura;
using NetArchTest.Rules;
using Xunit;

namespace CleanCode.M07_Sistemas;

/*****************************************************/
/* Preocupações Transversais e Testes de Arquitetura */
/*****************************************************/

#region Cross-Cutting Concerns
/*
    Preocupações Transversais:
    - Logging.
    - Segurança.
    - Transações.
*/
    public class Logger
{
    public void LogInfo(string mensagem) { /* ... */ }
    public void LogWarning(string mensagem) { /* ... */ }
    public void LogError(string mensagem) { /* ... */ }
}

public class Seguranca
{
    public void ValidarToken() { /* ... */ }
    public void InvalidarToken() { /* ... */ }
}

public class Transacao
{
    public void Begin() { /* ... */ }
    public void Commit() { /* ... */ }
    public void Rollback() { /* ... */ }
}
#endregion

#region Testar a Arquitetura do Sistema
/*
    Testes de Arquitetura:
    - Validação da estrutura do sistema.
    - Garantia de separacao de responsabilidades
*/
public class TestesDeArquitetura
{
    [Fact]
    public void Dominio_Nao_Deve_Depender_De_Infraestrutura()
    {
        // Arrange & Act
        var resultado = Types.InAssembly(typeof(Pedido).Assembly)
                             .That()
                             .ResideInNamespace("MeuProjeto.Dominio")
                             .ShouldNot()
                             .HaveDependencyOn("MeuProjeto.Infraestrutura")
                             .GetResult();

        // Assert
        Assert.True(resultado.IsSuccessful, "A camada de domínio não deve depender da camada de infraestrutura.");
    }

    [Fact]
    public void Dominio_Nao_Deve_Depender_De_Aplicacao()
    {
        // Arrange & Act
        var resultado = Types.InAssembly(typeof(Pedido).Assembly)
                             .That()
                             .ResideInNamespace("MeuProjeto.Dominio")
                             .ShouldNot()
                             .HaveDependencyOn("MeuProjeto.Aplicacao")
                             .GetResult();
        // Assert
        Assert.True(resultado.IsSuccessful, "A camada de domínio não deve depender da camada de aplicacao.");
    }

    [Fact]
    public void Infraestrutura_Deve_Depender_De_Dominio()
    {
        // Arrange & Act
        var resultado = Types.InAssembly(typeof(RepositorioEmMemoriaDePedido).Assembly)
                             .That()
                             .ResideInNamespace("MeuProjeto.Infraestrutura")
                             .Should()
                             .HaveDependencyOn("MeuProjeto.Dominio")
                             .GetResult();

        // Assert
        Assert.True(resultado.IsSuccessful, "A camada de infraestrutura deve depender da camada de domínio.");
    }
}
#endregion

#region Use Padrões com Sabedoria
/*
    Padrões de Design:
    - Uso inteligente.
    - Evitar uso excessivo.
    - Paternite é um vício, busque a cura!
*/
public class PadraoSingleton
{
    private static PadraoSingleton instancia;

    private PadraoSingleton() { }

    public static PadraoSingleton Instancia
    {
        get
        {
            if (instancia == null)
            {
                instancia = new PadraoSingleton();
            }
            return instancia;
        }
    }
}
#endregion

