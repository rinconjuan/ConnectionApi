using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using ConnectionApi.Modelos;
using ConnectionApi.Context;
using AppContext = ConnectionApi.Context.AppContext;
using ConnectionApi.Business;
using System;
using System.Web.Http;

namespace ConnectionApi.Business
{
    public class AgendaBL
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppContext _appContext;
        public AgendaBL(IWebHostEnvironment env, AppContext appContext)
        {
            _env = env;
            _appContext = appContext;
        }

        internal object CreateAgenda(Agenda agenda)
        {
            if(agenda.FechaFin < agenda.FechaInicio)
                throw new Exception("La fecha fin no puede ser menor a la fecha inicio");


            RespuestaCrearAgenda respuesta = new RespuestaCrearAgenda();
            DatosAgenda consultaAgenda = new DatosAgenda()
            {
                FechaFin = agenda.FechaFin,
                FechaInicio = agenda.FechaFin,
                IdUser = agenda.IdUser,
                Modo = "INS"
            };

            //try
            //{
                
                    var nuevoBooking = _appContext.Agenda.Add(agenda);
                    _appContext.SaveChanges();
                    respuesta.Creado = true;
                    respuesta.idUser = agenda.IdUser;
                    respuesta.Mensaje = "Agendamiento creado con exito.";
                
            //}
            //catch(Exception ex)
            //{
            //    //respuesta.Creado = false;
            //    //respuesta.idUser = agenda.IdUser;
            //    //respuesta.Mensaje = ex.Message;
                
            //}
                   
            return respuesta;
            
        }

        internal RespuestaAgenda GetAgenda([FromUri] DatosAgenda agenda)
        {

            RespuestaAgenda respuesta = new RespuestaAgenda();
            respuesta.Agendas = new List<Agenda>();
            switch (agenda.Modo)
            {
                case "INS":
                    var agendaDBIns = _appContext.Agenda.Where(x => x.FechaInicio < agenda.FechaFin & x.FechaFin > agenda.FechaInicio).FirstOrDefault();
                    if(agendaDBIns != null)
                        throw new MensajeError("No se puede agendar para estar hora, el espacio no esta disponible, busque otro horario");
                    respuesta.Disponibilidad = true;
                    respuesta.Acceso = true;
                    respuesta.IdUser = agenda.IdUser;

                    Agenda nuevaAgenda = new Agenda();
                    nuevaAgenda.Estado = "PROG";
                    nuevaAgenda.FechaFin = (DateTime)agenda.FechaFin;
                    nuevaAgenda.FechaInicio = (DateTime)agenda.FechaInicio;
                    nuevaAgenda.IdUser = agenda.IdUser;
                    CreateAgenda(nuevaAgenda);

                    break;
                case "LOG":
                    var agendaDBLog = _appContext.Agenda.Where(x => x.FechaFin == agenda.FechaFin & x.FechaInicio == agenda.FechaInicio & x.IdUser == agenda.IdUser).FirstOrDefault();
                    if (agendaDBLog == null)
                        throw new MensajeError("No puede ingresar en este momento, no esta agendado para esta hora");
                    respuesta.Disponibilidad = true;
                    respuesta.Acceso = true;
                    respuesta.IdUser = agenda.IdUser;
                    respuesta.Agendas.Add(agendaDBLog);
                    break;
                case "CON":
                    var agendaDBCon = _appContext.Agenda.ToList();
                    if(agendaDBCon.Count == 0)
                        throw new Exception("No hay agendas");
                    foreach(var item in agendaDBCon)
                    {
                        respuesta.Agendas.Add(item);
                    }
                    break;



            }

            return respuesta;
            
        }
    }
}
