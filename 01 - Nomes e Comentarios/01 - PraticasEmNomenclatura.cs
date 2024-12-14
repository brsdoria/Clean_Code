namespace CleanCode.M01_Nomes_e_Comentarios;


/*********************************/
/*     Importância dos Nomes     */
/*********************************/

#region Use Nomes que Revelam a Intenção
/*
    Use Nomes que Revelam a Intenção:
    Nomes devem revelar a intenção do código, explicando o que ele faz 
    e por que ele existe, sem a necessidade de comentários adicionais.
*/
public class ExemploRevelaIntencao
{
    // Ruim: não revela a intenção
    int dp;

    // Bom: revela a intenção
    int diasDesdeInicioProjeto;
}
#endregion

#region Evite Desinformação
/*
    Evite Desinformação:
    Evitar nomes que podem induzir ao erro ou causar 
    confusão é crucial para manter a clareza do código.
*/
public class ExemploDesinformacao
{
    // Ruim: confuso e desinformativo
    int resultado;

    // Bom: específico e claro
    int numeroDePedidos;
}
#endregion

/************************************/
/*     Práticas de Nomenclatura     */
/************************************/

#region Faça Distinções Significativas
/*
    Faça Distinções Significativas:
    Nomes devem distinguir-se claramente uns dos outros 
    para evitar ambiguidade e confusão.
*/
public class ExemploDistincaoSignificativa
{
    // Ruim: difícil distinguir entre as variáveis
    int valor1;
    int valor2;

    // Bom: distinções significativas
    int precoProduto;
    int quantidadeProduto;
}
#endregion

#region Use Nomes Pronunciáveis
/*
    Use Nomes Pronunciáveis:
    Nomes pronunciáveis facilitam a comunicação verbal sobre 
    o código, especialmente em discussões de equipe.
*/
public class ExemploNomesPronunciaveis
{
    // Ruim: difícil de pronunciar
    string nmProd;

    // Bom: pronunciável
    string nomeProduto;
}
#endregion

#region Use Nomes Pesquisáveis
/*
    Use Nomes Pesquisáveis:
    Nomes pesquisáveis facilitam a navegação e a modificação do código.
*/
public class ExemploNomesPesquisaveis
{
    // Ruim: não pesquisável
    int ic;

    // Bom: pesquisável
    int idadeCliente;
}
#endregion

#region Evite Codificações
/*
    Evite Codificações:
    Codificações e notações húngaras podem tornar o 
    código mais difícil de ler e entender.
*/
public class ExemploCodificacoes
{
    // Ruim: notação húngara
    int iContador;

    // Bom: sem codificação
    int contador;
}
#endregion

#region Interfaces e Implementações
/*
    Interfaces e Implementações:
    Nomear interfaces e suas implementações de forma clara 
    e consistente facilita a compreensão do papel de cada uma.
*/
public interface IRepositorioCliente
{
    void AdicionarCliente(Cliente cliente);
}

public class RepositorioCliente : IRepositorioCliente
{
    public void AdicionarCliente(Cliente cliente)
    {
        // Implementação do método
    }
}
#endregion

#region Evite Mapeamento Mental
/*
    Evite Mapeamento Mental:
    Nomes que exigem mapeamento mental tornam 
    o código mais difícil de entender.
*/
public class ExemploMapeamentoMental
{
    // Ruim: exige mapeamento mental
    int parcVlr;

    // Bom: sem mapeamento mental
    int valorParcial;
}
#endregion