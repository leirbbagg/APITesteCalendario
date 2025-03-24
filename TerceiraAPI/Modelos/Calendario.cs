using TerceiraAPI.Modelos.Interfaces;

namespace TerceiraAPI.Modelos
{
    public class Calendario : ICalendario
    {
        public int Id { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool AnoBissexto {  get; set; }
        public int QuantidadeDiasProximoAno { get; set; }
        public int QuantidadeDiasProximoMes { get; set; }

        public Calendario() { }
        public Calendario(int id, int dia, int mes, int ano, bool anoBissexto, int quantidadeDiasProximoAno, int quantidadeDiasProximoMes)
        {
            Id = id;
            Dia = dia;
            Mes = mes;
            Ano = ano;
            AnoBissexto = anoBissexto;
            QuantidadeDiasProximoAno = quantidadeDiasProximoAno;
            QuantidadeDiasProximoMes = quantidadeDiasProximoMes;
        }
    }
}
