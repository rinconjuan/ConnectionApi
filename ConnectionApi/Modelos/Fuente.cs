using System.ComponentModel.DataAnnotations;
namespace ConnectionApi.Modelos
{
    public class Fuente
    {
        [Key]
        public int IdAccion { get; set; }

        public int Accion { get; set; }
    }
}
