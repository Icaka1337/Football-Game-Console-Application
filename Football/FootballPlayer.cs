namespace Football;

public abstract class FootballPlayer : Person
{
    public int Number { get; private set; }
    public int Height { get; private set; }

    public FootballPlayer(string name, int age, int number, int height) : base(name, age)
    {
        this.Number = number;
        this.Height = height;
    }
}