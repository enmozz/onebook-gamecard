using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroClass
{
    CLERIC,
    WARRIOR
}

[CreateAssetMenu(fileName ="New Hero", menuName ="Players/Hero")]
public class Hero : ScriptableObject
{ 

    public HeroClass heroClass;

    public Sprite avatar;

    public int health;
    //public int attack;
    //public int armor;

    //public HeroPower power;

}
