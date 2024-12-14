namespace MeuProjeto.Dominio;

public class Pedido
{
    public int Id { get; private set; }
    public string NomeCliente { get; private set; }
    public DateTime DataPedido { get; private set; }

    public Pedido(int id, string nomeCliente)
    {
        Id = id;
        NomeCliente = nomeCliente;
        DataPedido = DateTime.UtcNow;
    }

    public void AlterarNomeCliente(string novoNomeCliente)
    {
        NomeCliente = novoNomeCliente;
    }
}