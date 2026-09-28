namespace CleanCodeShenaningans.DesignPatterns.Creational;

/// example from https://refactoring.guru/design-patterns/factory-method

public abstract class Logistics
{
    public void PlanDelivery()
    {
        Console.WriteLine("Planning delivery...");
        var transport = CreateTransport();
        transport.Deliver();
    }

    protected abstract ITransport CreateTransport();
}

public class RoadLogistics : Logistics
{
    protected override ITransport CreateTransport()
    {
        return new RoadTransport();
    }
}

public class SeaLogistics : Logistics
{
    protected override ITransport CreateTransport()
    {
        return new SeaTransport();
    }
}

# region Transport Implementations

public interface ITransport
{
    void Deliver();
}

public class RoadTransport : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivering by road...");
    }
}

public class SeaTransport : ITransport
{
    public void Deliver()
    {
        Console.WriteLine("Delivering by sea...");
    }
}

#endregion