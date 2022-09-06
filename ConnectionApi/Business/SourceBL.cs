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
        internal object ManagementSource(string accion)
        {
            throw new NotImplementedException();
        }
    }
}
