using System.ComponentModel.DataAnnotations;
namespace ConnectionApi.Modelos
{
    public class Acciones
    {
        [Key]
        public int IdAccion { get; set; }

        public string Accion { get; set; }
        public string CodigoKey { get; set; }

    }
}
