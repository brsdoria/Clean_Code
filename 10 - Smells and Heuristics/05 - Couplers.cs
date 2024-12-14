namespace CleanCode.M10_Smells_and_Heuristics;

/***********************************/
/*       Exemplos de Couplers      */
/***********************************/

#region Feature Envy
/*
    Feature Envy: Ocorre quando um método de uma classe depende mais dos dados ou 
    funcionalidades de outra classe do que dos próprios. Isso indica que o método 
    deveria ser movido para a classe da qual depende, promovendo o encapsulamento 
    e diminuindo o acoplamento.
*/

// Problema: Método na classe Funcionario que acessa muitos dados da classe Endereco
public class Funcionario
{
    public string Nome { get; set; }
    public Endereco EnderecoFuncionario { get; set; }

    public string ObterEnderecoCompleto()
    {
        return $"{EnderecoFuncionario.Rua}, {EnderecoFuncionario.Numero}, {EnderecoFuncionario.Cidade}";
    }
}

public class Endereco
{
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Cidade { get; set; }
}

// Solução: Mover o comportamento para a classe Endereco
public class FuncionarioRefatorado
{
    public string Nome { get; set; }
    public EnderecoRefatorado EnderecoFuncionario { get; set; }
}

public class EnderecoRefatorado
{
    public string Rua { get; set; }
    public int Numero { get; set; }
    public string Cidade { get; set; }

    public string ObterEnderecoCompleto()
    {
        return $"{Rua}, {Numero}, {Cidade}";
    }
}
#endregion

#region Inappropriate Intimacy
/*
    Inappropriate Intimacy: Ocorre quando uma classe conhece demasiadamente os detalhes 
    internos de outra classe, acessando diretamente seus atributos ou métodos protegidos. 
    Isso viola o princípio do encapsulamento e cria dependência excessiva entre as classes.
*/

// Problema: A classe Pedido acessa diretamente os detalhes internos da classe Cliente
public class Pedido2
{
    public void ProcessarPedido(Cliente3 cliente)
    {
        if (cliente.Saldo < 0) // Acesso direto a um campo privado ou protegido
        {
            // Lógica de processamento
        }
    }
}

public class Cliente3
{
    public decimal Saldo { get; private set; }
}

// Solução: Expor o comportamento necessário através de métodos da própria classe
public class PedidoRefatorado2
{
    public void ProcessarPedido(ClienteRefatorado2 cliente)
    {
        if (cliente.TemSaldoNegativo())
        {
            // Lógica de processamento
        }
    }
}

public class ClienteRefatorado2
{
    private decimal Saldo { get; set; }

    public bool TemSaldoNegativo()
    {
        return Saldo < 0;
    }
}
#endregion

#region Incomplete Library Class
/*
    Incomplete Library Class: Esse problema surge quando você depende de uma classe 
    de biblioteca que não fornece toda a funcionalidade necessária, forçando você a 
    criar subclasses ou métodos utilitários adicionais para atender às suas necessidades.
*/

// Problema: A classe biblioteca StringHelper não fornece o método necessário
public static class StringHelper
{
    public static string ToUppercase(string input)
    {
        return input.ToUpper();
    }
}

// Solução: Extender a funcionalidade com métodos de extensão
public static class StringHelperExtensions
{
    public static string ReverterString(this string input)
    {
        char[] array = input.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
}

// Uso
public class ExemploUso
{
    public void Exemplo()
    {
        string texto = "Exemplo";
        string textoRevertido = texto.ReverterString(); // Utilizando a extensão
    }
}
#endregion

#region Message Chains
/*
    Message Chains: Esse code smell ocorre quando há uma cadeia de chamadas de métodos,
    onde uma classe chama um método de outra classe, que chama outro método, e assim por 
    diante. Isso aumenta o acoplamento e torna o código mais difícil de entender.
*/

// Problema: Cadeia de chamadas de métodos
public class Pedido3
{
    public Cliente4 Cliente { get; set; }
}

public class Cliente4
{
    public Endereco2 EnderecoCliente { get; set; }
}

public class Endereco2
{
    public string Rua { get; set; }
}

public class ProcessadorPedido
{
    public string ObterRuaDoCliente(Pedido3 pedido)
    {
        return pedido.Cliente.EnderecoCliente.Rua; // Cadeia de chamadas
    }
}

// Solução: Evitar a cadeia de chamadas
public class ProcessadorPedidoRefatorado3
{
    public string ObterRuaDoCliente(ClienteRefatorado3 cliente)
    {
        return cliente.ObterRua(); // Encapsular a lógica dentro da classe relevante
    }
}

public class ClienteRefatorado3
{
    public Endereco EnderecoCliente { get; set; }

    public string ObterRua()
    {
        return EnderecoCliente.Rua;
    }
}
#endregion

#region Middle Man
/*
    Middle Man: Esse code smell ocorre quando uma classe delega a maior parte de suas 
    responsabilidades para outra classe, agindo como intermediária sem agregar valor real.
    Isso aumenta o acoplamento e reduz a clareza do código.
*/

// Problema: A classe Gerente apenas repassa chamadas para outra classe
public class Gerente
{
    private Funcionario2 funcionario;

    public Gerente(Funcionario2 funcionario)
    {
        this.funcionario = funcionario;
    }

    public void RealizarTarefa()
    {
        funcionario.RealizarTarefa(); // Delegação sem valor agregado
    }
}

public class Funcionario2
{
    public void RealizarTarefa()
    {
        // Lógica da tarefa
    }
}

// Solução: Eliminar o intermediário desnecessário
public class FuncionarioRefatorado2
{
    public void RealizarTarefa()
    {
        // Lógica da tarefa
    }
}

// Uso direto sem intermediário
public class ExemploUsoRefatorado
{
    public void Exemplo()
    {
        var funcionario = new FuncionarioRefatorado2();
        funcionario.RealizarTarefa(); // Acesso direto sem intermediário
    }
}
#endregion

