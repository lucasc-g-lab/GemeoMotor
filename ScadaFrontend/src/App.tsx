import { useState, useEffect } from 'react'
import './App.css'

function App() {
  // Estado para guardar os dados vindos do nosso backend em C#
  const [machineData, setMachineData] = useState({
    temperature: 0,
    pressure: 0,
    isRunning: false
  })

  // Função para ir buscar os dados à nossa API
  const fetchStatus = async () => {
    try {
      // O endereço do nosso backend que deixámos a correr no outro terminal
      const response = await fetch('http://localhost:5103/api/machine/status')
      const data = await response.json()
      setMachineData(data)
    } catch (error) {
      console.error("Erro ao procurar dados da máquina:", error)
    }
  }

  // O useEffect faz com que a função fetchStatus corra a cada 2 segundos automaticamente (igual ao sensor)
  useEffect(() => {
    fetchStatus() // Busca logo na primeira vez
    const interval = setInterval(fetchStatus, 2000)
    return () => clearInterval(interval)
  }, [])

  // Função para ligar/desligar a máquina ao clicar no botão
  const toggleMachine = async () => {
    try {
      await fetch('http://localhost:5103/api/machine/toggle', { method: 'POST' })
      fetchStatus() // Atualiza os dados imediatamente após clicar
    } catch (error) {
      console.error("Erro ao alternar o estado:", error)
    }
  }

  return (
    <div style={{ padding: '2rem', fontFamily: 'sans-serif' }}>
      <h1>Painel SCADA - Gêmeo Digital</h1>
      
      <div style={{ border: '2px solid #ccc', padding: '1rem', borderRadius: '8px', maxWidth: '350px', backgroundColor: '#1e1e1e', color: 'white' }}>
        <h2>Estado: {machineData.isRunning ? "🟢 LIGADA" : "🔴 DESLIGADA"}</h2>
        <p><strong>Temperatura do Motor:</strong> {machineData.temperature.toFixed(2)} °C</p>
        <p><strong>Pressão do Sistema:</strong> {machineData.pressure.toFixed(2)} Bar</p>
        
        <button 
          onClick={toggleMachine}
          style={{ 
            padding: '10px 20px', 
            backgroundColor: machineData.isRunning ? '#ff4444' : '#00C851',
            color: 'white',
            border: 'none',
            borderRadius: '5px',
            cursor: 'pointer',
            marginTop: '15px',
            fontWeight: 'bold',
            width: '100%'
          }}
        >
          {machineData.isRunning ? "PARAR MÁQUINA" : "ARRANCAR MÁQUINA"}
        </button>
      </div>
    </div>
  )
}

export default App