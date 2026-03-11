using System;
using System.Collections.Generic;
using System.Text;
using EstacionamentoApp.Models;

namespace EstacionamentoApp.Services
{
    internal class PagamentoService
    {
        public static decimal CalcularPreco(TimeSpan tempoEstadia)
        {
            int dias = tempoEstadia.Days;
            int horas = tempoEstadia.Hours;

            if (tempoEstadia.Minutes > 0)
            {
                horas++;
            }

            if (horas >= 9)
            {
                return (dias + 1) * 50m;
            }
            decimal precoHoras = horas == 0 ? 0 : 10m + (horas - 1) * 5m;
            return dias * 50m + precoHoras;
        }
    }
}
