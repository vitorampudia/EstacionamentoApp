using System;
using System.Collections.Generic;
using System.Text;
using EstacionamentoApp.Enums;

namespace EstacionamentoApp.Models
{
    internal abstract class Veiculo
    {
        
        private int Id { get; }
        public string? Placa {  get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string Cor {  get; set; }
        public TipoVeiculo TipoVeiculo { get; protected set; }

        protected Veiculo(string placa, string marca, string modelo, string cor) 
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }
        public override string ToString()
        {
            return $"{TipoVeiculo} | {Placa} | {Marca} | {Modelo} | {Cor}";
        }
    }
}
