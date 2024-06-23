# EURO Tournament Betting App

## General

The aim of the application is to enable users to place bets on EURO tournamet games. The application tracks users' active bets, store their betting history, and calculate the points they have accumulated.

### Disclaimer

The application was created in less than a week due to the time pressure of launching before the Euro started. It is not a perfect product - its code and architrecture might have flaws, and it may lack extensive testing - BUT it works and is functional. :)

### Key Features

#### User Authentication

- User registration and login

#### Betting System

- Display upcoming EURO tournament games
- Allow users to place bets on upcoming games
- User can only bet a game that has not started yet
- Once a game begins, it is possible to see the bets placed by other players

#### Points Calculation:
- Assign points based on the accuracy of users' bets
- Points system based on predefined rules - exact score match earns 5 points, correct goal difference earns 3 points, and predicting the winner earns 2 points

#### Reviewing Betting History
- Users can access their and another player's history to see past bets and results

#### Points and Leaderboard
- Users view their current points and ranking
- Leaderboard displays top users based on points earned

### Technologies

The application is written in .NET C# and is ASP.NET Blazor Web Application with SignalR and WebSockets connections.
SQL Server is used for persisent storage, and EF Core as ORM library.
MudBlazor has been selected as the Blazor UI component framework.
ASP.NET Core Identity is used for user authentication and authorization.

### Hosting

The application is currently hosted on the Azure cloud and uses Azure SQL Database in production.

### Screenshots:

![image](https://github.com/Qwertyluk/betting-tournament/assets/64921645/a5c69fd6-d994-4e3f-b787-fa82aca9d610)

![image](https://github.com/Qwertyluk/betting-tournament/assets/64921645/8123d3f3-6a73-4293-9f68-30280d16574c)

![image](https://github.com/Qwertyluk/betting-tournament/assets/64921645/0631748d-9b35-43ed-9f7f-a4dd5bc60c0d)

![image](https://github.com/Qwertyluk/betting-tournament/assets/64921645/cec17821-f792-4d1b-bbc8-15ccf21f6dc3)

![image](https://github.com/Qwertyluk/betting-tournament/assets/64921645/0d58bd06-ce53-4d31-a2f1-aae7f1ec8563)
