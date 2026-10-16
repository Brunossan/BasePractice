namespace CleanCodeShenaningans.DesignPatterns.Behavioral;


public interface IMovementCommand
{
    void Move(string direction);
}

public class WalkCommand : IMovementCommand
{
    public void Move(string direction)
    {
        Console.WriteLine("Walking " + direction);
    }
}

public class DashCommand :IMovementCommand
{
    private readonly int _distance;

    public DashCommand(int distance)
    {
        _distance = distance;
    }

    public void Move(string direction)
    {
        Console.WriteLine("Dashing " + direction + " for " + _distance + " units.");
    }

}