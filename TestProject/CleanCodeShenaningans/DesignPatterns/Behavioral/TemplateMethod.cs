using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeShenaningans.DesignPatterns.Behavioral;

// Example from https://refactoring.guru/design-patterns/template-method

public abstract class ArtificialInteligenceTemplateMethod
{
    public string Move { get; set; }

    // Template method
    public void MakeMove()
    {
        AnalyzeEnvironment();
        DecideNextMove();
        ExecuteMove();
    }
    protected abstract void AnalyzeEnvironment();
    protected abstract void DecideNextMove();
    protected void ExecuteMove()
    {
        Console.WriteLine($"Executing move: {Move}");
    }
}

public class AggressiveAI : ArtificialInteligenceTemplateMethod
{
    protected override void AnalyzeEnvironment()
    {
        Console.WriteLine("Finding something to attack...");
    }
    protected override void DecideNextMove()
    {
        Move = "Attack!";
    }
}


public class PassiveAI : ArtificialInteligenceTemplateMethod
{
    protected override void AnalyzeEnvironment()
    {
        Console.WriteLine("... checking for threats ... ");
    }
    protected override void DecideNextMove()
    {
        Random random = new Random();
        if (random.Next(2) == 0)
            Move = "Do nothing!";
        else Move = "Run away!";
    }
}
