using Xunit;
namespace CleanCode.M05_Testes_De_Unidade;

/*********************************/
/*   Práticas de Testes Limpos   */
/*********************************/

#region Mantendo os Testes Limpos
/*
    Testes devem ser tratados com o mesmo cuidado que o código de produção. 
    Devem ser claros, organizados e bem documentados.
 */

public class TestesLimpos
{
    private Calculadora calculadora = new Calculadora();

    // Ruim: Teste desorganizado e sem clareza
    [Fact]
    public void Teste_Calculadora()
    {   
        var resultado = calculadora.Somar(2, 2);
        Assert.Equal(4, resultado);

        resultado = calculadora.Subtrair(2, 2);
        Assert.Equal(0, resultado);
    }

    // Bom: Testes claros e organizados
    [Fact]
    public void Teste_Soma()
    {
        var resultado = calculadora.Somar(2, 2);
        Assert.Equal(4, resultado);
    }

    [Fact]
    public void Teste_Subtracao()
    {
        var resultado = calculadora.Subtrair(2, 2);
        Assert.Equal(0, resultado);
    }
}

#endregion

#region Linguagem de Teste Específica do Domínio
/*
    Utilize termos do domínio da aplicação dentro dos testes 
    para facilitar o entendimento e a comunicação.
 */

public class TestesDominio
{
    // Ruim: Termos genéricos e sem significado de domínio
    [Fact]
    public void Teste_SaldoConta()
    {
        var conta = new Conta();
        conta.Depositar(100);
        Assert.Equal(100, conta.Saldo);
    }

    // Bom: Termos específicos do domínio bancário
    [Fact]
    public void Teste_DepositoConta()
    {
        var conta = new Conta();
        conta.Depositar(100);
        Assert.Equal(100, conta.ObterSaldo());
    }

    public class Conta
    {
        public decimal Saldo { get; private set; }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public decimal ObterSaldo()
        {
            return Saldo;
        }
    }
}

#endregion

#region Um Padrão Duplo
/*
    Evite duplicação de lógica entre os testes e o código de produção. 
    Mantenha os testes simples e focados.
 */

public class TestesPadraoDuplo
{
    private Calculadora calculadora = new Calculadora();

    // Ruim: Duplicação de lógica de produção no teste
    [Fact]
    public void Teste_Duplicacao()
    {
        var resultado = Somar(2, 2);
        Assert.Equal(4, resultado); // Lógica duplicada do método de produção

        int Somar(int a, int b)
        {
            return a + b; // Duplicação
        }
    }

    // Bom: Teste simples e sem duplicação
    [Fact]
    public void Teste_SemDuplicacao()
    {
        var resultado = calculadora.Somar(2, 2);
        Assert.Equal(4, resultado);
    }
}

#endregion

#region Um Assert por Teste
/*
    Cada teste deve verificar uma única condição para facilitar a identificação de falhas.
 */

public class TestesAssertUnico
{
    // Ruim: Múltiplos asserts em um único teste
    [Fact]
    public void Teste_MultiplosAsserts()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
        Assert.Equal(0, calculadora.Subtrair(2, 2));
    }

    // Bom: Um assert por teste
    [Fact]
    public void Teste_Soma_AssertUnico()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
    }

    [Fact]
    public void Teste_Subtracao_AssertUnico()
    {
        var calculadora = new Calculadora();
        Assert.Equal(0, calculadora.Subtrair(2, 2));
    }
}

#endregion

#region Conceito Único por Teste
/*
    Cada teste deve focar em um único conceito ou cenário para manter a clareza e a precisão.
*/

public class TestesConceitoUnico
{
    // Ruim: Múltiplos conceitos em um único teste
    [Fact]
    public void Teste_MultiplosConceitos()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
        Assert.Equal(0, calculadora.Subtrair(2, 2));
        Assert.Equal(6, calculadora.Multiplicar(2, 3));
    }

    // Bom: Um conceito por teste
    [Fact]
    public void Teste_Soma()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
    }

    [Fact]
    public void Teste_Subtracao()
    {
        var calculadora = new Calculadora();
        Assert.Equal(0, calculadora.Subtrair(2, 2));
    }

    [Fact]
    public void Teste_Multiplicacao()
    {
        var calculadora = new Calculadora();
        Assert.Equal(6, calculadora.Multiplicar(2, 3));
    }
}

#endregion

#region F.I.R.S.T.

public class TestesFIRST
{
    // Fast (Rápidos)
    //  Testes de unidade devem ser executados rapidamente para que possam ser rodados
    //  frequentemente, sem atrapalhar o fluxo de trabalho do desenvolvedor.
    [Fact]
    public void Teste_Rapido()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
    }

    // Independent (Independentes)
    // Cada teste de unidade deve ser independente de outros testes. O resultado de um
    // teste não deve depender do resultado ou do estado gerado por outro teste.
    [Fact]
    public void Teste_Independente()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
    }

    // Repeatable (Repetíveis)
    // Testes de unidade devem produzir os mesmos resultados toda vez que são executados,
    // independentemente do ambiente em que são rodados.
    [Fact]
    public void Teste_Repetivel()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
    }

    // Self-validating (Auto-validados)
    // Testes de unidade devem ter uma clara indicação de sucesso ou falha. Isso geralmente
    // é feito através de asserts que verificam se os resultados esperados correspondem aos resultados reais.
    [Fact]
    public void Teste_AutoValidado()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
    }

    // Timely (Oportunos)
    // Testes de unidade devem ser escritos no momento certo, preferencialmente antes do código de produção
    // correspondente. Isso está alinhado com a prática de Test-Driven Development (TDD).
    [Fact]
    public void Teste_Oportuno()
    {
        var calculadora = new Calculadora();
        Assert.Equal(4, calculadora.Somar(2, 2));
    }
}

#endregion





#region Classe auxiliar Calculadora para os exemplos
public class Calculadora
{
    public int Somar(int a, int b) => a + b;
    public int Subtrair(int a, int b) => a - b;
    public int Multiplicar(int a, int b) => a * b;
}
#endregion