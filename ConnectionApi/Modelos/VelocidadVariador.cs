using System.ComponentModel.DataAnnotations;
namespace ConnectionApi.Modelos
{
    public class VelocidadVariador
    {
        [Key]
        public int idSpeed { get; set; }
        public string Speed { get; set; }

    }
}
