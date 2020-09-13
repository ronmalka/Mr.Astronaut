using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player" )
        {
            SoundManager.PlaySound("crystal");
            switch (gameObject.tag)
            {
                case "Crystal":
                    ScoreScript.scoreVal +=1;
                    break;
                case "Key":
                    KeyScript.keysVal +=1;
                    break;
                default:
                    break;
            }
           
            Destroy(gameObject);
        }
    }

}
