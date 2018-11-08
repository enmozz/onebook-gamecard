using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
    public static GameLevelManager instance;

    public Hero playerHero;
    public Hero enemyHero;

    public GameObject avatarPrefab;

    public Transform playerAvatarSpawn;
    public Transform enemyAvatarSpawn;

    [Header("P1")]
    public int currentTurn = 0;
    public int activeManaCrystals = 0;
    
    public Text manaText;
    public Text timeText;
    public Button endTurnButton;
    public float count;

    [Header("P2")]
    public int currentTurnP2 = 0;
    public int activeManaCrystalsP2 = 0;
    
    public Text manaTextP2;
    public Text timeTextP2;
    public Button endTurnButtonP2;
    public float count2;






    // เวลาเทริ่น
    private void Update()
    {
        time();

        if (Input.GetKeyDown(KeyCode.N))
            endGame(2f, 1);
    }
    public void time()
    {
        count -= Time.deltaTime;
        timeText.text = Mathf.Round(count).ToString();

        count2 -= Time.deltaTime;
        timeTextP2.text = Mathf.Round(count2).ToString();

        if (count <= 0)
        {
            OnTurEnd();
        }
        if (count2 <= 0)
        {
            OnTurEndP2();
        }
    }

    //เริ่มเกม
    private void Start()
    {
        Player1Setup();
        Player2Setup();

        int r = UnityEngine.Random.Range(0, 100); // สุ่มผู้เล่น
        //Debug.Log(r);
        if (r <= 50)
        {
            OnTurnStart();
            Temp.instance.addCoin(2);
        }
        else if (r >= 51)
        {
            OnTurnStartP2();
            Temp.instance.addCoin(1);
        }
    }



    //Temp t;
    private void Awake()
    {
        //t = GetComponent<Temp>();
        instance = this;
    }

    // playersetup
    private void Player2Setup()
    {
        GameObject go = Instantiate(avatarPrefab, new Vector3(enemyAvatarSpawn.position.x,
            enemyAvatarSpawn.position.y, -1.5f), Quaternion.identity);
        HeroDisplay display = go.GetComponent<HeroDisplay>();
        display.HeroSetup(enemyHero);
        //ตั้งชื่อ obj
        go.name = "Player2";
    }
    private void Player1Setup()
    {
        GameObject go = Instantiate(avatarPrefab, new Vector3(playerAvatarSpawn.position.x,
            playerAvatarSpawn.position.y, -1.5f), Quaternion.identity);
        HeroDisplay display = go.GetComponent<HeroDisplay>();
        display.HeroSetup(playerHero);
        go.name = "Player1";
    }

    public void OnTurnStart()
    {
        MessageManager.Instance.ShowMessage("Player1 Turn", 1.5f);
        manaText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);

        Temp tt = GetComponent<Temp>();
        tt.attackP1Button.gameObject.SetActive(true);

        count = 60;
        count2 = 70;

        currentTurn++;
        activeManaCrystals = currentTurn;

        if (activeManaCrystals >= 10)
        {
            activeManaCrystals = 10;
        }
        manaText.text = activeManaCrystals.ToString();


        //for (int i = 0; i < activeManaCrystals; i++)
        //{
        //    manaCrystals[i].SetActive(true);
        //}

        endTurnButton.gameObject.SetActive(true);
        tt.DrawP1(1);

        // ทำให้มีมเนียนที่ลงโจมตีได้
        for (int i = 0; i < tt.spawnPointBoard1.Length; i++)
        {
            if (tt.spawnPointBoard1[i] == true)
            {
                GameObject card = GameObject.Find("P1Creatre " + i);
                CretureDisplay a = card.GetComponent<CretureDisplay>();
                a.ischarge = true;
            }
        }
    }

    public void OnTurEnd()
    {
        endTurnButton.gameObject.SetActive(false);
        manaText.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
        OnTurnStartP2();
        activeManaCrystals = 0;

        Temp tt = GetComponent<Temp>();
        tt.attackP1Button.gameObject.SetActive(false);

        for (int i = 0; i < tt.spawnPointBoard1.Length; i++)
        {
            if (tt.spawnPointBoard1[i] == true)
            {
                GameObject card = GameObject.Find("P1Creatre " + i);
                CretureDisplay a = card.GetComponent<CretureDisplay>();
                a.ischarge = false;
            }
        }
    }

    public void OnTurnStartP2()
    {
        MessageManager.Instance.ShowMessage("Player2 Turn", 1.5f);
        manaTextP2.gameObject.SetActive(true);
        timeTextP2.gameObject.SetActive(true);

        Temp tt = GetComponent<Temp>();
        tt.attackP2Button.gameObject.SetActive(true);

        count2 = 60;
        count = 70;
        currentTurnP2++;
        activeManaCrystalsP2 = currentTurnP2;

        if (activeManaCrystalsP2 >= 10)
        {
            activeManaCrystalsP2 = 10;
        }
        manaTextP2.text = activeManaCrystalsP2.ToString();

        //for (int i = 0; i < activeManaCrystalsP2; i++)
        //{
        //    manaCrystals[i].SetActive(true);
        //}

        endTurnButtonP2.gameObject.SetActive(true);
        tt.DrawP2(1);

        // ทำให้มีมเนียนที่ลงโจมตีได้
        for (int i = 0; i < tt.spawnPointBoard2.Length; i++)
        {
            if (tt.spawnPointBoard2[i] == true)
            {
                GameObject card = GameObject.Find("P2Creatre " + i);
                CretureDisplay a = card.GetComponent<CretureDisplay>();
                a.ischarge = true;
            }
        }
    }

    public void OnTurEndP2()
    {
        endTurnButtonP2.gameObject.SetActive(false);
        manaTextP2.gameObject.SetActive(false);
        timeTextP2.gameObject.SetActive(false);
        OnTurnStart();
        activeManaCrystalsP2 = 0;

        Temp tt = GetComponent<Temp>();
        tt.attackP2Button.gameObject.SetActive(false);

        
        for (int i = 0; i < tt.spawnPointBoard2.Length; i++)
        {
            if (tt.spawnPointBoard2[i] == true)
            {
                GameObject card = GameObject.Find("P2Creatre " + i);
                CretureDisplay a = card.GetComponent<CretureDisplay>();
                a.ischarge = false;
            }
        }
    }


    public void endGame(float Duration, float win)
    {
        if( win == 1)
            MessageManager.Instance.ShowMessage("Player1 Win", 3f);
        else if(win == 2)
            MessageManager.Instance.ShowMessage("Player2 Win", 3f);

        StartCoroutine(LoadScene(Duration));
    }

    IEnumerator LoadScene(float Duration)
    {
        yield return new WaitForSeconds(Duration);

        SceneManager.LoadScene("Menu");
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

