using System;
using System.Threading;

namespace ScadaBackend.Services
{
    public class MachineSimulator
    {
        // Propriedades que representam o estado atual da minha máquina virtual
        public double MotorTemperature { get; private set; } = 25.0;
        public double SystemPressure { get; private set; } = 1.0;
        public bool IsRunning { get; private set; } = true;

        // Vou usar a classe Random para simular as pequenas variações físicas dos sensores
        private readonly Random _random = new Random();

        public void UpdateMachineState()
        {
            if (!IsRunning) return;

            // A simular o aquecimento do motor aos poucos, com um pequeno ruído aleatório
            // Se passar dos 90 graus, vou forçar um arrefecimento para não "queimar" na simulação
            MotorTemperature += _random.NextDouble() * 2.0 - 0.5;
            if (MotorTemperature > 90.0) MotorTemperature -= 5.0;

            // A pressão varia entre 1 e 5 bar
            SystemPressure = 1.0 + (_random.NextDouble() * 4.0);
        }

        // Função que vou chamar no futuro para ligar/desligar a máquina pelo meu painel web
        public void ToggleMachine()
        {
            IsRunning = !IsRunning;
            
            // Se eu desligar a máquina, forço a temperatura a começar a descer para a temperatura ambiente (25 graus)
            if (!IsRunning)
            {
                MotorTemperature = 25.0;
                SystemPressure = 1.0;
            }
        }
    }
}