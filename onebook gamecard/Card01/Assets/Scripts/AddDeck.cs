using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDeck : MonoBehaviour {

    public List<Card> addDeckP1 = new List<Card>();

    public List<Card> addDeckP2 = new List<Card>();


    public Card archerP1;
    public Card fireblastP1;
    public Card footmanP1;
    public Card healerP1;
    public Card trickP1;
    public Card counterP1;
    public Card hunterP1;
    public Card iceBallP1;
    public Card ironKnightP1;
    public Card knightP1;
    public Card woftP1;
    public Card atomP1;
    public Card barrierP1;
    public Card drawP1;
    public Card hellP1;
    public Card yetiP1;
    public Card fireballP1;
    public Card footmansP1;
    public Card destryP1;
    public Card faerieDragonP1;
    public Card flameLanceP1;
    public Card fireElementtalP1;
    public Card gaintP1;
    public Card meteorP1;
    public Card blockholdP1;
    public Card layonhandsP1;
    public Card pyroblastP1;
    public Card krakenP1;
    public Card dragonlordP1;
    public Card ultimateP1;

    void Start() {

        //Debug.Log("save deckp1 =" + PlayerPrefs.GetFloat("deckp1"));
        //Debug.Log("save card1 =" + PlayerPrefs.GetFloat("P1card1"));
        //Debug.Log("save card4 =" + PlayerPrefs.GetFloat("P1card4"));
        //Debug.Log("save card10 =" + PlayerPrefs.GetFloat("P1card10"));
        //Debug.Log("save card20 =" + PlayerPrefs.GetFloat("P1card20"));

        //P1
        for (int i = 1; i < 31; i++)
        {
            string key = "P1card" + i;
            if (PlayerPrefs.HasKey(key))
                for (int y = 0; y < PlayerPrefs.GetFloat(key); y++)
                {
                    if (i == 1) addDeckP1.Add(archerP1);
                    else if (i == 2) addDeckP1.Add(fireblastP1);
                    else if (i == 3) addDeckP1.Add(footmanP1);
                    else if (i == 4) addDeckP1.Add(healerP1);
                    else if (i == 5) addDeckP1.Add(trickP1);
                    else if (i == 6) addDeckP1.Add(counterP1);
                    else if (i == 7) addDeckP1.Add(hunterP1);
                    else if (i == 8) addDeckP1.Add(iceBallP1);
                    else if (i == 9) addDeckP1.Add(ironKnightP1);
                    else if (i == 10) addDeckP1.Add(knightP1);
                    else if (i == 11) addDeckP1.Add(woftP1);
                    else if (i == 12) addDeckP1.Add(atomP1);
                    else if (i == 13) addDeckP1.Add(barrierP1);
                    else if (i == 14) addDeckP1.Add(drawP1);
                    else if (i == 15) addDeckP1.Add(hellP1);
                    else if (i == 16) addDeckP1.Add(yetiP1);
                    else if (i == 17) addDeckP1.Add(fireballP1);
                    else if (i == 18) addDeckP1.Add(footmansP1);
                    else if (i == 19) addDeckP1.Add(destryP1);
                    else if (i == 20) addDeckP1.Add(faerieDragonP1);
                    else if (i == 21) addDeckP1.Add(flameLanceP1);
                    else if (i == 22) addDeckP1.Add(fireElementtalP1);
                    else if (i == 23) addDeckP1.Add(gaintP1);
                    else if (i == 24) addDeckP1.Add(meteorP1);
                    else if (i == 25) addDeckP1.Add(blockholdP1);
                    else if (i == 26) addDeckP1.Add(layonhandsP1);
                    else if (i == 27) addDeckP1.Add(pyroblastP1);
                    else if (i == 28) addDeckP1.Add(knightP1);
                    else if (i == 29) addDeckP1.Add(dragonlordP1);
                    else if (i == 30) addDeckP1.Add(ultimateP1);
                }
        }

        for (int i = 1; i < 31; i++)
        {
            string key = "P2card" + i;
            if (PlayerPrefs.HasKey(key))
                for (int y = 0; y < PlayerPrefs.GetFloat(key); y++)
                {
                    if (i == 1) addDeckP2.Add(archerP1);
                    else if (i == 2) addDeckP2.Add(fireblastP1);
                    else if (i == 3) addDeckP2.Add(footmanP1);
                    else if (i == 4) addDeckP2.Add(healerP1);
                    else if (i == 5) addDeckP2.Add(trickP1);
                    else if (i == 6) addDeckP2.Add(counterP1);
                    else if (i == 7) addDeckP2.Add(hunterP1);
                    else if (i == 8) addDeckP2.Add(iceBallP1);
                    else if (i == 9) addDeckP2.Add(ironKnightP1);
                    else if (i == 10) addDeckP2.Add(knightP1);
                    else if (i == 11) addDeckP2.Add(woftP1);
                    else if (i == 12) addDeckP2.Add(atomP1);
                    else if (i == 13) addDeckP2.Add(barrierP1);
                    else if (i == 14) addDeckP2.Add(drawP1);
                    else if (i == 15) addDeckP2.Add(hellP1);
                    else if (i == 16) addDeckP2.Add(yetiP1);
                    else if (i == 17) addDeckP2.Add(fireballP1);
                    else if (i == 18) addDeckP2.Add(footmansP1);
                    else if (i == 19) addDeckP2.Add(destryP1);
                    else if (i == 20) addDeckP2.Add(faerieDragonP1);
                    else if (i == 21) addDeckP2.Add(flameLanceP1);
                    else if (i == 22) addDeckP2.Add(fireElementtalP1);
                    else if (i == 23) addDeckP2.Add(gaintP1);
                    else if (i == 24) addDeckP2.Add(meteorP1);
                    else if (i == 25) addDeckP2.Add(blockholdP1);
                    else if (i == 26) addDeckP2.Add(layonhandsP1);
                    else if (i == 27) addDeckP2.Add(pyroblastP1);
                    else if (i == 28) addDeckP2.Add(knightP1);
                    else if (i == 29) addDeckP2.Add(dragonlordP1);
                    else if (i == 30) addDeckP2.Add(ultimateP1);
                }
        }




        //foreach (Card c in testBuildDeck)
        //{
        //    //show deck
        //    Debug.Log(c);
        //}

        //Temp.instance.DeckP1 = addDeckP1;


        // เพิมdeck ลงในเกม
        if (addDeckP1 != null)
        {
            Temp.instance.DeckP1 = addDeckP1;
            Debug.Log("addDeckP1 success");
        }


        if (addDeckP2 != null)
        {
            Temp.instance.DeckP2 = addDeckP2;
            Debug.Log("addDeckP2 success");
        }


        //Temp.instance.DeckP1 = addDeckP1;
    }




}
