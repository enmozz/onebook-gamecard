using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum Targets
//{
//    NONE,
//    ALL_CREATURES,
//    ENEMY_CREATURES,
//    FRIENDLY_CREATURES,
//    ENEMY_HERO,
//    FRIENDLY_HERO,
//    ALL_CHARACTERS,
//    ENEMY_CHARACTERS,
//    FRIENDLY_CHARACTERS

//}

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

public class Card : ScriptableObject, IComparable<Card>
{
    [Header("Standard Info")]

    public string cardName;
    [TextArea(2, 3)]
    public string description;

    public Sprite art;
    public int manaCost;
    //public Targets targets;

    [Header("Creature Info")]
    [Range(1, 30)]
    public int attack;
    [Range(1, 30)]
    public int health;

    public bool charge;

    public bool isCreature;

    [Header("Skills Info")]
    public bool healHero;
    public bool healallboard;
    public bool dealDamageHero;
    public bool dealAllBoard;
    public bool drawCard;
    public bool addManaThisTurn;

    public int SpecialSpellAmount;

    
    public int CompareTo(Card other)
    {
        return this.cardName.CompareTo(other.cardName);
    }

    public static implicit operator List<object>(Card v)
    {
        throw new NotImplementedException();
    }
}
