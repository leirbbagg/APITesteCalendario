namespace TerceiraAPI.Modelos.Interfaces
{
    public interface ICalendario
    {
        int Id { get; set; }
        int Dia { get; set; }
        int Mes { get; set; }
        int Ano { get; set; }
        bool AnoBissexto { get; set; }
        int QuantidadeDiasProximoAno { get; set; }
        int QuantidadeDiasProximoMes { get; set; }
    }
}
