using System;
using System.Collections.Generic;

namespace ProAgil.Domain.Entity
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public IList<Lote> Lote { get; set; }
    }
}