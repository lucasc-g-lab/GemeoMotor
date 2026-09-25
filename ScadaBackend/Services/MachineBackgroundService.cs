using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ScadaBackend.Services
{
    public class MachineBackgroundService : BackgroundService
    {
        private readonly MachineSimulator _simulator;

        // Injeto o meu simulador aqui para poder atualizar os dados dele
        public MachineBackgroundService(MachineSimulator simulator)
        {
            _simulator = simulator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Este loop vai correr infinitamente em segundo plano enquanto a API estiver ligada
            while (!stoppingToken.IsCancellationRequested)
            {
                _simulator.UpdateMachineState();
                
                // Espera 2 segundos antes de atualizar os dados novamente (simula o tempo de leitura de um sensor real)
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}