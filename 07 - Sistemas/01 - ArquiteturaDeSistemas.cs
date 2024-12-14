namespace CleanCode.M07_Sistemas;

/*********************************/
/*    Arquitetura de Sistemas    */
/*********************************/

#region Como Você Construiria uma Cidade?
/*
    Metáfora da construção de uma cidade:
    - Planejamento antecipado.
    - Infraestrutura bem definida.
*/
public class Cidade
{
    // Pense aqui numa cidade e como você deveria quebrar
    // cada um dos elementos e servicos de uma cidade
}
#endregion

#region Separar a Construção de um Sistema do seu Uso
/*
    Separação da construção e uso:
    - Facilita a manutenção.
    - Permite evolução do sistema.
*/

// Exemplo Ruim: Misturando construção e uso
public class ExemploRuim
{
    public void Executar()
    {
        var servico = new Servico();
        servico.Configurar("Configuração Inicial");
        servico.ExecutarTarefa();
    }
}

// Exemplo Bom: Separando construção e uso
public class ExemploBom
{
    private readonly IServico _servico;

    // Injeção de dependência via construtor
    public ExemploBom(IServico servico)
    {
        _servico = servico;
    }

    public void Executar()
    {
        _servico.ExecutarTarefa();
    }
}

public interface IServico
{
    void Configurar(string configuracao);
    void ExecutarTarefa();
}

public class Servico : IServico
{
    private string _configuracao;

    public void Configurar(string configuracao)
    {
        _configuracao = configuracao;
    }

    public void ExecutarTarefa()
    {
        // Implementação da tarefa utilizando a configuração
    }
}

public static class Inicializador
{
    public static ExemploBom Inicializar()
    {
        var servico = new Servico();
        servico.Configurar("Configuração Inicial");
        return new ExemploBom(servico);
    }
}

// Método Main isolado para inicialização
public static class Programa
{
    public static void Main()
    {
        var sistema = Inicializador.Inicializar();
        sistema.Executar();
    }
}
#endregion

#region Separação do Main
/*
    Isolando o Main:
    - Evita acoplamento excessivo.
    - Utilização de padrões de design.
*/

// Em cada plataforma temos um tipo de Main, no .NET podemos considerar o program.cs um deles.

#endregion

#region Fábricas
/*
    Padrão Factory:
    - Criação de instâncias sem expor lógica de criação.
*/
public interface IProduto { }

public class ProdutoA : IProduto { }
public class ProdutoB : IProduto { }

public static class FabricaProduto
{
    public static IProduto CriarProduto(string tipo)
    {
        switch (tipo)
        {
            case "A": return new ProdutoA();
            case "B": return new ProdutoB();
            default: throw new ArgumentException("Tipo de produto desconhecido");
        }
    }
}
#endregion

#region Injeção de Dependência
/*
    Injeção de Dependência:
    - Melhora testabilidade.
    - Melhora manutenibilidade.
*/
public interface IService { }
public class Service : IService { }

public class Consumidor
{
    private readonly IService _Service;

    // Injeção de dependência via construtor
    public Consumidor(IService Service)
    {
        _Service = Service;
    }
}
#endregion

#region Escalando
/*
    Técnicas de escalabilidade:
    - Arquitetura bem planejada.
    - Suporte ao crescimento.
*/

// Exemplo Ruim: Sistema não escalável
public class SistemaNaoEscalavel
{
    public void ProcessarDados()
    {
        List<string> dados = new List<string> { "Dado1", "Dado2" };
        foreach (var dado in dados)
        {
            // Processamento ineficiente
            Console.WriteLine(dado);
        }
    }
}

// Exemplo Bom: Sistema escalável
public class SistemaEscalavel
{
    private readonly IProcessador _processador;

    // Injeção de dependência via construtor
    public SistemaEscalavel(IProcessador processador)
    {
        _processador = processador;
    }

    public void ProcessarDados()
    {
        IEnumerable<string> dados = ObterDadosDeFonteExterna();
        _processador.Processar(dados);
    }

    private IEnumerable<string> ObterDadosDeFonteExterna()
    {
        // Simulação de obtenção de dados de uma fonte externa, por exemplo, banco de dados
        return new List<string> { "Dado1", "Dado2", "Dado3" };
    }
}

public interface IProcessador
{
    void Processar(IEnumerable<string> dados);
}

public class Processador : IProcessador
{
    public void Processar(IEnumerable<string> dados)
    {
        // Processamento eficiente
        Parallel.ForEach(dados, dado =>
        {
            Console.WriteLine(dado);
        });
    }
}

// Método Main isolado para inicialização
public static class Program
{
    public static void Main()
    {
        IProcessador processador = new Processador();
        var sistema = new SistemaEscalavel(processador);
        sistema.ProcessarDados();
    }
}
#endregion

