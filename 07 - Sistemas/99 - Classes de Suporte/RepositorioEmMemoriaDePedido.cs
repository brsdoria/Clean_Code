using MeuProjeto.Dominio;

namespace MeuProjeto.Infraestrutura;

public class RepositorioEmMemoriaDePedido : IPedidoRepositorio
{
    private readonly Dictionary<int, Pedido> _pedidos = new Dictionary<int, Pedido>();

    public void Adicionar(Pedido pedido)
    {
        _pedidos[pedido.Id] = pedido;
    }

    public Pedido ObterPorId(int id)
    {
        _pedidos.TryGetValue(id, out var pedido);
        return pedido;
    }
}