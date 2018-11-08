using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class useCard : MonoBehaviour
{
    public Text nameText;
    public Text hpText;
    public Text attackText;
    public Text manaText;
    public Image cImage;

    public string cardName;
    public int hp1;
    public int atk1;
    public int mana;

    public Card c;

    // คลิกการ์ดในมือ
    private void OnMouseDown()
    {
        CardDisplay display = GetComponent<CardDisplay>();

        //Debug.Log("manaP1 = " + GameLevelManager.instance.activeManaCrystals + "manaCard = " + display.intCardMana);

        if (GameLevelManager.instance.activeManaCrystals >= display.intCardMana)
        {
            //ถ้าเป็น การ์ดมอนสเตอร์

            if (display.isCreature)
            {
                Debug.Log("P1Drop " + nameText.text + " attack = " + attackText.text + " hp= " + hpText.text + "mana = " + manaText.text);
                c = display.card;
                //Debug.Log(c);
                Destroy(gameObject, 1);

                //Temp _Temp = GetComponent<Temp>();
                //ลงการ์ด
                Temp.instance.spawnCardP1(c);

                // ปิด position บนมือ
                Temp.instance.spawnPointHand1[display.positionInHand] = false;

                // ลบมานาที่ใช้ไป
                useMana(display.intCardMana);
            }
            //magic
            else
            {
                Debug.Log("P1Use " + nameText.text );
                Destroy(gameObject, 1);
                Temp.instance.spawnPointHand1[display.positionInHand] = false;

                // ลบมานาที่ใช้ไป
                useMana(display.intCardMana);
            }
            if (display.isdealDamage)
                dealDamage(display.positionInHand);
            if (display.ishealHero)
                healHero(display.positionInHand);
            if (display.isdrawCard)
                drawcard(display.positionInHand);
            if (display.isdealAllDamage)
                dealallDamage(display.positionInHand);
            if (display.ishealallboard)
                healAllFriendly(display.positionInHand);
            if (display.isAddmana)
                addMana(display.positionInHand);
        }

    }

    public void addMana(int p)
    {
        GameObject p1C0Atk = GameObject.Find("P1Card " + p);
        CardDisplay a = p1C0Atk.GetComponent<CardDisplay>();

        GameLevelManager.instance.activeManaCrystals = GameLevelManager.instance.activeManaCrystals + a.Amount;
        GameLevelManager.instance.manaText.text = GameLevelManager.instance.activeManaCrystals.ToString();
    }

    public void healAllFriendly(int p)
    {
        for (int i = 0; i < Temp.instance.spawnPointBoard1.Length; i++)
        {
            if (Temp.instance.spawnPointBoard1[i] == true)
            {
                GameObject p1C0Atk = GameObject.Find("P1Card " + p);
                CardDisplay a = p1C0Atk.GetComponent<CardDisplay>();

                //เป้าหมายที่ฮิว
                GameObject p2C0Def = GameObject.Find("P1Creatre " + i);
                CretureDisplay a2 = p2C0Def.GetComponent<CretureDisplay>();
                int P2hpc0 = Convert.ToInt32(a2.healthValueText.text);

                P2hpc0 = P2hpc0 + a.Amount;

                // โช ผล
                string z = "+" + a.Amount.ToString(); ;
                a2.ShowDamage(z, 1.5f);

                a2.healthValueText.text = P2hpc0.ToString();
            }
        }
    }

    public void drawcard(int p)
    {
        GameObject p1C0Atk = GameObject.Find("P1Card " + p);
        CardDisplay a = p1C0Atk.GetComponent<CardDisplay>();
        Temp.instance.DrawP1(a.Amount);
    }

    public void dealDamage(int p)
    {
        GameObject p2HeroDef = GameObject.Find("Player2");
        HeroDisplay a2 = p2HeroDef.GetComponent<HeroDisplay>();

        int P2hpc0 = Convert.ToInt32(a2.healthText.text);

        GameObject p1C0Atk = GameObject.Find("P1Card " + p);
        CardDisplay a = p1C0Atk.GetComponent<CardDisplay>();
        int magic = a.Amount;

        P2hpc0 = P2hpc0 - magic;

        // โช ผล
        string z = "-" + a.Amount.ToString(); ;
        a2.hDamage(z, 1.5f);

        a2.healthText.text = P2hpc0.ToString();

        if (P2hpc0 <= 0)
        {
            GameLevelManager.instance.endGame(2f, 1);
        }
    }

    public void dealallDamage(int p)
    {
        for (int i = 0; i < Temp.instance.spawnPointBoard2.Length; i++)
        {
            if (Temp.instance.spawnPointBoard2[i] == true)
            {
                GameObject p1C0Atk = GameObject.Find("P1Card " + p);
                CardDisplay a = p1C0Atk.GetComponent<CardDisplay>();

                //ฝ่ายโดนเวทโจมตี
                GameObject p2C0Def = GameObject.Find("P2Creatre " + i);
                CretureDisplay a2 = p2C0Def.GetComponent<CretureDisplay>();
                int P2hpc0 = Convert.ToInt32(a2.healthValueText.text);

                //Debug.Log(a.nameText.text + " attack = " + atkc0 + " hp= " + hpc0 + " atk " + a2.nameText.text + " attack = " + P2atkc0 + " hp= " + P2hpc0);

                P2hpc0 = P2hpc0 - a.Amount;

                // โช ผล
                string z = "-" + a.Amount.ToString(); ;
                a2.ShowDamage(z, 1.5f);

                a2.healthValueText.text = P2hpc0.ToString();

                if (P2hpc0 <= 0)
                {
                    Destroy(p2C0Def, 2);
                    Temp.instance.spawnPointBoard2[i] = false;
                }
            }
        }
    }

    public void healHero(int p)
    {
        GameObject p2HeroDef = GameObject.Find("Player1");
        HeroDisplay a2 = p2HeroDef.GetComponent<HeroDisplay>();

        int P2hpc0 = Convert.ToInt32(a2.healthText.text);

        GameObject p1C0Atk = GameObject.Find("P1Card " + p);
        CardDisplay a = p1C0Atk.GetComponent<CardDisplay>();
        int magic = a.Amount;

        P2hpc0 = P2hpc0 + magic;

        // โช ผล
        string z = "+" + a.Amount.ToString(); ;
        a2.hDamage(z, 1.5f);

        a2.healthText.text = P2hpc0.ToString();
    }

    public void useMana(int m)
    {
        GameLevelManager.instance.activeManaCrystals = GameLevelManager.instance.activeManaCrystals - m;
        GameLevelManager.instance.manaText.text = GameLevelManager.instance.activeManaCrystals.ToString();
    }

}


