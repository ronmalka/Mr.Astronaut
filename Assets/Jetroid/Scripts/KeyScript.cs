using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    public static int keysVal = 0;
    Text keys;
    private GameManage gameManage;
    private bool first;
    // Start is called before the first frame update
    void Start()
    {
        keys = GetComponent<Text>();
        first = true;
        gameManage = GameObject.Find("GameManager").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
        keys.text = keysVal.ToString();
        if (keysVal == 3)
        {
            Chest.chestLock = false;
             if(first)
            {
                first = false;
                string sentences = "Greet Job Mr. Astronaut \n Now You Can Open The Chest\n And Get The Cure";
                gameManage.startDialog(sentences);       
            }
        }
    }
}
