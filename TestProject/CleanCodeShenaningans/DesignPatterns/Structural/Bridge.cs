namespace CleanCodeShenaningans.DesignPatterns.Structural;

// https://refactoring.guru/design-patterns/bridge

public interface Weapon
{
    bool IsReady();
    void Attack();
    void Reset();
}

public class Sword : Weapon
{
    public DateTimeOffset? LastAttackTime { get; set; }
    public int CooldownTimeInSec { get; set; } = 2;

    public void Attack()
    {
        Console.WriteLine("Swinging a sword!");
        LastAttackTime = DateTimeOffset.UtcNow;
    }

    public bool IsReady()
    {
        return LastAttackTime == null || LastAttackTime - DateTimeOffset.UtcNow > TimeSpan.FromSeconds(CooldownTimeInSec);
    }

    public void Reset()
    {
        LastAttackTime = null;
    }
}

public class Bow : Weapon
{
    int ReloadTime { get; set; } = 5;
    DateTimeOffset? LastShotTime { get; set; }

    public void Attack()
    {
        Console.WriteLine("Shooting an arrow!");
        LastShotTime = DateTimeOffset.UtcNow;
    }

    public bool IsReady()
    {
        return LastShotTime == null || LastShotTime - DateTimeOffset.UtcNow > TimeSpan.FromSeconds(ReloadTime);
    }

    public void Reset()
    {
        LastShotTime = null;
    }
}

public class Character
{
    protected Weapon _weapon;
    public Character(Weapon weapon)
    {
        _weapon = weapon;
    }
    public void Attack()
    {
        if (_weapon.IsReady())
        {
            _weapon.Attack();
        }
        else
        {
            Console.WriteLine("Weapon is not ready yet!");
        }
    }
}

public class SkillfullCharacter : Character
{
    public SkillfullCharacter(Weapon weapon) : base(weapon)
    {
    }

    public void ResetWeaponSkill()
    {
        Console.WriteLine("Skillful character is resetting their weapon skill!");
        base._weapon.Reset();
    }
}

