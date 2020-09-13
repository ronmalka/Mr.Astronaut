using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public static bool chestLock = true;
    private GameManage gameManage;
    // Start is called before the first frame update
    void Start()
    {
        gameManage = GameObject.Find("GameManager").GetComponent<GameManage>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            
            if (!chestLock)
            {
               SoundManager.PlaySound("win");
               gameManage.gameWin(); 
            }
            else
            {
                string sentences = "You Need To Collect \n Three Keys";
                gameManage.startDialog(sentences);
            }
        } 
    }
}
