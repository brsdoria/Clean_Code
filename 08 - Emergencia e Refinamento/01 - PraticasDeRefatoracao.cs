/*********************************/
/*    Praticas de Refatoração    */
/*********************************/

#region Versão Inicial

namespace CleanCode.M08_Emergencia_E_Refinamento_Refactor_1
{
    public class DataUtils
    {
        private int dia;
        private int mes;
        private int ano;

        public DataUtils(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public bool EhAnoBissexto()
        {
            if ((ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0))
            {
                return true;
            }
            return false;
        }

        public int DiasNoMes()
        {
            if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                return 31;
            }
            else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                return 30;
            }
            else if (mes == 2)
            {
                if (EhAnoBissexto())
                {
                    return 29;
                }
                return 28;
            }
            return 0; // Caso de erro para meses inválidos
        }

        public override string ToString()
        {
            return $"{dia}/{mes}/{ano}";
        }
    }
}

#endregion

#region Melhorando Nomes de Variáveis e Métodos

// Nesta versão, os nomes das variáveis e métodos foram melhorados para torná-los mais descritivos,
// ajudando a clareza e a legibilidade do código.
namespace CleanCode.M08_Emergencia_E_Refinamento_Refactor_2
{
    public class DataUtils
    {
        private int dia;
        private int mes;
        private int ano;

        public DataUtils(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        // Renomeado para melhorar a clareza
        public bool EhAnoBissexto()
        {
            return (ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0);
        }

        // Renomeado para ser mais descritivo
        public int ObterDiasNoMes()
        {
            if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                return 31;
            }
            else if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                return 30;
            }
            else if (mes == 2)
            {
                return EhAnoBissexto() ? 29 : 28;
            }
            throw new ArgumentException("Mês inválido");
        }

        public override string ToString()
        {
            return $"{dia}/{mes}/{ano}";
        }
    }
}

#endregion

#region Isolando Funções

// Nesta versão, o método ObterDiasNoMes foi dividido em métodos menores e mais focados,
// isolando a lógica para verificar os dias dos meses e a validade do mês.
namespace CleanCode.M08_Emergencia_E_Refinamento_Refactor_3
{
    public class DataUtils
    {
        private int dia;
        private int mes;
        private int ano;

        public DataUtils(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public bool EhAnoBissexto()
        {
            return (ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0);
        }

        // Método para verificar meses com 31 dias
        private bool MesTem31Dias()
        {
            return mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12;
        }

        // Método para verificar meses com 30 dias
        private bool MesTem30Dias()
        {
            return mes == 4 || mes == 6 || mes == 9 || mes == 11;
        }

        // Método para validar o mês
        private bool MesValido()
        {
            return mes >= 1 && mes <= 12;
        }

        // Método principal agora usa métodos auxiliares
        public int ObterDiasNoMes()
        {
            if (!MesValido())
            {
                throw new ArgumentException("Mês inválido");
            }
            if (MesTem31Dias())
            {
                return 31;
            }
            if (MesTem30Dias())
            {
                return 30;
            }
            return EhAnoBissexto() ? 29 : 28;
        }

        public override string ToString()
        {
            return $"{dia}/{mes}/{ano}";
        }
    }
}

#endregion

#region Reduzindo Duplicação

// Nesta versão, métodos auxiliares foram introduzidos para reduzir a duplicação,
// e foi usada a inicialização de arrays para simplificar a verificação de meses.
namespace CleanCode.M08_Emergencia_E_Refinamento_Refactor_4
{
    public class DataUtils
    {
        private int dia;
        private int mes;
        private int ano;

        public DataUtils(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public bool EhAnoBissexto()
        {
            return (ano % 4 == 0 && ano % 100 != 0) || (ano % 400 == 0);
        }

        // Uso de arrays para reduzir duplicação
        private bool MesTem31Dias() => new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(mes);

        // Uso de arrays para reduzir duplicação
        private bool MesTem30Dias() => new[] { 4, 6, 9, 11 }.Contains(mes);

        // Método para validar o mês centralizado
        private void ValidarMes()
        {
            if (mes < 1 || mes > 12)
            {
                throw new ArgumentException("Mês inválido");
            }
        }

        // Método principal agora usa métodos auxiliares e validação centralizada
        public int ObterDiasNoMes()
        {
            ValidarMes();
            if (MesTem31Dias())
            {
                return 31;
            }
            if (MesTem30Dias())
            {
                return 30;
            }
            return EhAnoBissexto() ? 29 : 28;
        }

        public override string ToString()
        {
            return $"{dia}/{mes}/{ano}";
        }
    }
}
#endregion
