using System.ComponentModel.DataAnnotations;
namespace ConnectionApi.Modelos
{
#nullable disable
    public class AccionesVariador
    {
        [Key]
        public int idVariAccion { get; set; }
        public bool Funcion { get; set; }
    }
}
