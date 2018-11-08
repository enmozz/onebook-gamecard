using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageDeck : MonoBehaviour {

    // กลับไปหน้าเมนูหลักและตรวจสอบ deck 
    public void LoadScene(string SceneName)
    {
        // savedeck p1p2
        SaveDeckToPlayerPrefs();
        ManageDeckP2 s = GetComponent<ManageDeckP2>();
        s.SaveDeckToPlayerPrefsP2();

        if(PlayerPrefs.GetFloat("deckp1") == 30 && PlayerPrefs.GetFloat("deckp2") == 30)
            SceneManager.LoadScene(SceneName);
        else
            MessageManager.Instance.ShowMessage("Player1 Or Player2 not equal to 30 cards", 3.5f);

    }

    public void LoadDeckToPlayerPrefs()
    {

        for (int i = 1; i < 31; i++)
        {
            string key = "P1card" + i;
            if (PlayerPrefs.HasKey(key))
                valueCardP1[i] = PlayerPrefs.GetFloat(key);
            else
                valueCardP1[i] = StartingAmountOfCard;

            //Debug.Log(key);
            //Debug.Log(PlayerPrefs.GetFloat(key));
        }

        //if (PlayerPrefs.HasKey("P1card2"))
        //    c2 = PlayerPrefs.GetFloat("P1card2");
        //else
        //    c2 = StartingAmountOfCard;
        //if (PlayerPrefs.HasKey("P1card3"))
        //    c3 = PlayerPrefs.GetFloat("P1card3");
        //else
        //    c3 = StartingAmountOfCard;
        //if (PlayerPrefs.HasKey("P1card4"))
        //    c4 = PlayerPrefs.GetFloat("P1card4");
        //else
        //    c4 = StartingAmountOfCard;

        // deckCount
        if (PlayerPrefs.HasKey("deckp1"))
            valuedeckP1 = PlayerPrefs.GetFloat("deckp1");
        else
            for (int i = 0; i < 31; i++)
            {
                valuedeckP1 = valuedeckP1 + valueCardP1[i];
            }
            //valuedeckP1 = valueCardP1[1] + valueCardP1[2]+ valueCardP1[3]+ valueCardP1[4];

    }

    private void Awake()
    {
        LoadDeckToPlayerPrefs();

    }

    public void ShowDeck( float Duration)
    {
        StartCoroutine(ShowDeckCoroutine(Duration));
    }

    IEnumerator ShowDeckCoroutine(float Duration)
    {
        yield return new WaitForSeconds(Duration);

        PanelCardP1.SetActive(true);
        PanelCardP2.SetActive(false);
        tDeckP1.SetActive(true);
        tDeckP2.SetActive(false);
    }

    public void showDeckP1()
    {
        PanelCardP1.SetActive(true);
        PanelCardP2.SetActive(false);
        tDeckP1.SetActive(true);
        tDeckP2.SetActive(false);
    }
    public void showDeckP2()
    {
        PanelCardP1.SetActive(false);
        PanelCardP2.SetActive(true);
        tDeckP1.SetActive(false);
        tDeckP2.SetActive(true);
    }


    private void Start()
    {
        setUpDeck();
        ShowDeck(0.01f);
        //showDeckP1();
    }

    public void setUpDeck()
    {
        textdeckP1.text = valuedeckP1 + " Card";

        for (int i = 1; i < 31; i++)
        {
            // แสดง จน การ์ดปัจจุบันของใบนั้นๆ ใน text
            for (int y = 0; y < 31; y++)
            {
                if (i == y) textCardP1[i].text = valueCardP1[i] + " Card";
            }
            //if (i == 1) textCard[i].text = valueCardP1[i] + " Card";
            //if (i == 1)card1.text = valueCardP1[i] + " Card";
            //else if (i == 2) card2.text = valueCardP1[i] + " Card";
            //if (i == 3) card3.text = valueCardP1[i] + " Card";
            //else if (i == 4) card4.text = valueCardP1[i] + " Card";
            //else if (i == 5) card5.text = valueCardP1[i] + " Card";

            // แสดง จน การ์ดปัจจุบันของใบนั้นๆ ใน Slider
            string keySlider = "Slider (" + i + ")";
            Slider Sliders = GameObject.Find(keySlider).GetComponent<Slider>();
            Sliders.value = valueCardP1[i];
        }
        //card1.text = c1 + " Card";
        //Slider1 = GameObject.Find("Slider (1)").GetComponent<Slider>();
        //Slider1.value = c1;


        //card2.text = c2 + " Card";
        //Slider2 = GameObject.Find("Slider (2)").GetComponent<Slider>();
        //Slider2.value = c2;
        //card3.text = c3 + " Card";
        //Slider3 = GameObject.Find("Slider (3)").GetComponent<Slider>();
        //Slider3.value = c3;
        //card4.text = c4 + " Card";
        //Slider4 = GameObject.Find("Slider (4)").GetComponent<Slider>();
        //Slider4.value = c4;
        //
        Debug.Log("get deckp1 = " + PlayerPrefs.GetFloat("deckp1") +" card");
        //Debug.Log("get card1 = " + PlayerPrefs.GetFloat("P1card1"));
        //Debug.Log("get card2 = " + PlayerPrefs.GetFloat("card2"));
    }


    void OnApplicationQuit()
    {
        SaveDeckToPlayerPrefs();
    }

    public void SaveDeckToPlayerPrefs()
    {
        PlayerPrefs.SetFloat("deckp1", valuedeckP1);

        for (int i = 1; i < 31; i++)
        {
            string key = "P1card" + i;
            //Debug.Log(key);
            PlayerPrefs.SetFloat(key, valueCardP1[i]);

            //Debug.Log(PlayerPrefs.GetFloat(key));
        }

        //PlayerPrefs.SetFloat("P1card1", c1);
        //PlayerPrefs.SetFloat("P1card2", c2);
        Debug.Log("save deckp1 =" + PlayerPrefs.GetFloat("deckp1"));
        //Debug.Log("save card1 =" + PlayerPrefs.GetFloat("P1card1"));
        //Debug.Log("save card4 =" + PlayerPrefs.GetFloat("P1card4"));
        //Debug.Log("save card10 =" + PlayerPrefs.GetFloat("P1card10"));
        //Debug.Log("save card20 =" + PlayerPrefs.GetFloat("P1card20"));

        //delAll();
    }

    public void delAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public GameObject PanelCardP1;
    public GameObject PanelCardP2;
    int StartingAmountOfCard = 1;
    public Text textdeckP1;
    public Text textdeckP2;
    public GameObject tDeckP1;
    public GameObject tDeckP2;

    // UI manage deck
    //public Slider Slider1;
    //public Slider Slider2;
    //public Text card1;
    //public Text card2;

    public Text[] textCardP1;

    // valuecard
    public float valuedeckP1;

    public float[] valueCardP1 = new float[31];
    //public float c1;
    //public float c2;

    // update value Slider

    public void textupdate1(float value)
    {
        textCardP1[1].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[1])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[1])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[1] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate2(float value)
    {
        textCardP1[2].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[2])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[2])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[2] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate3(float value)
    {
        textCardP1[3].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[3])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[3])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[3] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate4(float value)
    {
        textCardP1[4].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[4])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[4])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[4] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate5(float value)
    {
        textCardP1[5].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[5])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[5])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[5] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate6(float value)
    {
        textCardP1[6].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[6])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[6])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[6] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate7(float value)
    {
        textCardP1[7].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[7])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[7])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[7] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate8(float value)
    {
        textCardP1[8].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[8])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[8])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[8] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate9(float value)
    {
        textCardP1[9].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[9])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[9])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[9] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate10(float value)
    {
        textCardP1[10].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[10])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[10])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[10] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate11(float value)
    {
        textCardP1[11].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[11])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[11])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[11] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate12(float value)
    {
        textCardP1[12].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[12])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[12])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[12] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate13(float value)
    {
        textCardP1[13].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[13])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[13])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[13] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate14(float value)
    {
        textCardP1[14].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[14])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[14])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[14] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate15(float value)
    {
        textCardP1[15].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[15])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[15])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[15] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate16(float value)
    {
        textCardP1[16].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[16])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[16])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[16] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate17(float value)
    {
        textCardP1[17].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[17])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[17])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[17] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate18(float value)
    {
        textCardP1[18].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[18])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[18])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[18] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate19(float value)
    {
        textCardP1[19].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[19])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[19])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[19] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate20(float value)
    {
        textCardP1[20].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[20])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[20])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[20] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate21(float value)
    {
        textCardP1[21].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[21])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[21])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[21] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate22(float value)
    {
        textCardP1[22].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[22])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[22])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[22] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }
    public void textupdate23(float value)
    {
        textCardP1[23].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[23])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[23])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[23] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }
    public void textupdate24(float value)
    {
        textCardP1[24].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[24])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[24])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[24] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }
    public void textupdate25(float value)
    {
        textCardP1[25].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[25])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[25])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[25] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }
    public void textupdate26(float value)
    {
        textCardP1[26].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[26])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[26])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[26] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }
    public void textupdate27(float value)
    {
        textCardP1[27].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[27])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[27])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[27] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }
    public void textupdate28(float value)
    {
        textCardP1[28].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[28])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[28])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[28] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }
    public void textupdate29(float value)
    {
        textCardP1[29].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[29])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[29])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[29] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }

    public void textupdate30(float value)
    {
        textCardP1[30].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP1[30])
            valuedeckP1 = valuedeckP1 + 1;
        else if (value < valueCardP1[30])
            valuedeckP1 = valuedeckP1 - 1;
        valueCardP1[30] = value;
        textdeckP1.text = Mathf.RoundToInt(valuedeckP1) + " Card";
    }


}
