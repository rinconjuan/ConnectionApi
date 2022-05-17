﻿using Microsoft.AspNetCore.Mvc;
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
    public class VariadorBL
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public VariadorBL(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        internal object UpdateFuncion(bool funcion)
        {
            RespuestaUpFuncion respuesta = new RespuestaUpFuncion();
            AccionesVariador accion = new AccionesVariador();
            accion.Funcion = funcion;
            switch (funcion)
            {
                case true:
                    respuesta.Accion = "Run";
                    respuesta.Estado = funcion;
                    break;
                case false:
                    respuesta.Accion = "Stop";
                    respuesta.Estado = funcion;
                    break;
            }

            var fileDb = _appContext.AccionesVariador.Count();
            if (fileDb == 0)
            {
                var nuevaAccion = _appContext.AccionesVariador.Add(accion);
                _appContext.SaveChanges();
            }
            else
            {
                var accionUpdate = _appContext.AccionesVariador.FirstOrDefault();
                accionUpdate.Funcion = accion.Funcion;
                _appContext.SaveChanges();
            }

            return respuesta;

        }

        internal object GetRun()
        {
            RespuestaRun respuesta = new RespuestaRun();
            var accionActual = _appContext.AccionesVariador.FirstOrDefault();
            if(accionActual != null)
            {
                switch (accionActual.Funcion)
                {
                    case true:
                        respuesta.Accion = "Run";
                        respuesta.Codigo = accionActual.Funcion;
                        break;
                    case false:
                        respuesta.Accion = "Stop";
                        respuesta.Codigo = accionActual.Funcion;
                        break;
                }
            }

            return respuesta;
        }
    }
}
