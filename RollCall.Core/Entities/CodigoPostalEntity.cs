namespace RollCall.Core.Entities
{
    public class CodigoPostalEntity
    {
        public string CodigoPostal { get; set; }

        public string Estado { get; set; }

        public int EstadoId { get; set; }

        public int AlcaldiaId { get; set; }

        public string Alcaldia { get; set; }

        public string TipoDeAsentamiento { get; set; }

        public string Asentamiento { get; set; }
    }
}