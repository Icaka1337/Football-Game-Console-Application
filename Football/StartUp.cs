using Football;

public class StartUp
{
    public static void Main(string[] args)
    {
        //Ръста да е в см а не в метри
        Console.WriteLine("Football Game");

        Console.WriteLine("First lets create the teams");

        Console.WriteLine("Enter Team A name: ");
        string teamName = Console.ReadLine();

        Console.WriteLine("Enter coach name: ");
        string coachName = Console.ReadLine();

        Console.WriteLine("Enter coach age: ");
        int coachAge = int.Parse(Console.ReadLine());

        var coachA = new Coach(coachName, coachAge);

        var teamA = new Team(teamName, coachA);

        Console.WriteLine("Enter Team B name: ");
        teamName = Console.ReadLine();
        Console.WriteLine("Enter coach name: ");
        coachName = Console.ReadLine();
        Console.WriteLine("Enter coach age: ");
        coachAge = int.Parse(Console.ReadLine());

        var coachB = new Coach(coachName, coachAge);
        var teamB = new Team(teamName, coachB);

        int n;
        do
        {
            Console.WriteLine("1. Add player");
            Console.WriteLine("2. Add active player");
            Console.WriteLine("3. Remove player");
            Console.WriteLine("4. Remove active player");
            Console.WriteLine("5. Start game");
            Console.WriteLine("0. Exit");

            n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    AddPlayer(teamA, teamB);
                    break;
                case 2:
                    AddActivePlayer(teamA, teamB);
                    break;
                case 3:
                    RemovePlayer(teamA, teamB);
                    break;
                case 4:
                    RemoveActivePlayer(teamA, teamB);
                    break;
                case 5:
                    if (CheckPlayersCount(teamA, teamB))
                    {
                        GameStart(teamA, teamB);
                        n = 0;
                    }

                    break;
                case 0:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (n != 0);
    }

    private static bool CheckPlayersCount(Team teamA, Team teamB)
    {
        if (teamA.TotalPlayers.Count < 11 || teamB.TotalPlayers.Count < 11)
        {
            Console.WriteLine("You need at least 11 players in each team to start the game");
            Console.WriteLine($"Your current players count in {teamA.Name} is: {teamA.TotalPlayers.Count}");
            Console.WriteLine($"Your current players count in {teamB.Name} is: {teamB.TotalPlayers.Count}");
            Console.WriteLine("Add some players and try again");
            return false;
        }
        else if (teamA.TotalPlayers.Count > 22 || teamB.TotalPlayers.Count > 22)
        {
            Console.WriteLine("You can't have more than 22 players in each team");
            Console.WriteLine($"Your current players count in {teamA.Name} is: {teamA.TotalPlayers.Count}");
            Console.WriteLine($"Your current players count in {teamB.Name} is: {teamB.TotalPlayers.Count}");
            Console.WriteLine("Remove some players and try again");
            return false;
        }

        if (teamA.ActivePlayers.Count != 11)
        {
            Console.WriteLine("You need 11 active players in each team to start the game");
            if (teamA.ActivePlayers.Count < 11)
            {
                Console.WriteLine($"Your current active players count is: {teamA.ActivePlayers.Count}");
                Console.WriteLine("Add some active players and try again");
                return false;
            }
            else
            {
                Console.WriteLine($"Your current active players count is: {teamA.ActivePlayers.Count}");
                Console.WriteLine("Remove some active players and try again");
                return false;
            }
        }
        else if (teamB.ActivePlayers.Count != 11)
        {
            Console.WriteLine("You need 11 active players in each team to start the game");
            if (teamB.ActivePlayers.Count < 11)
            {
                Console.WriteLine($"Your current active players count is: {teamB.ActivePlayers.Count}");
                Console.WriteLine("Add some active players and try again");
                return false;
            }
            else
            {
                Console.WriteLine($"Your current active players count is: {teamB.ActivePlayers.Count}");
                Console.WriteLine("Remove some active players and try again");
                return false;
            }
        }

        return true;
    }

    public static void AddPlayer(Team teamA, Team teamB)
    {
        Console.WriteLine("Enter player team: ");
        Console.WriteLine($"1. {teamA.Name}");
        Console.WriteLine($"2. {teamB.Name}");
        int num = int.Parse(Console.ReadLine());

        string playerTeam;

        if (num == 1)
        {
            playerTeam = teamA.Name;
        }
        else if (num == 2)
        {
            playerTeam = teamB.Name;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return;
        }

        Console.WriteLine("Enter player type: ");
        Console.WriteLine("1. Goalkeeper");
        Console.WriteLine("2. Defender");
        Console.WriteLine("3. Midfield");
        Console.WriteLine("4. Striker");

        int playerType = int.Parse(Console.ReadLine());
        if (playerType < 1 || playerType > 4)
        {
            Console.WriteLine("Invalid input");
            return;
        }

        Console.WriteLine("Enter player name: ");
        string playerName = Console.ReadLine();

        Console.WriteLine("Enter player age: ");
        int playerAge = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter player number: ");
        int playerNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter player height in cm: ");
        int playerHeight = int.Parse(Console.ReadLine());

        switch (playerType)
        {
            case 1:
                var goalkeeper = new Goalkeeper(playerName, playerAge, playerNumber, playerHeight);
                if (playerTeam == teamA.Name)
                {
                    teamA.AddPlayer(goalkeeper);
                    Console.WriteLine("Player added successfully");
                }
                else
                {
                    teamB.AddPlayer(goalkeeper);
                    Console.WriteLine("Player added successfully");
                }

                break;

            case 2:
                var defender = new Defender(playerName, playerAge, playerNumber, playerHeight);
                if (playerTeam == teamA.Name)
                {
                    teamA.AddPlayer(defender);
                    Console.WriteLine("Player added successfully");
                }
                else
                {
                    teamB.AddPlayer(defender);
                    Console.WriteLine("Player added successfully");
                }

                break;

            case 3:
                var midfielder = new Midfield(playerName, playerAge, playerNumber, playerHeight);
                if (playerTeam == teamA.Name)
                {
                    teamA.AddPlayer(midfielder);
                    Console.WriteLine("Player added successfully");
                }
                else
                {
                    teamB.AddPlayer(midfielder);
                    Console.WriteLine("Player added successfully");
                }

                break;

            case 4:
                var striker = new Striker(playerName, playerAge, playerNumber, playerHeight);
                if (playerTeam == teamA.Name)
                {
                    teamA.AddPlayer(striker);
                    Console.WriteLine("Player added successfully");
                }
                else
                {
                    teamB.AddPlayer(striker);
                    Console.WriteLine("Player added successfully");
                }

                break;
        }
    }

    public static void AddActivePlayer(Team teamA, Team teamB)
    {
        Console.WriteLine("Enter player team: ");
        Console.WriteLine($"1. {teamA.Name}");
        Console.WriteLine($"2. {teamB.Name}");

        int num = int.Parse(Console.ReadLine());

        string playerTeam;

        if (num == 1)
        {
            playerTeam = teamA.Name;
        }
        else if (num == 2)
        {
            playerTeam = teamB.Name;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return;
        }

        Console.WriteLine("Available players: ");
        if (playerTeam == teamA.Name)
        {
            int n = 1;
            int N = 0;
            foreach (var player in teamA.TotalPlayers)
            {
                if (!teamA.ActivePlayers.Contains(player))
                {
                    Console.WriteLine($"{n++}. {player.Name}");
                    N++;
                }
                else
                {
                    n++;
                }
            }

            if (N == 0)
            {
                Console.WriteLine("There are no available players");
                return;
            }

            Console.WriteLine("Which player do you want to add to the active players list ?");
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number > teamA.TotalPlayers.Count)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            if (teamA.ActivePlayers.Count > 0)
            {
                if (teamA.ActivePlayers.Contains(teamA.TotalPlayers[number - 1]))
                {
                    Console.WriteLine("This player is already in the active players list");
                    Console.WriteLine("Please choose someone from the available players list");
                }
                else
                {
                    teamA.AddActivePlayer(teamA.TotalPlayers[number - 1]);
                    Console.WriteLine("Player added successfully");
                }
            }
            else
            {
                teamA.AddActivePlayer(teamA.TotalPlayers[number - 1]);
                Console.WriteLine("Player added successfully");
            }
        }
        else
        {
            int n = 1;
            int N = 0;
            foreach (var player in teamB.TotalPlayers)
            {
                if (!teamB.ActivePlayers.Contains(player))
                {
                    Console.WriteLine($"{n++}. {player.Name}");
                    N++;
                }
                else
                {
                    n++;
                }
            }

            if (N == 0)
            {
                Console.WriteLine("There are no available players");
                return;
            }

            Console.WriteLine("Which player do you want to add to the active players list ?");
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number > teamB.TotalPlayers.Count)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            if (teamB.ActivePlayers.Count > 0)
            {
                if (teamB.ActivePlayers.Contains(teamB.TotalPlayers[number - 1]))
                {
                    Console.WriteLine("This player is already in the active players list");
                    Console.WriteLine("Please choose someone from the available players list");
                }
                else
                {
                    teamB.AddActivePlayer(teamB.TotalPlayers[number - 1]);
                    Console.WriteLine("Player added successfully");
                }
            }
            else
            {
                teamB.AddActivePlayer(teamB.TotalPlayers[number - 1]);
                Console.WriteLine("Player added successfully");
            }
        }
    }

    public static void RemovePlayer(Team teamA, Team teamB)
    {
        Console.WriteLine("Enter player team: ");
        Console.WriteLine($"1. {teamA.Name}");
        Console.WriteLine($"2. {teamB.Name}");
        int num = int.Parse(Console.ReadLine());

        string playerTeam;

        if (num == 1)
        {
            playerTeam = teamA.Name;
        }
        else if (num == 2)
        {
            playerTeam = teamB.Name;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return;
        }

        Console.WriteLine("Available players: ");

        if (playerTeam == teamA.Name)
        {
            if (teamA.TotalPlayers.Count == 0)
            {
                Console.WriteLine("There are no players in this team");
                return;
            }

            int n = 1;
            foreach (var player in teamA.TotalPlayers)
            {
                Console.WriteLine($"{n++}. {player.Name}");
            }

            Console.WriteLine("Which player do you want to remove from the players list ?");
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            teamA.RemovePlayer(teamA.TotalPlayers[number - 1]);
            Console.WriteLine("Player removed successfully");
        }
        else
        {
            if (teamB.TotalPlayers.Count == 0)
            {
                Console.WriteLine("There are no players in this team");
                return;
            }

            int n = 1;
            foreach (var player in teamB.TotalPlayers)
            {
                Console.WriteLine($"{n++}. {player.Name}");
            }

            Console.WriteLine("Which player do you want to remove from the players list ?");
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            teamB.RemovePlayer(teamB.TotalPlayers[number - 1]);
            Console.WriteLine("Player removed successfully");
        }
    }

    public static void RemoveActivePlayer(Team teamA, Team teamB)
    {
        Console.WriteLine("Enter player team: ");
        Console.WriteLine($"1. {teamA.Name}");
        Console.WriteLine($"2. {teamB.Name}");
        int num = int.Parse(Console.ReadLine());

        string playerTeam;

        if (num == 1)
        {
            playerTeam = teamA.Name;
        }
        else if (num == 2)
        {
            playerTeam = teamB.Name;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return;
        }

        Console.WriteLine("Available players: ");

        if (playerTeam == teamA.Name)
        {
            if (teamA.ActivePlayers.Count == 0)
            {
                Console.WriteLine("There are no active players in this team");
                return;
            }

            int n = 1;
            foreach (var player in teamA.ActivePlayers)
            {
                Console.WriteLine($"{n++}. {player.Name}");
            }

            Console.WriteLine("Which player do you want to remove from the active players list ?");
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            teamA.RemoveActivePlayer(teamA.ActivePlayers[number -= 1]);
            Console.WriteLine("Player removed successfully");
        }
        else
        {
            if (teamB.ActivePlayers.Count == 0)
            {
                Console.WriteLine("There are no active players in this team");
                return;
            }

            int n = 1;
            foreach (var player in teamB.ActivePlayers)
            {
                Console.WriteLine($"{n++}. {player.Name}");
            }

            Console.WriteLine("Which player do you want to remove from the active players list ?");
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            teamB.RemoveActivePlayer(teamB.ActivePlayers[number -= 1]);
            Console.WriteLine("Player removed successfully");
        }
    }

    public static void GameStart(Team teamA, Team teamB)
    {
        Console.WriteLine("Enter main referee name: ");
        string mainRefereeName = Console.ReadLine();
        Console.WriteLine("Enter main referee age: ");
        int mainRefereeAge = int.Parse(Console.ReadLine());
        var mainReferee = new Referee(mainRefereeName, mainRefereeAge);

        Console.WriteLine("Enter assistant referee 1 name: ");
        string assistantReferee1Name = Console.ReadLine();
        Console.WriteLine("Enter assistant referee 1 age: ");
        int assistantReferee1Age = int.Parse(Console.ReadLine());
        var assistantReferee1 = new Referee(assistantReferee1Name, assistantReferee1Age);

        Console.WriteLine("Enter assistant referee 2 name: ");
        string assistantReferee2Name = Console.ReadLine();
        Console.WriteLine("Enter assistant referee 2 age: ");
        int assistantReferee2Age = int.Parse(Console.ReadLine());
        var assistantReferee2 = new Referee(assistantReferee2Name, assistantReferee2Age);

        var game = new Game(teamA, teamB, mainReferee, assistantReferee1, assistantReferee2);
        game.StartGame();

        int n;

        do
        {
            Console.WriteLine("Enter 1 to add a goal");
            Console.WriteLine("Enter 2 to see current score");
            Console.WriteLine("Enter 3 to check who won the game");

            n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("Which team scored the goal: ");
                    Console.WriteLine($"1. {teamA.Name}");
                    Console.WriteLine($"2. {teamB.Name}");
                    int teamNumber = int.Parse(Console.ReadLine());
                    if (teamNumber < 1 || teamNumber > 2)
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Choose the player that scored the goal: ");
                    Console.WriteLine();
                    if (teamNumber == 1)
                    {
                        int i = 1;
                        foreach (var player in teamA.ActivePlayers)
                        {
                            Console.WriteLine($"{i++}. {player.Name}");
                        }
                    }
                    else
                    {
                        int i = 1;
                        foreach (var player in teamB.ActivePlayers)
                        {
                            Console.WriteLine($"{i++}. {player.Name}");
                        }
                    }

                    int playerNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Enter the minute of the goal: ");
                    int minute = int.Parse(Console.ReadLine());

                    if (teamNumber == 1)
                    {
                        game.Goal(teamA, minute, teamA.ActivePlayers[playerNumber - 1]);
                    }
                    else
                    {
                        game.Goal(teamB, minute, teamB.ActivePlayers[playerNumber - 1]);
                    }

                    break;
                case 2:
                    game.CurrentResult();
                    break;
                case 3:
                    game.FinalResult();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (n != 3);
    }
}