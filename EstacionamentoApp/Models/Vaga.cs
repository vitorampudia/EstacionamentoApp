using System;
using System.Collections.Generic;
using System.Text;
using EstacionamentoApp.Enums;



namespace EstacionamentoApp.Models
{
    internal class Vaga
    {
        public int Id { get; }
        public int Numero { get; }
        public bool Ocupada { get; private set; }
        public TipoVeiculo TipoPermitido { get; }

        public Vaga(int numero, TipoVeiculo tipoPermitido)
        {
            Ocupada = false;
            Numero = numero;
            TipoPermitido = tipoPermitido;
        }
        public void Ocupar()
        {
            Ocupada = true;
        }

        public void Liberar()
        {
            Ocupada = false;
        }
        public bool VerificarOcupada()
        {
            return Ocupada;
        }
        public TipoVeiculo VerificarVeiculo()
        {
            return TipoPermitido;
        }
        public override string ToString()
        {
            return $"Número: {Numero} | Tipo da Vaga: {TipoPermitido} | Status: {(VerificarOcupada() ? "Ocupada" : "Disponível")}";
        }
    }
}
