using UnityEngine;
using UnityEngine.U2D;

public abstract class Character
{
    protected readonly string _name;
    protected readonly int _maxHP;
    protected int _currHP;
    protected int _speed;
    protected readonly int _initiative;
    protected readonly bool _isPlayable;
    protected Card[] _cards;
    protected Sprite _sprite;

    public void setSprite(Sprite sprite) { _sprite = sprite; }
    public Sprite getSprite() { return _sprite; }
    public Card[] getCards() {  return _cards; }

    public abstract void Attack(int pos);
    public string getName() { return _name; }
    public int getMove() { return _speed; }
    public int getInitiative() { return _initiative; }
    public bool getIsPlayable() { return _isPlayable; }
    protected abstract void generateCards();
    protected Character(string name, int maxHP, int speed, int initiative ,bool isPlayable, Sprite sprite)
    {
        _name = name;
        _maxHP = _currHP = maxHP;
        _speed = speed;
        _initiative = initiative;
        _isPlayable = isPlayable;
        _sprite = sprite;
    }
}
public class MeleeEnemy : Character
{
    public MeleeEnemy(string name, int maxHP, int speed, int initiative, Sprite sprite) : base(name, maxHP, speed, initiative, false, sprite)
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
    public PlayerCharater(string name, int maxHP, int speed, int initiative, Sprite sprite) : base(name, maxHP, speed, initiative, true, sprite)
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

