using NUnit.Framework;
using UnityEngine;

public abstract class Character
{
    protected readonly string _name;
    protected readonly int _maxHP;
    protected int _currHP;
    protected int _speed;
    protected readonly int _initiative;
    protected readonly bool _isPlayable;
    protected Card[] _cards;
    public Card[] getCards() {  return _cards; }

    public abstract void Attack(int pos);
    public string getName() { return _name; }
    public int getMove() { return _speed; }
    public int getInitiative() { return _initiative; }
    public bool getIsPlayable() { return _isPlayable; }
    protected abstract void generateCards();
    protected Character(string name, int maxHP, int speed, int initiative ,bool isPlayable)
    {
        this._name = name;
        this._maxHP = _currHP = maxHP;
        this._speed = speed;
        this._initiative = initiative;
        this._isPlayable = isPlayable;
    }
}
public class MeleeEnemy : Character
{
    public MeleeEnemy(string name, int maxHP, int speed, int initiative) : base(name, maxHP, speed, initiative, false)
    {
        
    }

    public override void Attack(int pos)
    {
        //atak u¿ywaj¹c kart
    }

    protected override void generateCards()
    {
        //krupier
    }
}

public class PlayerCharater : Character
{
    public PlayerCharater(string name, int maxHP, int speed, int initiative) : base(name, maxHP, speed, initiative, true)
    {
    }

    public override void Attack(int pos)
    {
        throw new System.NotImplementedException();
    }

    protected override void generateCards()
    {
        throw new System.NotImplementedException();
    }
}

