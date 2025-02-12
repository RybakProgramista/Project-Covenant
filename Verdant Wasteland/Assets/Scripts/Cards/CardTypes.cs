using UnityEngine;
using UnityEngine.UI;

public abstract class Card
{
    protected Image _cardImage;
    protected string _cardName;
    protected string _cardDescription;
    protected int _maxNumberOfUses;
    protected int _currNumberOfUses;
    protected bool isInfinite;
    public abstract void Use();
}
public class Move : Card
{
    public override void Use()
    {
        
    }
}