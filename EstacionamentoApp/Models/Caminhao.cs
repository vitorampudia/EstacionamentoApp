using System;
using System.Collections.Generic;
using System.Text;
using EstacionamentoApp.Enums;

namespace EstacionamentoApp.Models
{
    internal class Caminhao : Veiculo
    {
        public int QuantidadeEixos { get; private set; }

        public Caminhao(string placa, string marca, string modelo, string cor, int quantidadeEixos) : base(placa, marca, modelo, cor)
        {
            QuantidadeEixos = quantidadeEixos;
            TipoVeiculo = TipoVeiculo.Caminhao;
        }
    }
}
