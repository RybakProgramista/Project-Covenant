using UnityEngine;
using UnityEngine.UI;

public abstract class Card
{
    private Image cardImage;
    private string cardName;
    private string cardDescription;
    public abstract void Use();
}
public abstract class Item : Card
{

}

public abstract class Spell : Card
{

}