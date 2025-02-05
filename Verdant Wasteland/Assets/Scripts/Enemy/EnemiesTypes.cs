using UnityEngine;

public abstract class Character
{
    protected readonly string name;
    protected readonly int maxHP;
    protected int currHP;
    protected readonly int maxMana;
    protected int currMana;
    protected int speed;
    protected int pos;
    protected readonly int initiative;
    protected readonly bool isPlayable;
    protected Card[] cards;
    public Card[] getCards() {  return cards; }

    public abstract void Attack(int pos);
    public abstract void Move(int pos);
    public abstract void Setup();
    protected abstract void generateCards();
    protected Character(string name, int maxHP, int maxMana, int speed, int initiative ,bool isPlayable)
    {
        this.name = name;
        this.maxHP = currHP = maxHP;
        this.maxMana = currMana = maxMana;
        this.speed = speed;
        this.initiative = initiative;
        this.isPlayable = isPlayable;
    }
}
public class MeleeEnemy : Character
{
    protected MeleeEnemy(string name, int maxHP, int maxMana, int speed, int initiative) : base(name, maxHP, maxMana, speed, initiative, false)
    {
        
    }

    public override void Attack(int pos)
    {
        //atak u¿ywaj¹c kart
    }

    public override void Move(int pos)
    {
        //zmiana pozycji
    }

    public override void Setup()
    {
        //setup walki
    }

    protected override void generateCards()
    {
        //krupier
    }
}

