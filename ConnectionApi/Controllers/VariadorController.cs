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
    public class VariadorController : ControllerBase
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
                MensajeError mensajeError = new MensajeError();
                if (ex is MensajeError error)
                {
                    mensajeError.Mensaje = error.Mensaje;
                }
                else
                {
                    mensajeError.Mensaje = "Error inesperado";
                }

                return BadRequest(mensajeError.Mensaje);
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
                MensajeError mensajeError = new MensajeError();
                if (ex is MensajeError error)
                {
                    mensajeError.Mensaje = error.Mensaje;
                }
                else
                {
                    mensajeError.Mensaje = "Error inesperado";
                }

                return BadRequest(mensajeError.Mensaje);
            }
        }

        [HttpPost, Route("UpdateVelocidad")]
        public IActionResult UpdateVelocidad(string  velocidad)
        {
            try
            {
                VariadorBL variadorBL = new VariadorBL(_env, _appContext);
                var respuesta = variadorBL.UpdateVelocidad(velocidad);
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {
                MensajeError mensajeError = new MensajeError();
                if (ex is MensajeError error)
                {
                    mensajeError.Mensaje = error.Mensaje;
                }
                else
                {
                    mensajeError.Mensaje = "Error inesperado";
                }

                return BadRequest(mensajeError.Mensaje);
            }
        }

        [HttpGet, Route("GetVelocidad")]
        public IActionResult GetVelocidad()
        {
            try
            {
                VariadorBL variadorBL = new VariadorBL(_env, _appContext);
                var respuesta = variadorBL.GetVelocidad();
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
                {
                MensajeError mensajeError = new MensajeError();
                if (ex is MensajeError error)
                {
                    mensajeError.Mensaje = error.Mensaje;
                }
                else
                {
                    mensajeError.Mensaje = "Error inesperado";
                }

                return BadRequest(mensajeError.Mensaje);
            }
        }
    }
}


