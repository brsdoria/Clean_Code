namespace CleanCode.M03_Principios_De_Formatacao;

/*********************************/
/*   Princípios de Formatação    */
/*********************************/

#region O Propósito da Formatação
/*
    O Propósito da Formatação:
    A formatação adequada do código é essencial para a legibilidade e manutenção, facilitando a compreensão e colaboração.
*/
public class PropositoFormatacao
{
    // Exemplo Ruim: código desorganizado e difícil de ler
    public void ExemploRuim()
    {
        int soma = 1 + 2; Console.WriteLine(soma);
    }

    // Exemplo Bom: código bem formatado e legível
    public void ExemploBom()
    {
        int soma = 1 + 2;
        Console.WriteLine(soma);
    }
}
#endregion

#region Formatação Vertical
/*
    Formatação Vertical:
    Organize o código de forma lógica e coerente, facilitando a leitura de cima para baixo.
*/
public class FormatacaoVertical
{
    // Propriedade
    public int Valor { get; set; }

    // Exemplo Ruim: código não estruturado verticalmente
    public void ExemploRuim()
    {
        if (Valor > 0) { Console.WriteLine("Valor positivo"); } else { Console.WriteLine("Valor não positivo"); }
    }

    // Exemplo Bom: código organizado verticalmente
    public void ExemploBom()
    {
        if (Valor > 0)
        {
            Console.WriteLine("Valor positivo");
        }
        else
        {
            Console.WriteLine("Valor não positivo");
        }
    }
}
#endregion

#region Formatação Horizontal
/*
    Formatação Horizontal:
    Use espaços e alinhamentos para melhorar a legibilidade dentro de uma linha de código.
*/
public class FormatacaoHorizontal
{
    // Exemplo Ruim: falta de espaços e alinhamento
    public void ExemploRuim()
    {
        int resultado=1+2;Console.WriteLine(resultado);
        Calcular(1,2,3);
    }

    // Exemplo Bom: uso adequado de espaços e alinhamento
    public void ExemploBom()
    {
        // Espaços ao redor de operadores e vírgulas
        int resultado = 1 + 2;
        Console.WriteLine(resultado);

        // Espaços após vírgulas em listas de parâmetros
        Calcular(1, 2, 3);
    }

    // Método auxiliar
    private void Calcular(int a, int b, int c)
    {
        Console.WriteLine(a + b + c);
    }
}
#endregion

#region Regras da Equipe
/*
    Regras da Equipe:
    Defina e siga regras de formatação para garantir consistência e facilitar a colaboração.
*/
public class RegrasEquipe
{
    // Propriedade seguindo convenções da equipe
    public int NumeroMembros { get; set; }

    // Exemplo Ruim: não segue as regras da equipe
    public void ExemploRuim()
    {
        for (int i = 0; i < NumeroMembros; i++) { Console.WriteLine("Membro " + i); }
    }

    // Exemplo Bom: código consistente com as regras da equipe
    public void ExemploBom()
    {
        for (int i = 0; i < NumeroMembros; i++)
        {
            Console.WriteLine("Membro " + i);
        }
    }
}
#endregion

#region Regras de Formatação do Uncle Bob
/*
    Regras de Formatação do Uncle Bob:
    Práticas de formatação que contribuem para a clareza e manutenção do código.
*/
public class RegrasUncleBob
{
    // Propriedade seguindo as regras de Uncle Bob
    public string Nome { get; set; }

    // Exemplo Ruim: não segue as práticas de Uncle Bob
    public void ExemploRuim()
    {
        if (Nome != "") { Console.WriteLine("Nome válido: " + Nome); } else { Console.WriteLine("Nome inválido"); }
    }

    // Exemplo Bom: seguindo as práticas de Uncle Bob
    public void ExemploBom()
    {
        // Indentação consistente e nomes claros
        if (!string.IsNullOrEmpty(Nome))
        {
            Console.WriteLine("Nome válido: " + Nome);
        }
        else
        {
            Console.WriteLine("Nome inválido");
        }
    }
}
#endregion