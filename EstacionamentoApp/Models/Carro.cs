using EstacionamentoApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstacionamentoApp.Models
{
    internal class Carro : Veiculo
    {
        public int QuantidadePorta { get; private set; }

        public Carro(string placa, string marca, string modelo, string cor, int quantidadePorta) : base (placa, marca, modelo, cor)
        {
            QuantidadePorta = quantidadePorta;
            TipoVeiculo = TipoVeiculo.Carro;
        }
    }
}
