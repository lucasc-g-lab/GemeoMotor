# SCADA Digital Twin 

Um sistema *full-stack* de Supervisão e Aquisição de Dados (SCADA) que atua como um Gêmeo Digital (Digital Twin) para equipamentos industriais. 

Este projeto une a **Engenharia de Controlo e Automação** ao **Desenvolvimento de Software Moderno**, substituindo interfaces industriais estáticas e proprietárias por uma arquitetura web ágil, reativa e escalável.

##  Arquitetura do Sistema

* **Backend (O Cérebro):** Desenvolvido em **C# (.NET 8)**. Utiliza um `BackgroundService` assíncrono que corre em segundo plano para simular a física de uma máquina (aquecimento termodinâmico de motores e variação estocástica de pressão). Expõe os dados através de uma API REST.
* **Frontend (A Interface):** Desenvolvido em **React + TypeScript** via Vite. Consome a API do backend de forma contínua, fornecendo um painel de controlo de baixa latência para monitorização e comando bidirecional.

## Como Executar Localmente

**1. Iniciar o Motor Físico (Backend)**
Navegue até à pasta do backend e execute:
```bash
cd ScadaBackend
dotnet run