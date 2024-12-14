namespace MeuProjeto.Dominio;

public interface IPedidoRepositorio
{
    void Adicionar(Pedido pedido);
    Pedido ObterPorId(int id);
}
