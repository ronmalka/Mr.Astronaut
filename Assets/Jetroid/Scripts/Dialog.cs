using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textDisplay;
    public string sentences;
    private int index;
    public float typingSpeed;
    public float waitingTime;
    public Text continueBtnText;
    private bool write =true;
    private GameManage gameManage;




    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = "";
        gameManage = GameObject.Find("GameManager").GetComponent<GameManage>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            continueOnClick();
        }
    }
    public void continueOnClick()
    {
        if(!write)
            gameManage.stopDialog();
    }
    public void startSentence()
    {
        write = false;
        textDisplay.text = sentences;
    }
    public void setSentences(string sentences)
    {
        
        this.sentences = sentences;
    }


}
        
    