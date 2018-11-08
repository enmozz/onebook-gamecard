using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp : MonoBehaviour
{

    public static Temp instance;

    private void Awake()
    {
        instance = this;
    }
    public Text DeckCountP1;
    public Text DeckCountP2;

    public Card coin;
    [Header("P1")]
    public List<Card> DeckP1 = new List<Card>();
    public int handP1;
    //public int boardP1;
    public Transform[] spawnPoint;
    public GameObject creature;
    public Transform[] spawnPointHand;
    public GameObject handcard;
    [Header("PositionP1")]
    public bool[] spawnPointBoard1 = new bool[5];
    public bool[] spawnPointHand1 = new bool[9];

    [Header("P1Battle")]
    public Button attackP1Button;
    public int Player1HP;
    public int P1creature0ATK;
    public int P1creature0HP;

    [Header("P2")]
    public List<Card> DeckP2 = new List<Card>();
    public int handP2;
    //public int boardP2;
    public Transform[] spawnPointP2;
    public Transform[] spawnPointHandP2;
    public GameObject creatureP2;
    public GameObject handcardP2;
    [Header("PositionP2")]
    public bool[] spawnPointBoard2 = new bool[5];
    public bool[] spawnPointHand2 = new bool[9];

    [Header("P2Battle")]
    public Button attackP2Button;
    public int P2ayer1HP;
    public int P2creature0ATK;
    public int P2creature0HP;

    public int countAtkHero;



    public void P1attack()
    {
        for (int i = 0; i < spawnPointBoard1.Length; i++)
        {
            if (spawnPointBoard1[i] == true)
            {
                // ฝ่ายP1 
                GameObject p1C0Atk = GameObject.Find("P1Creatre " + i);
                CretureDisplay a = p1C0Atk.GetComponent<CretureDisplay>();

                if (a.ischarge)
                {
                    int atkc0 = Convert.ToInt32(a.attackValueText.text);
                    int hpc0 = Convert.ToInt32(a.healthValueText.text);

                    
                    
                    //ค้นหาเป้าหมาบบนboard
                    if (spawnPointBoard2[i] == true)
                    {
                        GameObject p2C0Def = GameObject.Find("P2Creatre " + i);
                        CretureDisplay a2 = p2C0Def.GetComponent<CretureDisplay>();
                        int P2atkc0 = Convert.ToInt32(a2.attackValueText.text);
                        int P2hpc0 = Convert.ToInt32(a2.healthValueText.text);

                        Debug.Log(a.nameText.text + " attack = " + atkc0 + " hp= " + hpc0 + " atk " + a2.nameText.text + " attack = " + P2atkc0 + " hp= " + P2hpc0);
                        // ฝ่ายโจมตี P1c0 ตี P2c0 
                        P2hpc0 = P2hpc0 - atkc0;

                        // โช damage
                        string z = "-" + P2atkc0.ToString(); ;
                        a.ShowDamage(z, 1.5f);


                        a2.healthValueText.text = P2hpc0.ToString();

                        if (P2hpc0 <= 0)
                        {
                            Destroy(p2C0Def, 2);
                            spawnPointBoard2[i] = false;
                        }

                        // ฝ่ายป้องกัน P2c0 ตี P1c0 
                        hpc0 = hpc0 - P2atkc0;

                        // โช damage
                        string zz = "-" + atkc0.ToString(); ;
                        a2.ShowDamage(zz, 1.5f);

                        a.healthValueText.text = hpc0.ToString();

                        if (hpc0 <= 0)
                        {
                            Destroy(p1C0Atk, 2);
                            spawnPointBoard1[i] = false;
                        }

                    }
                    else //ไม่เจอCreture ตี hero
                    {

                        GameObject p2HeroDef = GameObject.Find("Player2");
                        HeroDisplay a2 = p2HeroDef.GetComponent<HeroDisplay>();

                        int P2hpc0 = Convert.ToInt32(a2.healthText.text);
                        Debug.Log(a.nameText.text + " attack = " + atkc0 + " hp= " + hpc0 + " atk " + a2.gameObject.name + " hp= " + P2hpc0);

                        P2hpc0 = P2hpc0 - atkc0;
                        countAtkHero = countAtkHero + atkc0;

                        // โช damage
                        string zz = "-" + countAtkHero.ToString(); ;
                        a2.hDamage(zz, 1.5f);

                        a2.healthText.text = P2hpc0.ToString();

                        if (P2hpc0 <= 0)
                        {
                            GameLevelManager.instance.endGame(2f, 1);
                        }
                    }
                }
                // set ว่าตีไปแล้ว

                a.ischarge = false;
            }
           

        }
        countAtkHero = 0;
        attackP1Button.gameObject.SetActive(false);
    }


    public void P2attack()
    {
        for (int i = 0; i < spawnPointBoard2.Length; i++)
        {
            if (spawnPointBoard2[i] == true)
            {
                // ฝ่ายP2
                GameObject p1C0Atk = GameObject.Find("P2Creatre " + i);
                CretureDisplay a = p1C0Atk.GetComponent<CretureDisplay>();

                if (a.ischarge)
                {
                    int atkc0 = Convert.ToInt32(a.attackValueText.text);
                    int hpc0 = Convert.ToInt32(a.healthValueText.text);

                    //ค้นหาเป้าหมาบบนboard
                    if (spawnPointBoard1[i] == true)
                    {
                        GameObject p2C0Def = GameObject.Find("P1Creatre " + i);
                        CretureDisplay a2 = p2C0Def.GetComponent<CretureDisplay>();
                        int P2atkc0 = Convert.ToInt32(a2.attackValueText.text);
                        int P2hpc0 = Convert.ToInt32(a2.healthValueText.text);

                        Debug.Log(a.nameText.text + " attack = " + atkc0 + " hp= " + hpc0 + " atk " + a2.nameText.text + " attack = " + P2atkc0 + " hp= " + P2hpc0);

                        // ฝ่ายโจมตี P2c0 ตี P1c0
                        P2hpc0 = P2hpc0 - atkc0;



                        // โช damage
                        string z = "-" + P2atkc0.ToString(); ;
                        a.ShowDamage(z, 1.5f);

                        a2.healthValueText.text = P2hpc0.ToString();
                        if (P2hpc0 <= 0)
                        {
                            Destroy(p2C0Def, 2);
                            spawnPointBoard1[i] = false;
                        }

                        // ฝ่ายป้องกัน P1c0 ตี P2c0 
                        hpc0 = hpc0 - P2atkc0;

                        // โช damage
                        string zz = "-" + atkc0.ToString(); ;
                        a2.ShowDamage(zz, 1.5f);

                        a.healthValueText.text = hpc0.ToString();

                        if (hpc0 <= 0)
                        {
                            Destroy(p1C0Atk, 2);
                            spawnPointBoard2[i] = false;
                        }
                    }
                    else //ไม่เจอCreture ตี hero
                    {
                        GameObject p2HeroDef = GameObject.Find("Player1");
                        HeroDisplay a2 = p2HeroDef.GetComponent<HeroDisplay>();

                        int P2hpc0 = Convert.ToInt32(a2.healthText.text);
                        Debug.Log(a.nameText.text + " attack = " + atkc0 + " hp= " + hpc0 + " atk " + a2.gameObject.name + " hp= " + P2hpc0);

                        P2hpc0 = P2hpc0 - atkc0;

                        countAtkHero = countAtkHero + atkc0;

                        // โช damage
                        string zz = "-" + countAtkHero.ToString(); ;

                        a2.hDamage(zz, 1.5f);

                        a2.healthText.text = P2hpc0.ToString();
                        if (P2hpc0 <= 0)
                        {
                            // endgame
                            GameLevelManager.instance.endGame(2f, 2);
                        }
                    }
                }
                // set ว่าตีไปแล้ว

                a.ischarge = false;
            }
        }
        countAtkHero = 0;
        attackP2Button.gameObject.SetActive(false);
    }



    //ลงการ์ดจากมือลงบอร์ด p1
    public void spawnCardP1(Card thiscard)
    {
        for (int i = 0; i < spawnPointBoard1.Length; i++)
        {
            if (spawnPointBoard1[i] == false)
            {
                GameObject go = Instantiate(creature, spawnPoint[i].position, Quaternion.identity);
                CretureDisplay cDisplay = go.GetComponent<CretureDisplay>();
                //ตั้งชื่อ obj
                go.name = "P1Creatre " + i;

                //Debug.Log("befor" + spawnPointBroad1[boardP1]);
                spawnPointBoard1[i] = true;

                cDisplay.CretureSetup(thiscard);
                //boardP1 = i;

                break;
            }
        }
    }

    //ลงการ์ดจากมือลงบอร์ด p2
    public void spawnCardP2(Card thiscard)
    {
        for (int i = 0; i < spawnPointBoard2.Length; i++)
        {
            if (spawnPointBoard2[i] == false)
            {
                GameObject go = Instantiate(creatureP2, spawnPointP2[i].position, Quaternion.identity);
                CretureDisplay cDisplay = go.GetComponent<CretureDisplay>();
                //ตั้งชื่อ obj
                go.name = "P2Creatre " + i;

                //Debug.Log("befor" + spawnPointBroad1[boardP1]);
                spawnPointBoard2[i] = true;

                cDisplay.CretureSetup(thiscard);
                //boardP2 = i;

                break;
            }
        }
    }

    public void addCoin(int p)
    {
        if (p == 1)
        {
            // หา position ที่ว่างแล้วลง
            for (int i = 0; i < spawnPointHand1.Length; i++)
            {
                if (spawnPointHand1[i] == false)
                {
                    GameObject go = Instantiate(handcard, spawnPointHand[i].position, Quaternion.identity);
                    CardDisplay display = go.GetComponent<CardDisplay>();
                    go.name = "P1Card " + i;

                    spawnPointHand1[i] = true;
                    handP1 = i;
                    display.CardSetup(coin, 1);
                    break;
                }
            }
        }
        else if(p == 2)
        {
            for (int i = 0; i < spawnPointHand2.Length; i++)
            {
                if (spawnPointHand2[i] == false)
                {
                    GameObject go2 = Instantiate(handcardP2, spawnPointHandP2[i].position, Quaternion.identity);
                    CardDisplay display = go2.GetComponent<CardDisplay>();
                    go2.name = "P2Card " + i;

                    spawnPointHand2[i] = true;
                    handP2 = i;
                    display.CardSetup(coin, 2);
                    break;
                }
            }
        }
    }




    private void Start()
    {

        DrawP2(4);
        DrawP1(4);
    }

    public void DrawP1(int n)
    {
        // ถ้าไม่มีการ์ดก็ไม่จั่ว
        if (DeckP1.Count > 0)
            for (int y = 0; y < n; y++)
        {
            int c = UnityEngine.Random.Range(0, DeckP1.Count - 1);
            // หา position ที่ว่างแล้วลง
            for (int i = 0; i < spawnPointHand1.Length; i++)
            {
                if (spawnPointHand1[i] == false)
                {
                    GameObject go = Instantiate(handcard, spawnPointHand[i].position, Quaternion.identity);
                    CardDisplay display = go.GetComponent<CardDisplay>();
                    go.name = "P1Card " + i;

                    spawnPointHand1[i] = true;
                    handP1 = i;
                    display.CardSetup(DeckP1[c], 1);
                    DeckP1.RemoveAt(c);
                    //Debug.Log(DeckP1.Count);


                    DeckCountP1.text = DeckP1.Count.ToString();
                    break;
                }
            } 

        }
        

        if (DeckP1.Count <= 0)
        {
            // endgame card 0
            GameLevelManager.instance.endGame(3f, 2);
        }
    }

    public void DrawP2(int n)
    {
        // ถ้าไม่มีการ์ดก็ไม่จั่ว
        if (DeckP2.Count > 0)
            for (int y = 0; y < n; y++)
        {
            int c = UnityEngine.Random.Range(0, DeckP2.Count - 1);

            // หา position ที่ว่างแล้วลง
            for (int i = 0; i < spawnPointHand2.Length; i++)
            {
                if (spawnPointHand2[i] == false)
                {
                    GameObject go2 = Instantiate(handcardP2, spawnPointHandP2[i].position, Quaternion.identity);
                    CardDisplay display = go2.GetComponent<CardDisplay>();
                    go2.name = "P2Card " + i;

                    spawnPointHand2[i] = true;
                    handP2 = i;
                    display.CardSetup(DeckP2[c], 2);
                    DeckP2.RemoveAt(c);

                    DeckCountP2.text = DeckP2.Count.ToString();
                    break;
                }
            }
        }
        if (DeckP2.Count <= 0)
        {
            // endgame card 0
            GameLevelManager.instance.endGame(3f, 1);
        }
    }


}
