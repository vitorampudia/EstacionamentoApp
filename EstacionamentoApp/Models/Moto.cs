using System;
using System.Collections.Generic;
using System.Text;
using EstacionamentoApp.Enums;

namespace EstacionamentoApp.Models
{
    internal class Moto : Veiculo
    {
        public int Cilindradas { get; private set; }

        public Moto(string placa, string marca, string modelo, string cor, int cilindradas) : base(placa, marca, modelo, cor)
        {
            Cilindradas = cilindradas;
            TipoVeiculo = TipoVeiculo.Moto;
        }
    }
}
