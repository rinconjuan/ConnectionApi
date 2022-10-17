using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using ConnectionApi.Modelos;
using ConnectionApi.Context;
using AppContext = ConnectionApi.Context.AppContext;
using ConnectionApi.Business;

namespace ConnectionApi.Controllers
{
    public class SourceController : ControllerBase
    {

        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public SourceController(IWebHostEnvironment env, AppContext appContext)
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
                return BadRequest(ex.Message);
            }
        }
        [HttpGet, Route("GetAccionSource")]
        public IActionResult GetAccionSource( )
        {
            try
            {
                SourceBL ManagementSource = new SourceBL(_env, _appContext);
                var respuesta = ManagementSource.GetAccionSource();
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
