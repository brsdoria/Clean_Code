namespace CleanCode.M02_Funcoes_Simples;
/******************************/
/* Escrevendo Funções Simples */
/******************************/

#region Pequenas!
/*
    Pequenas!:
    Funções devem ser curtas e focadas em uma única tarefa.
    Idealmente, uma função deve ter entre 5 a 20 linhas de código.
    Funções curtas são mais fáceis de entender, testar e manter.
*/
public class FuncoesSimples
{
    // Ruim: função longa e complexa
    public void ExecutarProcesso()
    {
        // Lógica de consulta de dados { ... }
        // Lógica de validação de dados { ... }
        // Lógica de salvamento de dados { ... }
        // Lógica de envio de notificação { ... }
    }

    // Bom: funções curtas e focadas
    public List<string> ConsultarDados()
    {
        // Lógica de consulta de dados
        return new List<string>();
    }

    public List<string> ValidarDados(List<string> dados)
    {
        // Lógica de validação de dados
        return dados;
    }

    public void SalvarDados(List<string> dados)
    {
        // Lógica de salvamento de dados
    }

    public void EnviarNotificacao(List<string> dados)
    {
        // Lógica de envio de notificação
    }
}
#endregion

#region Faça Uma Coisa
/*
    Faça Uma Coisa:
    Cada função deve fazer apenas uma coisa e fazer bem.
    Se uma função está fazendo mais de uma coisa, deve ser dividida em funções menores.
*/
public class FazerUmaCoisa
{
    // Ruim: faz mais de uma coisa
    public void Processar()
    {
        // Lógica de processamento do relatório
        // Lógica de envio do relatório
    }

    // Boa: Orquestra pequenas unidades
    public void ProcessarEnviarRelatorio()
    {
        ProcessarRelatorio();
        EnviarRelatorio();
    }

    private void ProcessarRelatorio()
    {
        // Lógica de processamento do relatório
    }

    private void EnviarRelatorio()
    {
        // Lógica de envio do relatório
    }
}
#endregion

#region Blocos e Recuo
/*
    Blocos e Recuo:
    Use blocos de código claros e recuo consistente para melhorar a legibilidade.
*/
public class BlocosERecuo
{
    public void Exemplo()
    {
        if (true)
        {
            // Bloco de código com recuo consistente
            Console.WriteLine("Bloco de código bem formatado.");
        }
    }
}
#endregion

#region Seções dentro de Funções
/*
    Seções dentro de Funções:
    Evite dividir funções em seções, mantenha-as simples e focadas.
*/
public class SecoesDentroDeFuncoes
{
    // Ruim: função com seções
    public void ProcessarDadosComSecoes()
    {
        // Validação
        // ValidarDados  { ... }

        // Salvamento
        // SalvarDados { ... }

        // Notificação
        // EnviarNotificacao { ... }
    }

    // Bom: funções separadas
    public void ProcessarDados()
    {
        ValidarDados();
        SalvarDados();
        EnviarNotificacao();
    }

    private void ValidarDados() { /* ... */ }
    private void SalvarDados() { /* ... */ }
    private void EnviarNotificacao() { /* ... */ }
}
#endregion

#region Um Nível de Abstração por Função
/*
    Um Nível de Abstração por Função:
    Mantenha cada função em um único nível de abstração.
*/
public class NivelDeAbstracao
{
    // Ruim: diferentes níveis de abstração
    public void ProcessarRelatorio()
    {
        // Alto nível
        ObterDados();

        // Baixo nível
        ValidarDados();
        SalvarDados();
    }

    // Bom: um nível de abstração por função
    public void ProcessarRelatorioAltoNivel()
    {
        var dados = ObterDados();
        Atualizar(dados);
    }

    private void Atualizar(List<string> dados)
    {
        ValidarDados();
        SalvarDados();
    }

    private List<string> ObterDados() { return new List<string>(); }
    private void ValidarDados() { /* ... */ }
    private void SalvarDados() { /* ... */ }
}
#endregion
