namespace CleanCode.M02_Funcoes_Simples;

/*********************************/
/* Práticas Avançadas de Funções */
/*********************************/

#region Verbos e Palavras-Chave
/*
    Verbos e Palavras-Chave:
    Use verbos para nomes de funções e palavras-chave relevantes.
*/
public class VerbosPalavrasChave
{
    // Ruim: nome não expressivo
    public void Dados() { /* ... */ }

    // Bom: uso de verbo e palavra-chave
    public void ProcessarDados() { /* ... */ }
}
#endregion

#region Não Tenha Efeitos Colaterais
/*
    Não Tenha Efeitos Colaterais:
    Funções devem evitar alterar estados fora de seu escopo.
    Efeitos colaterais podem tornar o comportamento da função imprevisível e difícil de testar.
*/
public class EviteEfeitosColaterais
{
    private List<string> items = new List<string>();

    // Ruim: função com efeito colateral
    public void AdicionarItem(string item)
    {
        items.Add(item);
    }

    // Bom: função sem efeito colateral
    public List<string> ObterListaAtualizada(List<string> listaAtual, string item)
    {
        var novaLista = new List<string>(listaAtual);
        novaLista.Add(item);
        return novaLista;
    }
}
#endregion

#region Argumentos de Saída
/*
    Argumentos de Saída:
    Evite modificar argumentos de saída, prefira retornar novos valores.
*/
public class ArgumentosDeSaida
{
    // Ruim: modificando argumentos de saída
    public void AtualizarUsuario(Usuario usuario, string novoEndereco)
    {
        // Modifica diretamente a propriedade do objeto passado como argumento
        usuario.Endereco = novoEndereco;
    }

    // Bom: retornando novos valores
    public Usuario ObterUsuarioAtualizado(Usuario usuario, string novoEndereco)
    {
        return new Usuario
        {
            Nome = usuario.Nome,
            Sobrenome = usuario.Sobrenome,
            Idade = usuario.Idade,
            Endereco = novoEndereco,
            Email = usuario.Email
        };
    }
}
#endregion

#region Separação de Comando e Consulta
/*
    Separação de Comando e Consulta:
    Separe funções que realizam ações (comandos) das que retornam valores (consultas).
*/
public class ComandoConsulta
{
    // Comando
    public void AtualizarUsuario(Usuario usuario)
    {
        // Lógica de atualização do usuário
    }

    // Consulta
    public Usuario ObterUsuario(int id)
    {
        // Lógica de obtenção do usuário
        return new Usuario();
    }
}
#endregion

#region Prefira Exceções a Códigos de Retorno de Erro
/*
    Prefira Exceções a Códigos de Retorno de Erro:
    Use exceções para tratar erros de forma clara.
*/
public class ExcecoesVsCodigosDeErro
{
    // Ruim: uso de "FALSE" de retorno para erro
    public class LeitorDeArquivoRuim
    {
        public string LerArquivo(string caminho, out bool sucesso)
        {
            sucesso = true;
            try
            {
                return File.ReadAllText(caminho);
            }
            catch (FileNotFoundException)
            {
                sucesso = false;
                return string.Empty;
            }
        }
    }

    // Bom: uso de exceções para erro
    // Deixe a exception ocorrer e trate num outro nivel.
    public class LeitorDeArquivoBom
    {
        // Bom: uso de exceções para indicar erro
        public string LerArquivo(string caminho)
        {
            return File.ReadAllText(caminho);
        }
    }
}
#endregion

#region Extraia Blocos Try/Catch
/*
    Extraia Blocos Try/Catch:
    Mantenha os blocos try/catch pequenos e extraia-os para funções específicas.
*/
public class BlocosTryCatch
{
    public void Executar()
    {
        try
        {
            ProcessarDados();
        }
        catch (Exception ex)
        {
            LogarErro(ex);
            throw;
        }
    }

    private void ProcessarDados()
    {
        // Lógica de processamento de dados
    }

    private void LogarErro(Exception ex)
    {
        // Lógica de logging de erro
    }
}
#endregion

#region Tratamento de Erros é Uma Coisa
/*
    Tratamento de Erros é Uma Coisa:
    Funções devem ter uma responsabilidade única, incluindo o tratamento de erros.
*/
public class TratamentoDeErros
{
    // Ruim: mistura lógica de negócios com tratamento de erros
    // Se a palavra-chave try aparece em uma função, ela deve ser a primeira palavra
    // e não deve haver nada depois dos blocos catch/finally.
    public void ExecutarProcesso()
    {
        ObterDados();

        try
        {           
            ProcessarDados();            
        }
        catch (Exception ex)
        {
            TratarErro(ex);
        }

        EnviarNotificao();
    }

    // Bom: separa lógica de negócios e tratamento de erros
    public void ExecutarProcessamento()
    {
        ObterDados();
        ProcessarDadosInterno();
        EnviarNotificao();
    }

    private void ProcessarDadosInterno() 
    {
        try
        {
            ProcessarDados();
        }
        catch (Exception ex)
        {
            TratarErro(ex);
            throw;
        }
    }

    private void ObterDados() { }
    private void ProcessarDados() { }
    private void TratarErro(Exception ex) { }
    private void EnviarNotificao() { }
}
#endregion

#region Não Se Repita
/*
    Não Se Repita:
    Evite duplicação de código, extraia funcionalidades repetidas em funções comuns.
*/
public class NaoSeRepita
{
    // Ruim: código duplicado
    public void ProcessarPedido()
    {
        ValidarDados();
        SalvarDados();
    }

    public void ProcessarPedidoExpresso()
    {
        ValidarDados();
        SalvarDados();
    }

    // Bom: código reutilizado
    public void ProcessarPedidoGeral()
    {
        ValidarESalvarDados();
    }

    private void ValidarESalvarDados()
    {
        ValidarDados();
        SalvarDados();
    }

    private void ValidarDados() { /* ... */ }
    private void SalvarDados() { /* ... */ }
}
#endregion

