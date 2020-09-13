using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteManage : MonoBehaviour
{
AudioSource audioSource;
private Button theButton;
private ColorBlock theColor;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        theButton = GetComponent<Button>();
        theColor = GetComponent<Button>().colors;
    }

    void Update()
    {
    }
    public void setMute()
    {
        if (audioSource.mute)
        {
            theColor.highlightedColor = Color.white;
            theColor.normalColor = Color.white;
            theColor.pressedColor = Color.white;
            theColor.selectedColor = Color.white;
        }
        else
        {
            theColor.highlightedColor = Color.gray;
            theColor.normalColor =  Color.gray;
            theColor.pressedColor =  Color.gray;
            theColor.selectedColor = Color.gray;
        }
        
 
        
        theButton.colors = theColor;
        audioSource.mute = !audioSource.mute;
    }
    
}
