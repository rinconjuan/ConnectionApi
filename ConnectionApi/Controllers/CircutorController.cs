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

        [HttpGet("DescargarImagen/{id:int}")]
        public IActionResult DownloadFile(int id)
        {
            try
            {
                var imagenDownload = _appContext.Imagenes.Where(x => x.idImagen == id).FirstOrDefault();
                if (imagenDownload == null)
                    throw new ExcepcionMessage("CCTDLF01", "No se encontro imagen con ese ID");
                var dataImagen = Convert.FromBase64String(imagenDownload.DataImagen);
                return File(dataImagen, imagenDownload.MimeType, imagenDownload.NameImagen);
            }
            catch(Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }
            
        }
    }
}
