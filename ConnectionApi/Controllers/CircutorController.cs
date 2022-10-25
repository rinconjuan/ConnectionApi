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
    
    public class CircutorController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public CircutorController(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }           
        
        [HttpPost, Route("CargarImagen")]
        public IActionResult UploadFile(IFormFile fileup, string modo)
        {
            try
            {
                CircutorBL circutorBL = new CircutorBL(_env, _appContext);
                var respuesta = circutorBL.UploadImagen(fileup, modo);
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

        [HttpGet("DescargarImagen")]
        public IActionResult DownloadFile(string Modo)
        {
            try
            {
                switch (Modo)
                {
                    case "NOM":
                        var imagenDownload = _appContext.Imagenes.FirstOrDefault();
                        if (imagenDownload == null)
                            throw new Exception("No se encontro imagen con ese ID");
                        return new ObjectResult(imagenDownload);
                        break;
                    case "BLQ":
                        var registroDownload = _appContext.Registro.FirstOrDefault();
                        if (registroDownload == null)
                            throw new Exception("No hay imagen");
                        return new ObjectResult(registroDownload);
                        break;
                    default:
                        throw new Exception("Modo no permitido");
                        break;
                }


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


        [HttpGet, Route("Acciones")]
        public IActionResult GetAccion()
        {
            try
            {
                CircutorBL circutorBL = new CircutorBL(_env, _appContext);
                var respuesta = circutorBL.GetAccion();
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

        [HttpPost, Route("Accion")]
        public IActionResult PostAccion(string key)
        {
            try
            {
                CircutorBL circutorBL = new CircutorBL(_env, _appContext);
                var respuesta = circutorBL.AccionKey(key);
                return new ObjectResult(respuesta);
            }
            catch(Exception ex)
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
