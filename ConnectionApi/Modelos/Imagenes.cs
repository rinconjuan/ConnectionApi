using System.ComponentModel.DataAnnotations;

namespace ConnectionApi.Modelos
{
    public class Imagenes
    {
        [Key]
        public int idImagen { get; set; }
        public string DataImagen { get; set; }

        public string NameImagen {get; set; }
        public string MimeType { get; set; }


    }
}
