namespace ConnectionApi.Modelos
{
    public class MensajeError : Exception
    {
        public MensajeError(string? mensaje = default(String))
        {
            Mensaje = mensaje;
        }

        public string? Mensaje { get; set; }
    }
}
