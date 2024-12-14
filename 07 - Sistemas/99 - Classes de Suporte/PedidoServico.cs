using MeuProjeto.Dominio;

namespace MeuProjeto.Aplicacao;

public class PedidoServico
{
    private readonly IPedidoRepositorio _pedidoRepositorio;

    public PedidoServico(IPedidoRepositorio pedidoRepositorio)
    {
        _pedidoRepositorio = pedidoRepositorio;
    }

    public void CriarPedido(CriarPedidoComando comando)
    {
        var pedido = new Pedido(comando.Id, comando.NomeCliente);
        _pedidoRepositorio.Adicionar(pedido);
    }
}
