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

        internal object GetAccion()
        {
            RespuestaAccion respuesta = new RespuestaAccion();
            var countAcciones = _appContext.Acciones.Count();
            if(countAcciones == 0 )
                throw new ExcepcionMessage("CCTGAC01", "No hay acciones");

            var accionDb = _appContext.Acciones.FirstOrDefault();
            respuesta.Accion = accionDb.Accion;
            respuesta.CodigoKey = accionDb.CodigoKey;

            _appContext.Acciones.Remove(accionDb);
            _appContext.SaveChanges();

            return respuesta;
        }

        internal object AccionKey(string key)
        {
            RespuestaAccion respuesta = new RespuestaAccion();
            Acciones accion = new Acciones();
            if(string.IsNullOrEmpty(key))
                throw new ExcepcionMessage("CCTAKE01", "Accion no puede ser nula");

            switch (key)
            {
                case "5":
                    respuesta.Accion = "Back";
                    respuesta.CodigoKey = key;
                    break;
                case "1":
                    respuesta.Accion = "F1";
                    respuesta.CodigoKey = key;
                    break;
                case "2":
                    respuesta.Accion = "F2";
                    respuesta.CodigoKey = key;
                    break;
                case "3":
                    respuesta.Accion = "F3";
                    respuesta.CodigoKey = key;
                    break;
                case "4":
                    respuesta.Accion = "F4";
                    respuesta.CodigoKey = key;
                    break;
                case "0":
                    respuesta.Accion = "Enter";
                    respuesta.CodigoKey = key;
                    break;
                default:
                    throw new ExcepcionMessage("CCTAKE02", "Accion no valida");

            }
            accion.Accion = respuesta.Accion;
            accion.CodigoKey = respuesta.CodigoKey;
            var fileDb = _appContext.Acciones.Count();
            if (fileDb == 0)
            {
                var nuevaAccion = _appContext.Acciones.Add(accion);
                _appContext.SaveChanges();
            }
            else
            {
                var accionUpdate = _appContext.Acciones.FirstOrDefault();
                accionUpdate.Accion = accion.Accion;
                _appContext.SaveChanges();
            }


            return respuesta;
        }
    }
}
