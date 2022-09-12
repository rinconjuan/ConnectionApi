using System.ComponentModel.DataAnnotations;
namespace ConnectionApi.Modelos
{
    public class Agenda
    {
        [Key]
        public int IdAgenda { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public int IdUser { get; set; }

    }
}
