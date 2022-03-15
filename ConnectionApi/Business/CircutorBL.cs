using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using ConnectionApi.Utils;
using ConnectionApi.Modelos;
using ConnectionApi.Context;
using AppContext = ConnectionApi.Context.AppContext;
using ConnectionApi.Business;

namespace ConnectionApi.Business
{
    public class CircutorBL
    {

        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public CircutorBL(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }
        public RespuestaCargueArchivo UploadImagen(IFormFile fileup)
        {
            var respuesta = new RespuestaCargueArchivo();                      

            if (fileup == null)
                throw new ExcepcionMessage("CCTUPF01", "No hay imagen para cargar");
            
            var nuevaImagen = new Imagenes();
            using (var ms = new MemoryStream())
            {
                fileup.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                nuevaImagen.DataImagen = s;
                nuevaImagen.NameImagen = fileup.FileName;
                nuevaImagen.MimeType = "image/bmp";
                var fileDb = _appContext.Imagenes.Count();
                if(fileDb == 0)
                {
                    var imagenes = _appContext.Imagenes.Add(nuevaImagen);
                    _appContext.SaveChanges();
                }
                else
                {
                    var imgUpdate = _appContext.Imagenes.FirstOrDefault();
                    imgUpdate.DataImagen = nuevaImagen.DataImagen;
                    _appContext.SaveChanges();
                }

                respuesta.EstadoArchivo = "Ok";
                respuesta.NombreArchivo = fileup.FileName;

                return respuesta;
            }
            
            
        }        
    }
}
