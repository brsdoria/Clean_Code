namespace CleanCode.M03_Principios_De_Formatacao;

/*********************************/
/*  Abstração e Encapsulamento   */
/*********************************/

#region Abstração de Dados
/*
    Abstração de Dados:
    Crie interfaces públicas que escondem a implementação interna, permitindo modificações sem afetar os clientes da classe.
*/
public class Usuario
{
    // Exemplo Ruim: sem abstração
    public string Nome;
    public string Senha;
}

public class UsuarioMelhor
{
    // Exemplo Bom: com abstração usando propriedades automáticas e expressões lambda
    public string Nome { get; private set; }
    private string Senha { get; set; }

    public void DefinirNome(string value) => Nome = value;

    public bool VerificarSenha(string senha) => Senha == senha;

    public void DefinirSenha(string senha)
    {
        // Lógica de validação pode ser aplicada aqui
        Senha = senha;
    }
}
#endregion

#region Anti-Simetria de Dados/Objetos
/*
    Anti-Simetria de Dados/Objetos:
    Objetos possuem comportamento e dados, enquanto estruturas de dados possuem apenas dados.
*/
public class Pedido
{
    // Exemplo Ruim: estrutura de dados
    public int Id;
    public string Produto;
    public int Quantidade;
}

public class PedidoBom
{
    // Exemplo Bom: objeto com comportamento
    private int id;
    private string produto;
    private int quantidade;

    public PedidoBom(int id, string produto, int quantidade)
    {
        this.id = id;
        this.produto = produto;
        this.quantidade = quantidade;
    }

    public void ExibirPedido()
    {
        Console.WriteLine($"Pedido {id}: {quantidade}x {produto}");
    }
}
#endregion

#region A Lei de Demeter
/*
    A Lei de Demeter:
    Um método deve apenas chamar métodos de seu próprio objeto, de seus parâmetros ou de objetos que cria.
*/
// Exemplo Ruim: violação da Lei de Demeter
public class PedidoRuim
{
    public Cliente Cliente { get; set; }

    public void ExibirEnderecoDoCliente()
    {
        Console.WriteLine(Cliente.Endereco.Cidade.Nome);
    }
}

// Exemplo Bom: seguindo a Lei de Demeter
public class PedidoDemeter
{
    private Cliente Cliente { get; }

    public PedidoDemeter(Cliente cliente)
    {
        Cliente = cliente;
    }

    public void ExibirEnderecoDoCliente()
    {
        Console.WriteLine(Cliente.FormataEndereco());
    }
}

public class Cliente
{
    public Endereco Endereco { get; }

    public Cliente(Endereco endereco)
    {
        Endereco = endereco;
    }

    public string FormataEndereco()
    {
        return $"{Endereco.Cidade.Nome} + ";
    }
}

public class Endereco
{
    public Cidade Cidade { get; }

    public Endereco(Cidade cidade)
    {
        Cidade = cidade;
    }
}

public class Cidade
{
    public string Nome { get; }

    public Cidade(string nome)
    {
        Nome = nome;
    }
}
#endregion