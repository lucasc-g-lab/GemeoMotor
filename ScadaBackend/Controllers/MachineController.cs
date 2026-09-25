using Microsoft.AspNetCore.Mvc;
using ScadaBackend.Services;

namespace ScadaBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly MachineSimulator _simulator;

        // Injeto o simulador no meu controlador para ter acesso aos dados em tempo real
        public MachineController(MachineSimulator simulator)
        {
            _simulator = simulator;
        }

        // Endpoint para eu ler o estado atual da máquina a partir da web
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            var status = new
            {
                temperature = _simulator.MotorTemperature,
                pressure = _simulator.SystemPressure,
                isRunning = _simulator.IsRunning
            };
            
            return Ok(status);
        }

        // Endpoint para eu ligar ou desligar a máquina com um clique no botão do frontend
        [HttpPost("toggle")]
        public IActionResult ToggleMachine()
        {
            _simulator.ToggleMachine();
            return Ok(new { message = "Estado da máquina alterado!", isRunning = _simulator.IsRunning });
        }
    }
}