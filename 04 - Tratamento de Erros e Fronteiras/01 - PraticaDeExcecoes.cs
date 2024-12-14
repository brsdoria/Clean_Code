namespace CleanCode.M04_Tratamento_de_Erros_e_Fronteiras;

/*********************************/
/*     Práticas de Exceções      */
/*********************************/

#region Use Exceções em vez de Códigos de Retorno
/*
    Use Exceções em vez de Códigos de Retorno:
    Exceções tornam o código mais limpo e fácil de entender.
*/
public class Processador
{
    // Exemplo Ruim: Uso de códigos de retorno
    public int ProcessarDados(string entrada)
    {
        if (string.IsNullOrEmpty(entrada))
        {
            return -1; // Código de erro
        }
        // Processamento...
        return 0; // Sucesso
    }

    // Exemplo Bom: Uso de exceções
    public void ProcessarDadosComExcecao(string entrada)
    {
        if (string.IsNullOrEmpty(entrada))
        {
            throw new ArgumentException("Entrada não pode ser nula ou vazia");
        }
        // Processamento...
    }
}
#endregion

#region Escreva suas Declarações Try-Catch-Finally Primeiro
/*
    Escreva suas Declarações Try-Catch-Finally Primeiro:
    Definir blocos try-catch-finally no início facilita o manejo de erros.
*/
public class LeitorArquivo
{
    public void LerArquivo(string caminho)
    {
        try
        {
            // Código para leitura do arquivo
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
        finally
        {
            // Limpeza de recursos
        }
    }
}
#endregion

#region Use Exceções Não Verificadas
/*
    Use Exceções Não Verificadas:
    Exceções não verificadas simplificam o código.
    Em C#, todas as exceções são tratadas como não verificadas, simplificando a gestão de erros
    O que significa que você não precisa declarar as exceções que um método pode lançar
*/
public class Calculadora
{
    public int Dividir(int numerador, int denominador)
    {
        if (denominador == 0)
        {
            throw new InvalidOperationException("Denominador não pode ser zero");
        }
        return numerador / denominador;
    }
}
#endregion

#region Forneça Contexto com Exceções
/*
    Forneça Contexto com Exceções:
    Inclua mensagens detalhadas nas exceções para facilitar o diagnóstico.
*/
public class BancoDados
{
    // Exemplo ruim: Lançando nova exception
    public void Conectar(string stringConexao)
    {
        try
        {
            // Código para conexão ao banco de dados
        }
        catch (SqlException ex)
        {
            throw new InvalidOperationException("Erro ao conectar ao banco de dados", ex);
        }
    }

    // Exemplo bom: Log personalizado
    public void ConectarBom(string stringConexao)
    {
        try
        {
            // Código para conexão ao banco de dados
        }
        catch (SqlException ex)
        {
            // Entenda como seu mecanismo de log
            Console.WriteLine("Erro ao conectar ao banco de dados", ex);
            throw;
        }
    }
}
public class SqlException : Exception { }
#endregion

#region Defina Classes de Exceção em Termos das Necessidades do Chamador
/*
    Defina Classes de Exceção em Termos das Necessidades do Chamador:
    Use pelo menos três os construtores comuns ao criar suas próprias classes de exceção:
*/
public class ExcecaoSaldoInsuficiente : Exception
{
    public ExcecaoSaldoInsuficiente() : base() { }
    public ExcecaoSaldoInsuficiente(string mensagem) : base(mensagem) { }
    public ExcecaoSaldoInsuficiente(string mensagem, Exception inner) : base(mensagem, inner) { }
}

public class ContaBancaria
{
    public void Sacar(decimal quantia)
    {
        if (quantia > Saldo)
        {
            throw new ExcecaoSaldoInsuficiente("Saldo insuficiente para a operação.");
        }
        Saldo -= quantia;
    }

    public decimal Saldo { get; private set; }
}
#endregion