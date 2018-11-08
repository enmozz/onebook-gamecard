using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroDisplay : MonoBehaviour {

    public Text healthUpdate;
    public GameObject hUpdate;

    public Text healthText;
    public Text armorText;
    public Text attackText;

    public Image heroAvatar;

    private Hero myHero;

    public void HeroSetup(Hero thisHero)
    {
        myHero = thisHero;

        healthText.text = myHero.health.ToString();
        //armorText.text = myHero.armor.ToString();
        //attackText.text = myHero.attack.ToString();

        heroAvatar.sprite = myHero.avatar;
    }

    public static HeroDisplay instance;

    private void Awake()
    {
        instance = this;

    }

    public void hDamage(string Message, float Duration)
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
        if (Input.GetKeyDown(KeyCode.H))
            hDamage("+3", 1.5f);
    }
}
