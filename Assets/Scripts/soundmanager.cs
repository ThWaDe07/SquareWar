using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public static AudioClip menuClick, gameClick, wrongMove;
    static AudioSource audioSrc;

    void Start()
    {
        menuClick = Resources.Load<AudioClip>("menuclick");
        gameClick = Resources.Load<AudioClip>("gameclick");
        wrongMove = Resources.Load<AudioClip>("wrongmove");

        audioSrc = GetComponent<AudioSource>();
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "menuclick":
                audioSrc.PlayOneShot(menuClick);
                break;
            case "gameclick":
                audioSrc.PlayOneShot(gameClick);
                break;
            case "wrongmove":
                audioSrc.PlayOneShot(wrongMove);
                break;
        }
    }
}
