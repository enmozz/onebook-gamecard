using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageDeckP2 : MonoBehaviour {

    //public void LoadScene(string SceneName)
    //{
    //    SaveDeckToPlayerPrefsP2();
    //    SceneManager.LoadScene(SceneName);
    //}

    public void LoadDeckToPlayerPrefs()
    {

        for (int i = 1; i < 31; i++)
        {
            string key = "P2card" + i;
            if (PlayerPrefs.HasKey(key))
                valueCardP2[i] = PlayerPrefs.GetFloat(key);
            else
                valueCardP2[i] = StartingAmountOfCard;

            //Debug.Log(key);
            //Debug.Log(PlayerPrefs.GetFloat(key));
        }

        // deckCount
        if (PlayerPrefs.HasKey("deckp2"))
            valuedeckP2 = PlayerPrefs.GetFloat("deckp2");
        else
            for (int i = 0; i < 31; i++)
            {
                valuedeckP2 = valuedeckP2 + valueCardP2[i];
            }
            //valuedeckP1 = valueCardP1[1] + valueCardP1[2]+ valueCardP1[3]+ valueCardP1[4];

    }


    public static ManageDeckP2 instance;


    private void Awake()
    {
        
        LoadDeckToPlayerPrefs();
    }


    private void Start()
    {
        setUpDeck();
    }

    public void setUpDeck()
    {
        textdeckP2.text = valuedeckP2 + " Card";


        for (int i = 1; i < 31; i++)
        {
            // แสดง จน การ์ดปัจจุบันของใบนั้นๆ ใน text
            for (int y = 0; y < 31; y++)
            {
                if (i == y) textCardP2[i].text = valueCardP2[i] + " Card";
            }
            //if (i == 1) textCard[i].text = valueCardP1[i] + " Card";
            //if (i == 1)card1.text = valueCardP1[i] + " Card";
            //else if (i == 2) card2.text = valueCardP1[i] + " Card";
            //if (i == 3) card3.text = valueCardP1[i] + " Card";
            //else if (i == 4) card4.text = valueCardP1[i] + " Card";
            //else if (i == 5) card5.text = valueCardP1[i] + " Card";

            // แสดง จน การ์ดปัจจุบันของใบนั้นๆ ใน Slider
            string keySlider = "Slider (" + i + ")P2";
            Slider Sliders = GameObject.Find(keySlider).GetComponent<Slider>();
            Sliders.value = valueCardP2[i];
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
        Debug.Log("get deckp2 = " + PlayerPrefs.GetFloat("deckp2") + " card");
        //Debug.Log("get card1 = " + PlayerPrefs.GetFloat("P2card1"));
        //Debug.Log("get card2 = " + PlayerPrefs.GetFloat("card2"));
    }


    void OnApplicationQuit()
    {
        SaveDeckToPlayerPrefsP2();
    }

    public void SaveDeckToPlayerPrefsP2()
    {
        PlayerPrefs.SetFloat("deckp2", valuedeckP2);

        for (int i = 1; i < 31; i++)
        {
            string key = "P2card" + i;
            //Debug.Log(key);
            PlayerPrefs.SetFloat(key, valueCardP2[i]);

            //Debug.Log(PlayerPrefs.GetFloat(key));
        }

        //PlayerPrefs.SetFloat("P1card1", c1);
        //PlayerPrefs.SetFloat("P1card2", c2);
        //Debug.Log("save deckp2 =" + PlayerPrefs.GetFloat("deckp2"));
        //Debug.Log("save card1 =" + PlayerPrefs.GetFloat("P1card1"));
        //Debug.Log("save card4 =" + PlayerPrefs.GetFloat("P1card4"));
        //Debug.Log("save card10 =" + PlayerPrefs.GetFloat("P1card10"));
        Debug.Log("save P2card20 =" + PlayerPrefs.GetFloat("P1card20"));
        //delAll();
    }

    public void delAll()
    {
        PlayerPrefs.DeleteAll();
    }


    int StartingAmountOfCard = 1;
    public Text textdeckP2;



    // UI manage deck
    //public Slider Slider1;
    //public Slider Slider2;
    //public Text card1;
    //public Text card2;

    public Text[] textCardP2;

    // valuecard
    public float valuedeckP2;

    public float[] valueCardP2 = new float[31];
    //public float c1;
    //public float c2;

    // update value Slider

    public void textupdate1(float value)
    {
        textCardP2[1].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[1])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[1])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[1] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate2(float value)
    {
        textCardP2[2].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[2])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[2])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[2] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate3(float value)
    {
        textCardP2[3].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[3])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[3])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[3] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate4(float value)
    {
        textCardP2[4].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[4])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[4])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[4] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate5(float value)
    {
        textCardP2[5].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[5])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[5])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[5] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate6(float value)
    {
        textCardP2[6].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[6])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[6])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[6] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate7(float value)
    {
        textCardP2[7].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[7])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[7])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[7] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate8(float value)
    {
        textCardP2[8].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[8])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[8])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[8] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate9(float value)
    {
        textCardP2[9].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[9])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[9])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[9] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate10(float value)
    {
        textCardP2[10].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[10])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[10])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[10] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate11(float value)
    {
        textCardP2[11].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[11])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[11])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[11] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate12(float value)
    {
        textCardP2[12].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[12])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[12])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[12] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate13(float value)
    {
        textCardP2[13].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[13])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[13])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[13] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate14(float value)
    {
        textCardP2[14].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[14])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[14])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[14] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate15(float value)
    {
        textCardP2[15].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[15])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[15])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[15] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate16(float value)
    {
        textCardP2[16].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[16])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[16])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[16] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate17(float value)
    {
        textCardP2[17].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[17])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[17])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[17] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate18(float value)
    {
        textCardP2[18].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[18])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[18])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[18] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate19(float value)
    {
        textCardP2[19].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[19])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[19])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[19] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate20(float value)
    {
        textCardP2[20].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[20])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[20])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[20] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate21(float value)
    {
        textCardP2[21].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[21])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[21])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[21] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate22(float value)
    {
        textCardP2[22].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[22])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[22])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[22] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }
    public void textupdate23(float value)
    {
        textCardP2[23].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[23])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[23])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[23] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }
    public void textupdate24(float value)
    {
        textCardP2[24].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[24])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[24])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[24] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }
    public void textupdate25(float value)
    {
        textCardP2[25].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[25])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[25])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[25] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }
    public void textupdate26(float value)
    {
        textCardP2[26].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[26])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[26])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[26] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }
    public void textupdate27(float value)
    {
        textCardP2[27].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[27])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[27])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[27] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }
    public void textupdate28(float value)
    {
        textCardP2[28].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[28])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[28])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[28] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }
    public void textupdate29(float value)
    {
        textCardP2[29].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[29])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[29])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[29] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }

    public void textupdate30(float value)
    {
        textCardP2[30].text = Mathf.RoundToInt(value) + " Card";
        if (value > valueCardP2[30])
            valuedeckP2 = valuedeckP2 + 1;
        else if (value < valueCardP2[30])
            valuedeckP2 = valuedeckP2 - 1;
        valueCardP2[30] = value;
        textdeckP2.text = Mathf.RoundToInt(valuedeckP2) + " Card";
    }


}
