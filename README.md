# EstacionamentoWeb

Prova da Rhitmo Tech para a vaga de Dev Back-End. Os arquivos a serem analisados são:
- A pasta "EstacionamentoCore" inteira;
- Default.aspx e Default.aspx.cs dentro de "EstacionamentoWeb".

O resto são arquivos padrões de um projeto do Web Forms (Bootstrap, etc.).

## ParkingLot, ParkingSpots e Vehicles

Diagrama:

![Diagrama](https://raw.githubusercontent.com/PauloVinicius97/EstacionamentoWeb/master/diagrama.jpg)

Basicamente, um ParkingLot tem vários ParkingSpots, e cada Vehicle pode ter vários ParkingSpots. Existem vagas pequenas, médias e grandes e cada uma sua respectiva capacidade para acomodar veículos. A lógica de como o estacionamento funciona está na ParkingLot, contendo métodos para estacionar, remover veículos e análise de dados (está lotado, está cheio, etc.). Em um cenário não-fictício utilizando DDD, eu moveria alguns métodos como o "CreateAndTryParkVehicle" para um App Service. Toda a lógica indicada na proposta da prova está incluída.

ParkingSpots podem estacionar ou remover um veículo. 

Existem três tipos de veículos: carros, motos e vans. Todas derivam de Vehicle, seu tipo sendo definido pela classe. 

Existem também outras classes como as Factories e o Result, que servem para auxiliar no processo de criação de classes e resposta para o front, respectivamente.

## Tela

![Tela](https://github.com/PauloVinicius97/EstacionamentoWeb/blob/master/print-tela.png)

Não é possível estacionar sem uma placa. O botão "Gerar estacionamento maior" gera um estacionamento com 30 vagas. Tudo é salvo em uma variável de sessão, que é apagada quando uma requisição não-Postback é feita.

## To-dos

Assim como um [livro nunca é terminado, mas sim abandonado](https://www.goodreads.com/quotes/192509-a-book-is-never-finished-it-s-abandoned), creio que sempre existam pontos de evolução e melhoria de um programa. Eis alguns pontos que gostaria de explorar no futuro:

- Fazer com que vagas pequenas, médias e grandes herdem de uma "vaga pai" e contenham lógica para estacionar veículos de acordo com as regras do estacionamento;
- Indicar no README qual é a lógica do estacionamento;
- Fazer com que a aplicação use banco de dados, com padrão Repository e estrutura de DDD;
- Implementar front em Angular.
