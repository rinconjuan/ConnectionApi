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
    public class WebAppController : ControllerBase
    {       

        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public WebAppController(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        [HttpGet, Route("GetUsuario")]
        public IActionResult GetUsuario(DatosLogin datosLogin)
        {
            try
            {
                WebAppBL webAppBL = new WebAppBL(_env, _appContext);
                var respuesta = webAppBL.GetUsuario(datosLogin);
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


        [HttpGet, Route("GetDatos")]
        public IActionResult GetDatos(string email)
        {
            try
            {
                WebAppBL webAppBL = new WebAppBL(_env, _appContext);
                var respuesta = webAppBL.GetDatos(email);
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

        [HttpPost, Route("AddUser")]
        public IActionResult AddUser(DatosUsuario usuario)
        {
            try
            {
                WebAppBL webAppBL = new WebAppBL(_env, _appContext);
                var respuesta = webAppBL.Adduser(usuario);
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
