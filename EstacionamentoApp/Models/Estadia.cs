using EstacionamentoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstacionamentoApp.Models
{
    internal class Estadia : ICobravel
    {
        private int Id;
        public Veiculo Veiculo { get; set; }
        public Vaga Vaga { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public decimal ValorPago { get; set; }

        public Estadia(Veiculo veiculo, Vaga vaga)
        {
            Veiculo = veiculo;
            Vaga = vaga;
            DataEntrada = DateTime.Now;
            ValorPago = 0;
        }
        public void RegistrarSaida()
        {
            DataSaida = DateTime.Now;
        }
        public TimeSpan CalcularValor()
        {
            return DataSaida - DataEntrada; 
        }
        public bool VerificarAtividade()
        {
            bool atividade = DataSaida.Year == 0001 ? true : false;
            return atividade;
        }

        public override string ToString()
        {
            return $"{Veiculo.TipoVeiculo} | {Veiculo.Placa} | Numero da Vaga: {Vaga.Numero} | Data Entrada: {DataEntrada} | Data Saída: {(VerificarAtividade() ? "Nenhuma" : DataSaida)} | Valor Pago: ${ValorPago}";
        }
        
    }
}
