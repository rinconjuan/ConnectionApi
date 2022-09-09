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
    public class WebAppBL
    {

        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public WebAppBL(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        
        public RespuestaUsuarios GetUsuario(DatosLogin data)
        {

            RespuestaUsuarios respuesta = new RespuestaUsuarios();
            var userFind = _appContext.Usuarios.Where(x => x.Email == data.email && x.Contrasenia == data.password).FirstOrDefault();
            if(userFind == null)
            {
                respuesta.EstadoLogin = false;
            }
            else
            {
                respuesta.Usuario = userFind;
                respuesta.EstadoLogin = true;
            }                           
            return respuesta;
        }
        
    }
}
