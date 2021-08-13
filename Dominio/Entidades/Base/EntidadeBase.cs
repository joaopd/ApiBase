using Dominio.Interfaces;
using System;

namespace Dominio.Entidades.Base
{
    public abstract class EntidadeBase : IEntidadeBase
    {
        public Guid Id { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataDeRegistro { get; set; }

        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
            DataDeRegistro = DateTime.Now;
            Excluido = false;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}
