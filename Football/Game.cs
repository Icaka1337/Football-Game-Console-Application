using System.Text;

namespace Football;

public class Game
{
    private Team TeamA { get; set; }
    private Team TeamB { get; set; }
    private Referee MainReferee { get; set; }
    private Referee AssistantReferee1 { get; set; }
    private Referee AssistantReferee2 { get; set; }
    public StringBuilder Sb { get; private set; }

    public Game(Team teamA, Team teamB, Referee mainReferee, Referee assistantReferee1, Referee assistantReferee2)
    {
        this.TeamA = teamA;
        this.TeamB = teamB;
        this.MainReferee = mainReferee;
        this.AssistantReferee1 = assistantReferee1;
        this.AssistantReferee2 = assistantReferee2;
        Sb = new StringBuilder();
    }

    public void StartGame()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Game started between {TeamA.Name} and {TeamB.Name}");
        sb.AppendLine();
        sb.AppendLine($"Coach of {TeamA.Name}: {TeamA.Coach.Name}");
        sb.AppendLine($"Coach of {TeamB.Name}: {TeamB.Coach.Name}");
        sb.AppendLine();
        sb.AppendLine($"Main referee: {MainReferee.Name}");
        sb.AppendLine($"Assistant referee 1: {AssistantReferee1.Name}");
        sb.AppendLine($"Assistant referee 2: {AssistantReferee2.Name}");
        sb.AppendLine();
        sb.AppendLine($"Active players of {TeamA.Name}:");

        foreach (var player in TeamA.ActivePlayers)
        {
            sb.AppendLine($"{player.Name}");
            sb.AppendLine($"Age: {player.Age}");
            sb.AppendLine($"Height: {player.Height}cm");
        }

        sb.AppendLine($"{TeamA.Name} players average age is {TeamA.GetAverageAge()}");
        sb.AppendLine();

        sb.AppendLine($"Active players of {TeamB.Name}:");
        foreach (var player in TeamB.ActivePlayers)
        {
            sb.AppendLine($"{player.Name}");
            sb.AppendLine($"Age: {player.Age}");
            sb.AppendLine($"Height: {player.Height}cm");
        }


        sb.AppendLine($"{TeamB.Name} players average age is {TeamB.GetAverageAge()}");
        sb.AppendLine();

        Console.WriteLine(sb.ToString());
    }

    public void Goal(Team team, int minute, FootballPlayer player)
    {
        Console.WriteLine($"Goal scored by {player.Name} at {minute} minute");
        Sb.AppendLine($"{player.Name} from {team.Name} scored a goal at {minute} minute");
        Console.WriteLine();
        team.TotalGoals++;
    }

    public void CurrentResult()
    {
        Console.WriteLine($"Current Result: {TeamA.Name} {TeamA.TotalGoals} - {TeamB.Name} {TeamB.TotalGoals}");
        Console.WriteLine(Sb.ToString());
    }

    public void FinalResult()
    {
        Console.WriteLine($"Final Result: {TeamA.Name} {TeamA.TotalGoals} - {TeamB.Name} {TeamB.TotalGoals}");

        Console.WriteLine(Sb.ToString());

        if (TeamA.TotalGoals > TeamB.TotalGoals)
        {
            Console.WriteLine($"The Winner is {TeamA.Name}");
        }
        else if (TeamA.TotalGoals < TeamB.TotalGoals)
        {
            Console.WriteLine($"The Winner is {TeamB.Name}");
        }
        else
        {
            Console.WriteLine($"Draw");
        }
    }
}