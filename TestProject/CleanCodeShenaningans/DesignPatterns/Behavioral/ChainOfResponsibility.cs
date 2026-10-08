using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeShenaningans.DesignPatterns.Behavioral;

public class Damage
{
    public string Type { get; set; }
    public int Amount { get; set; }
    public Damage(string type, int amount)
    {
        Type = type;
        Amount = amount;
    }
}

public interface IDamageHandler
{
    IDamageHandler SetNext(IDamageHandler handler);
    void Handle(Damage request);
}

public abstract class DamageHandler : IDamageHandler
{
    protected IDamageHandler? _nextHandler;
    public IDamageHandler SetNext(IDamageHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public abstract void Handle(Damage request);
}

public class MagicShieldHandler : DamageHandler
{
    private int ShieldStrength { get; set; }
    public MagicShieldHandler() => ShieldStrength = new Random().Next(0, 50);

    public override void Handle(Damage request)
    {
        if (request.Type == "Magic")
        {
            if (ShieldStrength >= request.Amount)
            {
                Console.WriteLine($"Magic shield absorbed the damage: {request.Amount}");
                ShieldStrength -= request.Amount;
                return;
            }
            else
            {
                Console.WriteLine($"Magic shield absorbed {ShieldStrength} damage, remaining damage: {request.Amount - ShieldStrength}");
                ShieldStrength = 0;
            }
        }
        
        if(_nextHandler != null)
        {
            Console.WriteLine("Passing to next handler...");
            _nextHandler.Handle(request);
        }
    }
}

public class PhysicalShieldHandler : DamageHandler
{
    private int ShieldStrength { get; set; }
    public PhysicalShieldHandler() => ShieldStrength = new Random().Next(0, 100);

    public override void Handle(Damage request)
    {
        if (request.Type == "Physical")
        {
            if (ShieldStrength >= request.Amount)
            {
                Console.WriteLine($"Physical shield absorbed the damage: {request.Amount}");
                ShieldStrength -= request.Amount;
                return;
            }
            else
            {
                Console.WriteLine($"Physical shield absorbed {ShieldStrength} damage, remaining damage: {request.Amount - ShieldStrength}");
                ShieldStrength = 0;
            }
        }
        
        if (_nextHandler != null)
        {
            Console.WriteLine("Passing to next handler...");
            _nextHandler.Handle(request);
        }
    }
}

public class HealthDamageHandler : DamageHandler
{
    private int Health { get; set; }
    public HealthDamageHandler() => Health = new Random().Next(50, 100);

    public override void Handle(Damage request)
    {
        if (request.Type == "Health")
        {
            if(Health >= request.Amount)
            {
                Health -= request.Amount;
                Console.WriteLine($"Health reduced by {request.Amount}, remaining health: {Health}");
            }
            else
            {
                Console.WriteLine($"Health reduced by {request.Amount}, remaining health: 0");
                Health = 0;
            }
        }
        
        if (_nextHandler != null)
        {
            Console.WriteLine("Passing to next handler...");
            _nextHandler.Handle(request);
        }
    }
}

public class Hero
{
    private IDamageHandler? _damageHandler = null;
    public Hero(List<IDamageHandler> damageHandler)
    {
        // chain the handlers
        for (int i = 0; i < damageHandler.Count - 1; i++)
        {
            damageHandler[i].SetNext(damageHandler[i + 1]);
        }
    }

    public void TakeDamage(Damage damage)
    {
        _damageHandler?.Handle(damage);
    }
}

