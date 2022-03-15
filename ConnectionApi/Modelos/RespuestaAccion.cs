using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace ConnectionApi.Modelos
{
    public class RespuestaAccion
    {
        public string Accion { get; set; }
        public string CodigoKey { get; set; }


    }
}
