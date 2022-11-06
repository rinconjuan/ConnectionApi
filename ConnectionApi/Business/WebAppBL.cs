using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
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
            if (userFind == null)
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

        internal object Adduser(DatosUsuario usuario)
        {
            RespuestaNuevoUsuario respuesta = new RespuestaNuevoUsuario();
            Usuarios nuevoUsuario = new Usuarios();
            nuevoUsuario.Email = usuario.Email;
            nuevoUsuario.Nombres = usuario.Nombres;
            nuevoUsuario.Contrasenia = usuario.Contrasenia;
            nuevoUsuario.Apellidos = usuario.Apellidos;

            
            var finduser  = _appContext.Usuarios.Where(x => x.Email == nuevoUsuario.Email).FirstOrDefault();
            if(finduser != null)
                throw new MensajeError("Ya esta registrado el usuario");

            try
            {
                _appContext.Usuarios.Add(nuevoUsuario);
                _appContext.SaveChanges();
                respuesta.usuario = nuevoUsuario.Email;
                respuesta.Estado = "CREADO";
            }
            catch (Exception ex)
            {
                throw new MensajeError("No se pudo crear el usuario.");
            }


            return respuesta;
        }

        internal object GetDatos(string email)
        {
            Usuarios respuesta = new Usuarios();
            var userFind = _appContext.Usuarios.Where(x => x.Email == email).FirstOrDefault();
            if (userFind == null)
                return respuesta;

            respuesta = userFind;
            return respuesta;

        }
    }
}
