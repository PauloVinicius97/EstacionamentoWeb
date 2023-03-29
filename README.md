# EstacionamentoWeb

Prova da Rhitmo Tech para a vaga de Dev Back-End. Os arquivos a serem analisados são:
- A pasta "EstacionamentoCore" inteira;
- Default.aspx e Default.aspx.cs dentro de "EstacionamentoWeb".

A seguir, uma análise das classes encontradas.

## ParkingLot, ParkingSpots e Vehicles

Diagrama:

Basicamente, um ParkingLot tem vários ParkingSpots, e cada Vehicle pode ter vários ParkingSpots. A lógica de como o estacionamento funciona está na ParkingLot, contendo métodos para estacionar, remover veículos e análise de dados (está lotado, está cheio, etc.). Em um cenário não-fictício utilizando DDD, eu moveria alguns métodos como o "CreateAndTryParkVehicle" para um App Service.

ParkingSpots podem estacionar ou remover um veículo. 

Existem três tipos de veículos: carros, motos e vans. Todas derivam de Vehicle, seu tipo sendo definido pela classe. 

Existem também outras classes como as Factories e o Result, que servem para auxiliar no processo de criação de classes e resposta para o front, respectivamente.

## Tela

To-do

## To-dos
