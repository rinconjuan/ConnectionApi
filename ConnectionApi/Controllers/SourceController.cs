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
    public class SourceController : Controller
    {

        private readonly IWebHostEnvironment _env;
        private readonly WebContext _appContext;
        public SourceController(IWebHostEnvironment env, WebContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        [HttpPost, Route("ManagementSource")]
        public IActionResult ManagementSource(string accion)
        {
            try
            {
                SourceBL ManagementSource = new SourceBL(_env, _appContext);
                var respuesta = ManagementSource.ManagementSource(accion);
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }
        }

        
    }
}
