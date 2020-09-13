using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip crystal, explode, laser, win;
    static AudioSource source; 
    // Start is called before the first frame update
    void Start()
    {
        crystal = Resources.Load<AudioClip>("crystal");
        explode = Resources.Load<AudioClip>("explode");
        laser = Resources.Load<AudioClip>("laser");
        win = Resources.Load<AudioClip>("win");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
       switch (sound)
       {
           case "crystal":
            source.PlayOneShot(crystal);
            break;
           case "explode":
            source.PlayOneShot(explode);
            break; 
           case "laser":
            source.PlayOneShot(laser);
            break; 
           case "win":
            source.PlayOneShot(win);
            break; 
           default:
            break;
       } 
    }

}
