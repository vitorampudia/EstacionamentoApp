using System;
using System.Collections.Generic;
using System.Text;

namespace EstacionamentoApp.Interfaces
{
    internal interface ICobravel
    {
        protected TimeSpan CalcularValor();
    }
}
