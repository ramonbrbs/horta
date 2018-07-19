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
        public String Contador {
            get
            {
                var t = (UltimaRega.AddHours(TempoRega).Subtract(DateTime.Now));
                var retorno = "";
                if (t.Days > 0)
                {
                    retorno += $"{t.Days} dia{(t.Days > 1 ? "s" : "")}";
                }

                if (t.Hours > 0)
                {
                    retorno += $"{t.Hours}h, ";
                }

                if (t.Minutes > 0)
                {
                    retorno += $"{t.Minutes} m, ";
                }
                return retorno +=  $" {t.Seconds} s";
            }
        }
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
