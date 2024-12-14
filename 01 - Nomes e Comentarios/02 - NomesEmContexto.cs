namespace CleanCode.M01_Nomes_e_Comentarios;


/*********************************/
/*       Nomes em Contexto       */
/*********************************/

#region Nomes de Classes
/*
    Nomes de Classes:
    Classes devem ter nomes substantivos que descrevam 
    claramente sua responsabilidade.
*/
// Ruim: não descritivo
public class CardFluentCheck { }

// Bom: descritivo
public class ValidadorDeCartaoDeCredito { }
#endregion

#region Nomes de Métodos
/*
    Nomes de Métodos:
    Métodos devem ter nomes que descrevam claramente a ação que realizam.
*/
public class ExemploNomesMetodos
{
    // Ruim: não descritivo
    public void Executar() { }

    // Bom: descritivo
    public void ProcessarPagamento() { }
}
#endregion

#region Não Seja Fofo
/*
    Não Seja Fofo:
    Evite nomes "fofos" ou engraçados que não refletem o propósito do código.
*/
public class ExemploNaoSejaFofo
{
    // Ruim: nome fofo
    public void VaiQueDa() { }

    // Bom: nome profissional
    public void ProcessarTransacao() { }
}
#endregion

#region Escolha uma Palavra por Conceito
/*
    Escolha uma Palavra por Conceito:
    Use uma única palavra para descrever um conceito específico em todo o código.
*/
public class ExemploPalavraPorConceito
{
    // Ruim: inconsistência no nome
    public void ObterCliente() { }
    public void BuscarUsuario() { }
    public void GetByAno() { }

    // Bom: consistência no nome
    public void ObterPedido() { }
    public void ObterUsuario() { }
    public void ObterTransacao() { }
}
#endregion

#region Não Faça Trocadilhos
/*
    Não Faça Trocadilhos:
    Evite usar trocadilhos ou jogos de palavras nos nomes, 
    pois podem ser confusos.
*/
public class ExemploNaoFacaTrocadilhos
{
    // Ruim: trocadilho
    public void DetonarPedido() { }

    // Bom: direto e descritivo
    public void CancelarPedido() { }
}
#endregion

/*********************************/
/*     Contexto e Domínio        */
/*********************************/

#region Use Nomes do Domínio da Solução
/*
    Use Nomes do Domínio da Solução:
    Nomes devem refletir o domínio da solução, descrevendo 
    claramente as responsabilidades e funcionalidades.
*/
public class CarrinhoDeCompras
{
    public void AdicionarItem(Item item)
    {
        // Lógica para adicionar item ao carrinho
    }
}
#endregion

#region Use Nomes do Domínio do Problema
/*
    Use Nomes do Domínio do Problema:
    Nomes devem refletir o domínio do problema, alinhando-se 
    com os termos usados pelos especialistas do domínio.
*/
public class Sinistro
{
    public void RegistrarSinistro(DetalhesSinistro detalhes)
    {
        // Lógica para registrar um sinistro
    }
}
#endregion

#region Adicione Contexto Significativo
/*
    Adicione Contexto Significativo:
    Nomes devem fornecer contexto suficiente para serem 
    compreendidos fora do seu escopo imediato.
*/
// Ruim: falta de contexto
public class Pedido
{
    public void Salvar()
    {
        // Lógica para fechar pedido
    }
}

// Bom: contexto significativo
public class PedidoController
{
    public void FecharPedido()
    {
        // Lógica para fechar pedido
    }
}
#endregion

#region Não Adicione Contexto Desnecessário
/*
    Não Adicione Contexto Desnecessário:
    Evite adicionar contexto desnecessário que possa 
    tornar os nomes longos e confusos.
*/

// Ruim: contexto desnecessário
public class SistemaDeGerenciamentoDeUsuarios
{
    public void InserirNovoUsuarioNoBancoDeDados()
    {
        // Lógica para adicionar usuário
    }
}

// Bom: contexto adequado
public class UsuarioService
{
    public void AdicionarUsuario()
    {
        // Lógica para adicionar usuário
    }
}
#endregion
