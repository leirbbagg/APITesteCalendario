using System.Diagnostics.Metrics;
using TerceiraAPI.Modelos;

namespace TerceiraAPI
{
    public static class UsandoModelos
    {
        private static Calendario CriandoCalendario(int id)
        {
            Random gerador = new Random();
            int mes = gerador.Next(1, 13);
            int ano = gerador.Next(1984, 2060);
            bool anoBissexto = RetornarAnoBissexto(ano);
            int dia = RetornarQuantidadeDiasBaseadoMes(gerador, mes, anoBissexto);
            int diasProximoAno = RetonarQuantidadeDiasProximoAno(dia, mes, anoBissexto);
            int diasProximoMes = RetornarQuantidadeDiasProximoMes(mes, dia, anoBissexto);
            Calendario c = new Calendario(id, dia, mes, ano, anoBissexto, diasProximoAno, diasProximoMes);
            return c;
        }
        private static int RetornarQuantidadeDiasBaseadoMes(Random gerador, int meses, bool anoBissexto)
        {
            switch (meses)
            {
                case 1: return gerador.Next(1, 32);
                case 2:
                    {
                        if (anoBissexto == true)
                        {
                            return gerador.Next(1, 30);
                        }

                        else return gerador.Next(1, 29);
                    }
                case 3: return gerador.Next(1, 32);
                case 4: return gerador.Next(1, 31);
                case 5: return gerador.Next(1, 32);
                case 6: return gerador.Next(1, 31);
                case 7: return gerador.Next(1, 32);
                case 8: return gerador.Next(1, 32);
                case 9: return gerador.Next(1, 31);
                case 10: return gerador.Next(1, 32);
                case 11: return gerador.Next(1, 31);
                case 12: return gerador.Next(1, 32);
                default: return 0;
            }
        }
        private static bool RetornarAnoBissexto(int ano)
        {
            return ano % 4 == 0;
        }
        private static int RetonarQuantidadeDiasProximoAno(int dias, int meses, bool anoBissexto)
        {
            int diasMaximoAno;
            int diasCalendarioGerado = ContandoDiasCalendarioGerado(dias, meses, anoBissexto);
            if (anoBissexto == true)
            {
                diasMaximoAno = 366;
            }
            else
            {
                diasMaximoAno = 365;
            }
            return (diasMaximoAno - diasCalendarioGerado) + 1;
        }
        private static int ContandoDiasCalendarioGerado(int dias, int meses, bool anoBissexto)
        {

            int quantidadeDiasCalendario = 0;
            if (meses > 1)
            {
                for (int i = 1; i <= meses - 1; i++)
                {
                    quantidadeDiasCalendario += IncrementarDiasBaseadoMes(i, anoBissexto);
                }
                quantidadeDiasCalendario += dias;
            }
            else
            {
                quantidadeDiasCalendario += dias;
            }
            return quantidadeDiasCalendario;
        }
        private static int IncrementarDiasBaseadoMes(int meses, bool anoBissexto)
        {
            switch (meses)
            {
                case 1: return 31;
                case 2:
                    {
                        if (anoBissexto == true)
                        {
                            return 29;
                        }

                        else return 28;
                    }
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                default: return 0;
            }
        }

        private static int RetornarQuantidadeDiasProximoMes(int mesAtual, int dias, bool anoBissexto)
        {
            int quantidadeDiasProximoMes = 0;
            quantidadeDiasProximoMes += IncrementarDiasBaseadoMes(mesAtual, anoBissexto);
            quantidadeDiasProximoMes = quantidadeDiasProximoMes - dias;
            return Math.Abs(quantidadeDiasProximoMes + 1);
        }
        public static IList<Calendario> RetornarListaCalendario()
        {
            IList<Calendario> lista = new List<Calendario>();
            Random gerador = new Random();
            int quantidadeItensLista = gerador.Next(2, 4);
            for (int i = 0; i < quantidadeItensLista; i++)
            {
                lista.Add(CriandoCalendario(lista.Count));
            }
            return lista;
        }
    }
}
