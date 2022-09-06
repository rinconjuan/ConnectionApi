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
    public class SourceBL
    {

        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public SourceBL(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        internal object GetAccionSource()
        {

            RespuestaAccionFuente respuesta = new RespuestaAccionFuente();
            var accionActual = _appContext.Fuente.FirstOrDefault();
            if (accionActual != null)
            {
                switch (accionActual.Accion)
                {
                    case 1:
                        respuesta.Accion = accionActual.Accion;
                        respuesta.DescripcionAccion = "Run";
                        break;
                    case 0:
                        respuesta.Accion = accionActual.Accion;
                        respuesta.DescripcionAccion = "Stop";
                        break;
                }
            }


            return respuesta;

     
        }

        internal object ManagementSource(string accion)
        {

                string respuesta = "";
                Fuente fuente = new Fuente();
                if (string.IsNullOrEmpty(accion))
                    throw new ExcepcionMessage("SSMMS01", "Accion no puede ser nula");

                switch (accion)
                {
                    case "Run":
                        respuesta= "Run";
                        fuente.Accion = 1;
                        break;
                
                    case "Stop":
                        respuesta = "Stop";
                        fuente.Accion = 0;
                        break;
                    default:
                        throw new ExcepcionMessage("SSMMS02", "Accion no valida");

                }
               
                var fileDb = _appContext.Fuente.Count();
                if (fileDb == 0)
                {
                    var nuevaAccion = _appContext.Fuente.Add(fuente);
                    _appContext.SaveChanges();
                }
                else
                {
                    var accionUpdate = _appContext.Fuente.FirstOrDefault();
                    accionUpdate.Accion = fuente.Accion;
                    _appContext.SaveChanges();
                }


                return respuesta;
         
        }
    }
}
