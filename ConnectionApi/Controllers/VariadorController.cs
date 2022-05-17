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
    public class VariadorController : AdministrarException
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public VariadorController(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        [HttpPost, Route("Run")]
        public IActionResult Run(bool funcion)
        {
            try
            {
                VariadorBL variadorBL = new VariadorBL(_env, _appContext);
                var respuesta = variadorBL.UpdateFuncion(funcion);
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }
        }

        [HttpGet, Route("GetRun")]
        public IActionResult GetRun()
        {
            try
            {
                VariadorBL variadorBL = new VariadorBL(_env, _appContext);
                var respuesta = variadorBL.GetRun();
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }
        }
    }
}
