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
        private readonly WebContext _appContext;
        public WebAppBL(IWebHostEnvironment env, WebContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        
        public RespuestaUsuarios GetUsuario(string email, string password)
        {

            RespuestaUsuarios respuesta = new RespuestaUsuarios();
            var userFind = _appContext.Usuarios.Where(x => x.Email == email && x.Contrasenia == password).FirstOrDefault();
            if(userFind == null)
                throw new ExcepcionMessage("WAPGUS01", "No existe el usuario");
            respuesta.idUser = userFind.idUser;
            respuesta.Nombres = userFind.Nombres;
            respuesta.Apellidos = userFind.Apellidos;
            respuesta.Email = userFind.Email;
            respuesta.Contrasenia = userFind.Contrasenia;
            return respuesta;
        }

        internal RespuestaLogin GetAutenticacion(DatosLogin data)
        {
            RespuestaLogin respuesta = new RespuestaLogin();
            var userFind = _appContext.Usuarios.Where(x => x.Email == data.email && x.Contrasenia == data.password).FirstOrDefault();
            if (userFind == null)
            {
                respuesta.idUser = 0;
                respuesta.statusLogin = false;
            }
            else
            {   respuesta.idUser = userFind.idUser;
                respuesta.statusLogin = true;
            }               
            
            return respuesta;
        }
    }
}
