namespace ProAgil.Domain.Entity
{
    public class Lote
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}