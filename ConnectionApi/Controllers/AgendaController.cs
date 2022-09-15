using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using ConnectionApi.Utils;
using ConnectionApi.Modelos;
using ConnectionApi.Context;
using AppContext = ConnectionApi.Context.AppContext;
using ConnectionApi.Business;
namespace ConnectionApi.Controllers
{
    public class AgendaController : AdministrarException
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public AgendaController(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        [HttpPost, Route("CreateAgenda")]
        public IActionResult CreateAgenda(Agenda agenda)
        {
            try
            {
                AgendaBL Agenda = new AgendaBL(_env, _appContext);
                var respuesta = Agenda.CreateAgenda(agenda);
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }
        }



        [HttpGet, Route("GetAgenda")]
        public IActionResult GetAgenda(DatosAgenda agenda)
        {
            try
            {
                AgendaBL Agenda = new AgendaBL(_env, _appContext);
                var respuesta = Agenda.GetAgenda(agenda);
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }
        }
    }
}
