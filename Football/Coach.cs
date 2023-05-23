namespace Football;

public class Coach : Person
{
    private string Name { get; set; }
    public Coach(string name, int age) : base(name, age)
    {
        this.Name = name;
    }

    public string GetName()
    {
        return $"{Name}";
    }
}