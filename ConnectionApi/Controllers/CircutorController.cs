using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using ConnectionApi.Utils;
using ConnectionApi.Modelos;
using ConnectionApi.Context;
using AppContext = ConnectionApi.Context.AppContext;

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
             
        

        //Verbo de accion (HttPost) de tipo POST
        //Renombrar la ruta de la accion a "cargar-archivo" con el atributo "Route"
        [HttpPost, Route("cargar-archivo")]
        public IActionResult UploadFile(IFormFile fileup)
        {
            try
            {
                var countFiles = Request.Form.Files.Count();
                var respuesta = new RespuestaCargueArchivo();
                if(countFiles == 0)
                    throw new ExcepcionMessage("CCTUPF01", "Es obligatorio el archivo");
                foreach(var img in Request.Form.Files)
                {
                    var nuevaImagen = new Imagenes();
                    using (var ms = new MemoryStream())
                    {
                        img.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                        nuevaImagen.DataImagen = s;
                        nuevaImagen.NameImagen = "file.bmp";
                        nuevaImagen.MimeType = "image/bmp";
                        var imagenes = _appContext.Imagenes.Add(nuevaImagen);
                        _appContext.SaveChanges();
                        
                        // act on the Base64 data
                    }
                    

                }
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {               

                //return Task.FromResult(resultado);
                return BadRequest(AdministrarExcepcion(ex));
            }

            
            ////Variable que retorna el valor del resultado del metodo
            ////El valor predeterminado es Falso (false)

            ////La variable "file" recibe el archivo en el objeto Request.Form
            ////Del POST que realiza la aplicacion a este servicio.
            ////Se envia un formulario completo donde uno de los valores es el archivo
            //var file = Request.Form.Files[0];

            ////Variable donde se coloca la ruta relativa de la carpeta de destino
            ////del archivo cargado
            //string NombreCarpeta = "/Archivos/";

            ////Variable donde se coloca la ruta raíz de la aplicacion
            ////para esto se emplea la variable "_env" antes de declarada
            //string RutaRaiz = _env.ContentRootPath;

            ////Se concatena las variables "RutaRaiz" y "NombreCarpeta"
            ////en una otra variable "RutaCompleta"
            //string RutaCompleta = RutaRaiz + NombreCarpeta;


            ////Se valida con la variable "RutaCompleta" si existe dicha carpeta            
            //if (!Directory.Exists(RutaCompleta))
            //{
            //    //En caso de no existir se crea esa carpeta
            //    Directory.CreateDirectory(RutaCompleta);
            //}

            ////Se valida si la variable "file" tiene algun archivo
            //if (file.Length > 0)
            //{
            //    //Se declara en esta variable el nombre del archivo cargado
            //    string NombreArchivo = file.FileName;

            //    //Se declara en esta variable la ruta completa con el nombre del archivo
            //    string RutaFullCompleta = Path.Combine(RutaCompleta, NombreArchivo);

            //    //Se crea una variable FileStream para carlo en la ruta definida
            //    using (var stream = new FileStream(RutaFullCompleta, FileMode.Create))
            //    {
            //        file.CopyTo(stream);

            //        //Como se cargo correctamente el archivo
            //        //la variable "resultado" llena el valor "true"
            //        resultado = true;
            //    }

            //}

            ////Se retorna la variable "resultado" como resultado de una tarea
            //return Task.FromResult(resultado);

        }
    }
}
