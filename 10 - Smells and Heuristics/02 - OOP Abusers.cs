namespace CleanCode.M10_Smells_and_Heuristics;

/******************************************/
/* Exemplos de Object-Orientation Abusers */
/******************************************/

#region Switch Statements
/*
    Switch Statements: 
    O uso excessivo de declarações switch ou if-else para decidir o comportamento
    baseado no tipo de objeto ou estado é um sinal de que o código não está utilizando
    polimorfismo adequadamente. O ideal é que o comportamento seja encapsulado dentro
    das próprias classes derivadas, eliminando a necessidade de estruturas de controle de fluxo.
*/

// Problema: Uso excessivo de switch para decidir o comportamento

public class Pagamento
{
    public string TipoPagamento { get; set; } // "CartaoCredito", "Boleto"

    public void ProcessarPagamento()
    {
        switch (TipoPagamento)
        {
            case "CartaoCredito":
                Console.WriteLine("Processando pagamento via cartão de crédito...");
                break;
            case "Boleto":
                Console.WriteLine("Processando pagamento via boleto...");
                break;
            default:
                Console.WriteLine("Tipo de pagamento desconhecido.");
                break;
        }
    }
}

// Solução: Substituindo o switch por polimorfismo

public abstract class PagamentoBase
{
    public abstract void ProcessarPagamento();
}

public class PagamentoCartaoCredito : PagamentoBase
{
    public override void ProcessarPagamento()
    {
        Console.WriteLine("Processando pagamento via cartão de crédito...");
    }
}

public class PagamentoBoleto : PagamentoBase
{
    public override void ProcessarPagamento()
    {
        Console.WriteLine("Processando pagamento via boleto...");
    }
}
#endregion

#region Temporary Field
/*
    Temporary Field: 
    Campos temporários são atributos de uma classe que nem sempre são utilizados,
    o que indica que a classe está acumulando responsabilidades que poderiam ser divididas
    em classes menores. Isso viola o princípio da responsabilidade única (SRP).
*/

// Problema: Campos temporários que só são usados em certos contextos

public class Pedido
{
    public string CodigoRastreamento { get; set; } // Campo temporário
    public DateTime? DataEnvio { get; set; } // Campo temporário

    public void EnviarPedido(string codigoRastreamento)
    {
        if (!string.IsNullOrEmpty(codigoRastreamento))
        {
            CodigoRastreamento = codigoRastreamento;
            DataEnvio = DateTime.Now;
        }
    }
}

// Solução: Extrair os campos temporários para uma classe mais apropriada

public class PedidoRefatorado
{
    public Envio Envio { get; set; }

    public void EnviarPedido(Envio envio)
    {
        Envio = envio;
    }
}

public class Envio
{
    public string CodigoRastreamento { get; private set; }
    public DateTime DataEnvio { get; private set; }

    public Envio(string codigoRastreamento, DateTime dataEnvio)
    {
        CodigoRastreamento = codigoRastreamento;
        DataEnvio = dataEnvio;
    }
}
#endregion

#region Alternative Classes with Different Interfaces
/*
    Alternative Classes with Different Interfaces:
    Classes que representam a mesma abstração, mas têm interfaces diferentes,
    criam inconsistência e dificultam o uso intercambiável dessas classes. Isso
    viola o princípio de substituição de Liskov (LSP). A refatoração deve unificar
    as interfaces ou criar uma interface comum para garantir a consistência.
*/

// Problema: Classes alternativas com interfaces diferentes

public class LeitorCsv
{
    public string LerCsv()
    {
        // Lógica para ler arquivo CSV
        return "dados csv";
    }
}

public class LeitorJson
{
    public string CarregarJson()
    {
        // Lógica para ler arquivo JSON
        return "dados json";
    }
}

// Solução: Criar uma interface comum para unificar as classes

public interface ILeitorArquivo
{
    string Ler();
}

public class LeitorCsvRefatorado : ILeitorArquivo
{
    public string Ler()
    {
        return LerCsv();
    }

    private string LerCsv()
    {
        // Lógica para ler arquivo CSV
        return "dados csv";
    }
}

public class LeitorJsonRefatorado : ILeitorArquivo
{
    public string Ler()
    {
        return CarregarJson();
    }

    private string CarregarJson()
    {
        // Lógica para ler arquivo JSON
        return "dados json";
    }
}
#endregion

#region Refused Bequest
/*
    Refused Bequest:
    Esse problema ocorre quando uma classe filha herda de uma classe pai, mas não
    utiliza ou até rejeita alguns dos métodos ou propriedades herdados. Isso indica
    que a herança está sendo mal utilizada e que, possivelmente, a classe filha
    deveria estar em uma outra hierarquia ou usando composição ao invés de herança.
*/

// Problema: Herança inadequada onde a classe filha não utiliza os métodos herdados

public class Processo
{
    public virtual void Executar()
    {
        Console.WriteLine("Processando a tarefa...");
    }
}

public class RelatorioProcesso : Processo
{
    // O Relatório não precisa do método Executar, já que não processa tarefas.
    // Isso sugere que a herança está incorreta.
}

// Solução: Usar composição ao invés de herança para evitar métodos inadequados

public class ProcessoRefatorado
{
    // Lógica comum para todos os processos
}

public interface IProcessavel
{
    void Executar();
}

public class ProcessoDeTarefa : ProcessoRefatorado, IProcessavel
{
    public void Executar()
    {
        Console.WriteLine("Processando a tarefa...");
    }
}

public class RelatorioRefatorado : ProcessoRefatorado
{
    // O Relatório não implementa IProcessavel, pois não processa tarefas
}
#endregion
