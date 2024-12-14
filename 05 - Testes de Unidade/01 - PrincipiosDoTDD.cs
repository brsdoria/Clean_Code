using Xunit;
namespace CleanCode.M05_Testes_De_Unidade;

/*********************************/
/*       Princípios do TDD       */
/*********************************/

#region As Três Leis do TDD

public class TestesTDD  
{
    // Primeira Lei: Não escreva código de produção até que você tenha escrito um teste que falhe.
    // Tenha claro o conceito do que é "assistir" o teste falhar!
    [Fact]
    public void TesteFalha_Inicial()
    {
        var resultado = Calculadora.Somar(2, 2);
        Assert.Equal(4, resultado); // Este teste deve falhar inicialmente, pois o código não existe
    }

    // Segunda Lei: Escreva apenas um teste de unidade que falhe por vez.
    [Fact]
    public void TesteFalha_Suficiente()
    {
        var resultado = Calculadora.Somar(2, 2);
        Assert.Equal(4, resultado); // Este teste deve passar após correção
    }

    // Terceira Lei: Não escreva mais código de produção do que o necessário para passar no teste atual.
    public class Calculadora
    {
        public static int Somar(int a, int b)
        {
            return a + b; // Apenas o necessário para passar o teste
        }
    }
}

#endregion
