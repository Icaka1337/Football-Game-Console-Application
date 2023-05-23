namespace Football;

public class Team
{
    public string Name { get; private set; }
    public Coach Coach { get; private set; }
    public List<FootballPlayer> TotalPlayers { get; private set; }
    public List<FootballPlayer> ActivePlayers { get; private set; }
    public int TotalGoals { get; set; }

    public Team(string name, Coach coach)
    {
        TotalPlayers = new List<FootballPlayer>();
        ActivePlayers = new List<FootballPlayer>();
        this.Name = name;
        this.Coach = coach;
    }

    public void AddPlayer(FootballPlayer player)
    {
        TotalPlayers.Add(player);
    }

    public void RemovePlayer(FootballPlayer player)
    {
        TotalPlayers.Remove(player);
    }

    public void AddActivePlayer(FootballPlayer player)
    {
        ActivePlayers.Add(player);
    }

    public void RemoveActivePlayer(FootballPlayer player)
    {
        ActivePlayers.Remove(player);
    }

    public double GetAverageAge()
    {
        double sum = 0;
        foreach (var player in TotalPlayers)
        {
            sum += player.Age;
        }

        return Math.Round((sum / TotalPlayers.Count), 0);
    }
}