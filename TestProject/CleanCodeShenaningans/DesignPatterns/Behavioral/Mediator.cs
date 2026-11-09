using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeShenaningans.DesignPatterns.Behavioral;


// The Mediator interface declares a method used by components to notify the
// mediator about various events. The Mediator may react to these events and
// pass the execution to other components.
public interface IMediator
{
    void Interact(object sender, string ev);
}

// Concrete Mediators implement cooperative behavior by coordinating several
// components.
class DungeonMediator : IMediator
{
    private Player Player;

    private Monster Monster;

    public DungeonMediator(Player component1, Monster component2)
    {
        this.Player = component1;
        this.Player.SetMediator(this);
        this.Monster = component2;
        this.Monster.SetMediator(this);
    }

    public void Interact(object sender, string ev)
    {
        if (ev == "Find treasure")
        {
            Console.WriteLine("Mediator reacts on Player Finding treasure and triggers following operations:");
            this.Monster.TrackPlayer();
        }
        if (ev == "Finds Player")
        {
            Console.WriteLine("Mediator reacts on Player Finding treasure and triggers following operations:");
            this.Monster.AttackPlayer();
        }
    }
}

// The Base Component provides the basic functionality of storing a
// mediator's instance inside component objects.
class BaseComponent
{
    protected IMediator _mediator;

    public BaseComponent(IMediator mediator = null)
    {
        this._mediator = mediator;
    }

    public void SetMediator(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public void Notify(string ev)
    {
        _mediator.Interact(this, ev);
    }
}

// Concrete Components implement various functionality. They don't depend on
// other components. They also don't depend on any concrete mediator
// classes.
class Player : BaseComponent
{
    public void TriggerFight()
    {
        Console.WriteLine("Player Find Monster.");

        Notify("Find Monster");
    }

    public void TriggerTrap()
    {
        Console.WriteLine("Player Triggers trap.");

        Notify("Triggers trap");
    }

    public void FindTreasure()
    {
        Console.WriteLine("Player Triggers trap.");

        Notify("Triggers trap");
    }
}

class Monster : BaseComponent
{
    public void FindPlayer()
    {
        Console.WriteLine("Monster  finds Character.");

        Notify("Finds Player");
    }

    public void AttackPlayer()
    {
        Console.WriteLine("Monster Attack player");

        Notify("Attack player");
    }
    public void TrackPlayer()
    {
        Console.WriteLine("Monster Track Player");

        Notify("Track player");
    }
}
