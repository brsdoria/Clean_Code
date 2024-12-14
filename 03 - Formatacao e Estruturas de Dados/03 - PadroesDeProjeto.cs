namespace CleanCode.M03_Principios_De_Formatacao;

/*********************************/
/*      Padrões de Projeto       */
/*********************************/


#region Acidentes de Trem
/*
    Acidentes de Trem:
    Longas cadeias de chamadas de método que dificultam a compreensão e manutenção do código.
    Isto é previnido aplicando a Lei de Demeter!
*/
public class AcidenteDeTrem
{
    // Exemplo Ruim: acidente de trem
    public void ExibirEndereco(Cliente cliente)
    {
        Console.WriteLine(cliente.Endereco.Cidade.Nome);
    }
}
#endregion

#region Híbridos
/*
    Híbridos:
    Classes com características de objetos e estruturas de dados são difíceis de entender e manter.
*/
public class Hibrido
{
    // Exemplo Ruim: classe híbrida
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    public string NomeCompleto()
    {
        return Nome + " " + Sobrenome;
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }
}

public class HibridoMelhor
{
    // Exemplo Bom: separação de responsabilidades
    private string nome;
    private string sobrenome;

    public string NomeCompleto()
    {
        return $"{nome} {sobrenome}";
    }

    public void AtualizarNome(string nome)
    {
        this.nome = nome;
    }
}
#endregion

#region Esconder Estrutura
/*
    Esconder Estrutura:
    Exponha apenas o necessário e esconda a implementação interna para proteger a integridade dos dados.
*/
public class BancoDados
{
    // Exemplo Ruim: exposição da estrutura interna
    public List<string> Usuarios { get; set; }

    public BancoDados()
    {
        Usuarios = new List<string>();
    }
}

public class BancoDadosSeguro
{
    // Exemplo Bom: esconder estrutura
    private List<string> usuarios;

    public BancoDadosSeguro()
    {
        usuarios = new List<string>();
    }

    public void AdicionarUsuario(string usuario)
    {
        usuarios.Add(usuario);
    }

    public IReadOnlyList<string> ObterUsuarios()
    {
        return usuarios.AsReadOnly();
    }
}
#endregion

#region Objetos de Transferência de Dados
/*
    Objetos de Transferência de Dados:
    Estruturas de dados simples usadas para transferir dados entre subsistemas.
*/
public class UsuarioDTO
{
    // Exemplo Bom: objeto de transferência de dados
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
}

// Melhor ainda, utilizando Records:
public record UsuarioRDTO(string Nome, string Email, DateTime DataNascimento);

#endregion

#region Registro Ativo
/*
    Registro Ativo:
    Combina dados e comportamento, mas frequentemente é usado de maneira que viola princípios de design.
*/

// Exemplo Ruim: mistura de dados e comportamento
public class ProdutoRegistroAtivo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }

    public void AtualizarEstoque(int quantidade)
    {
        QuantidadeEmEstoque += quantidade;
    }

    public decimal CalcularValorTotal()
    {
        return Preco * QuantidadeEmEstoque;
    }
}

// Exemplo Bom: separação de dados e comportamento
public class Produto
{
    public int Id { get; }
    public string Nome { get; }
    private decimal preco;
    private int quantidadeEmEstoque;

    public Produto(int id, string nome, decimal preco, int quantidadeEmEstoque)
    {
        Id = id;
        Nome = nome;
        this.preco = preco;
        this.quantidadeEmEstoque = quantidadeEmEstoque;
    }

    public decimal Preco => preco;
    public int QuantidadeEmEstoque => quantidadeEmEstoque;

    public void AtualizarEstoque(int quantidade)
    {
        quantidadeEmEstoque += quantidade;
    }

    public void AtualizarPreco(decimal novoPreco)
    {
        if (novoPreco > 0)
        {
            preco = novoPreco;
        }
    }

    public decimal CalcularValorTotal()
    {
        return preco * quantidadeEmEstoque;
    }
}

#endregion
