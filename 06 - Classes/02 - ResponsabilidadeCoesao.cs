namespace CleanCode.M06_Classes;

/*********************************/
/*   Responsabilidade e Coesão   */
/*********************************/

#region Classes Devem Ser Pequenas!
/*
    Classes Devem Ser Pequenas!:
    Classes pequenas são mais fáceis de entender e manter.
*/
public class ClasseGrandeRuim
{
    // Ruim: Classe com muitas responsabilidades
    public void ProcessarDados() { /* ... */ }
    public void ConectarBancoDeDados() { /* ... */ }
    public void ValidarEntrada() { /* ... */ }
}

public class ClassePequenaBoa
{
    // Bom: Classes pequenas com responsabilidades únicas
    public void ProcessarDados() { /* ... */ }
}

public class ConexaoBancoDeDados
{
    public void Conectar() { /* ... */ }
}

public class ValidacaoEntrada
{
    public void Validar() { /* ... */ }
}
#endregion

#region O Princípio da Responsabilidade Única
/*
    O Princípio da Responsabilidade Única:
    Cada classe deve ter uma única responsabilidade.
*/
public class RelatorioRuim
{
    // Ruim: Classe com múltiplas responsabilidades
    public void GerarRelatorio() { /* ... */ }
    public void EnviarEmail() { /* ... */ }
}

public class RelatorioBom
{
    // Bom: Classe com uma única responsabilidade
    public void Gerar() { /* ... */ }
}

public class EmailService
{
    public void Enviar() { /* ... */ }
}
#endregion

#region Coesão
/*
    Coesão:
    Mantenha métodos relacionados juntos na mesma classe.
*/
public class PedidoRuim
{
    // Ruim: Métodos não relacionados na mesma classe
    public void Pagamento() { /* ... */ }
    public void Reclamacao() { /* ... */ }
    public void ConsultaCep() { /* ... */ }
}

public class PedidoBom
{
    // Bom: Métodos relacionados na mesma classe
    public void Processar() { /* ... */ }
    public void Cancelar() { /* ... */ }
}
#endregion

#region Manter a Coesão Resulta em Diversas Classes Pequenas
/*
    Manter a coesão resulta em diversas classes pequenas:
    Divida responsabilidades para manter classes coesas.
*/
public class Pedido
{
    public void AdicionarItem() { /* ... */ }
}

public class Pagamento
{
    public void ProcessarPagamento() { /* ... */ }
}
#endregion

#region Organizando para Mudanças
/*
    Organizando para mudanças:
    Estruture o código para facilitar futuras mudanças.
    Aplicando o Princípio Aberto/Fechado (OCP):
    O código deve ser aberto para extensão, mas fechado para modificação.
*/
public abstract class OrdemServico
{
    public abstract void CriarOrdem();
    public abstract void AtualizarOrdem();
}

public class OrdemServicoSistemaAtual : OrdemServico
{
    public override void CriarOrdem()
    {
        // Lógica para criar ordem no sistema atual
    }

    public override void AtualizarOrdem()
    {
        // Lógica para atualizar ordem no sistema atual
    }
}

public class OrdemServicoNovoSistema : OrdemServico
{
    public override void CriarOrdem()
    {
        // Nova lógica para criar ordem no novo sistema
    }

    public override void AtualizarOrdem()
    {
        // Nova lógica para atualizar ordem no novo sistema
    }
}
#endregion

#region Isolando para Mudanças
/*
    Isolando para mudanças:
    Separe partes do código que mudam frequentemente.
*/
public class ConfiguracaoSistema
{
    // Ruim: Configuração diretamente no código
    public string ObterConfiguracao() { return "Config"; }
}

public class ConfiguracaoSistemaIsolada
{
    private readonly IConfiguracaoRepositorio _configuracaoRepositorio;

    public ConfiguracaoSistemaIsolada(IConfiguracaoRepositorio configuracaoRepositorio)
    {
        _configuracaoRepositorio = configuracaoRepositorio;
    }

    public string ObterConfiguracao()
    {
        return _configuracaoRepositorio.BuscarConfiguracao();
    }
}

public interface IConfiguracaoRepositorio
{
    string BuscarConfiguracao();
}
#endregion
