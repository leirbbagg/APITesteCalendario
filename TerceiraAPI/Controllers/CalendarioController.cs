using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TerceiraAPI.Modelos;

namespace TerceiraAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CalendarioController : Controller
    {
        IList<Calendario> listaCalendarios = UsandoModelos.RetornarListaCalendario();
        [HttpGet]
        public IList<Calendario> Get()
        {
            return listaCalendarios;
        }
        [HttpGet("{id}")]
        public Calendario Get(int id)
        {
            Calendario val = new Calendario();
            foreach (var calendario in listaCalendarios)
            {
                if (calendario.Id == id)
                {
                    val = calendario;
                }
            }
            return val;
        }
        [HttpPost]
        public IList<Calendario> Post(int index, [FromBody] Calendario c)
        {
            listaCalendarios.Add(c);
            return listaCalendarios;
        }
        [HttpPut]
        public IList<Calendario> Put([FromBody] Calendario calendarioEditado)
        {
            for (int i = 0; i < listaCalendarios.Count; i++)
            {
                if (listaCalendarios[i].Id == calendarioEditado.Id)
                {
                    listaCalendarios[i].Dia = calendarioEditado.Dia;
                    listaCalendarios[i].Mes = calendarioEditado.Mes;
                    listaCalendarios[i].Ano = calendarioEditado.Ano;
                    listaCalendarios[i].AnoBissexto = calendarioEditado.AnoBissexto;
                    listaCalendarios[i].QuantidadeDiasProximoAno = calendarioEditado.QuantidadeDiasProximoAno;
                    listaCalendarios[i].QuantidadeDiasProximoMes = calendarioEditado.QuantidadeDiasProximoMes;
                }
            }
            return listaCalendarios;
        }
        [HttpDelete]
        public IList<Calendario> Delete(int id)
        {
            for (int i = 0; i < listaCalendarios.Count; i++)
            {
                if (listaCalendarios[i].Id == id)
                {
                    listaCalendarios.Remove(listaCalendarios[i]);
                }
            }
            return listaCalendarios;
        }
    }
}
