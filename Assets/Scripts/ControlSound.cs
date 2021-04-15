using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSound : MonoBehaviour
{
    public static GameObject btnSound;
    public static bool playingSound;
    public static GameObject Sound;

    void Start()
    {
        btnSound = GameObject.Find("btnSound");
        Sound = GameObject.Find("full_joyful_times");
        playingSound = true; // Comienza sonando la música
    }
    public void MutePlaySound()
    {
        if(Sound.gameObject.GetComponent<AudioSource>().isPlaying==true)
        {
            //Mute sound
            Sprite mySprite = Resources.Load<Sprite>("mute-sound");
            btnSound.GetComponent<Image>().sprite = mySprite;
            Sound.gameObject.GetComponent<AudioSource>().Stop();
        }
        else
        {
            //Play sound
            Sprite mySprite = Resources.Load<Sprite>("play-sound");
            btnSound.GetComponent<Image>().sprite = mySprite;
            Sound.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
