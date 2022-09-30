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
    
    public class CircutorController : AdministrarException
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public CircutorController(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }           
        
        [HttpPost, Route("CargarImagen")]
        public IActionResult UploadFile(IFormFile fileup)
        {
            try
            {
                CircutorBL circutorBL = new CircutorBL(_env, _appContext);
                var respuesta = circutorBL.UploadImagen(fileup);
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {               
                return BadRequest(AdministrarExcepcion(ex));
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
                return BadRequest(AdministrarExcepcion(ex));
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
                return BadRequest(AdministrarExcepcion(ex));
            }
        }

        [HttpGet("DescargarImagen")]
        public IActionResult DownloadFile()
        {
            try
            {
                var imagenDownload = _appContext.Imagenes.FirstOrDefault();
                if (imagenDownload == null)
                    throw new ExcepcionMessage("CCTDLF01", "No se encontro imagen con ese ID");
                //var dataImagen = Convert.FromBase64String(imagenDownload.DataImagen);
                //return File(dataImagen, imagenDownload.MimeType, imagenDownload.NameImagen);
                return new ObjectResult(imagenDownload);
            }
            catch(Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }
            
        }

          [HttpPost, Route("CargarRegistro")]
        public IActionResult CargarRegistro(IFormFile fileup, int IdUser)
        {
            try
            {
                CircutorBL circutorBL = new CircutorBL(_env, _appContext);
                var respuesta = circutorBL.CargarRegistro(fileup, IdUser);
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {               
                return BadRequest(AdministrarExcepcion(ex));
            }      

        }

        [HttpGet("DescargarRegistro")]
        public IActionResult DownloadRegistro(int IdUser)
        {
            try
            {
                var imagenDownload = _appContext.Registro.Where(x => x.idUser == IdUser).FirstOrDefault();
                if (imagenDownload == null)
                    throw new ExcepcionMessage("CCTDLF01", "No se encontro imagen con ese ID");
               
                return new ObjectResult(imagenDownload);
            }
            catch (Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }

        }
    }
}
