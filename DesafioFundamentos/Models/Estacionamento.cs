using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public bool AdicionarVeiculo(string placa)
        {
            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa);
                return true; // Veículo adicionado com sucesso
            }
            return false; // Placa inválida
        }

        public bool RemoverVeiculo(string placa)
        {

            if (ValidarPlaca(placa))
            {
                veiculos.Remove(placa);
                return true; // Veículo removido com sucesso
            }

            return false; // Veículo não encontrado
        }

        public List<string> ListarVeiculos()
        {
            return veiculos;
        }

        public bool VeiculoExiste(string placa)
        {
            return veiculos.Any(x => x.ToUpper() == placa.ToUpper());
        }

        public bool ValidarPlaca(string placa)
        {
            return Regex.IsMatch(placa, @"^[A-Z]{3}-\d{4}$");
        }

        public decimal CalcularValorTotal(int horasEstacionado)
        {
            return precoInicial + (precoPorHora * horasEstacionado);
        }
    }
}
