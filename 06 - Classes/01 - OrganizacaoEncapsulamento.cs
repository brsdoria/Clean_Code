namespace CleanCode.M06_Classes;

/*********************************/
/* Organização e Encapsulamento  */
/*********************************/

#region Organização de Classes
/*
    Organização de Classes:
    Estruture as classes de maneira lógica e ordenada.
*/
public class OrganizaClasse
{
    // Ruim: métodos e variáveis misturados
    public void MetodoPublico() { /* ... */ }
    private int variavelPrivada;
    public int VariavelPublica;

    // Bom: variáveis e constantes antes dos métodos
    public const int CONSTANTE = 10;
    private static int variavelEstaticaPrivada;
    private int variavelInstanciaPrivada;

    public void MetodoPublicoOrdenado() { /* ... */ }
    private void MetodoPrivadoUtilitario() { /* ... */ }
}
#endregion

#region Encapsulamento
/*
    Encapsulamento:
    Proteja as variáveis e métodos internos das classes.
*/
public class Encapsulamento
{
    // Ruim: variáveis públicas expostas
    public int dadosPublicos;

    // Bom: uso de métodos para acesso controlado
    private int dadosPrivados;

    public int GetDados() { return dadosPrivados; }
    public void SetDados(int valor) { dadosPrivados = valor; }
}
#endregion
