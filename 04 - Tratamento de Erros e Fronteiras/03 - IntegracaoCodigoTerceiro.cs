using log4net;
namespace CleanCode.M04_Tratamento_de_Erros_e_Fronteiras;

/****************************************/
/*  Integração com Código de Terceiros  */
/****************************************/

#region Usando Código de Terceiros

/*
    Existe muita tensão entre o código interno ou externo, padroes, retornos, chamadas
    Nesse caso é importante encapsular a responsabilidade num Wrapper
 */

// Exemplo Ruim
// Dependência direta de biblioteca de terceiros
public class ExemploRuim
{
    private static readonly ILog log = LogManager.GetLogger(typeof(ExemploRuim));

    public void FazerAlgo()
    {
        log.Info("Fazendo algo...");
    }
}

// Exemplo Bom
// Encapsulamento da biblioteca de terceiros
public interface IMeuLogger
{
    void Info(string message);
}

public class MeuLogger : IMeuLogger
{
    private static readonly ILog log = LogManager.GetLogger(typeof(MeuLogger));

    public void Info(string message)
    {
        log.Info(message);
    }
}

public class ExemploBom
{
    private readonly IMeuLogger logger;

    public ExemploBom(IMeuLogger logger)
    {
        this.logger = logger;
    }

    public void FazerAlgo()
    {
        logger.Info("Fazendo algo...");
    }
}

#endregion

#region Explorando e Aprendendo Fronteiras
/*
    A ideia aqui é sempre criar um programa de teste para cobrir
    situações comuns e testar o comportamento do codigo externo.
 */

// Exemplo Ruim
// Falta de testes exploratórios
public class ExploracaoRuim
{
    public void ConfigurarLogger()
    {
        var log = LogManager.GetLogger(typeof(ExploracaoRuim));
        log.Info("Logger configurado");
    }
}

// Exemplo Bom
// Testes exploratórios para entender a biblioteca
public class ExploracaoBoa
{
    public void TestarLog4Net()
    {
        var log = LogManager.GetLogger(typeof(ExploracaoBoa));
        log.Info("Teste de info");
        log.Warn("Teste de warn");
        log.Error("Teste de erro");
    }
}
#endregion