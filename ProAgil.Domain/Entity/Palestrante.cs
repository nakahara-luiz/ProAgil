using System.Collections.Generic;

namespace ProAgil.Domain.Entity
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Minicurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefine { get; set; }
        public string Email { get; set; }
        public IList<RedeSocial> RedesSociais { get; set; }
        public IList<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}