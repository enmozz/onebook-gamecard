using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atk : MonoBehaviour
{
    public int i;

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        GameObject p1C0Atk = GameObject.Find(gameObject.name);
        CretureDisplay a = p1C0Atk.GetComponent<CretureDisplay>();

        for (int y = 0; y < 5; y++)
        {
            if (gameObject.name == "P1Creatre " + y)
                i = y;
        }

        if (Temp.instance.spawnPointBoard1[i] == true)
        {
            // ฝ่ายP1 
            

            if (a.ischarge)
            {
                int atkc0 = Convert.ToInt32(a.attackValueText.text);
                int hpc0 = Convert.ToInt32(a.healthValueText.text);



                //ค้นหาเป้าหมาบบนboard
                if (Temp.instance.spawnPointBoard2[i] == true)
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
                        Temp.instance.spawnPointBoard2[i] = false;
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
                        Temp.instance.spawnPointBoard1[i] = false;
                    }

                }
                else //ไม่เจอCreture ตี hero
                {

                    GameObject p2HeroDef = GameObject.Find("Player2");
                    HeroDisplay a2 = p2HeroDef.GetComponent<HeroDisplay>();

                    int P2hpc0 = Convert.ToInt32(a2.healthText.text);
                    Debug.Log(a.nameText.text + " attack = " + atkc0 + " hp= " + hpc0 + " atk " + a2.gameObject.name + " hp= " + P2hpc0);

                    P2hpc0 = P2hpc0 - atkc0;
                    //countAtkHero = countAtkHero + atkc0;

                    // โช damage
                    string zz = "-" + atkc0.ToString(); ;
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
    //countAtkHero = 0;
    //    attackP1Button.gameObject.SetActive(false);
}
    

