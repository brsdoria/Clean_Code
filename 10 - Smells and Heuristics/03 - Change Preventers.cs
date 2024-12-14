namespace CleanCode.M10_Smells_and_Heuristics;

/***********************************/
/*  Exemplos de Change Preventers  */
/***********************************/

#region Divergent Change
/*
    Divergent Change: Isso ocorre quando uma classe sofre muitas modificações por razões diferentes.
    Exemplo: A classe abaixo gerencia tanto a lógica de negócios quanto a lógica de e-mail para um cliente.
    Sempre que há uma mudança em uma dessas áreas, a classe precisa ser alterada.
*/

// Problema
public class ClienteService
{
    public void AdicionarCliente(Cliente cliente)
    {
        // Lógica de negócios
        cliente.DataCadastro = DateTime.Now;
        SalvarNoBanco(cliente);

        // Lógica de e-mail
        EnviarEmailDeBoasVindas(cliente.Email);
    }

    private void SalvarNoBanco(Cliente cliente)
    {
        // Código para salvar o cliente no banco de dados
    }

    private void EnviarEmailDeBoasVindas(string email)
    {
        // Código para enviar e-mail de boas-vindas
    }
}

public class Cliente
{
    public DateTime DataCadastro { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
}

// Solução
public class ClienteServiceRefatorado
{
    private readonly ClienteRepository _clienteRepository;
    private readonly EmailService2 _emailService;

    public ClienteServiceRefatorado(ClienteRepository clienteRepository, EmailService2 emailService)
    {
        _clienteRepository = clienteRepository;
        _emailService = emailService;
    }

    public void AdicionarCliente(Cliente cliente)
    {
        _clienteRepository.Salvar(cliente);
        _emailService.EnviarBoasVindas(cliente.Email);
    }
}

public class ClienteRepository
{
    public void Salvar(Cliente cliente)
    {
        // Código para salvar o cliente no banco de dados
    }
}

public class EmailService2
{
    public void EnviarBoasVindas(string email)
    {
        // Código para enviar e-mail de boas-vindas
    }
}
#endregion

#region Shotgun Surgery
/*
    Shotgun Surgery: Esse code smell ocorre quando uma simples mudança no sistema,
    como a alteração da taxa de serviço, impacta várias classes. O código abaixo 
    demonstra como a lógica de cálculo da taxa está espalhada por várias partes do sistema,
    resultando em modificações dispersas quando a taxa de serviço precisa ser alterada.
*/

public class ContaPoupanca
{
    public decimal Saldo { get; private set; }

    public void Sacar(decimal valor)
    {
        if (Saldo < valor)
        {
            NotificarTitular("SALDO_INSUFICIENTE_SAQUE");
            return;
        }
        // Implementação do saque
    }

    public void Transferir(decimal valor)
    {
        if (Saldo < valor)
        {
            NotificarTitular("SALDO_INSUFICIENTE_TRANSFERENCIA");
            return;
        }
        // Implementação da transferência
    }

    public void ProcessarTarifas(decimal tarifa)
    {
        Saldo -= tarifa;
        if (Saldo < tarifa)
        {
            NotificarTitular("AVISO_SALDO_INSUFICIENTE_TARIFAS");
            return;
        }
        // Implementação da tarifa
    }

    private void NotificarTitular(string motivo)
    {
        // Lógica para notificar o titular da conta
        Console.WriteLine($"Notificação enviada ao titular: {motivo}");
    }
}
/*
    Solução: Centralizar a lógica de verificação de saldo mínimo em um único método,
    para evitar a duplicação de código e facilitar a manutenção.
    Agora, qualquer mudança na lógica de verificação pode ser feita em um único lugar.
*/

public class ContaPoupancaRF
{
    public decimal Saldo { get; private set; }

    private bool VerificarSaldoMinimo(decimal valor, string motivo)
    {
        if (Saldo < valor)
        {
            NotificarTitular(motivo);
            return false;
        }
        return true;
    }

    public void Sacar(decimal valor)
    {
        if (!VerificarSaldoMinimo(valor, "SALDO_INSUFICIENTE_SAQUE")) return;
        // Implementação do saque
    }

    public void Transferir(decimal valor)
    {
        if (!VerificarSaldoMinimo(valor, "SALDO_INSUFICIENTE_TRANSFERENCIA")) return;
        // Implementação da transferência
    }

    public void ProcessarTarifas(decimal tarifa)
    {
        Saldo -= tarifa;
        if (!VerificarSaldoMinimo(tarifa, "AVISO_SALDO_INSUFICIENTE_TARIFAS")) return;
        // Implementação da tarifa
    }

    private void NotificarTitular(string motivo)
    {
        // Lógica para notificar o titular da conta
        Console.WriteLine($"Notificação enviada ao titular: {motivo}");
    }
}
#endregion

#region Parallel Inheritance Hierarchies
/*
    Parallel Inheritance Hierarchies: Este problema ocorre quando, para adicionar uma nova funcionalidade
    a uma hierarquia de classes, você precisa criar novas classes em várias hierarquias ao mesmo tempo.
    Exemplo: Novas funcionalidades exigem duplicação nas hierarquias Funcionario e Relatorio.
*/

public abstract class Transacao
{
    public string Id { get; set; }
    public double Valor { get; set; }
}

public class TransacaoBancaria : Transacao
{
    public string NomeBanco { get; set; }
}

public class TransacaoCartaoCredito : Transacao
{
    public string NumeroCartao { get; set; }
}

// Hierarquias paralelas de persistência
public class RepositorioTransacaoBancaria
{
    public void Salvar(TransacaoBancaria transacao) { }
    public TransacaoBancaria Obter(string id) { return null; }
}

public class RepositorioTransacaoCartaoCredito
{
    public void Salvar(TransacaoCartaoCredito transacao) { }
    public TransacaoCartaoCredito Obter(string id) { return null; }
}
/*
    Solução: Em vez de criar hierarquias paralelas de persistência, usamos um repositório genérico
    que lida diretamente com as classes de domínio, evitando duplicação de código e mantendo o foco no domínio.
*/

public class ServicoTransacao
{
    private readonly ITransacaoRepository _repositorio;

    public ServicoTransacao(ITransacaoRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public void SalvarTransacao(Transacao transacao)
    {
        _repositorio.Salvar(transacao);
    }

    public Transacao ObterTransacao(string id)
    {
        return _repositorio.Obter(id);
    }
}

public interface ITransacaoRepository
{
    void Salvar(Transacao transacao);
    Transacao Obter(string id);
}

public class RepositorioTransacao : ITransacaoRepository
{
    // Implementação de persistência, usando um framework como Entity Framework
    public void Salvar(Transacao transacao)
    {
        // Código de persistência no banco de dados
    }

    public Transacao Obter(string id)
    {
        // Código para carregar a transação do banco de dados
        return null; // Exemplo simplificado
    }
}
#endregion
