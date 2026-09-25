# Gemeo digital de um motor

Um sistema de Supervisao e Aquisicao de Dados (SCADA) que atua como um Gemeo Digital para equipamentos industriais. Este projeto une a Engenharia de Controlo e Automacao ao Desenvolvimento de Software, substituindo interfaces industriais estaticas por uma arquitetura web.

## Arquitetura do Sistema

- Backend: Desenvolvido em C# (.NET 8). Utiliza um servico em segundo plano para simular a termodinamica de um motor e a variacao de pressao, expondo os dados atraves de uma API REST.
- Frontend: Desenvolvido em React e TypeScript via Vite. Consome a API do backend de forma continua para fornecer um painel de controlo bidirecional em tempo real.

## Como Executar Localmente

Para correr este projeto no seu computador, e necessario ter o .NET SDK 8 e o Node.js instalados.

Passo 1: Iniciar o Servidor Backend (C#)
1. Abra um terminal no seu computador.
2. Navegue ate a pasta do backend utilizando o comando: cd ScadaBackend
3. Inicie a aplicacao executando o comando: dotnet run
4. Aguarde alguns segundos ate aparecer a mensagem indicando que a aplicacao esta a escutar no endereco http://localhost:5103. 
5. Deixe este terminal aberto e a correr em segundo plano.

Passo 2: Iniciar o Painel Frontend (React)
1. Abra uma nova janela de terminal separada.
2. Navegue ate a pasta do frontend utilizando o comando: cd ScadaFrontend
3. Instale as ferramentas necessarias executando o comando: npm install
4. Quando a instalacao terminar, ligue o servidor web executando o comando: npm run dev
5. Aguarde ate o terminal indicar que o site esta pronto no endereco http://localhost:5173.

Passo 3: Aceder ao Sistema
1. Abra o seu navegador de internet.
2. Copie e cole o endereco http://localhost:5173 na barra de pesquisa e prima Enter.
3. O painel SCADA vai carregar. Pode clicar no botao para arrancar a maquina virtual e ver os dados de temperatura e pressao a serem atualizados em tempo real.