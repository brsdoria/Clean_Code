namespace CleanCode.M01_Nomes_e_Comentarios;

/******************************/
/*       Bons Comentários     */
/******************************/

#region Comentários Não Compensam Código Ruim
/*
    Comentários Não Compensam Código Ruim:
    Comentários não devem ser usados para compensar um código mal escrito. 
    O código deve ser autoexplicativo.
*/
public class CodigoRuim
{
    // Ruim: comentário tentando compensar código ruim
    int dp; // número de dias desde o início do projeto

    // Bom: código autoexplicativo
    int diasDesdeInicioProjeto; // número de dias desde o início do projeto
}
#endregion

#region Explique-se no Código
/*
    Explique-se no Código:
    Prefira explicar-se no código em vez de adicionar comentários.
*/
public class ExpliqueSeNoCodigo
{
    // Ruim: comentário explicando variável
    int ts; // tempo em segundos

    // Bom: nome de variável descritivo
    int tempoEmSegundos;
}
#endregion

#region Comentários Legais
/*
    Comentários Legais:
    Comentários legais são necessários para declarar direitos autorais e licenças.
*/
/*
    © 2024 Empresa XYZ. Todos os direitos reservados.
    Este código está licenciado sob a licença XYZ.
*/
public class ComentariosLegais
{
    // Implementação da classe
}
#endregion

#region Comentários Informativos
/*
    Comentários Informativos:
    Comentários informativos fornecem informações adicionais que 
    não estão diretamente no código.
*/
public class ComentariosInformativos
{
    // Este método usa o algoritmo de Dijkstra para encontrar o caminho mais curto.
    public void EncontrarCaminhoMaisCurto() { /* ... */ }
}
#endregion

#region Explicação de Intenção
/*
    Explicação de Intenção:
    Use comentários para explicar a intenção por trás de um pedaço de código.
*/
public class ExplicacaoDeIntencao
{
    // Usamos um mapa hash aqui para garantir que a pesquisa seja O(1).
    Dictionary<int, string> mapa = new Dictionary<int, string>();
}
#endregion

#region Esclarecimento
/*
    Esclarecimento:
    Comentários de esclarecimento ajudam a entender partes complexas do código.
*/
public class Esclarecimento
{
    // A linha abaixo normaliza o vetor.
    public int vetor = Vetor.Normalizar();
}
#endregion

#region Aviso de Consequências
/*
    Aviso de Consequências:
    Use comentários para avisar sobre possíveis consequências de certas ações no código.
*/
public class AvisoDeConsequencias
{
    // Cuidado: alterar esta variável afetará todas as instâncias da classe.
    static int contadorGlobal;
}
#endregion

#region Comentários TODO
/*
    Comentários TODO:
    Use comentários TODO para marcar tarefas a serem concluídas no futuro.
*/
public class ComentariosTODO
{
    // TODO: implementar verificação de segurança
    public void VerificarSeguranca() { /* ... */ }
}
#endregion

#region Amplificação
/*
    Amplificação:
    Comentários de amplificação reforçam a compreensão do código.
*/
public class Amplificacao
{
    // O método abaixo é crítico para o desempenho da aplicação.
    public void ProcessarDadosCriticos() { /* ... */ }
}
#endregion

/******************************/
/*       Comentários Ruins    */
/******************************/

#region Murmúrios
/*
    Murmúrios:
    Murmúrios são comentários vagos que não adicionam valor.
*/
public class Murmurios
{
    // Inicializa a variável
    int x = 0;
}
#endregion

#region Comentários Redundantes
/*
    Comentários Redundantes:
    Comentários redundantes repetem o que o código já diz.
*/
public class ComentariosRedundantes
{
    // Ruim: comentário redundante
    int _contador = 0; // inicializa contador com zero

    // Bom: sem comentário redundante
    int contador = 0;
}
#endregion

#region Comentários Enganosos
/*
    Comentários Enganosos:
    Comentários enganosos fornecem informações incorretas ou desatualizadas.
*/
public class ComentariosEnganosos
{
    public int CalcularSoma()
    {
        // Retorna a média (na verdade retorna a soma)
        return 1;
    }
}
#endregion

#region Comentários Obrigatórios
/*
    Comentários Obrigatórios:
    Comentários obrigatórios são adicionados apenas porque "é necessário".
*/
public class ComentariosObrigatorios
{
    // Método principal
    public void Main() { /* ... */ }
}
#endregion

#region Comentários de Jornal
/*
    Comentários de Jornal:
    Comentários de jornal são longos e detalhados demais, semelhantes a um diário.
*/
public class ComentariosDeJornal
{
    // Em 24/07/2024, João alterou o método para melhorar a performance
    public void Calcular() { /* ... */ }
}
#endregion

#region Comentários de Ruído
/*
    Comentários de Ruído:
    Comentários de ruído não adicionam valor e apenas poluem o código.
*/
public class ComentariosDeRuido
{
    // Abaixo está o início do método
    public void Iniciar() { /* ... */ }
}
#endregion

#region Ruído Assustador
/*
    Ruído Assustador:
    Ruído assustador são comentários que tentam explicar algo óbvio ou trivial.
*/
public class RuidoAssustador
{
    public void Main()
    {
        // Este é um loop for
        for (int i = 0; i < 10; i++) { /* ... */ }
    }
}
#endregion

#region Não Use um Comentário Quando Você Pode Usar uma Função ou Variável
/*
    Não Use um Comentário Quando Você Pode Usar uma Função ou Variável:
    Substitua comentários com funções ou variáveis descritivas.
*/
public class NaoUseComentario
{
    // Ruim: comentário explicando código
    int s = 0; // soma dos valores

    // Bom: variável descritiva
    int somaDosValores = 0;
}
#endregion

#region Marcadores de Posição
/*
    Marcadores de Posição:
    Marcadores de posição são comentários deixados para adicionar 
    código mais tarde, mas frequentemente esquecidos.
*/
public class MarcadoresDePosicao
{
    // Adicionar lógica aqui
    public void Processar() { /* ... */ }
}
#endregion

#region Comentários de Fechamento de Chave
/*
    Comentários de Fechamento de Chave:
    Comentários de fechamento de chave são usados para marcar o fim de blocos de código, mas podem ser desnecessários em código limpo.
*/
public class ComentariosDeFechamentoDeChave
{
    public void Main()
    {
        // Ruim: comentário de fechamento de chave
        if (true)
        {
            // código
        } // fim do if

        // Bom: indentação basta
        if (true)
        {
            // código
        }
    }
}
#endregion

#region Atribuições e Assinaturas
/*
    Atribuições e Assinaturas:
    Comentários de atribuições e assinaturas podem se tornar desatualizados e confusos.
*/
public class AtribuicoesEAssinaturas
{
    public void Main()
    {
        // Ruim: comentário de atribuição
        int x = 10; // atribui 10 a x

        // Bom: sem comentário desnecessário
        int y = 10;
    }
}
#endregion

#region Código Comentado
/*
    Código Comentado:
    Código comentado deve ser removido, pois causa confusão e polui o código.
*/
public class CodigoComentado
{
    // Ruim: código comentado
    // int y = 20;

    // Bom: código limpo
    int z = 30;
}
#endregion

#region Comentários HTML
/*
    Comentários HTML:
    Comentários HTML podem ser inadequados em código-fonte e causar confusão.
*/
public class ComentariosHTML
{
    // Ruim: comentário HTML
    //<!-- Este é um comentário HTML -->

    // Bom: comentário de código
    // Este é um comentário de código
}
#endregion

#region Informação Não Local
/*
    Informação Não Local:
    Comentários que fornecem informações não locais podem ser confusos.
*/
public class InformacaoNaoLocal
{
    // Verificar se o usuário está autenticado
    // (este comentário deve estar perto do código de autenticação)
    public void Autenticar() { /* ... */ }
}
#endregion

#region Informação Demais
/*
    Informação Demais:
    Comentários com informação demais podem sobrecarregar e confundir.
*/
public class InformacaoDemais
{
    // Este método faz isso, isso e aquilo e foi criado para
    // resolver tal problema porque tivemos uma reunião em 01/01/2024...
    public void Complexo() { /* ... */ }
}
#endregion

#region Conexão Não Óbvia
/*
    Conexão Não Óbvia:
    Comentários que fazem referência a partes do código de 
    forma não óbvia podem ser enganosos.
*/
public class ConexaoNaoObvia
{
    // A variável abaixo é usada no método X (certifique-se de que isso é óbvio no código)
    int variavelImportante;
}
#endregion

#region Cabeçalhos de Função
/*
    Cabeçalhos de Função:
    Cabeçalhos de função devem ser usados para descrever a função 
    de maneira concisa e clara.
*/
public class CabecalhosDeFuncao
{
    // Calcula a soma de dois números.
    public int Somar(int a, int b)
    {
        return a + b;
    }
}
#endregion




