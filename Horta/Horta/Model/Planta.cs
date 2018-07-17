using System;
using System.Collections.Generic;
using System.Text;

namespace Horta2.Model
{
    public class Planta
    {
        public override string ToString()
        {
            return Nome;
        }

        public string Imagem { get; set; }
        public string Nome { get; set; }
        public DateTime UltimaRega { get; set; }
        public DateTime QuandoRegar { get
            {
                return UltimaRega.AddHours(TempoRega);
            }
        }
        public double TempoRega { get; set; }
        public bool PossivelRegar {
            get {
                return UltimaRega.AddHours(TempoRega) < DateTime.Now;
            } }
        public bool NaoPossivelRegar
        {
            get
            {
                return !PossivelRegar;
            }
        }

    }
}
