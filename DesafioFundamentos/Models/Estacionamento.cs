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

        public void AdicionarVeiculo()
        {

            bool ehValida = false;

            while (!ehValida)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                
                string placa = Console.ReadLine();

                string padrao = @"^[A-Z]{3}-[0-9][A-Z][0-9]{2}$";
                
                if (Regex.IsMatch(placa, padrao))
                {
                    veiculos.Add(placa);
                    Console.WriteLine("Placa válida");
                    ehValida = true;
                }

                else 
                {
                    Console.WriteLine("A Placa informada é inválida. Digite a placa no formato AAA-0A00");
                }

            }
            
        }

        public void RemoverVeiculo()
        {

            bool ehValida = false;
            string placa = "";

            while (!ehValida)
            {
            
                Console.WriteLine("Digite a placa do veículo para remover:");
                
                placa = Console.ReadLine();

                string padrao = @"^[A-Z]{3}-[0-9][A-Z][0-9]{2}$";
                    
                if (Regex.IsMatch(placa, padrao))
                {
                    veiculos.Add(placa);
                    Console.WriteLine("Placa válida");
                    ehValida = true;
                }

                else 
                {
                    Console.WriteLine("A Placa informada é inválida. Digite a placa no formato AAA-0A00");
                }
        
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = 0; 
                valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }

            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach(string item in veiculos)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
