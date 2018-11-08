using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour
{

    ////Play Global
    //private static BGSoundScript instance = null;
    //public static BGSoundScript Instance
    //{
    //    get { return instance; }
    //}

    //void Awake()
    //{
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
    //    else
    //    {
    //        instance = this;
    //    }

    //    DontDestroyOnLoad(this.gameObject);
    //}
    ////Play Gobal End

    // Update is called once per frame

    public AudioSource a;

    public void onSound()
    {
        a.mute = false;
        soundStatus = 0;
        PlayerPrefs.SetInt("sound", soundStatus);
        //Debug.Log("soundstatus" + PlayerPrefs.GetInt("sound"));

    }

    public void offSound()
    {
        a.mute = true;
        soundStatus = 1;
        PlayerPrefs.SetInt("sound", soundStatus);
        //Debug.Log(PlayerPrefs.GetInt("sound"));
    }

    int soundStatus;

    public void LoadSoundToPlayerPrefs()
    {
        // 0 เปิดเสียง 1 ปิดเสียง
        if (PlayerPrefs.HasKey("sound"))
            soundStatus = PlayerPrefs.GetInt("sound");
        else
            soundStatus = 0;
    }

    private void Awake()
    {
        LoadSoundToPlayerPrefs();
    }

    private void Start()
    {
        setUpSound();
        Debug.Log("soundstatus ==  " +  PlayerPrefs.GetInt("sound") + " (0 open 1 close)");
    }


    public void setUpSound()
    {
        if (soundStatus == 0)
            a.mute = false;
        else if (soundStatus == 1)
            a.mute = true;
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("sound", soundStatus);
    }

}


    

    
