using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CretureDisplay : MonoBehaviour
{
    //[HideInInspector]
    public static CretureDisplay instance;

    private void Awake()
    {
        instance = this;
        
    }




    public Card card;

    public Text descriptionText;
    public Text manaCostText;
    public Text attackValueText;
    public Text healthValueText;


    public Text nameText;

    public Image cardImage;

    public bool ischarge;
    public bool isCreature;
    public int intCretureMana;
    public int intCretureAttack;
    public int intCretureHealth;

    public int positionInBroad;

    public void CretureSetup(Card thisCard)
    {
        // ตำแหน่งบนมือ
        //positionInHead = Temp.instance.handP1;
        //Debug.Log(positionInBroad);

        card = thisCard;
        attackValueText.text = card.attack.ToString();
        healthValueText.text = card.health.ToString();
        nameText.text = card.cardName;

        isCreature = card.isCreature;
        ischarge = card.charge;
        // int
        intCretureMana = card.manaCost;
        intCretureAttack = card.attack;
        intCretureHealth = card.health;
        //descriptionText.text = card.description;
        //manaCostText.text = card.manaCost.ToString();

        cardImage.sprite = card.art;
    }

    public Text healthUpdate;
    public GameObject hUpdate;


    public void ShowDamage(string Message, float Duration)
    {
        StartCoroutine(sDamage(Message, Duration));
    }

    IEnumerator sDamage(string Message, float Duration)
    {
        //Debug.Log("Showing some message. Duration: " + Duration);
        healthUpdate.text = Message;
        hUpdate.SetActive(true);

        yield return new WaitForSeconds(Duration);

        hUpdate.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ShowDamage("+3", 1.5f);
    }
}
