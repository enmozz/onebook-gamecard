using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    //[HideInInspector]

    public Card card;

    public Text descriptionText;
    public Text manaCostText;
    public Text attackValueText;
    public Text healthValueText;
    public Text nameText;

    public Image cardImage;

    public Image attackImage;
    public Image healthImage;

    public bool isCreature;
    public int intCardMana;
    public int intCardAttack;
    public int intCardHealth;

    public bool ischarge;
    public bool ishealHero;
    public bool ishealallboard;
    public bool isdealDamage;
    public bool isdealAllDamage;
    public bool isdrawCard;
    public bool isAddmana;
    public int Amount;

    //ตำแหน่งบนมือ
    public int positionInHand;

    public object manaText { get; internal set; }

    public void CardSetup(Card thisCard, int P)
    {
        if (P == 1)
        {
            // ตำแหน่งบนมือ
            positionInHand = Temp.instance.handP1;
            //Debug.Log(positionInHand);
        }
        else if (P == 2)
        {
            positionInHand = Temp.instance.handP2;
        }


        card = thisCard;

        nameText.text = card.cardName;
        descriptionText.text = card.description;
        manaCostText.text = card.manaCost.ToString();

        isCreature = card.isCreature;
        // int
        intCardMana = card.manaCost;
        intCardAttack = card.attack;
        intCardHealth = card.health;
        // skill
        ischarge = card.charge;
        ishealHero = card.healHero;
        ishealallboard = card.healallboard;
        isdealDamage = card.dealDamageHero;
        isdealAllDamage = card.dealAllBoard;
        isdrawCard = card.drawCard;
        isAddmana = card.addManaThisTurn;
        Amount = card.SpecialSpellAmount;




        if (card.isCreature)
        {
            attackValueText.text = card.attack.ToString();
            healthValueText.text = card.health.ToString();
        }
        else
        {
            attackImage.gameObject.SetActive(false);
            healthImage.gameObject.SetActive(false);
        }

        cardImage.sprite = card.art;
    }
}
