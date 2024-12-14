namespace CleanCode.M04_Tratamento_de_Erros_e_Fronteiras;

/***************************/
/*  Práticas de Fronteira  */
/***************************/

#region Usando Código que Ainda Não Existe

/*
    Durante o desenvolvimento, pode ser necessário trabalhar com interfaces ou 
    subsistemas que ainda não foram definidos ou implementados.
 */

// Exemplo Ruim
// Desenvolvimento bloqueado pela falta de interface
public class DesenvolvimentoRuim
{
    private Transmitter transmitter;

    public void EnviarDados(string dados)
    {
        //transmitter.Send(dados); // Transmitter ainda não definido
    }
}

public record Transmitter();

// Exemplo Bom
// Uso de interface temporária para continuar o desenvolvimento
public interface ITransmitter
{
    void Send(string data);
}

public class MockTransmitter : ITransmitter
{
    public void Send(string data)
    {
        Console.WriteLine($"Mock sending: {data}");
    }
}

public class DesenvolvimentoBom
{
    private readonly ITransmitter transmitter;

    public DesenvolvimentoBom(ITransmitter transmitter)
    {
        this.transmitter = transmitter;
    }

    public void EnviarDados(string dados)
    {
        transmitter.Send(dados);
    }
}

#endregion

#region Fronteiras Limpas

/*
    Manter uma separação clara entre o código do projeto e o código de terceiros 
    é essencial para a manutenção e flexibilidade do sistema:
 */

// Exemplo Ruim
// Dependência direta de biblioteca de terceiros sem encapsulamento
public class FronteiraRuim
{
    public void RealizarOperacao()
    {
        var cliente = new ApiClient(); // Uso direto de uma biblioteca externa
        cliente.FazerRequisicao();
    }
}

// Exemplo Bom
// Encapsulamento da interação com a biblioteca de terceiros
// A ideia aqui alem de encapsular é adaptar todo contexto externo ao interno
public interface IApiCliente
{
    void FazerRequisicao();
}

public class ApiClienteWrapper : IApiCliente
{
    private readonly ApiClient cliente = new ApiClient();

    public void FazerRequisicao()
    {
        cliente.FazerRequisicao();
    }
}

public class FronteiraBoa
{
    private readonly IApiCliente apiCliente;

    public FronteiraBoa(IApiCliente apiCliente)
    {
        this.apiCliente = apiCliente;
    }

    public void RealizarOperacao()
    {
        apiCliente.FazerRequisicao();
    }
}


public class ApiClient()
{
    public void FazerRequisicao() { }
}
#endregion