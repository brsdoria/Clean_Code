namespace CleanCode.M10_Smells_and_Heuristics;

/***********************************/
/*    Exemplos de Dispensables     */
/***********************************/

#region Comentários (Comments)
/*
    Comentários: Embora possam ser úteis em certos casos, o excesso de comentários
    geralmente indica que o código não está claro o suficiente. Em código limpo,
    o código deve ser autoexplicativo, por meio de bons nomes de variáveis,
    métodos e classes. A presença de muitos comentários pode ser um sinal
    de que o código precisa ser refatorado para melhorar a legibilidade.
*/

// Problema: Comentários explicando o que o código faz
public class CalculadoraFinanceira
{
    // Calcula o total com imposto
    public decimal CalcularTotal(decimal valor, decimal imposto)
    {
        // Adiciona o imposto ao valor original
        return valor + (valor * imposto);
    }
}

// Solução: Código autoexplicativo sem a necessidade de comentários
public class CalculadoraFinanceiraRefatorada
{
    public decimal CalcularTotalComImposto(decimal valor, decimal percentualImposto)
    {
        return valor + (valor * percentualImposto);
    }
}
#endregion

#region Código Duplicado (Duplicate Code)
/*
    Código Duplicado: Duplicar código em diferentes partes do sistema aumenta
    a complexidade e o esforço de manutenção. Alterar um bloco duplicado
    exige que todas as cópias sejam atualizadas, o que pode introduzir erros.
*/

// Problema: Código duplicado em dois métodos diferentes
public class RelatorioVendas
{
    public decimal CalcularTotalVendas(List<decimal> vendas)
    {
        decimal total = 0;
        foreach (var venda in vendas)
        {
            total += venda;
        }
        return total;
    }

    public decimal CalcularTotalDescontos(List<decimal> descontos)
    {
        decimal total = 0;
        foreach (var desconto in descontos)
        {
            total += desconto;
        }
        return total;
    }
}

// Solução: Extrair o código duplicado para um método reutilizável
public class RelatorioVendasRefatorado
{
    public decimal CalcularTotal(List<decimal> valores)
    {
        decimal total = 0;
        foreach (var valor in valores)
        {
            total += valor;
        }
        return total;
    }

    public decimal CalcularTotalVendas(List<decimal> vendas) => CalcularTotal(vendas);
    public decimal CalcularTotalDescontos(List<decimal> descontos) => CalcularTotal(descontos);
}
#endregion

#region Classe de Dados (Data Class)
/*
    Classe de Dados: Classes que apenas armazenam dados sem comportamentos associados
    são consideradas dispensáveis em sistemas orientados a objetos. O comportamento
    deve estar próximo dos dados, para manter o código mais coeso e orientado ao domínio.
*/

// Problema: Classe de dados sem comportamentos
public class Cliente2
{
    public string Nome { get; set; }
    public string Endereco { get; set; }
}

// Solução: Adicionar comportamento à classe de dados
public class ClienteRefatorado
{
    public string Nome { get; private set; }
    public string Endereco { get; private set; }

    public ClienteRefatorado(string nome, string endereco)
    {
        Nome = nome;
        Endereco = endereco;
    }

    public void AtualizarEndereco(string novoEndereco)
    {
        Endereco = novoEndereco;
    }
}
#endregion

#region Código Morto (Dead Code)
/*
    Código Morto: Código que não é mais utilizado ou chamado em nenhuma parte do sistema
    é considerado código morto. Isso inclui variáveis, métodos ou classes que ficaram
    obsoletas após mudanças no sistema. Código morto aumenta a complexidade
    sem trazer valor ao sistema e deve ser removido.
*/

// Problema: Método que nunca é chamado em lugar nenhum
public class GeradorRelatorio
{
    public void GerarRelatorioVendas()
    {
        // Lógica para gerar relatório de vendas
    }

    // Código morto, não utilizado
    public void GerarRelatorioObsoleto()
    {
        // Lógica obsoleta
    }
}

// Solução: Remover código morto
public class GeradorRelatorioRefatorado
{
    public void GerarRelatorioVendas()
    {
        // Lógica para gerar relatório de vendas
    }
}
#endregion

#region Classe Preguiçosa (Lazy Class)
/*
    Classe Preguiçosa: Classes que têm pouca responsabilidade ou que foram criadas
    para suportar uma funcionalidade específica, mas acabaram não sendo necessárias.
    Essas classes aumentam a complexidade do sistema sem realmente agregar valor.
*/

// Problema: Classe com pouca responsabilidade
public class ValidadorEmail
{
    public bool ValidarFormato(string email)
    {
        return email.Contains("@");
    }
}

// Solução: Mover o comportamento para uma classe mais coesa
public class Usuario
{
    public string Email { get; private set; }

    public Usuario(string email)
    {
        if (!ValidarEmail(email))
            throw new ArgumentException("Email inválido");

        Email = email;
    }

    private bool ValidarEmail(string email)
    {
        return email.Contains("@");
    }
}
#endregion

#region Generalidade Especulativa (Speculative Generality)
/*
    Generalidade Especulativa: Código que foi escrito para lidar com cenários futuros
    que talvez nunca aconteçam. Isso resulta em complexidade adicional sem benefício imediato,
    e é uma forma de otimização prematura. Evitar escrever código que não é necessário agora.
*/

// Problema: Método genérico especulativo
public class ExportadorDados
{
    public void ExportarParaFormato(string formato, object dados)
    {
        if (formato == "JSON")
        {
            // Exportar para JSON
        }
        else if (formato == "XML")
        {
            // Exportar para XML
        }
        // Outros formatos não implementados ainda, especulativo
    }
}

// Solução: Implementar apenas o necessário
public class ExportadorDadosRefatorado
{
    public void ExportarParaJson(object dados)
    {
        // Exportar para JSON
    }
}
#endregion
