using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test01 : MonoBehaviour {



    public Transform[] spawnPointHand;

    public List<Card> DeckP1 = new List<Card>();
    public GameObject handcard;

    public bool[] spawnPointHand1 = new bool[18];

    private void Start()
    {
        DrawP1(18);
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
                        //handP1 = i;
                        display.CardSetup(DeckP1[c], 1);
                        DeckP1.RemoveAt(c);
                        //Debug.Log(DeckP1.Count);


                        //DeckCountP1.text = DeckP1.Count.ToString();
                        break;
                    }
                }
            }
    }

}
