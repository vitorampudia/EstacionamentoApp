using EstacionamentoApp.Enums;
using EstacionamentoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EstacionamentoApp.Services;

namespace EstacionamentoApp.Services
{
    internal class EstacionamentoService
    {
        public List<Vaga> Vagas {  get; set; } = new List<Vaga> 
        {
                new Vaga(1, TipoVeiculo.Carro),
                new Vaga(3, TipoVeiculo.Carro),
                new Vaga(4, TipoVeiculo.Carro),
                new Vaga(5, TipoVeiculo.Carro),
                new Vaga(6, TipoVeiculo.Carro),
                new Vaga(7, TipoVeiculo.Moto),
                new Vaga(8, TipoVeiculo.Moto),
                new Vaga(9, TipoVeiculo.Moto),
                new Vaga(10, TipoVeiculo.Caminhao),
                new Vaga(11, TipoVeiculo.Caminhao)
        };
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>
        {
            new Carro("ABC1234", "Honda", "Civic", "Preto", 4),
            new Carro("DEF5678", "Toyota", "Corolla", "Branco", 4),
            new Carro("GHI9012", "Chevrolet", "Onix", "Prata", 4),
            new Carro("JKL3456", "Hyundai", "HB20", "Vermelho", 4),
            new Carro("MNO7890", "Volkswagen", "Golf", "Azul", 4),
            new Carro("PQR2345", "Ford", "Focus", "Cinza", 4),

            new Moto("STU6789", "Yamaha", "Fazer 250", "Preta", 250),
            new Moto("VWX1234", "Honda", "CB 500", "Vermelha", 500),
            new Moto("YZA5678", "Kawasaki", "Ninja 400", "Verde", 400),
            new Moto("BCD9012", "Suzuki", "GSX-S750", "Azul", 750),
            new Moto("EFG3456", "BMW", "G310R", "Branca", 310),

            new Caminhao("HIJ7890", "Volvo", "FH 540", "Branco", 6),
            new Caminhao("KLM2345", "Scania", "R450", "Azul", 6),
            new Caminhao("NOP6789", "Mercedes", "Actros", "Prata", 8),
            new Caminhao("QRS1234", "DAF", "XF", "Vermelho", 6)
        };
        public List<Estadia> Estadias { get; set; } = new List<Estadia>();

        public EstacionamentoService() 
        {
        }
        public bool CadastrarVeiculo(Veiculo veiculo)
        {
            if (Veiculos.Any(v => v.Placa == veiculo.Placa)) return false;
            Veiculos.Add(veiculo);
            return true;
        }
        public bool RegistrarEntrada(string placaVeiculo)
        {
            Veiculo? veiculoEntrada = Veiculos.Where(v => v.Placa == placaVeiculo).FirstOrDefault();

            if (veiculoEntrada == null) return false;
            if (Estadias.Any(e => e.Veiculo == veiculoEntrada && e.VerificarAtividade())) return false;
            if (!Vagas.Any(v => v.TipoPermitido == veiculoEntrada.TipoVeiculo && !v.VerificarOcupada())) return false;
          
            Vaga vagaLivre = Vagas.Where(v => v.TipoPermitido == veiculoEntrada.TipoVeiculo && !v.VerificarOcupada()).First();
            Estadias.Add(new Estadia(veiculoEntrada, vagaLivre));
            vagaLivre.Ocupar();

            return true;
        }
        public bool RegistrarSaida(string placaVeiculo)
        {
            Veiculo? veiculoSaida = Veiculos.Where(v => v.Placa == placaVeiculo).FirstOrDefault();
            if (veiculoSaida == null) return false;

            Estadia? veiculoEstadia = Estadias.Where(e => e.Veiculo == veiculoSaida && e.VerificarAtividade()).FirstOrDefault();       
            if (veiculoEstadia == null) return false;

            veiculoEstadia.RegistrarSaida();
            veiculoEstadia.ValorPago = PagamentoService.CalcularPreco(veiculoEstadia.CalcularValor());
            veiculoEstadia.Vaga.Liberar();
            return true;
        }
        public bool ExisteVeiculosEstacionamento()
        {
            return Estadias.Any(e => e.VerificarAtividade());
        }
        public List<Veiculo> VeiculosNoEstacionamento()
        {
            List<Veiculo> veiculosEstacionamento = Estadias.Where(e => e.VerificarAtividade()).Select(e => e.Veiculo).ToList();
            return veiculosEstacionamento;
        }
        public List<Estadia> Historico()
        {
            return Estadias.OrderByDescending(e => e.VerificarAtividade()).ToList();
        }
        public List<Vaga> VagasDisponiveis()
        {
            return Vagas.Where(v => !v.VerificarOcupada()).ToList();
        }
        public List<Vaga> VagasOcupadas()
        {
            return Vagas.Where(v => v.VerificarOcupada()).ToList();
        }
    }
}
