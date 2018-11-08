using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour {

    //public GameManager instance;
    public GameObject cardPrefab;

    public List<Card> cardsInColl = new List<Card>();

    //public List<Card> testBuildDeck = new List<Card>();
    //public Card Archer;
    //public Card Atom ;

    private int cardDisplayPosition = 0;

    private void Awake()
    {
        //instance = FindObjectOfType<GameManager>();
        //instance.cards.Sort();

        //เรียงการ์ด
        cardsInColl.Sort();

        //foreach (Card c in testBuildDeck)
        //{
        //    Debug.Log(c);
        //}

        //testBuildDeck.Add(Archer);
        //testBuildDeck.Add(Atom);

    }

    private void Start()
    {
        int currentSpawn = 0;
        float xPos = 0f;
        float yPos = 2f;


        for (int i = 0; i < 11; i++) {

            foreach (Card card in cardsInColl)
            {

                if (card.manaCost == i)
                {
                    switch (cardDisplayPosition)
                    {
                        case 0:
                            xPos = -1.5f;
                            break;
                        case 1:
                            xPos = 1f;
                            break;
                        case 2:
                            xPos = 3.5f;
                            break;
                        case 3:
                            xPos = 6f;
                            break;

                        default:
                            break;
                    }


                    cardDisplayPosition++;
                    if (cardDisplayPosition > 3)
                    {
                        cardDisplayPosition = 0;
                    }


                    GameObject go = Instantiate(cardPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    CardDisplay display = go.GetComponent<CardDisplay>();
                    display.CardSetup(card, 0);

                    currentSpawn++;

                    //เลื่อนแถวไปบรรทัดต่อไป
                    if (currentSpawn > 3)
                    {
                        yPos -= 4.5f;
                        currentSpawn = 0;
                    }
                }
            }
        }

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
