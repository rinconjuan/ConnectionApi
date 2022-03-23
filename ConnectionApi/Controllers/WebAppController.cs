﻿using Microsoft.AspNetCore.Mvc;
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
    public class WebAppController : AdministrarException
    {       

        private readonly IWebHostEnvironment _env;
        private readonly WebContext _appContext;
        public WebAppController(IWebHostEnvironment env, WebContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        [HttpGet, Route("GetUsuario")]
        public IActionResult GetUsuario(DatosLogin datosLogin)
        {
            try
            {
                WebAppBL webAppBL = new WebAppBL(_env, _appContext);
                var respuesta = webAppBL.GetUsuario(datosLogin);
                return new ObjectResult(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(AdministrarExcepcion(ex));
            }
        }
        
    }
}
