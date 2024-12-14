namespace CleanCode.M02_Funcoes_Simples;

/***************************************/
/* Estrutura e Legibilidade de Funções */
/***************************************/

#region Ler Código de Cima para Baixo: A Regra da Descida
/*
    Ler Código de Cima para Baixo: A Regra da Descida:
    O código deve ser lido como uma história, de cima para baixo.
*/
public class RegraDaDescida
{
    public void Executar()
    {
        PrepararAmbiente();
        ProcessarDados();
        Finalizar();
    }

    private void PrepararAmbiente() { /* ... */ }
    private void ProcessarDados() { /* ... */ }
    private void Finalizar() { /* ... */ }
}
#endregion

#region Instruções Switch
/*
    Instruções Switch:
    Use-as com parcimônia e prefira abstrações que eliminem a necessidade de muitos switch cases.
    A regra é: Se aparece apenas uma vez ok, se mais de uma então resolva de outra forma.
*/
public class InstrucoesSwitch
{
    // Ruim: muitos casos no switch
    public string ObterDescricao(int codigo)
    {
        switch (codigo)
        {
            case 1: return "Descrição 1";
            case 2: return "Descrição 2";
            case 3: return "Descrição 3";
            // ...
            default: return "Descrição desconhecida";
        }
    }

    // Bom: usar um dicionário para eliminar o switch
    private static readonly Dictionary<int, string> Descricoes = new Dictionary<int, string>
        {
            { 1, "Descrição 1" },
            { 2, "Descrição 2" },
            { 3, "Descrição 3" },
            // ...
        };

    public string ObterDescricaoMelhorada(int codigo)
    {
        return Descricoes.ContainsKey(codigo) ? Descricoes[codigo] : "Descrição desconhecida";
    }
}
#endregion

#region Use Nomes Descritivos
/*
    Use Nomes Descritivos:
    Nomes de funções devem ser descritivos e revelar a intenção.
*/
public class NomesDescritivos
{
    // Ruim: nome não descritivo
    public void ProcPag_0002() { /* ... */ }

    // Bom: nome descritivo
    public void ProcessarPagamento() { /* ... */ }
}
#endregion

#region Argumentos de Funções
/*
    Argumentos de Funções:
    Funções devem ter poucos argumentos, idealmente não mais que três.
    Muitos argumentos podem indicar que a função está fazendo mais do que deveria.
*/
public class ArgumentosDeFuncao
{
    // Ruim: muitos argumentos
    public void CriarUsuario(string nome, string sobrenome, int idade, string endereco, string email)
    {
        // Lógica de criação de usuário
    }

    // Bom: agrupar argumentos relacionados
    public void CriarUsuario(Usuario usuario)
    {
        // Lógica de criação de usuário
    }
}

public class Usuario
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public int Idade { get; set; }
    public string Endereco { get; set; }
    public string Email { get; set; }
}
#endregion

