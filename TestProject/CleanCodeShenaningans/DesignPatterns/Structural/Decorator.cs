namespace CleanCodeShenaningans.DesignPatterns.Structural;

public interface ISword
{
    void Attack();
}

public class BasicSword : ISword
{
    public void Attack()
    {
        Console.WriteLine("Melee damage dealt!");
    }
}

public class SwordDecorator : ISword
{
    private readonly ISword _sword;

    public SwordDecorator(ISword sword)
    {
        _sword = sword;
    }

    public void Attack()
    {
        _sword.Attack();
    }
}

public class FireSwordDecorator : SwordDecorator
{
    public FireSwordDecorator(ISword sword) : base(sword)
    {
    }
    public new void Attack()
    {
        base.Attack();
        Console.WriteLine("Fire damage dealt!");
    }
}

public class PoisonSwordDecorator : SwordDecorator
{
    public PoisonSwordDecorator(ISword sword) : base(sword)
    {
    }
    public new void Attack()
    {
        base.Attack();
        Console.WriteLine("Poison damage dealt!");
    }
}