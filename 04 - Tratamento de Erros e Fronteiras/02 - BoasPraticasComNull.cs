namespace CleanCode.M04_Tratamento_de_Erros_e_Fronteiras;

/*********************************/
/*     Boas Práticas com Null    */
/*********************************/

#region Não Retorne Null
/*
    Não Retorne Null:
    Evite retornar null para eliminar a necessidade de verificações nulas.
    Retornar um objeto vazio as vezes pode dar o mesmo nível de trabalho de validação
*/
public class Repositorio
{
    // Exemplo Ruim: Retornando null
    public Produto ObterProdutoPorId(int id)
    {
        // Simulação de busca no repositório
        return null; // Produto não encontrado
    }

    // Exemplo Bom: Usando Optional ou retornando uma coleção vazia
    public Produto? ObterProdutoPorIdSeguro(int id)
    {
        // Simulação de busca no repositório
        Produto? produto = /* lógica para obter o produto */ null;

        return produto; // Pode retornar null, mas uso de ? indica que o consumidor deve estar ciente
    }

    // Alternativa: Retornando uma lista vazia para múltiplos resultados
    public List<Produto> ObterProdutos()
    {
        // Simulação de busca no repositório
        List<Produto> produtos = /* lógica para obter produtos */ null;

        return produtos ?? new List<Produto>(); // Retorna uma lista vazia se não houver produtos
    }

    public record Produto(int Id, string Nome);
}
#endregion

#region Não Passe Null
/*
    Não Passe Null:
    Não passe null como argumento para evitar a propagação de erros.
*/

// Exemplo Ruim: Passando null
public class ProcessadorPedido
{
    // Exemplo Ruim: Aceitando e processando null sem validação
    public void Processar(Pedido pedido)
    {
        // Processamento do pedido sem validar se é null...
        // Isso é ruim porque permite que null seja processado
        // e cause falhas no código posteriormente.
        // Falha de execução se pedido for null.
        var nome = pedido.Nome; // Isso causará uma NullReferenceException
    }

    // Exemplo Bom: Validando argumento e lançando exceção
    public void ProcessarSeguro(Pedido pedido)
    {
        if (pedido == null)
        {
            throw new ArgumentNullException(nameof(pedido), "Pedido não pode ser null.");
        }

        // Processamento do pedido...
        var nome = pedido.Nome; // Isso é seguro porque null foi evitado
    }

    // Exemplo Alternativo: Em algum momento pode ser possível receber null e o código sabe disso
    // Nesse caso o compilador nao vai apontar a possibilidade do erro
    public void ProcessarSeguroAlternativo(Pedido? pedido)
    {
        if (pedido == null)
        {
            throw new ArgumentNullException(nameof(pedido), "Pedido não pode ser null.");
        }

        // Processamento do pedido...
        var nome = pedido.Nome; // Isso é seguro porque null foi evitado
    }
}
public record Pedido(int Id, string Nome);
#endregion

#region Como o C# lida com Null

public class Demo
{
    static void Main()
    {
        // Exemplo de tipo nullable
        int? nullableInt = null;
        Console.WriteLine($"Nullable int: {nullableInt}");

        // Verificando se uma variável nullable tem valor
        if (nullableInt.HasValue)
        {
            Console.WriteLine("nullableInt tem um valor.");
        }
        else
        {
            Console.WriteLine("nullableInt é nulo.");
        }

        // Operador de coalescência nula (??)
        int valorDefault = nullableInt ?? 10;
        Console.WriteLine($"Valor após coalescência nula: {valorDefault}");

        // Operador condicional null (?.) para acessar membros de objetos potencialmente nulos
        string mensagem = null;
        int? tamanhoMensagem = mensagem?.Length;
        Console.WriteLine($"Tamanho da mensagem: {tamanhoMensagem}");

        // Operador de coalescência nula (??) com strings
        string nome = null;
        string nomeOuPadrao = nome ?? "Nome padrão";
        Console.WriteLine($"Nome: {nomeOuPadrao}");

        // Usando o operador null-forgiving (!)
        string? nomeNullable = null;
        // Console.WriteLine(nomeNullable!.Length); // Isso lançará uma exceção em tempo de execução se nomeNullable for nulo

        // Tratamento de nulidade em classes
        Pessoa pessoa = new Pessoa();
        pessoa.Nome = null; // Nome é um string nullable

        // Acessando propriedades de um objeto potencialmente nulo com o operador condicional null (?.)
        string primeiroNome = pessoa.Nome?.Split(' ')[0] ?? "Primeiro nome não disponível";
        Console.WriteLine($"Primeiro nome: {primeiroNome}");

        // Usando o operador is para verificar nulidade
        if (pessoa.Nome is null)
        {
            Console.WriteLine("O nome da pessoa é nulo.");
        }

        // Usando o operador null-forgiving com mais segurança
        if (pessoa.Nome is not null)
        {
            Console.WriteLine($"Comprimento do nome: {pessoa.Nome.Length}");
        }

        // Usando o operador switch com valores nulos
        switch (nullableInt)
        {
            case null:
                Console.WriteLine("nullableInt é nulo no switch.");
                break;
            case int valor:
                Console.WriteLine($"nullableInt tem valor no switch: {valor}");
                break;
        }
    }
}

// <Project Sdk="Microsoft.NET.Sdk">
//   <PropertyGroup>
//     <OutputType>Exe</OutputType>
//     <TargetFramework>net8.0</TargetFramework>
//     <ImplicitUsings>enable</ImplicitUsings>
//     <Nullable>enable</Nullable>
//   </PropertyGroup>
// </Project>
   
// Habilitado(<Nullable>enable</Nullable>) :
   
// Força a consideração de nullabilidade nas variáveis de referência.
// Ajuda a prevenir erros de referência nula com avisos do compilador.
// Requer verificações explícitas de nullabilidade ou uso de operadores como ?..

// Desabilitado(<Nullable>disable</Nullable>) :
   
// Comportamento tradicional do C#, onde variáveis de referência podem ser nulas sem avisos.
// Maior risco de exceções de referência nula em tempo de execução.


class Pessoa
{
    public string? Nome { get; set; } // Propriedade nullable
}
#endregion