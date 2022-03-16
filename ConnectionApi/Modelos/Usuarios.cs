using System.ComponentModel.DataAnnotations;
namespace ConnectionApi.Modelos
{
    public class Usuarios
    {
        [Key]
        public int idUser { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Contrasenia {get; set;}

    }
}
